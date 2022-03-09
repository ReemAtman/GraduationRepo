namespace AppAPIs.Models
{
    public class Citie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public int? StateId { get; set; } 
        public State State { get; set; }
        public virtual ICollection<Journey> Journey { get; set; }




    }
}
