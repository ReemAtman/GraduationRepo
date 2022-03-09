namespace AppAPIs.Models
{
    public class Journey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StartCityId { get; set; }
        public int DistinationCityId { get; set; }
        public decimal Price { get; set; }
        public DateTime LeavingTime { get; set; }
        public DateTime Returing { get; set; }
        public string Comment { get; set; }
        public string Rules { get; set; }
        public string Frequency { get; set; }
        public int? UserId { get; set; }
        public virtual User Users { get; set; }
        public int? DriverId { get; set; }
        public virtual Driver Drivers { get; set; }
        public virtual Citie Cities { get; set; }

    }
}
