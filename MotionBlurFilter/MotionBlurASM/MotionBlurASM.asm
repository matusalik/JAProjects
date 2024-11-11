.code
MyProc1 proc
	mov rax, 0	;index to "move" pointers
loop_start:
	movdqu xmm0, [rcx + rax]	;move four 32-bit numbers from arrayA to xmm0
	movdqu xmm1, [rdx + rax]	;move four 32-bit numbers from arrayB to xmm1
	paddd xmm0, xmm1			;simultaneously add numbers from arrayA and arrayB
	movdqu [r8 + rax], xmm0		;save result to outcome array
	add rax, 16					;move pointer by 16 bytes forward (4 * 32-bit (4 byte) numbers)
	sub r9, 4					;reduce counter by 4 (we proceesed 4 numbers at once)
	jnz loop_start				;if not 0 (array not finished) jump back to loop
	ret
MyProc1 endp
end