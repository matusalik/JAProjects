.data
bytesPerPixel dq 4
DivArray dd 11, 11, 11, 11
;Odwrotnosc_ dq 1_11, 1_11, 1_11, 1_11

.code
MyProc1 proc 
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

    ;Calculating Stride
    mov rax, r10
    shl rax, 2
    mov r10, rax
    ;Height - 5 to not go out of the bitmap
    sub r11, 5
    mov r13, 5
    mov rcx, r8
OuterLoop:    
    cmp r13, r11    
    je EndFunc
    mov r8, rcx
    
InnerLoop:
    cmp r9, r8
    je OuterInc   
    dec r8
    cmp r8, r9
    je Decrement
    inc r8
    jmp Back
Decrement:
    dec r8
    dec r8
Back:
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
    pmovzxbw xmm0, xmm0
    mov r15, 0

AddValues:
    cmp r15, 10
    je Continue
    add r14, r10
    movdqu xmm2, xmmword ptr [rsi + r14 - 8]
    movhlps xmm2, xmm2
    pmovzxbw xmm2, xmm2
    paddw xmm0, xmm2
    inc r15
    jmp AddValues

Continue:
    pxor xmm2, xmm2
    movhlps xmm2, xmm0
    movdqu xmm3, xmmword ptr [DivArray]
    pmovzxwd xmm2,xmm2 
    pmovzxwd xmm0,xmm0
    
    divps xmm0, xmm3    ;dzielenie
    divps xmm2, xmm3
    ;pmulld xmm0, xmm3
    ;pmulld xmm2, xmm3
    CVTPS2DQ xmm0, xmm0 ;konwersja z float do int
    CVTPS2DQ xmm2, xmm2
    packusdw xmm0,xmm0
    packusdw xmm2,xmm2
    movlhps xmm0, xmm2
    packuswb xmm0, xmm0
    movq rax, xmm0
    mov r14, r12
	mov qword ptr [rdi + r14], rax
    mov al, 255
    mov [rdi + r14 + 3], al
    mov [rdi + r14 + 7], al

InnerInc:
    add r8, 2
    jmp InnerLoop

OuterInc:
    inc r13
    jmp OuterLoop

EndFunc:
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