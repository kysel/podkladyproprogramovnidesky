/*
 * K019.h
 *
 * Created: 30.7.2013 17:05:08
 *  Author: Jiøí Kyzlink
 *	© 2013 Jiøí Kyzlink
 */ 


#ifndef _K019_H_
#define _K019_H_	1

#define F_CPU 14745600UL

#include "util/makra.h"
#include "util/delay.h"
extern "C" {
	#include "i2cmaster.h"
};
#include "queue.h"
#include "rs232new-basic.h"
#include "format_rs232.h"

using namespace kubas;

format_t pc;

#define pA	0
#define pA2 1
#define pB	2
#define pB2	3
#define pC	4
#define pC2	5
#define pD	6
#define pE	7
#define pF	8
#define pF2 9
#define pG	10
#define pG2 11
#define pH	12
#define pH2	13
#define pI	14
#define pI2	15
#define pJ	16
#define pJ2	17
#define pK	18
#define pK2	19
#define pL	20
#define pM	21

#define EeAdd	0xA0

#define EFM		10		//posunuti adresy fwPin

#define ledGOFF	SETBIT(PORTC,2);
#define ledROFF	SETBIT(PORTC,3);
#define ledGON	CLEARBIT(PORTC,2);
#define ledRON	CLEARBIT(PORTC,3);
#define ledGT	TOGGLEBIT(PORTC,2);
#define ledRT	TOGGLEBIT(PORTC,3);

uint8_t pfi [8];		//half-port forwad array
uint64_t out [7];		//out cache
uint64_t in [4];		//inp cache

class ee_t
{
	uint8_t tmp8;
	uint16_t tmp16;
	public:
	void init()
	{
		i2c_init();
	}
	
	void address(const uint16_t address)
	{
		i2c_start_wait(EeAdd+I2C_WRITE);
		i2c_write(address >> 8);
		i2c_write(address & 0xff);
		i2c_stop();
	}
	
	void writeByte(const uint16_t address, const uint8_t data)
	{
		i2c_start_wait(EeAdd+I2C_WRITE);
		i2c_write(address >> 8);
		i2c_write(address & 0xff);
		i2c_write(data);
		i2c_stop();
	}
	
	void writeWord(const uint16_t address, const uint16_t data)
	{
		i2c_start_wait(EeAdd+I2C_WRITE);
		i2c_write(address >> 8);
		i2c_write(address & 0xff);
		i2c_write(data >> 8);
		i2c_write(data & 0xff);
		i2c_stop();
	}
	
	uint8_t readByte(uint16_t address)
	{
		i2c_start_wait(EeAdd+I2C_WRITE);
		i2c_write(address >> 8);
		i2c_write(address & 0xff);
		i2c_rep_start(EeAdd+I2C_READ);
		tmp8 = i2c_readNak();
		i2c_stop();
		return tmp8;
	}
	
	uint16_t readWord(uint16_t address)
	{
		i2c_start_wait(EeAdd+I2C_WRITE);
		i2c_write(address >> 8);
		i2c_write(address & 0xff);
		i2c_rep_start(EeAdd+I2C_READ);
		tmp16 = i2c_readAck();
		tmp16 += i2c_readNak();
		i2c_stop();
		return tmp16;
	}
	
	uint8_t read()
	{
		i2c_start_wait(EeAdd+I2C_READ);
		tmp8 = i2c_readNak();
		i2c_stop();
		return tmp8;
	}
	
	uint8_t rd()
	{
		tmp8 = i2c_readNak();
		return tmp8;
	}
}ee;
class input_t
{	
	bool reading=true;
	uint32_t tmp;
	uint8_t i;
	uint8_t data;
	private:
		inline uint8_t read(void)	{
			DDRA=0;
			CLEARBIT(PORTC,0);
			asm ("nop");
			asm ("nop");
			data=PINA;
			SETBIT(PORTC,0);
			return data;
		}
		
		inline void write(const uint8_t data)	{
			DDRA=0xff;
			PORTA=data;
			CLEARBIT(PORTC,1);
			SETBIT(PORTC,1);
		}
	
