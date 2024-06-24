namespace AgriCultureWeb.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
