.data

sum dq 0 
pTab dq     0
dwa dd 2.0f
first dq 0
sec dq 0
avg dq 0
dest dq 0

.code

ProcAsm3 proc

mov pTab, rcx ; adres pierwszego el tablicy
mov rcx, rdx ; dlugosc tblicy
mov dl,4 ; mno�nik, int to 4 bajty = 32 bity

l:
mov rax, rcx
mul dl
add rax, pTab
mov rax, [rax]
add rax, sum
mov sum, rax
loop l

mov rdi, pTab
add rax, [rdi]
ret
ProcAsm3 endp


Srednia proc

mov rdx, 0;

mov rbx, rcx
mov rbx, [rbx]
mov first, rbx
mov rbx, [rcx+8]
mov sec, rbx
mov rbx, [rcx+16]
mov dest, rbx

mov rcx,16
petla:
mov rbx, first
mov rax, [rbx+rdx]
movd XMM0, eax

mov rbx, sec
mov rax, [rbx+rdx]
movd XMM1, eax

movd xmm2, dwa

addss xmm0, xmm1
divss xmm0, xmm2
movq rax, xmm0
mov rbx, dest
mov [rbx+rdx], rax
add rdx , 4
loop petla

ret
Srednia endp

END