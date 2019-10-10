# Project for Computing Architecture Optimization
1. Realizaţi un scheduller minimal care să cuprindă următoarele tehnici de rearanjare a instrucţiunilor
în scopul eliminării statice a dependenţelor reale de date (RAW) şi a dezambiguizării referinţelor la
memorie. Simularea se face pe trace-urile benchmark-urilor SPEC folosite de simulatorul PSATSIM
sau pe fisierele (.ins, .trc) aferente benchmark-urilor Stanford.
a) Fuzionarea instrucţiunilor (merging)
Tehnica “merging” implică combinarea a două instrucţiuni într-una singură. Există trei categorii
de astfel de instrucţiuni. Prima categorie, numită MOV Merging implică o pereche de instrucţiuni în
care prima din ele este MOV. A doua categorie numită Immediate Merging se caracterizează prin
faptul că ambele instruţiuni au ca operanzi sursă valori immediate. A treia categorie se numeşte MOV
Reabsorption şi are ca a doua instrucţiune o instrucţiune MOV sau instrucţiunea ce se va infiltra va fi
convertită la tipul primei instrucţiuni.
 MOV Merging
Când apare o dependenţă reală de date între o instrucţiune MOV şi o instrucţiune care încearcă să
promoveze în sus în structura de cod a programului, se verifică faptul dacă cele două instrucţiuni pot fi
procesate în paralel. În caz afirmativ instrucţiunea ce se infiltrează îşi continuă drumul ascendent prin
basic block. În continuare vom prezenta tipurile de situaţii ce pot să apară în cadrul tehnicii MOV
merging.
 Combinarea cu o instrucţiune de adunare.
a) Secvenţa iniţială:
MOV R6, R7
ADD R3, R6, R5 /* instrucţiunea care se infiltrează */
Secvenţa modificată:
MOV R6, R7; ADD R3, R7, R5
b) Secvenţa iniţială:
MOV R6, #4
ADD R3, R6, #5 /* instrucţiunea care se infiltrează */
Secvenţa modificată:
MOV R6, #4; MOV R3, #9
Prin înlocuirea registrului R6 cu valoarea imediată respectivă instrucţiunea de adunare devine
MOV.
 Combinarea cu o instrucţiune store
Secvenţa iniţială:
MOV R3, #0
ST (R1, R2), R3 /* instrucţiunea care se infiltrează */
Secvenţa modificată:
MOV R3, #0; ST (R1, R2), R0
Registrul R3 este înlocuit cu R0 deoarece toate procesoarele RISC au registrul R0 cablat la 0.
 Combinarea cu o instrucţiune relaţională
Secvenţa iniţială:
MOV R4, #4
10
GT B1, R4, R3 /* instrucţiunea care se infiltrează */
Secvenţa modificată:
MOV R4, #4; LTE B1 R3, #4
Registrul R4 este înlocuit cu valoarea imediată memorată de el şi instrucţiunea GT devine LTE
pentru a permite operanzilor instrucţiunilor interschimbarea.
 Combinarea instrucţiunilor gardate
a) Secvenţa iniţială:
EQ B3, R0, R0 /* B3 := true */
TB3 ADD R10, R11, R12 /* instrucţiunea care se infiltrează */
Secvenţa modificată:
EQ B3, R0, R0; ADD R10, R11, R12
Instrucţiuni de tipul EQ Bi, R0, R0 şi NE Bi, R0, R0 sunt folosite pentru a înlocui instrucţiunile
MOV Bi, #true sau MOV Bi, #false pe care arhitectura HSA nu le pune la dispoziţie. Deoarece B3 este
întotdeauna true garda TB3 aferentă instrucţiunii de adunare poate fi înlăturată. Dacă B3 ar fi evaluată
întotdeauna la false atunci instrucţiunea care se infiltrează va fi înlocuită cu un NOP.
b) Secvenţa iniţială:
MOV B1, B2
TB1 LD R4, (R0, R6) /* instrucţiunea care se infiltrează */
Secvenţa combinată:
MOV B1, B2; TB2 LD R4, (R0, R6)
Pentru eliminarea dependenţelor de date, garda instrucţiunii LD devine acum B2.
c) Secvenţa iniţială:
MOV B1, B2
BT B1, label /* instrucţiunea care se infiltrează */
Secvenţa modificată:
MOV B1, B2; BT B2, label
d) Secvenţa iniţială:
EQ B1, R0, R0
BT B1, label /* instrucţiunea care se infiltrează */
Secvenţa modificată:
BRA label
Dacă registrul boolean care constituie gardă pentru instrucţiunea care se infiltrează are valoare
constantă saltul fie va fi eliminat fie va fi transformat într-unul necondiţionat (BRA).
 Immediate Merging
