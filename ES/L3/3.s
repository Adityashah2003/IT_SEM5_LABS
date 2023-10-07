;hex to bcd	
	
	AREA RESET, DATA, READONLY
	EXPORT __Vectors
__Vectors 
	DCD 0x10001000 ; stack pointer value when stack is empty
	DCD Reset_Handler ; reset vector
	ALIGN
	AREA mycode, CODE, READONLY
	ENTRY
	EXPORT Reset_Handler
Reset_Handler
	ldr r0,=hex
	ldr r2,=rem
	mov r5,#0
	mov r7,#32
	ldr r1,[ro]
up2
	bl divide
	cmp r1,#0
	bne up2
	ldr r0,=bcd
	lsr r5, r7
	str r5,[ro]

stop B stop

divide mov r3,#0

up1
	cmp r1,#0x0a
	blo down
	sub r1,#0x0a
	add r3,#1
	b up1

down
	orr r5, r1
	ror r5,#4
	mov r1,r3 
	sub r7,#4
	bx lr

hex DCD 0xfffe 
	AREA data1,DATA
bcd DCD 0