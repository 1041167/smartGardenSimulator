using System;

/// <summary>
/// Interfaccia per le piante che possono ricevere acqua
/// </summary>
public interface IIrrigabile
{
    /// <summary>
    /// Permette alla pianta di ricevere acqua
    /// </summary>
    /// <param name="quantita">Quantità di acqua da fornire</param>
    void RiceviAcqua(int quantita);
}