Această tehnică implică orice pereche de instrucţiuni care au valori imediate pe post de al doilea
operand sursă.
Secvenţa iniţială:
SUB R3, R6, #3
ADD R4, R3, #1 /* instrucţiunea care se infiltrează */
Secvenţa modificată:
SUB R3, R6, #3; ADD R4, R6, #-2
11
 MOV Reabsorption
Acest tip de combinare implică transformarea instrucţiunii MOV într-o instrucţiune de acelaşi tip
cu prima.
Secvenţa iniţială:
ADD R3, R4, R5
MOV R6, R3 /* instrucţiunea care se infiltrează */
Secvenţa combinată:
ADD R3, R4, R5; ADD R6, R4, R5
Ideea aflată la baza acestei metode este de a absorbi instrucţiunea MOV prin renaming aplicat
registrului destinaţie al primei instrucţiuni reducând astfel expansiunea codului. În cazul în care prima
instrucţiune este una cu referire la memorie (Load sau Store) duplicarea instrucţiunilor poate duce la
reducerea performanţei datorită numărului limitat de porturi de date ale cache-ului.
b) Analiza anti-alias a referinţelor la memorie
Dependenţele de date nu apar doar între regiştri, ci şi între locaţii de memorie referite în
instrucţiunile LD şi ST. La fel ca celelalte dependenţe ele provoacă deseori degradarea performanţei
procesoarelor. Pentru a face distincţie între locaţiile de memorie referite de cele două tipuri de
instrucţiuni, folosim tehnica numită analiză anti-alias statică a memoriei (static memory
disambiguation). Pentru a decide dacă o instrucţiune LD poate fi inserată în faţa unei instrucţiuni ST,
lucru ce se poate face în siguranţă doar dacă cele două adrese diferă, adresele locaţiilor de memorie
sunt comparate şi este returnată una din valorile:
 Diferit: Adresele sunt întotdeauna diferite.
 Identic: Adresele sunt întotdeauna identice.
 Eşuează: Adresele nu se pot distinge.
Dacă valoarea returnată este “Diferit” instrucţiunea LD poate fi inserată în faţa instrucţiunii ST.
De asemenea, dacă valoarea returnată este “Identic” instrucţiunea LD poate fi înlocuită cu o
instrucţiune MOV ca în exemplul următor:
Secvenţa iniţială:
ST (R0, R5), R6
LD R10, (R0, R5)
Secvenţa devine:
MOV R10, R6
ST (R0, R5), R6
Pe de altă parte, în cazul în care instrucţiunea LD este urmată de o instrucţiune ST, pentru ca
aceasta din urmă să poată fi infiltrată în faţa primeia trebuie ca cele două adrese să fie distincte
întotdeauna.
Secvenţa de cod ce va fi analizată este următoarea:
MOV R6, R5
DIV R5, R6, #120
ASL R13, R5, #4
SUB R13, R13, R5
ADD R13, R13, #-60
ST (R0, R17), R13
ADD R17, R17, #4
ADD R18, R18, #1
LES B1, R18, #25
BT B1, L10 (#0)
ADD R19, R19, #104
LES B1, R19, #2600
BT B1, L11 (#0)
LD R18, 12(SP)
LD RA, 0(SP)
ADD SP, SP, #128
12
MOV PC, RA (#0)
_Innerproduct:
SUB SP, SP, #128
MOV R10, R5
MOV R13, R8
ST (R0, R10), R0
MOV R8, #1
ASL R5, R13, #1
ASL R5, R5, #2
ADD R5, R5, R13
ADD R13, R5, R6
ASL R9, R9, #2
ADD R6, R13, #4
ADD R7, R7, #104
L16:
ADD R13, R7, R9
LD R5, (R0, R6)
LD R13, (R0, R13)
MULT R5, R5, R13
LD R13, (R0, R10)
ADD R13, R5, R13
ST (R0, R10), R13
ADD R6, R6, #4
ADD R8, R8, #1
LES B1, R8, #25
BT B1, L16 (#0)
ADD SP, SP, #128
MOV PC, RA (#0)
