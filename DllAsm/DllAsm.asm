.data

; data for ProcSuma
sum dq 0 
pTab dq 0

; data for ProcSrednia
two dd 2.0f
first dq 0
sec dq 0
avg dq 0
dest dq 0

.code

ProcSum proc

mov pTab, rcx ; adresf of the first array's element
mov rcx, rdx ; lenght of array
mov dl,4 ; multiplicator, int is 4 bytes = 32 bits

loop1:
mov rax, rcx
mul dl
add rax, pTab
mov rax, [rax]
add rax, sum
mov sum, rax
loop loop1

mov rdi, pTab
add rax, [rdi]
ret
ProcSum endp


ProcMean proc

mov rdx, 0;

mov rbx, rcx
mov rbx, [rbx]
mov first, rbx
mov rbx, [rcx+8]
mov sec, rbx
mov rbx, [rcx+16]
mov dest, rbx

mov rcx,16
loop1:
mov rbx, first
mov rax, [rbx+rdx]
movd XMM0, eax

mov rbx, sec
mov rax, [rbx+rdx]
movd XMM1, eax

movd xmm2, two

addss xmm0, xmm1
divss xmm0, xmm2
movq rax, xmm0
mov rbx, dest
mov [rbx+rdx], rax
add rdx , 4
loop loop1

ret
ProcMean endp

END