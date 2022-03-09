namespace AppAPIs.Models
{
    public class CarType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
    }
}
