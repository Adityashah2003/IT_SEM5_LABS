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
	LDR R3,=N1
	LDR R4,=N2
	LDR R8,=N3
	LDR R2,=RES
	LDR R0, [R3]
	LDR R1, [R4]
	LDR R5,[R8]
	
LOOP
	MUL R6,R5,R0
	UDIV R9,R6,R1
	MUL R7,R9,R1
	SUB R6,R7,R9
	CMP R6,#0
	BNE DOWN
	B EXIT
DOWN
	ADDS R5,R5,#1
EXIT		
	CMP R6,#0
	BNE	LOOP
	MUL R0,R0,R5
	STR R0,[R2]
STOP
	B STOP
N1 DCD 0X00000003
N2 DCD 0X00000002
N3 DCD 0X00000001
	AREA mydata, DATA, READWRITE
RES DCD 0 
	END