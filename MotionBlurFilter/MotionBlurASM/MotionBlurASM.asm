.data
bytesPerPixel dq 4
brightArray db 40, 40, 40, 0, 40, 40, 40, 0, 40, 40, 40, 0, 40, 40, 40, 0

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

    ;size of the bitmap
    mov r13, r10
    imul r13, r11
    imul r13, [bytesPerPixel]

    ;counter
    mov r14, 0

    ;bright xmm
    movdqu xmm1, xmmword ptr[brightArray]
    

ProcessChunk:
    cmp r13, r14
    jnge EndFunc
    movdqu xmm0, [rcx + r14]
    paddusb xmm0, xmm1
    movdqu [rdx + r14], xmm0
    add r14, 16
    jmp ProcessChunk

EndFunc:
    mov rsp, rbp 
    pop rbp
    ret
MyProc1 endp
end