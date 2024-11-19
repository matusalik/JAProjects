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
    mov r12, 3
    imul r11, r12

    ;calculating move index for xmm
    mov r12, rax
    mov r13, 3
    imul r12, r13

ProcessCollumns:
    cmp rax, rbx
    jge EndFunc


EndFunc:
    mov rsp, rbp 
    pop rbp
    ret
MyProc1 endp
end