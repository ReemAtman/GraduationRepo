namespace AppAPIs.Models
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public Countrie Country { get; set; }
        public ICollection<Citie> Cities { get; set; }

    }
}
