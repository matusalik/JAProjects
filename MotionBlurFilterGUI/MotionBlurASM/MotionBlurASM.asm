.data
;DivArray dd 11, 11, 11, 11 ; Tablica wartoœci dzielnika do dzielenia pikseli przez 11
DivArray dd 0.090909, 0.090909, 0.090909, 0.090909

.code
MyProc1 proc
    ; Pobieranie parametrów ze stosu
    xor r10, r10             ; Wyzerowanie rejestru r10
    mov r10d, [rsp + 40]     ; Szerokoœæ obrazu (Width) ze stosu
    xor r11, r11             ; Wyzerowanie rejestru r11
    mov r11d, [rsp + 48]     ; Wysokoœæ obrazu (Height) ze stosu

    ; Zapisanie rejestrów na stosie, aby zachowaæ ich wartoœæ
    push rbx
    push rbp
    push rdi
    push rsi
    push r12
    push r13
    push r14
    push r15

    ; Pobieranie parametrów z rejestrów
    mov rsi, rcx             ; ród³owe dane obrazu (Source data)
    mov rdi, rdx             ; Docelowe dane obrazu (Destination data)

    ; Obliczanie kroku (Stride) obrazu
    mov rax, r10             ; Kopiowanie szerokoœci obrazu do rax
    shl rax, 2               ; Mno¿enie szerokoœci przez 4 (liczba bajtów na piksel)
    mov r10, rax             ; Zapisanie wyniku jako Stride
    ; Wysokoœæ - 5, aby nie wyjœæ poza bitmapê
    sub r11, 5
    mov r13, 5               ; Inicjalizacja zmiennej r13 do pêtli zewnêtrznej
    mov rcx, r8              ; Pocz¹tkowa wartoœæ dla startX

    movdqu xmm3, xmmword ptr [DivArray] ; Za³adowanie tablicy dzielników

OuterLoop:    
    cmp r13, r11             ; Sprawdzenie, czy r13 osi¹gnê³o wysokoœæ - 5
    je EndFunc               ; Wyjœcie z procedury, jeœli r13 >= (Height - 5)
    mov r8, rcx              ; Resetowanie r8 do pocz¹tkowego startX

InnerLoop:
    cmp r9, r8               ; Sprawdzenie, czy r8 osi¹gnê³o endX
    je OuterInc              ; Przejœcie do zwiêkszenia r13, jeœli r8 == endX
    dec r8                   ; Zmniejszenie r8
    cmp r8, r9               ; Sprawdzenie warunku
    je Decrement             ; Jeœli r8 == r9, przejdŸ do Decrement
    inc r8                   ; Zwiêkszenie r8
    jmp Back                 ; Powrót do bloku Back
Decrement:
    sub r8, 2
Back:
    mov r14, r8              ; Przepisanie wartoœci r8 do r14
    shl r14, 2               ; Mno¿enie r14 przez 4 (liczba bajtów na piksel)
    mov rax, r13             ; Kopiowanie r13 do rax (obecny wiersz)
    mov rbx, r10             ; Wartoœæ Stride
    mul rbx                  ; Mno¿enie wiersza przez Stride
    add r14, rax             ; Dodanie przesuniêcia r13 * Stride do r14
    mov r12, r14             ; Zapisanie przesuniêcia pikseli w r12

    ; Rozpoczêcie przenoszenia pikseli do rejestrów xmm
    mov rax, r10             ; Stride obrazu
    imul rax, rax, 5         ; Mno¿enie przez 5
    sub r14, rax             ; Przesuniêcie w górê o 5 wierszy
    movdqu xmm0, xmmword ptr [rsi + r14] ; Za³adowanie danych pikseli do xmm0
    pmovzxbw xmm0, xmm0      ; Konwersja bajtów do 16-bitów
    mov r15, 0               ; Inicjalizacja licznika r15 dla pêtli dodawania

AddValues:
    cmp r15, 10              ; Sprawdzenie, czy licznik osi¹gn¹³ 10
    je Continue              ; Przejœcie dalej, jeœli tak
    add r14, r10             ; Przesuniêcie r14 o Stride w dó³
    movdqu xmm2, xmmword ptr [rsi + r14 - 8] ; Za³adowanie kolejnych danych pikseli do xmm2
    movhlps xmm2, xmm2       ; Przesuniêcie górnej po³owy do dolnej
    pmovzxbw xmm2, xmm2      ; Konwersja bajtów do 16-bitów
    paddw xmm0, xmm2         ; Dodanie wartoœci pikseli
    inc r15                  ; Zwiêkszenie licznika
    jmp AddValues            ; Powrót do pocz¹tku pêtli

Continue:
    pxor xmm2, xmm2          ; Wyzerowanie xmm2
    movhlps xmm2, xmm0       ; Przesuniêcie górnej po³owy xmm0 do xmm2
    pmovzxwd xmm2,xmm2       ; Rozszerzenie do 32-bitowych s³ów
    pmovzxwd xmm0,xmm0       ; Rozszerzenie do 32-bitowych s³ów
    cvtdq2ps xmm0, xmm0      ;int -> float
    cvtdq2ps xmm2, xmm2      ;int -> float
    mulps xmm0, xmm3  ;mnozenie przez odwrotnosc
    mulps xmm2, xmm3  ;mnozenie przez odwrotnosc
    CVTTPS2DQ xmm0, xmm0      ; Konwersja z float do int
    CVTTPS2DQ xmm2, xmm2      ; Konwersja z float do int
    packusdw xmm0,xmm0       ; Pakowanie 32-bitów do 16-bitów
    packusdw xmm2,xmm2       ; Pakowanie 32-bitów do 16-bitów
    movlhps xmm0, xmm2       ; Po³¹czenie danych w xmm0
    packuswb xmm0, xmm0      ; Pakowanie 16-bitów do bajtów
    movq rax, xmm0           ; Zapisanie wyniku do rax
    mov r14, r12             ; Przywrócenie przesuniêcia do r14
	mov qword ptr [rdi + r14], rax ; Zapisanie wyniku do docelowego obrazu

InnerInc:
    add r8, 2                ; Przesuniêcie do nastêpnego piksela
    jmp InnerLoop            ; Powrót do pocz¹tku pêtli wewnêtrznej

OuterInc:
    inc r13                  ; Przejœcie do nastêpnego wiersza
    jmp OuterLoop            ; Powrót do pocz¹tku pêtli zewnêtrznej

EndFunc:
    ; Przywracanie wartoœci rejestrów ze stosu
    pop r15
    pop r14
    pop r13
    pop r12
    pop rsi
    pop rdi
    pop rbp
    pop rbx
    ret                      ; Zakoñczenie procedury
MyProc1 endp
end