using System;

// Entry point
class SmartGardenSimulator
{
    private static int _giornoCorrente = 0;

    static void Main(string[] args)
    {
        // Impostazione per vedere gli Emoji su Console
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Inizializzazione del giardino
        Giardino mioGiardino = new Giardino();
        bool esci = false;

        Console.WriteLine("🌿 BENVENUTO NEL TUO SMART GARDEN 🌿");

        while (!esci)
        {
            // Visualizza il giardino
            Console.Write($"\n🌿 Giorno {_giornoCorrente} - {mioGiardino}\n");

            // Visualizza il menu
            Console.WriteLine("\n--- MENU UTENTE ---\n");
            Console.WriteLine("1. Visualizza Dettaglio Pianta 📋");
            Console.WriteLine("2. Aggiungi Pianta ➕");
            Console.WriteLine("3. Annaffia Pianta 💧");
            Console.WriteLine("4. Raccogli Frutti 🍒");
            Console.WriteLine("5. Rimuovi Pianta 🪏");
            Console.WriteLine("6. Passa Giorno ⏳");
            Console.WriteLine("7. Visualizza Statistiche Giardino 📈");
            Console.WriteLine("0. Esci");
            Console.Write("\nScelta: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci ID pianta da visualizzare: ");
                    int idVisualizzare = int.Parse(Console.ReadLine());
                    Console.WriteLine(mioGiardino.GetDettaglioPianta(idVisualizzare));
                    break;
                case "2":
                    AggiungiPianta(mioGiardino);
                    break;
                case "3":
                    Console.Write("Inserisci ID pianta da annaffiare: ");
                    int idAnnaffiare = int.Parse(Console.ReadLine());
                    mioGiardino.AnnaffiaPianta(idAnnaffiare);
                    break;
                case "4":
                    mioGiardino.RaccogliFrutti();
                    break;
                case "5":
                    Console.Write("Inserisci ID pianta da rimuovere: ");
                    int idRimuovere = int.Parse(Console.ReadLine());
                    mioGiardino.RimuoviPianta(idRimuovere);
                    break;
                case "6":
                    PassaGiorno(mioGiardino);
                    Console.WriteLine("...È passato un giorno! ☀️");
                    break;
                case "7":
                    mioGiardino.VisualizzaStatistiche();
                    break;
                case "0":
                    esci = true;
                    break;
                default:
                    Console.WriteLine("⚠️ Scelta non valida!");
                    break;
            }
        }

        Console.WriteLine("Grazie per aver usato Smart Garden Simulator! 👋");
    }

    static void AggiungiPianta(Giardino giardino)
    {
        Console.WriteLine("\n🌿 TIPI DI PIANTE DISPONIBILI:");
        Console.WriteLine("1️⃣  Rosa (Fiore)");
        Console.WriteLine("2️⃣  Pomodoro (Ortaggio - produce frutti)");
        Console.WriteLine("3️⃣  Pianta Grassa");
        Console.Write("Scelta: ");

        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                giardino.AggiungiPianta(new Rosa());
                break;

            case "2":
                giardino.AggiungiPianta(new Pomodoro());
                break;

            case "3":
                giardino.AggiungiPianta(new PiantaGrassa());
                break;

            default:
                Console.WriteLine("❌ Scelta non valida!");
                break;
        }
    }

    public static void PassaGiorno(Giardino giardino)
    {
        _giornoCorrente++;
        Console.WriteLine($"\n⏰ Giorno {_giornoCorrente} iniziato!\n");
        giardino.PassaGiorno();
        Console.WriteLine();
    }
}
