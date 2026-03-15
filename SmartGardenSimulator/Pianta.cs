using System;
using System.Collections.Generic;

/// <summary>
/// Classe astratta che rappresenta una pianta generica
/// Implementa i pilastri OOP: Incapsulamento, Astrazione, Ereditarietà
/// </summary>
public abstract class Pianta : IIrrigabile
{
    private string _tipo;
    private int _livelloAcqua;
    private int _giorni;
    private int _giorniInSofferenza;
    private FaseCrescita _faseCrescita;
    protected int _sogliaSete;
    protected int _consumoAcquaGiornaliero;
    protected int _giorniPerGermoglio;
    protected int _giorniPerMatura;

    public string Tipo
    {
        get { return _tipo; }
        protected set { _tipo = value; }
    }

    public int LivelloAcqua
    {
        get { return _livelloAcqua; }
        private set { _livelloAcqua = Math.Max(0, Math.Min(10, value)); }
    }

    public int Giorni
    {
        get { return _giorni; }
        private set { _giorni = Math.Max(0, value); }
    }

    public int GiorniInSofferenza
    {
        get { return _giorniInSofferenza; }
        private set { _giorniInSofferenza = Math.Max(0, value); }
    }

    public FaseCrescita FaseCrescita
    {
        get { return _faseCrescita; }
        protected set { _faseCrescita = value; }
    }

    // ===== COSTRUTTORE =====
    protected Pianta(string tipo)
    {
        _tipo = tipo;
        _livelloAcqua = 5; // Livello iniziale
        _giorni = 0;
        _giorniInSofferenza = 0;
        _faseCrescita = FaseCrescita.Seme;
    }

    // ===== METODO RiceviAcqua (Interfaccia IIrrigabile) =====
    public virtual void RiceviAcqua(int quantita)
    {
        if (quantita < 0)
            throw new ArgumentException("La quantità di acqua non può essere negativa");

        LivelloAcqua += quantita;
        GiorniInSofferenza = 0; // Resetta il contatore di sofferenza
        Console.WriteLine($"✨ {_tipo} ha ricevuto {quantita} unità di acqua. Livello: {LivelloAcqua}/10");
    }

    // ===== METODO ASTRATTO Invecchia =====
    /// <summary>
    /// Metodo astratto che simula l'invecchiamento della pianta
    /// Sarà implementato diversamente da ogni tipo di pianta
    /// </summary>
    public abstract void Invecchia();

    // ===== METODO PROTETTO PER AGGIORNARE LA FASE DI CRESCITA =====
    protected void Aggiorna()
    {
        if (_faseCrescita == FaseCrescita.Morta)
            return;

        // Consuma acqua
        LivelloAcqua -= _consumoAcquaGiornaliero;

        // Controlla se la pianta è assetata
        if (LivelloAcqua < _sogliaSete)
        {
            GiorniInSofferenza++;
            Console.WriteLine($"💧 {_tipo} è assetata! Giorni in sofferenza: {GiorniInSofferenza}");

            // Se è assetata per più di 7 giorni, muore
            if (GiorniInSofferenza >= 7)
            {
                _faseCrescita = FaseCrescita.Morta;
                Console.WriteLine($"💀 {_tipo} è morta per disidratazione!");
                return;
            }
        }
        else
        {
            // Se ha acqua, cresce
            GiorniInSofferenza = 0;
            _giorni++;
            Cresci();
        }
    }

    // ===== METODO PROTETTO PER GESTIRE LA CRESCITA =====
    protected void Cresci()
    {
        switch (_faseCrescita)
        {
            case FaseCrescita.Seme:
                if (_giorni >= _giorniPerGermoglio)
                {
                    _faseCrescita = FaseCrescita.Germoglio;
                    Console.WriteLine($"🌱 {_tipo} è diventato germoglio!");
                    _giorni = 0;
                }
                break;

            case FaseCrescita.Germoglio:
                if (_giorni >= _giorniPerMatura)
                {
                    _faseCrescita = FaseCrescita.Matura;
                    Console.WriteLine($"🌿 {_tipo} è maturo!");
                    _giorni = 0;
                }
                break;

            case FaseCrescita.Matura:
                // Rimane in stato maturo
                break;
        }
    }

    // ===== METODO PER OTTENERE LA RAPPRESENTAZIONE =====
    public string GetDettaglio()
    {
        string emoji = GetEmoji();
        return $"{emoji} Tipo: {_tipo} | Acqua: {LivelloAcqua}/10 | Sofferenza: {GiorniInSofferenza}";
    }

    public override string ToString()
    {
        return GetEmoji();
    }

    // ===== METODO PROTETTO PER OTTENERE L'EMOJI =====
    protected virtual string GetEmoji()
    {
        return _faseCrescita switch
        {
            FaseCrescita.Seme => "🌱",
            FaseCrescita.Germoglio => "🌿",
            FaseCrescita.Matura => "🪴",
            FaseCrescita.Morta => "💀",
            _ => "❓"
        };
    }
}