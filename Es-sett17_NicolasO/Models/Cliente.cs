namespace Es_sett17_NicolasO.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public ICollection<Prenotazione>? Prenotazioni { get; set; }
    }

}
