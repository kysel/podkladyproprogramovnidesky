/*
 * K019.cpp
 *
 * Created: 30.7.2013 16:11:51
 *  Author: Jirka
 */ 

#ifndef F_CPU
	#define F_CPU 14745600UL
#endif

#include <avr/io.h>
#include <stdio.h>
#include <util/delay.h>
#include <util/makra.h>

#include "K019.h"
#include "queue.h"
#include "rs232new-basic.h"
#include "format_rs232.h"
extern "C" {
	#include "i2cmaster.S"
};

uint8_t vstupy[23];

uint8_t presmerovani[3];

using namespace kubas;
format_t pc;

int main(void)
{	
	rs232.init(115200);
	rs232.wait();
	init();
    //while(1)
    {
		uint8_t tmp;
		i2c_init();	
		/*i2c_start_wait(0xA0+I2C_WRITE);
		i2c_write(0x00);
		i2c_write(0x05);
		i2c_write(0x75);
		i2c_stop();
		
		i2c_start_wait(0xA0+I2C_WRITE);
		i2c_write(0x00);
		i2c_write(0x05);
		if(i2c_rep_start(0xA0+I2C_READ)==1)
		ledGOFF
		tmp = i2c_readNak();
		i2c_stop();
		
		if (tmp==0x75)
		ledROFF*/
				
		/*SoftI2CInit();		
		SoftI2CStart();
		pc.send_char_immediately(SoftI2CWriteByte(0xA0));
		pc.send_char_immediately(SoftI2CWriteByte(0x01));		
		pc.send_char_immediately(SoftI2CWriteByte(0x01));
		pc.send_char_immediately(SoftI2CWriteByte(0x60));
		SoftI2CStop();
		
		SoftI2CStart();
		pc.send_char_immediately(SoftI2CWriteByte(0xA0));
		pc.send_char_immediately(SoftI2CWriteByte(0x01));
		pc.send_char_immediately(SoftI2CWriteByte(0x01));
		
		SoftI2CStart();
		SoftI2CWriteByte(0xA1);
		for (uint16_t i=0; i!=10; i++)
		{
			pc.send_char_immediately(SoftI2CReadByte(1));
		}
		SoftI2CStop();*/
			
		/*for (int i=0; i!=16; i++)
		{
			pc.send_char_immediately(input.readByte(i*8));
		}
		pc.send_immediately("/r /n");
		_delay_ms(1000);
		for (int i=pA; i!=pC2; i++)
		{
			if (presmerovani[i]!=0)
			{
				for (int j=pF; j!=pM; j++)
				{
					
				}				
			}
		}
		
		
		for (register int i=0; i!=23; i++)
		{
			vstupy[i]=input.readByte(i);
		}*/
				
    }
}	
	
	
