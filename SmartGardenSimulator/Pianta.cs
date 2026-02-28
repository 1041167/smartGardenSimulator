using System;
using System.Collections.Generic;

public abstract class Pianta
    {
        /* TODO */

        public virtual void VisualizzaStato() 
        {
            Console.WriteLine($"[Tipo di pianta: {this.GetType().Name} | Stato: {Stato} | Acqua: {Acqua}/10 | GiorniInSofferenza: {GiorniInSofferenza}]");
        }
    }