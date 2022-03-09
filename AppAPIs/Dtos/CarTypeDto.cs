namespace AppAPIs.Dtos
{
    public class CarTypeDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
    }
}
