namespace Opiskelijaportaali.Models
{
    //Tapahtuma
    public class Event
    {
        public int Id { get; set; }                    // Primary key
        public string Title { get; set; } = string.Empty;       // Tapahtuman otsikko, ei null
        public DateTime EventDateTime { get; set; }  // Päivämäärä + kellonaika
        public string Description { get; set; } = string.Empty;  // Kuvaus, ei null
    }
}
