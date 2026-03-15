# SmartGardenSimulator

## Software Requirements Specification (SRS)
### Versione: 1.0
Ambito: Esercizio Finale Modulo UML e OOP corso Full Stack Developer

### 1. Introduzione

1.1 Scopo del Prodotto

L'obiettivo è sviluppare una console application in C# che simuli la gestione di un giardino smart.
Il sistema deve permettere all'utente di gestire e monitorare un giardino botanico virtuale tramite interfaccia testuale con diverse tipologie di piante, simulando cicli di crescita temporali ovvero simulare il passaggio del tempo e l'interazione tra piante e ambiente.

1.2 Obiettivi Didattici

Il progetto deve servire come prova pratica per applicare: 
- Pilastri OOP (Incapsulamento, Astrazione, Ereditarietà, Polimorfismo)
- Modellazione UML

### 2. Requisiti Funzionali

L'applicazione deve gestire i seguenti scenari:

- Gestione Giardino da parte dell'utente: 

	- L'utente può aggiungere piante ad una lista (giardino virtuale)
    - L'utente può annaffiare e raccogliere i frutti delle piante
	- L'utente può rimuovere piante dal giardino (cioè dalla lista) ma solo se già morte
	- L'utente può visualizzare il dettaglio di una pianta selezionata

- Simulazione Temporale: 

	- Un comando "PassaGiorno" da parte dell'utente deve far avanzare il tempo (un giorno alla volta), aumentando la sete e progredendo nella crescita di ogni pianta.

- Diversificazione Piante:

	- Devono esistere almeno tre tipi di piante (es. PianteDaFiori, Ortaggi, PianteGrasse a piacere)
	- I tre tipi hanno tempi di crescita differenti e differenti fabbisogni di acqua (dopo un giorno una pianta diminuisce il livello di acqua di 1/10, un'altra di 2/10 eccetera...)
	- Solo un tipo di pianta può dare frutto (prevedere un'interfaccia IRaccoglibile con un metodo Raccogli() e al comando dell'utente "se la pianta è di un certo tipo allora Raccogli() altrimenti stampa messaggio che non c'è nulla da raccogliere" e per farlo usare l'operatore "is")
	- Se le piante sono assetate (il livello dell'acqua è sotto una certa soglia, differente per ogni pianta) non crescono e dopo 7 giorni muoiono (contatore GiorniInSofferenza). Altrimenti restano nello stato Matura
	- Le piante hanno un ciclo di vita che segue i seguenti stati: Seme -> Germoglio -> Matura -> Morta
	- Il dettaglio delle piante è simile a "Tipo di pianta: Rosa | Stato: germoglio | Acqua: 8/10 | GiorniInSofferenza: 0"

- Monitoraggio:
    - L'utente può visualizzare le statistiche attuali del giardino

### 3. Requisiti Tecnici

Per concludere con successo l'esercizio il codice deve riflettere la seguente architettura:

#### 3.1 I quattro Pilastri della OOP

- Incapsulamento

Ogni pianta deve avere proprietà private (es. _livelloAcqua, _faseCrescita) accessibili solo tramite metodi pubblici con logica di validazione.

- Astrazione

Usare una classe astratta Pianta per definire il comportamento comune (es. Invecchia()), nascondendo i dettagli complessi.

- Ereditarietà

Prevedere classi derivate che ereditano da Pianta ma specializzano alcune caratteristiche.

- Polimorfismo

Il giardino deve contenere una lista di tipo List< Pianta >. Ciclando sulla lista con un unico ciclo, la chiamata al metodo Invecchia() deve comportarsi diversamente a seconda del tipo reale dell'oggetto.


#### 3.2 Diagrammi UML Richiesti

Realizzare i seguenti diagrammi:

- (PER CASA) Diagramma dei casi d'uso comprendente tutti gli scenari

- Diagramma delle Classi per mostrare la gerarchia delle piante e le loro relazioni

- (PER CASA) Diagramma di Attività

- Diagramma di Stato

- (PER CASA) Diagramma di Sequenza per modellare cosa succede internamente quando si preme "PassaGiorno"

*(PER CASA) -> perché ridondanti per un esercizio semplice e perché abbiamo poco tempo

### 4. Consigli

- La classe Giardino funziona da Controller: Gestisce la lista List< Pianta > e delega le azioni

- L'Interfaccia IIrrigabile: definisce il metodo RiceviAcqua(int quantità)

- La gestione degli input utente avviene tramite un menu numerico (switch) nel Main (ve lo fornisco io per brevità)

### 4. Requisiti Non Funzionali

Linguaggio: C# (Console App)

Interfaccia: Testuale (CLI), con feedback per ogni azione (es: "Hai annaffiato la Rosa.")

Per disegnare le piante usare gli Emoji Unicode: https://emojipedia.org/unicode-8.0

Esempio visivo:

- Fasi di crescita:
    - Seme: 🌱
    - Pianta Matura: 🌿
    - Fruttifera: 🍅 o 🍓
    - Morta: 🍂 o 💀

- Stato Salute:
    - Assetata: 💧
    - In salute: ✨

- Giardino: [ 🌱 ] [ 🌿 ] [ 🍅 ] [ 🍂 ]


## INDICAZIONE PRATICA

- 20 min - Modellazione UML
- 60 min - Architettura e Logica Piante
- 30 min - Classe Giardino

