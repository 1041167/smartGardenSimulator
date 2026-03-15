/// <summary>
/// Classe che rappresenta un pomodoro (ortaggio)
/// Implementa IRaccoglibile per raccogliere i frutti
/// </summary>
public class Pomodoro : Pianta, IRaccoglibile
{
    private bool _fruttiRaccolti;

    public Pomodoro() : base("Pomodoro")
    {
        _sogliaSete = 5;
        _consumoAcquaGiornaliero = 2; // Consuma 2/10 di acqua al giorno
        _giorniPerGermoglio = 4;
        _giorniPerMatura = 6;
        _fruttiRaccolti = false;
    }

    public override void Invecchia()
    {
        Aggiorna();
    }

    public string Raccogli()
    {
        if (FaseCrescita != FaseCrescita.Matura)
            return "❌ Non ci sono frutti da raccogliere!";

        if (_fruttiRaccolti)
            return "❌ I frutti sono già stati raccolti!";

        _fruttiRaccolti = true;
        return "🍅 Hai raccolto un delizioso pomodoro!";
    }

    protected override string GetEmoji()
    {
        return FaseCrescita switch
        {
            FaseCrescita.Seme => "🌱",
            FaseCrescita.Germoglio => "🥬",
            FaseCrescita.Matura => _fruttiRaccolti ? "🥬" : "🍅",
            FaseCrescita.Morta => "💀",
            _ => "❓"
        };
    }
}