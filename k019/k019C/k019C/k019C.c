/*
 * k019C.c
 *
 * Created: 11.8.2013 10:28:35
 *  Author: Jirka
 */ 


#include <avr/io.h>
#include <avr/interrupt.h>
#include "K019.h"

void fwPort()
{
	
}

void fwPin()
{
	uint16_t dest;
	uint8_t from;
	for(int i=0; i!= 32; i++)
	{
		if(BITVAL(in[4],32 + i))
		{
			from = ee.readByte(i*128 + EFM);
			for(int j=0; j!=64; j++)
			{		
				if (BITVAL(in[from], j))
				{
					dest = ee.readWord((i * j) + i + 1 + EFM);
					if(dest)
						break;
					else
						io.cacheOut(dest);
				}
			}
		}
	}
}

void ioView()
{
	while (pc.get()=='i')
	{
		pc<<"a";
		
		for (uint8_t i=0; i!=4; i++)
			pc<<io.cacheIn(i, io.readQWord(i*8))<<endl;
		fwPin();
		for (uint8_t i=0; i!=7; i++)
			pc<<io.readCache(i)<<endl;
		ledGT
	}
}

int main(void)
{
	init();	
	sei();
	_delay_ms(3000);
	char dt;
	if (pc.peek(dt))
	{
		switch (dt)
		{
			case 'i'  : ioView();
			
		}
	}
	ledRON
	
    while(1)
    {
		pc.get();
		pc<<"a";
		{
			pc<<io.readQWord(0)<<endl;
			ledGT
		}
		/*for (int i=0; i!=4; i++)
		{
			io.cacheOut(i,io.readQWord(i));
		}
		io.write();
		ledRT*/
    }
}