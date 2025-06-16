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

    ;jeœli parametrem nie jest hue - podzielenie min, max przez 100
    cmp r8, 0
    je start_cont
    movss   xmm2, [constMultiplier]
    divss   xmm0, xmm2
    divss   xmm1, xmm2

    ;ustawienie adresu na stosie oraz odpowiednich licznika pêtli zewnêtrznej
start_cont:
    mov rsi, [rbp+48]               ;rsi - index tablicy
    mov ecx, r9d                    ;ecx - licznik pêtli
    mov edx, 0

;powielenie wartoœci do porównania (min max)
    shufps xmm0, xmm0, 0h
    shufps xmm1, xmm1, 0h

;petla zewnêtrzna - iteracja po tablicy, szukanie wejœcia/wyjœcia w zakres
loop_start:
    cmp ecx, 0                      ;sprawdzenie licznika
    jle loop_end

    movaps xmm2, real4 ptr [rsi]   ;zapisanie 4 flaotów do xmm2,3 (Hue, Sat, Light, Alpha)
    movaps xmm3, real4 ptr [rsi]


;Sprawdzenie zakresu do sortowania (0 - nie, sprawdz wejscie do zakresu | 1 - tak, sprawdz czy nie wyst¹pi³o wyjœcie poza zakres )
    cmp edx, 0
    je not_in_range_logic
    jmp in_range_logic

;logika poza zakresem - sprawdzenie wejœcia w zakres, jeœli tak - zapisanie adresu
not_in_range_logic:

;porównanie piksela z wartoœciami min/max
    call check_if_in_range
    test eax, eax
    jz continue

    mov edx, 1
    mov r10, rsi
    jmp continue

;logika w zakresie - sprawdzenie wyjœcia z zakresu, jeœli tak - wywo³anie pêtli sortuj¹cej
in_range_logic:

call check_if_in_range
    test eax, eax
    jnz sort
    mov edx, 0
    jmp continue

;Pêtla sortuj¹ca wykorzystuj¹ca insertion sort (iteracja w przeciwnym kierunku ni¿ pêtla zewnêtrzna)
sort:
    mov rdx, rsi
sort_loop:
    sub rdx, 16

    movaps xmm2, real4 ptr [rdx]
    movaps xmm3, xmm2
    movaps xmm4, real4 ptr [rdx+16]

    cmpps xmm2, xmm4, 6 ;(xmm2 > xmm4 | [i-1] > i)
    
    
    
;Sprawdzenie parametru porównania
    cmp r8, 0
    je comp_cont
    cmp r8, 1
    je comp_m_saturation
    cmp r8, 2
    je comp_m_lightness
    jmp comp_cont

;przesuniêcie na saturacjê
    comp_m_saturation:
    pshufd xmm2, xmm2, 01h
    jmp comp_cont

;przesuniêcie na jasnoœæ
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

    pop rsi                         ;przywrócenie stosu
    pop rbp

;testowanie wartoœci zwracanej
    ;movaps xmm0, xmm3
    ;pshufd xmm0, xmm0, 03h

    ret
AsmSort ENDP


;Procedura sprawdzaj¹ca czy wartoœæ jest w zakresie
check_if_in_range:
    movaps xmm3, xmm2
    cmpps xmm2, xmm0, 5 ;(xmm2 >= xmm0 | currValue >= min)
    cmpps xmm3, xmm1, 2 ;(xmm3 <= xmm1 | currValue <= max)
    andps xmm2, xmm3

;sprawdzenie porównywanej wartoœci
    cmp r8, 0
    je n_in_select_end
    cmp r8, 1
    je n_in_saturation
    cmp r8, 2
    je n_in_lightness
    jmp comp_end

;sprawdzenie saturacji jeœli nie w zakresie
n_in_saturation:
    pshufd xmm2, xmm2, 01h
    jmp n_in_select_end

;sprawdzenie jasnoœci jeœli nie w zakresie
n_in_lightness:
    pshufd xmm2, xmm2, 02h
    jmp n_in_select_end

;sprawdzenie czy weszliœmy do zakresu
n_in_select_end:

    movd eax, xmm2
comp_end:
    ret

END