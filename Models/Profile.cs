namespace Opiskelijaportaali.Models
{
    //Profiili
    //Salasana täytyy vielä lisätä!
    public class Profile
    {
        public int Id { get; set; }                   // Primary key
        public string FName { get; set; } = string.Empty;  // Etunimi, ei null
        public string LName { get; set; } = string.Empty;  // Sukunimi, ei null
        public string Email { get; set; } = string.Empty;  // Sähköposti, ei null
        public DateTime? Bdate { get; set; }             // Syntymäaika, nullable jos ei anneta
        public string Phone { get; set; } = string.Empty;  // Puhelin, ei null
    }
}
