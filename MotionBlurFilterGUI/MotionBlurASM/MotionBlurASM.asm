.data
;DivArray dd 11, 11, 11, 11 ; Tablica warto�ci dzielnika do dzielenia pikseli przez 11
DivArray dd 0.090909, 0.090909, 0.090909, 0.090909

.code
MyProc1 proc
    ; Pobieranie parametr�w ze stosu
    xor r10, r10             ; Wyzerowanie rejestru r10
    mov r10d, [rsp + 40]     ; Szeroko�� obrazu (Width) ze stosu
    xor r11, r11             ; Wyzerowanie rejestru r11
    mov r11d, [rsp + 48]     ; Wysoko�� obrazu (Height) ze stosu

    ; Zapisanie rejestr�w na stosie, aby zachowa� ich warto��
    push rbx
    push rbp
    push rdi
    push rsi
    push r12
    push r13
    push r14
    push r15

    ; Pobieranie parametr�w z rejestr�w
    mov rsi, rcx             ; �r�d�owe dane obrazu (Source data)
    mov rdi, rdx             ; Docelowe dane obrazu (Destination data)

    ; Obliczanie kroku (Stride) obrazu
    mov rax, r10             ; Kopiowanie szeroko�ci obrazu do rax
    shl rax, 2               ; Mno�enie szeroko�ci przez 4 (liczba bajt�w na piksel)
    mov r10, rax             ; Zapisanie wyniku jako Stride
    ; Wysoko�� - 5, aby nie wyj�� poza bitmap�
    sub r11, 5
    mov r13, 5               ; Inicjalizacja zmiennej r13 do p�tli zewn�trznej
    mov rcx, r8              ; Pocz�tkowa warto�� dla startX

    movdqu xmm3, xmmword ptr [DivArray] ; Za�adowanie tablicy dzielnik�w

OuterLoop:    
    cmp r13, r11             ; Sprawdzenie, czy r13 osi�gn�o wysoko�� - 5
    je EndFunc               ; Wyj�cie z procedury, je�li r13 >= (Height - 5)
    mov r8, rcx              ; Resetowanie r8 do pocz�tkowego startX

InnerLoop:
    cmp r9, r8               ; Sprawdzenie, czy r8 osi�gn�o endX
    je OuterInc              ; Przej�cie do zwi�kszenia r13, je�li r8 == endX
    dec r8                   ; Zmniejszenie r8
    cmp r8, r9               ; Sprawdzenie warunku
    je Decrement             ; Je�li r8 == r9, przejd� do Decrement
    inc r8                   ; Zwi�kszenie r8
    jmp Back                 ; Powr�t do bloku Back
Decrement:
    sub r8, 2
Back:
    mov r14, r8              ; Przepisanie warto�ci r8 do r14
    shl r14, 2               ; Mno�enie r14 przez 4 (liczba bajt�w na piksel)
    mov rax, r13             ; Kopiowanie r13 do rax (obecny wiersz)
    mov rbx, r10             ; Warto�� Stride
    mul rbx                  ; Mno�enie wiersza przez Stride
    add r14, rax             ; Dodanie przesuni�cia r13 * Stride do r14
    mov r12, r14             ; Zapisanie przesuni�cia pikseli w r12

    ; Rozpocz�cie przenoszenia pikseli do rejestr�w xmm
    mov rax, r10             ; Stride obrazu
    imul rax, rax, 5         ; Mno�enie przez 5
    sub r14, rax             ; Przesuni�cie w g�r� o 5 wierszy
    movdqu xmm0, xmmword ptr [rsi + r14] ; Za�adowanie danych pikseli do xmm0
    pmovzxbw xmm0, xmm0      ; Konwersja bajt�w do 16-bit�w
    mov r15, 0               ; Inicjalizacja licznika r15 dla p�tli dodawania

AddValues:
    cmp r15, 10              ; Sprawdzenie, czy licznik osi�gn�� 10
    je Continue              ; Przej�cie dalej, je�li tak
    add r14, r10             ; Przesuni�cie r14 o Stride w d�
    movdqu xmm2, xmmword ptr [rsi + r14 - 8] ; Za�adowanie kolejnych danych pikseli do xmm2
    movhlps xmm2, xmm2       ; Przesuni�cie g�rnej po�owy do dolnej
    pmovzxbw xmm2, xmm2      ; Konwersja bajt�w do 16-bit�w
    paddw xmm0, xmm2         ; Dodanie warto�ci pikseli
    inc r15                  ; Zwi�kszenie licznika
    jmp AddValues            ; Powr�t do pocz�tku p�tli

Continue:
    pxor xmm2, xmm2          ; Wyzerowanie xmm2
    movhlps xmm2, xmm0       ; Przesuni�cie g�rnej po�owy xmm0 do xmm2
    pmovzxwd xmm2,xmm2       ; Rozszerzenie do 32-bitowych s��w
    pmovzxwd xmm0,xmm0       ; Rozszerzenie do 32-bitowych s��w
    cvtdq2ps xmm0, xmm0      ;int -> float
    cvtdq2ps xmm2, xmm2      ;int -> float
    mulps xmm0, xmm3  ;mnozenie przez odwrotnosc
    mulps xmm2, xmm3  ;mnozenie przez odwrotnosc
    CVTTPS2DQ xmm0, xmm0      ; Konwersja z float do int
    CVTTPS2DQ xmm2, xmm2      ; Konwersja z float do int
    packusdw xmm0,xmm0       ; Pakowanie 32-bit�w do 16-bit�w
    packusdw xmm2,xmm2       ; Pakowanie 32-bit�w do 16-bit�w
    movlhps xmm0, xmm2       ; Po��czenie danych w xmm0
    packuswb xmm0, xmm0      ; Pakowanie 16-bit�w do bajt�w
    movq rax, xmm0           ; Zapisanie wyniku do rax
    mov r14, r12             ; Przywr�cenie przesuni�cia do r14
	mov qword ptr [rdi + r14], rax ; Zapisanie wyniku do docelowego obrazu

InnerInc:
    add r8, 2                ; Przesuni�cie do nast�pnego piksela
    jmp InnerLoop            ; Powr�t do pocz�tku p�tli wewn�trznej

OuterInc:
    inc r13                  ; Przej�cie do nast�pnego wiersza
    jmp OuterLoop            ; Powr�t do pocz�tku p�tli zewn�trznej

EndFunc:
    ; Przywracanie warto�ci rejestr�w ze stosu
    pop r15
    pop r14
    pop r13
    pop r12
    pop rsi
    pop rdi
    pop rbp
    pop rbx
    ret                      ; Zako�czenie procedury
MyProc1 endp
end