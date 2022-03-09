namespace AppAPIs.Models
{
    public class Countrie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string? SortName { get; set; }
        public int? PhoneCode { get; set; }
        public ICollection<State> States { get; set; }
    }
}
