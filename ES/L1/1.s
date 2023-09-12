	AREA    RESET, DATA, READONLY
    EXPORT  __Vectors

__Vectors 
	DCD  0x100000FF     ; stack pointer value when stack is empty
    DCD  Reset_Handler  ; reset vector
  
    ALIGN

	AREA mycode, CODE, READONLY
	EXPORT Reset_Handler
	ENTRY
Reset_Handler

	LDR R0,=SRC
	LDR R1,=DST
	MOV R2,#5
	
LOOP	
	LDR R3,[R0],#04
	STR R3,[R1],#04
	SUBS R2,#1
	BNE LOOP
	
STOP
	B STOP

SRC DCD 0x00000001,0x00000002,0x00000003,0x00000004,0x00000005
	AREA mydata, DATA, READWRITE
DST DCD 0,0,0,0,0
	END