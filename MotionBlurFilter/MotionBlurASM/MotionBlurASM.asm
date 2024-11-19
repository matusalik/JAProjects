.data
Brightness DWORD 30
bytesPerPixel dq 3
offsetCount dq 0 

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
    mov rcx, [rsp + 40]         ;width  
    mov rdx, [rsp + 48]         ;height
    mov r10, [rsp + 56]         ;radius

    ;calculating stride and loading it to r11
    mov r11, rcx
    imul r11, [bytesPerPixel]

    ;calculating move index for xmm
    mov r12, rax
    imul r12, [bytesPerPixel]

    movd xmm1, Brightness
    pshufd xmm1, xmm1, 0

    ;Calculating total bytes
    mov r14, rcx
    imul r14, rdx
    imul r14, [bytesPerPixel]

    ;Offset for copying pixels
    mov r13, 0

ProcessCollumns:
    cmp r12, rbx
    jge CopyPixels
    movups xmm0, [rsi + r12]
    paddusb xmm0, xmm1
    movups [rdi + r12], xmm0
    add r12, 12
    jmp ProcessCollumns

CopyPixels:
    cmp r13, r14
    jge EndFunc
    mov al, [rdi + r13]
    mov[rsi + r13], al
    inc r13
    jmp CopyPixels

EndFunc:
    mov rsp, rbp 
    pop rbp
    ret
MyProc1 endp
end