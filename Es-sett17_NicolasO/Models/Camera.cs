namespace Es_sett17_NicolasO.Models
{
    public class Camera
    {
        public int CameraId { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }

        public ICollection<Prenotazione>? Prenotazioni { get; set; }
    }

}
