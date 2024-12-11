.data
bytesPerPixel dq 3
brightArray db 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10


.code
MyProc1 proc 
    ;stack pointer
    push rbp
    mov rbp, rsp

    ;parameters from registers
    ;rcx - image data ptr
    ;rdx - temp data ptr
    ;r8 - startX
    ;r9 - endX

    ;parameters from stack
    mov r10, [rsp + 48]         ;width  
    mov r11, [rsp + 56]         ;height
    mov r12, [rsp + 64]         ;radius

    ;calculating stride and loading it to r13
    mov r13, r10
    imul r13, [bytesPerPixel]

    ;loading bright array to xmm2
    movdqu xmm2, xmmword ptr[brightArray]
    cvtdq2ps xmm2, xmm2

    ;Total size from startX to endX (in bytes) - CHUNK size
    mov r14, r9
    imul r14, r11
    imul r14, [bytesPerPixel]

    ;Calculating divisor needed apply motion blur and pushing it to xmm3 register
    mov r15, r12
    imul r15, 2
    add r15, 1
    movd xmm3, r15
    shufps xmm3, xmm3, 0

ProcessChunk:
    cmp r14, r8
    js EndFunc
    movdqu xmm1, [rcx + r8] 
    cvtdq2ps xmm1, xmm1
    divss xmm1, xmm2
    CVTPS2DQ xmm1, xmm1
    movdqu [rdx + r8], xmm1
    add r8, 15
    jmp ProcessChunk

EndFunc:
    mov rsp, rbp 
    pop rbp
    ret
MyProc1 endp
end