namespace Services.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Franchise FranchiseName { get; set; }
    }
}
