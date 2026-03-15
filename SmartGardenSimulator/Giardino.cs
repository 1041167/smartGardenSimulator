using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


public class Giardino
{
    private List<Pianta> _piante;
    private int _giornoCorrente;

    public Giardino()
    {
        _piante = new List<Pianta>();
        _giornoCorrente = 0;
    }

    public void AggiungiPianta(Pianta pianta)
    {
        if (pianta == null)
            throw new ArgumentNullException(nameof(pianta));

        _piante.Add(pianta);
        Console.WriteLine($"✅ {pianta.Tipo} aggiunta al giardino!");
    }

    public void AnnaffiaPianta(int indice, int quantita = 3)
    {
        if (indice < 0 || indice >= _piante.Count)
        {
            Console.WriteLine("❌ Indice non valido!");
            return;
        }

        _piante[indice].RiceviAcqua(quantita);
    }

    public void RaccogliFrutti()
    {
        foreach (Pianta pianta in _piante)
        {
            // Usa l'operatore "is" per verificare se implementa IRaccoglibile
            if (pianta is IRaccoglibile raccoglibile)
            {
                string messaggio = raccoglibile.Raccogli();
                Console.WriteLine(messaggio);
            }
            else
            {
                Console.WriteLine("❌ Questa pianta non produce frutti!");
            }
        }    
    }

    public void RimuoviPianta(int indice)
    {
        if (indice < 0 || indice >= _piante.Count)
        {
            Console.WriteLine("❌ Indice non valido!");
            return;
        }

        if (_piante[indice].FaseCrescita != FaseCrescita.Morta)
        {
            Console.WriteLine("❌ Puoi rimuovere solo piante morte!");
            return;
        }

        Pianta rimossa = _piante[indice];
        _piante.RemoveAt(indice);
        Console.WriteLine($"🗑️ {rimossa.Tipo} rimossa dal giardino.");
    }

    public string GetDettaglioPianta(int indice)
    {
        if (indice < 0 || indice >= _piante.Count)
            return "❌ Indice non valido!";

        return _piante[indice].GetDettaglio();
    }

    public override string ToString()
    {
        String dettaglioGiardino = $"GIARDINO:  ";
        for (int i = 0; i < _piante.Count; i++)
        {
            dettaglioGiardino += $"[{i}] {_piante[i]} ";
        }
        return dettaglioGiardino;
    }

    public void VisualizzaStatistiche()
    {
        int vive = _piante.Count(p => p.FaseCrescita != FaseCrescita.Morta);
        int morte = _piante.Count(p => p.FaseCrescita == FaseCrescita.Morta);
        int mature = _piante.Count(p => p.FaseCrescita == FaseCrescita.Matura);
        int assetate = _piante.Count(p => p.LivelloAcqua < 4);

        Console.WriteLine($"\n📈 STATISTICHE DEL GIARDINO:");
        Console.WriteLine($"   Piante Totali: {_piante.Count}");
        Console.WriteLine($"   Piante Vive: {vive}");
        Console.WriteLine($"   Piante Morte: {morte}");
        Console.WriteLine($"   Piante Mature: {mature}");
        Console.WriteLine($"   Piante Assetate: 💧 {assetate}\n");
    }

    public void PassaGiorno()
    {
        // Polimorfismo: ogni pianta invecchia diversamente
        foreach (Pianta pianta in _piante)
        {
            pianta.Invecchia();
        }
    }
}