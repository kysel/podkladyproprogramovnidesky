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

/*
#include "util/makra.h"
extern "C" {
	#include "i2cmaster.h"
};
#include "queue.h"
#include "rs232new-basic.h"
#include "format_rs232.h"*/

#define pA	1
#define pA2 2
#define pB	3
#define pB2	4
#define pC	5
#define pC2	6
#define pD	7
#define pE	8
#define pF	9
#define pF2 10
#define pG	11
#define pG2 12
#define pH	13
#define pH2	14
#define pI	15
#define pI2	16
#define pJ	17
#define pJ2	18
#define pK	19
#define pK2	20
#define pL	21
#define pM	22

#define DBR 1

#define ledGOFF	SETBIT(PORTC,2);
#define ledROFF	SETBIT(PORTC,3);
#define ledGON CLEARBIT(PORTC,2);
#define ledRON CLEARBIT(PORTC,3);

class input_t
{	
	bool reading=true;
	uint32_t tmp;
	uint8_t i;
	uint8_t data;
	private:
		inline uint8_t read(void)
		{
			CLEARBIT(PORTC,0);
			_delay_us(DBR);
			data=PINA;
			SETBIT(PORTC,0);
			return data;
		}
		
		inline void write(uint8_t data)
		{
			PINA=data;
			CLEARBIT(PORTC,1);
			_delay_us(DBR);			
			SETBIT(PORTC,1);
		}
	
	public:	
		uint32_t readWord(const uint8_t add)
		{
			add>pE?pE:add;
			tmp=0;
			for (i=0; i<4; i++)
				tmp+=(readByte(i + add) << (8 * i));
			return tmp;
		}
		
		uint8_t readByte(const uint8_t add)
		{
			add>23?23:add;
			tmp=((7 - (add % 8)) + (add / 8) * 8);
			PORTD = (((tmp % 8) << 2 | (tmp / 8) << 5) & 0xfc);
			return read();
		}
		
		bool write(const uint8_t add, const uint8_t data)
		{
			if(add>55)
				return false;
			tmp=((7 - (add % 8)) + (add / 8) * 8);
			PORTD = (((tmp % 8) << 2 | (tmp / 8) << 5) & 0xfc);
			write(data);
			return true;
		}
		
		bool write(const uint8_t add, const uint32_t data)
		{
			if(add>13)
				return false;
			for (i=0; i<4; i++)
				write(add+i, uint8_t(data >> ((4 - i) * 8)));
			return true;
		}		
}input;

bool init()
{
	SETBIT(DDRB,4);
	SETBIT(DDRC,2);
	SETBIT(DDRC,3);
	DDRC=0xff;
	DDRD=0xfe;
	SETBIT(PORTC,0);
	SETBIT(PORTC,1);
	//rs232.init(115200);
	return true;
}


#endif /* K019_H_ */