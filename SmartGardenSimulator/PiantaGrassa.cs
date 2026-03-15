/// <summary>
/// Classe che rappresenta una pianta grassa
/// Ha bassissimi consumi di acqua
/// </summary>
public class PiantaGrassa : Pianta
{
    public PiantaGrassa() : base("Pianta Grassa")
    {
        _sogliaSete = 2;
        _consumoAcquaGiornaliero = 1; // Consuma poco
        _giorniPerGermoglio = 5;
        _giorniPerMatura = 8;
    }

    public override void Invecchia()
    {
        Aggiorna();
    }

    protected override string GetEmoji()
    {
        return FaseCrescita switch
        {
            FaseCrescita.Seme => "🌱",
            FaseCrescita.Germoglio => "🌵",
            FaseCrescita.Matura => "🏜️",
            FaseCrescita.Morta => "💀",
            _ => "❓"
        };
    }
}