/// <summary>
/// Classe che rappresenta una rosa (fiore)
/// </summary>
public class Rosa : Pianta
{
    public Rosa() : base("Rosa")
    {
        _sogliaSete = 4;
        _consumoAcquaGiornaliero = 1; // Consuma 1/10 di acqua al giorno
        _giorniPerGermoglio = 3;
        _giorniPerMatura = 5;
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
            FaseCrescita.Germoglio => "🌿",
            FaseCrescita.Matura => "🌹",
            FaseCrescita.Morta => "💀",
            _ => "❓"
        };
    }
}