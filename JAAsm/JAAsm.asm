; Parametry:
    ; xmm0 - float min
    ; xmm1 - float max
    ; r8d - int option
    ; r9d - int pxheight
    ; [rsp+28h] - HSLColor[] tab


    ;polecenia wykorzystywane do testowania biblioteki
    ;testowanie nadpisania danych
    ;mov eax, 3F800000h              ; 1.0f
    ;mov dword ptr [rsi], eax

    ;xmm2 - przechowywane dane aktualnego piksela



.data
    ;currInRange       db 0         ;now in edx
    constMultiplier   dd 100.0


.code
AsmSort PROC
    push rbp
    mov rbp, rsp
    push rsi

    ;je�li parametrem nie jest hue - podzielenie min, max przez 100
    cmp r8, 0
    je start_cont
    movss   xmm2, [constMultiplier]
    divss   xmm0, xmm2
    divss   xmm1, xmm2

    ;ustawienie adresu na stosie oraz odpowiednich licznika p�tli zewn�trznej
start_cont:
    mov rsi, [rbp+48]               ;rsi - index tablicy
    mov ecx, r9d                    ;ecx - licznik p�tli
    mov edx, 0

;powielenie warto�ci do por�wnania (min max)
    shufps xmm0, xmm0, 0h
    shufps xmm1, xmm1, 0h

;petla zewn�trzna - iteracja po tablicy, szukanie wej�cia/wyj�cia w zakres
loop_start:
    cmp ecx, 0                      ;sprawdzenie licznika
    jle loop_end

    movaps xmm2, real4 ptr [rsi]   ;zapisanie 4 flaot�w do xmm2,3 (Hue, Sat, Light, Alpha)
    movaps xmm3, real4 ptr [rsi]


;Sprawdzenie zakresu do sortowania (0 - nie, sprawdz wejscie do zakresu | 1 - tak, sprawdz czy nie wyst�pi�o wyj�cie poza zakres )
    cmp edx, 0
    je not_in_range_logic
    jmp in_range_logic

;logika poza zakresem - sprawdzenie wej�cia w zakres, je�li tak - zapisanie adresu
not_in_range_logic:

;por�wnanie piksela z warto�ciami min/max
    call check_if_in_range
    test eax, eax
    jz continue

    mov edx, 1
    mov r10, rsi
    jmp continue

;logika w zakresie - sprawdzenie wyj�cia z zakresu, je�li tak - wywo�anie p�tli sortuj�cej
in_range_logic:

call check_if_in_range
    test eax, eax
    jnz sort
    mov edx, 0
    jmp continue

;P�tla sortuj�ca wykorzystuj�ca insertion sort (iteracja w przeciwnym kierunku ni� p�tla zewn�trzna)
sort:
    mov rdx, rsi
sort_loop:
    sub rdx, 16

    movaps xmm2, real4 ptr [rdx]
    movaps xmm3, xmm2
    movaps xmm4, real4 ptr [rdx+16]

    cmpps xmm2, xmm4, 6 ;(xmm2 > xmm4 | [i-1] > i)
    
    
    
;Sprawdzenie parametru por�wnania
    cmp r8, 0
    je comp_cont
    cmp r8, 1
    je comp_m_saturation
    cmp r8, 2
    je comp_m_lightness
    jmp comp_cont

;przesuni�cie na saturacj�
    comp_m_saturation:
    pshufd xmm2, xmm2, 01h
    jmp comp_cont

;przesuni�cie na jasno��
    comp_m_lightness:
    pshufd xmm2, xmm2, 02h
    jmp comp_cont

comp_cont:
    movd eax, xmm2
    test eax, eax

    test eax, eax
    jz sort_loop_cont

;warunkowa zamiana danych w xmm3, 4 w celu sortowania
    movaps real4 ptr [rdx], xmm4
    movaps real4 ptr [rdx+16], xmm3

sort_loop_cont:
    cmp rdx, r10
    jg sort_loop


continue:
    add rsi, 16
    dec ecx
    jmp loop_start

loop_end:
    mov eax, r9d

    pop rsi                         ;przywr�cenie stosu
    pop rbp

;testowanie warto�ci zwracanej
    ;movaps xmm0, xmm3
    ;pshufd xmm0, xmm0, 03h

    ret
AsmSort ENDP


;Procedura sprawdzaj�ca czy warto�� jest w zakresie
check_if_in_range:
    movaps xmm3, xmm2
    cmpps xmm2, xmm0, 5 ;(xmm2 >= xmm0 | currValue >= min)
    cmpps xmm3, xmm1, 2 ;(xmm3 <= xmm1 | currValue <= max)
    andps xmm2, xmm3

;sprawdzenie por�wnywanej warto�ci
    cmp r8, 0
    je n_in_select_end
    cmp r8, 1
    je n_in_saturation
    cmp r8, 2
    je n_in_lightness
    jmp comp_end

;sprawdzenie saturacji je�li nie w zakresie
n_in_saturation:
    pshufd xmm2, xmm2, 01h
    jmp n_in_select_end

;sprawdzenie jasno�ci je�li nie w zakresie
n_in_lightness:
    pshufd xmm2, xmm2, 02h
    jmp n_in_select_end

;sprawdzenie czy weszli�my do zakresu
n_in_select_end:

    movd eax, xmm2
comp_end:
    ret

END