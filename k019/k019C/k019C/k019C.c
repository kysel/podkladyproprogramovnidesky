/*
 * k019C.c
 *
 * Created: 11.8.2013 10:28:35
 *  Author: Jirka
 */ 

#include <math.h>
#include <avr/io.h>
#include <avr/interrupt.h>
#include "K019.h"

bool dbg = false;

inline void fwPort()
{
	for (int i=0; i!=4; i++)
		io.cacheOut(spiEe.readByte(i+2),in[i]);
}

void fwPin()
{
	uint16_t dest;
	uint8_t from;
	for(int i=0; i!= 32; i++)
	{
		if(BITVAL(in[4],32 + i))
		{
			from = spiEe.readByte(i + EFM);
			for(int j=0; j!=64; j++)
			{		
				if (BITVAL(in[from], j))
				{
					dest = spiEe.readWord((i * j) + 32 + EFM);
					if(dest)
						break;
					else
						io.cacheOut(dest);
				}
			}
		}
	}
}

void fw()
{
	ledGON
	
	io.load();
		if (dbg)
		{
			pc<<"bfr pud:"<<endl;
			for (int i=0; i!=4; i++)
			{
				pc<<io.RCIn(i)<<endl;
				pc.wait();
			}
		}
	io.pud();	//set ee add to 0
	spiEe.endNext();
		if (dbg)
		{
			pc<<"after PUD"<<endl;
			for (int i=0; i!=4; i++)
			{
				pc<<io.RCIn(i)<<endl;
				pc.wait();
			}
		}
	// PORT
		if (dbg)
		{
			pc<<"before port"<<endl;
			for (int i=0; i!=7; i++)
			{
				pc<<io.RCOut(i)<<endl;
				pc.wait();
			}
		}
	spiEe.setAddress(2);
	for (int i=0; i!=4; i++)
	{
		io.cacheOut(spiEe.readNextByte(),io.RCIn(i));
	}
	spiEe.endNext();
		if (dbg)
		{
			pc<<"after port"<<endl;
			for (int i=0; i!=7; i++)
			{
				pc<<io.RCOut(i)<<endl;
				pc.wait();
			}
		}	
	uint8_t from;
	uint16_t dest;
	for (int f=0; f!=32; f++)
	{
		if (BITSET(io.RCIn(3), f))
		{
			pc<<"b set: "<<f<<endl;
			spiEe.setAddress(6 + f);
			from = spiEe.readNextByte();
			spiEe.endNext();
			
			spiEe.setAddress(f * 64 + 26);
			for (int i=0; i!=64; i++)
			{
				dest = spiEe.readNextWord();
				if (dest != 0 && BITSET(io.RCIn(from),i))
					io.cacheOut(dest);
			}
			spiEe.endNext();
		}
	}
	
		if (dbg)
		{
			pc<<"after pin"<<endl;
			for (int i=0; i!=7; i++)
			{
				pc<<io.RCOut(i)<<endl;
				pc.wait();
			}
		}
	
	io.push();
	ledGOFF
}

void downConf()
{	
	bool zapis = true;
	uint8_t n = 0;
	uint16_t add = 0;
	char cislo[8] = {0,0,0,0,0,0,0,0};
		
	ledRT
	_delay_ms(500);
	ledRT
	uint8_t dataIn = pc.get();
	while (dataIn != 'c')
	{		
		dataIn = pc.get();
	}
	pc.send("a");

	while (zapis)
	{
		ledRT
		dataIn = pc.get();
		if(dataIn == 'e')
			zapis = false;
		else if(dataIn == 's')
			break;
		else if (dataIn == 0x0A)
		{
			uint16_t recv = 0;
			for (int i=1; i!=(n+1); i++)
			{
				if(cislo[n - i]!=0)
				recv += ((cislo[n - i] - '0') * (IntPower(10, i-1)));
			}
			n = 0;
			spiEe.writeByte((add++), recv);
			_delay_ms(5);
			pc.send("a");
		}
		else
		{
			cislo[n] = dataIn;
			n++;
		}	
	}		
	zapis = true;
	pc<<"a";
	
	while (zapis)
	{
		ledRT
		dataIn = pc.get();
		if(dataIn == 'e')
			zapis = false;	
		else if(dataIn == 's')
			return;
		else if (dataIn == 0x0A)
		{
			uint16_t recv = 0;
			for (int i=1; i!=(n+1); i++)
			{
				if(cislo[n - i]!=0)
				recv += ((cislo[n - i] - '0') * (IntPower(10, i-1)));
			}
			n = 0;	
			spiEe.writeByte(add++, uint8_t(recv>>8));
			_delay_ms(5);
			spiEe.writeByte(add++, uint8_t(recv));
			_delay_ms(5);
			pc<<"a";
		}
		else
		{
			cislo[n] = dataIn;
			n++;
		}	
	}	
	ledROFF
	_delay_ms(100);
	for (uint16_t i=0; i!=2084; i++)
	{
		pc<<spiEe.readByte(i)<<"\n";
		pc.wait();
		dataIn = pc.get();
		if(dataIn == 'o')
			continue;
		else
			break;
	}
}

void ioView()
{
	pc<<"a";	
	
	io.load();
	io.pud();
	spiEe.endNext();
	
	//fwPin();
	//fwPort();
	
	for (int i=0; i!=4; i++)
		pc<<io.RCIn(i)<<endl;
		

	for (uint8_t i=0; i!=7; i++)
	{
		pc.send_number_immediately(io.RCOut(i));
		pc<<endl;
	}
	io.push();
	ledGT
}

void eraseEe()
{
	for (uint16_t i = 0; i != 32768; i++)
	{
		ledRT
		pc<<i<<endl;
		spiEe.writeByte(i,0xff);
		_delay_ms(2);
	}
	ledROFF
}

void readEe()
{
	for (uint16_t i = 0; i != 32768; i++)
	{
		ledRT
		pc.send_char_immediately(spiEe.readByte(i));
	}
	ledROFF
}

void eetest()
{
	spiEe.setAddress();
	uint16_t snd;
	for (int i=0; i != 16384; i++)
	{
		snd = spiEe.readNextWord();
		pc.send_char_immediately(snd>>8);
		pc.send_char_immediately(snd);
		pc.wait();
	}
	spiEe.endNext();
}

int main(void)
{
	init();	
	sei();	
	char ch;
	//ioView();
	while(1)
    {
		while(!BITSET(PINC,4))
		{
			dbg = true;
			ledRT	
				switch (pc.get())
				{
					case 'i'	:	ioView();	break;
					case 'd'	:	downConf(); break;
					case 'r'	:	readEe();	break;
					case 'e'	:	eraseEe();	break;
					case 'x'	:	fw();	break;
				}	
			ledROFF			
		}	
		ledRT
		dbg = false;
		
		pc<<io.readByte(0)<<endl;
		_delay_ms(1000);
		//pc.get();
		//pc<<"a";			
	
		/*for (long i=0; i!=32767; i++)
		{
			pc.send_char_immediately(spiEe.readByte(i));
		}*/
		/*for (int i=0; i!=4; i++)
		{
			io.cacheOut(i,io.readQWord(i));
		}
		io.write();
		ledRT*/
    }
}