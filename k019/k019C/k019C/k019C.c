/*
 * k019C.c
 *
 * Created: 11.8.2013 10:28:35
 *  Author: Jirka
 */ 

#include <math.h>
#include <avr/io.h>
#include <stdint.h>
#include <avr/interrupt.h>
#include "K019.h"


uint16_t bit=0;

void fw(bool dbg = false, bool ioV = false)
{
	ledGON
	
	io.load();
		if (dbg)
		{
			pc<<"b pud:"<<endl;
			for (int i=0; i!=4; i++)
			{
				pc<<io.RCIn(i)<<endl;
				pc.wait();
			}
		}
	io.pud();	//set ee add to 0
	spiEe.endNext();
		if (dbg || ioV)
		{
			if(dbg)
				pc<<"a PUD"<<endl;
			else
				pc<<"a";
			for (int i=0; i!=4; i++)
			{
				pc<<io.RCIn(i)<<endl;
				pc.wait();
			}
		}
	// PORT
		if (dbg)
		{
			pc<<"b port"<<endl;
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
			pc<<"a port"<<endl;
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
		if (BITVAL(io.RCIn(3),f))
		{
			if(dbg)
				pc<<"b set: "<<f<<endl;
			spiEe.setAddress(6 + f);
			from = spiEe.readNextByte();
			spiEe.endNext();
			
			spiEe.setAddress((f * 128) + 38);
			for (int i=0; i!=64; i++)
			{
				dest = spiEe.readNextWord();
				if(dbg)
					pc<<"i: "<<i<<" d: "<<dest<<" a: "<<uint16_t((f * 128) + 38)<<endl; pc.wait();
				if (dest != 65535 && BITVAL(io.RCIn(from-1),i))
					io.bitOut(dest);
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
	if(dbg)
		pc<<"dbgPush :"<<endl;	
	if (dbg || ioV)
		io.dbgPush();
	else
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
	uint8_t dataIn = 0;
	while (dataIn != 'c')
	{		
		dataIn = pc.get();
	}
	pc.send("a");
	
	while (dataIn != 0x0a)
	{
		dataIn = pc.get();
	}
	
	_delay_ms(50);

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
			spiEe.writing();
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
			spiEe.writing();
			spiEe.writeByte(add++, uint8_t(recv));
			spiEe.writing();
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
		pc.wait();
		spiEe.writeByte(i,0xff);
		spiEe.writing();
		pc.wait();
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

void remoteControlDbg()
{	
	for(uint8_t i=1; i!=3; i++)
	if (!BITVAL(PINE,i))		// 1+, 2-
	{
		if(i==1 && (bit + sMove) < 384)
		{
			bit += sMove;
			pc<<"+"<<endl;
		}
		else if(!((bit - sMove) < 0) && !((bit - sMove) > 384))
		{
			bit -=sMove;
			pc<<"-"<<endl;
		}
		io.bitOut(bit);
		io.dbgPush();
		_delay_ms(cDelay);
		if (!BITVAL(PINE,i))
		{
			if(i==1 && (bit + bMove - 1) < 384)
			{
				bit += bMove - 1;
				pc<<"+"<<endl;
				//pc.wait();
			}
			else if(!((bit - bMove - 1) < 0) && !((bit - bMove - 1) > 384))
			{
				bit -= bMove - 1;
				pc<<"-"<<endl;
				//pc.wait();
			}			
			io.bitOut(bit);
			io.dbgPush();
		}
		while(!BITVAL(PINE,i));
	}
}

void remoteControl()
{
	for(uint8_t i=1; i!=3; i++)
	if (!BITVAL(PINE,i))		// 1+, 2-
	{
		if(i==1 && (bit + sMove) < 384)
			bit += sMove;
		else if(!((bit - sMove) < 0) && !((bit - sMove) > 384))
			bit -=sMove;
		io.bitOut(bit);
		io.push();
		_delay_ms(cDelay);
		if (!BITVAL(PINE,i))
		{
			if(i==1 && (bit + bMove - 1) < 384)
				bit += bMove - 1;
			else if(!((bit - bMove - 1) < 0) && !((bit - bMove - 1) > 384))
				bit -= bMove - 1;
			io.bitOut(bit);
			io.push();
		}
		while(!BITVAL(PINE,i));
	}
}

int main(void)
{
	init();	
	pc<<endl<<"k019 v1.0 JK 2013"<<endl;
	sei();	
	ledGON
	
	while(1)
    {
		while(!BITVAL(PINC,4))
		{
			ledRT	
				switch (pc.get())
				{
					case 'i'	:	fw(false, true)		;break;
					case 'd'	:	downConf(); break;
					case 'r'	:	readEe();	break;
					case 'f'	:	pc<<
				}	
			ledROFF			
		}	
		
		while(!BITVAL(PINE,0))	
				
			remoteControl();
		
		fw();		
		
    }
}