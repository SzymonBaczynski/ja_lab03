.data

sum dq 0 
pTab dq	 0

.code

ProcAsm3 proc

mov pTab, rcx ; adres pierwszego el tablicy
mov rcx, rdx ; dlugosc tblicy
mov dl,4 ; mno¿nik, int to 4 bajty = 32 bity

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

; ProcAsm33 proc

; xor r9, r9
; mov r8, rcx ; adres pierwszego el tablicy
; mov rcx, rdx ; dlugosc tblicy
; mov dl,4

; l1:
; mov rax, rcx
; mul dl
; mov rax, [rax + r8]
; add rax, r9
; mov r9, rax
; loop l1

; add rax, [r8]	
; ret
; ProcAsm33 endp



ProcAsm2 proc
xor rax,rax
mov rax, rdx ; numer elementu tablicy do rax, potrzebujemy tylko ah (krótka tablica)
mov dl,4 ; mno¿nik, int to 4 bajty = 32 bity
mul dl ; rozmiar int to 4 bajty
mov eax, [rcx+rax]
ret
ProcAsm2 endp

ProcAsm1 proc
mov RAX, RCX
add RAX, RDX
ret
ProcAsm1 endp

END