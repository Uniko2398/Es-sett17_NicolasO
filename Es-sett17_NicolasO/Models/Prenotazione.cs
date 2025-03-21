namespace Es_sett17_NicolasO.Models
{
    public class Prenotazione
    {
        public int PrenotazioneId { get; set; }
        public int ClienteId { get; set; }
        public int CameraId { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public string Stato { get; set; } = "Attiva";

        public Cliente? Cliente { get; set; }
        public Camera? Camera { get; set; }
    }

}
