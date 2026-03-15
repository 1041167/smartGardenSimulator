/// <summary>
/// Interfaccia per le piante che producono frutti
/// </summary>
public interface IRaccoglibile
{
    /// <summary>
    /// Permette di raccogliere i frutti dalla pianta
    /// </summary>
    /// <returns>Messaggio di raccolta</returns>
    string Raccogli();
}