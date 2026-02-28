using System;

// Entry point
class SmartGardenSimulator
{
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
            Console.Write($"Giardino: ${mioGiardino.toString()}\n"); /* TODO */

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
                    /* TODO */
                    break;
                case "2":
                    /* TODO */
                    break;
                case "3":
                    Console.Write("Inserisci ID pianta da annaffiare: ");
                    int idAnnaffiare = int.Parse(Console.ReadLine());
                    /* TODO */

                    break;
                case "4":
                    Console.Write("Inserisci ID pianta da raccogliere: ");
                    int idRaccogliere = int.Parse(Console.ReadLine());
                    /* TODO */
                    break;
                case "5":
                    Console.Write("Inserisci ID pianta da rimuovere: ");
                    int idRimuovere = int.Parse(Console.ReadLine());
                    /* TODO */
                    Console.WriteLine("...È passato un giorno! ☀️");
                    break;
                case "6":
                    /* TODO */
                    Console.WriteLine("...È passato un giorno! ☀️");
                    break;
                case "7":
                    Console.WriteLine(/* TODO */);
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
}
