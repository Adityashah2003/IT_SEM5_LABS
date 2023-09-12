	AREA RESET, DATA, READONLY
	EXPORT __Vectors
__Vectors
	DCD 0X40001000
	DCD Reset_Handler
	ALIGN
	AREA mycode, CODE, READONLY
	ENTRY
	EXPORT Reset_Handler
Reset_Handler
	
	LDR R0, =NUM
	LDR R1, =RES
	LDR R2, [R0]	;num, stores remainder after each iteration
	MOV R3, #0
	MOV R4, #0 		;quotient	
	
UP BL DIV
	LSL R2, R3
	ADD R3, #0X4	;total bits size for left shifting increasing
	ADD R6, R2
	MOV R2, R4  	;quotient goes back into r2(num) for further division
	CMP R2, #0X0
	MOV R4, #0X0
	BNE UP
	STR R6, [R1]
STOP 
	B STOP

DIV CMP R2, #0XA
	BLE DOWN
	SUB R2, #0XA
	ADD R4, #0X1
	CMP R2, #0X0
	BNE DIV
DOWN BX LR

NUM DCD 0X2F
	AREA data, DATA, READWRITE
RES DCD 0
	END