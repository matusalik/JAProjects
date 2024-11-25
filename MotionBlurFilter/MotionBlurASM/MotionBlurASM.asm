.data
bytesPerPixel dq 3
brightArray db 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 0

.code
MyProc1 proc 
    ;stack pointer
    push rbp
    mov rbp, rsp

    ;parameters from registers
    mov rsi, rcx                ;image data ptr
    mov rdi, rdx                ;temp data ptr
    mov rax, r8                 ;startX
    mov rbx, r9                 ;endX

    ;parameters from stack
    mov rcx, [rsp + 48]         ;width  
    mov rdx, [rsp + 56]         ;height
    mov r10, [rsp + 64]         ;radius

    ;calculating stride and loading it to r11
    mov r11, rcx
    imul r11, [bytesPerPixel]

    ;loading bright array to xmm2
    movdqu xmm2, xmmword ptr[brightArray]

    ;Moving counter
    mov r9, 0

    ;Total size of pixel array (in bytes)
    mov r12, rcx
    imul r12, rdx
    imul r12, [bytesPerPixel]

ProcessChunk:
    cmp r12, r9
    js EndFunc
    movdqu xmm1, [rsi + r9] 
    paddb xmm1, xmm2
    movdqu [rdi + r9], xmm1
    add r9, 15
    jmp ProcessChunk

EndFunc:
    mov rsp, rbp 
    pop rbp
    ret
MyProc1 endp
end