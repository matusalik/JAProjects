.code
MyProc1 proc
mov RAX, qword ptr [RCX]
add RDX, RAX
mov qword ptr [RCX], RDX
ret
MyProc1 endp
end