namespace AppAPIs.Dtos
{
    public class DriverDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Must Be Insert!!"), Display(Name = "First Name")]
        [Column(TypeName = "nvarchar(10)"), MaxLength(10)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Must Be Insert!!"), Display(Name = "Last Name")]
        [Column(TypeName = "nvarchar(10)"), MaxLength(10)]
        public string LastName { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"), Required(ErrorMessage = "Email number Must Insert")]
        public string Email { get; set; }
        [Required]
        [Column("Password", TypeName = "nvarchar(20)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public byte[] DriverLicence { get; set; }
        public byte[] NationalId { get; set; }
        public string CarNumber { get; set; }
        public int CarModel { get; set; }
        [ForeignKey("CarType")]
        public CarTypeDto CarTypes { get; set; }
        public int CarTypeId { get; set; }

        [Required(), Column(TypeName = "char(1)")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(20)"), MaxLength(20), Required(ErrorMessage = "Mobile number Must Insert")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }
        public virtual ICollection<Journey> Journey { get; set; }


    }
}
