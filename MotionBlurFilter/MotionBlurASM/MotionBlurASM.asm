.data
bytesPerPixel dq 4
ByteArray db 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0
ByteArray_2 db 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0
ByteArray_3 db 255, 255, 0, 0, 255, 255, 0, 0, 255, 255, 0, 0, 255, 255, 0, 0
ShuffleArray db 0,4,8,12,1,2,3,5,6,7,9,10,11,13,14,15
ShuffleArray_2 db 0,1,2,3,8,9,10,11,12,13,14,15
DivArray dd 11, 11, 11, 11



.code
MyProc1 proc 
    ;stack pointer
    ;push rbp
    ;mov rbp, rsp

    ;parameters from stack
    mov r10, [rsp + 40] ;Width
    mov r11, [rsp + 48] ;Height

    push rbx
    push rbp
    push rdi
    push rsi
    push r12
    push r13
    push r14
    push r15

    ;parameters from registers
    mov rsi, rcx    ;Source data
    mov rdi, rdx    ;Destination data
    ;r8 - startX
    ;r9 - endX


    ;Height - 5 to not go out of the bitmap
    sub r11, 5

    ;Calculating Stride
    mov rax, r10
    shl rax, 2
    mov r10, rax



OuterLoop:
    cmp r8, r9
    jge EndFunc
    mov r13, 5
    
InnerLoop:
    cmp r13, r11    
    jge OuterInc   
    mov r14, r8
    shl r14, 2
    mov rax, r13
    mov rbx, r10
    mul rbx
    add r14, rax
    mov r12, r14

    ;Starting moving pixels to xmm registers
    mov rax, r10
    imul rax, rax, 5
    sub r14, rax
    movdqu xmm0, xmmword ptr [rsi + r14]
    movdqu xmm1, xmmword ptr [ByteArray]
    movdqu xmm5, xmmword ptr [ByteArray_2]
    pand xmm0, xmm1
    punpcklbw xmm0, xmm0
    pand xmm0, xmm5
    mov r15, 0

AddValues:
    cmp r15, 10
    jz Continue
    mov rax, r10
    add r14, rax
    movdqu xmm2, xmmword ptr [rsi + r14]
    pand xmm2, xmm1
    punpcklbw xmm2, xmm2
    pand xmm2, xmm5
    paddw xmm0, xmm2
    inc r15
    jmp AddValues

Continue:
    pxor xmm2, xmm2
    movhlps xmm2, xmm0
    pand xmm0, xmm1
    movdqu xmm3, xmmword ptr [DivArray]
    punpcklwd xmm2, xmm2  
    punpcklwd xmm0, xmm0 
    movdqu xmm5, xmmword ptr [ByteArray_3]
    pand xmm2, xmm5
    pand xmm0, xmm5
    divps xmm0, xmm3
    divps xmm2, xmm3
    CVTPS2DQ xmm0, xmm0
    CVTPS2DQ xmm2, xmm2
    movdqu xmm5, xmmword ptr [ShuffleArray]
    pshufb xmm0, xmm5
    pshufb xmm2, xmm5
    movlhps xmm0, xmm2
    movdqu xmm5, xmmword ptr [ShuffleArray_2]
    pshufb xmm0, xmm5
    pand xmm0, xmm1
    mov r14, r12
    PEXTRB rax, xmm0, 0
	mov byte ptr [rdi + r14], al
    inc r14
	PEXTRB rax, xmm0, 1
	mov byte ptr [rdi + r14], al
	inc r14
	PEXTRB rax, xmm0, 2
	mov byte ptr [rdi + r14], al
	inc r14
	mov al, byte ptr [rsi + r14]
	mov byte ptr [rdi + r14], al

    mov rbx, r8
    add rbx, 2
    add rbx, r13
    mov r15, r9
    add r15, r11
    cmp rbx, r15
    jz InnerInc
    inc r14
    PEXTRB rax, xmm0, 4
	mov byte ptr [rdi + r14], al
	inc r14
	PEXTRB rax, xmm0, 5
	mov byte ptr [rdi + r14], al
	inc r14
	PEXTRB rax, xmm0, 6
	mov byte ptr [rdi + r14], al
    inc r14
	mov al, byte ptr [rsi + r14]
	mov byte ptr [rdi + r14], al

    

InnerInc:
    inc r13
    jmp InnerLoop

OuterInc:
    inc r8
    jmp OuterLoop

EndFunc:
    ;mov rsp, rbp 
    ;pop rbp
    pop r15
    pop r14
    pop r13
    pop r12
    pop rsi
    pop rdi
    pop rbp
    pop rbx
    ret
MyProc1 endp
end