	public:	
		inline uint8_t readByte(const uint8_t add)
		{
			if (add>23)
				tmp = ((3 - (add % 4)) + (add / 4) * 4);
			else
				tmp = ((7 - (add % 8)) + (add / 8) * 8);							//pøehození 1. pinu
			PORTD = (((tmp % 8) << 2 | (tmp / 8) << 5) & 0xfc);
			return read();
		}	
		
		inline uint32_t readDWord(const uint8_t add)
		{
			uint32_t temp=0;
			for (i=0; i!=4; i++)
			{
				temp <<= 8;
				temp += readByte(add+i);
			}
			return temp;
		}
		
		inline uint64_t readQWord(const uint8_t add)
		{
			uint64_t temp=0;
			for (i=0; i!=8; i++)
			{
				temp <<= 8;
				temp |= readByte(add+i);
			}
			return temp;
		}
		
		inline void write(){
			for (int i=0; i!=4; i++)
				writeQWord(i*8,out[i]);
		}
		
		inline void writeByte(uint8_t add, const uint8_t data)
		{
			if (add>23)
				add+=8;
			tmp=((7 - (add % 8)) + (add / 8) * 8);
			PORTD = (((tmp % 8) << 2 | (tmp / 8) << 5) & 0xfc);
			write(data);
		}
		
		inline void writeDWord(const uint8_t add, uint32_t data)
		{
			for (i=0; i!=4; i++)
			{
				writeByte((add*4)+i, uint8_t(data));
				data >>= 8;
			}
		}

		inline void writeQWord(const uint8_t add, uint64_t data)
		{
			for (i=0; i!=8; i++)
			{
				writeByte((add*8)+i, uint8_t(data));
				data >>= 8;
			}
		}
		
		inline uint64_t readCache(const uint8_t add)	{
			return out[add];
		}
		
		inline void cacheOut(const uint16_t add)	{
			SETBIT(out[add / 64], add % 64);
		}
		
		inline void cacheOut(const uint8_t add, const uint8_t data)		{
			out[add / 8] |= uint64_t(data << ((add / 8) * 8));
		}		
		
		inline void cacheOut(const uint8_t add, const uint16_t data)	{
			out[add / 4] |= uint64_t(data << ((add / 4) * 16));
		}		
		
		inline void cacheOut(const uint8_t add, const uint32_t data)	{
			out[add / 2] |= uint64_t(data << ((add / 2) * 32));
		}	
		
		inline void cacheOut(const uint8_t add, const uint64_t data)	{
			out[add] |= data;
		}
		
				
		/*inline void cacheBIn(const uint8_t add, const uint8_t data)	{
			in[add / 8] |= uint64_t(data << ((add / 8) * 8));
		}
		
		inline void cacheWIn(const uint8_t add, const uint16_t data)	{
			in[add / 4] |= uint64_t(data << ((add / 4) * 16));
		}
		
		inline void cacheDIn(const uint8_t add, const uint32_t data)	{
			in[add / 2] |= uint64_t(data << ((add / 2) * 32));
		}	*/
		
		inline uint64_t cacheIn(const uint8_t add, const uint64_t data)		{
			in[add] |= data;
			return data;
		}		
		
		inline void load()	{
			for(int i=0; i!=4; i++)
				cacheIn(i, readQWord(i*8));
		}
		
		inline void push()	{
			for(int i=0; i!=4; i++)
				writeQWord(i, out[i]);
		}
		
		inline void pud(){
			uint8_t fw = ee.readByte(0);
			for (int i=0; i!=4; i++)
			{
				if (BITVAL(fw, i))
					in[i] = ~in[i];
			}
		}
}io;



bool init()
{
	SETBIT(DDRB,4);
	SETBIT(DDRC,2);
	SETBIT(DDRC,3);
	DDRC=0xff;
	DDRD=0xfe;
	SETBIT(PORTC,0);
	SETBIT(PORTC,1);
	rs232.init(115200);
	ee.init();
	for (int i=0; i!=8; i++)
	{
		pfi[i]=ee.readByte(i);
	}
	ledROFF
	for (int i=0; i!=5; i++)
	{
		ledGON
		_delay_ms(100);
		ledGOFF
		_delay_ms(100);
	}
	return true;
}


#endif /* K019_H_ */