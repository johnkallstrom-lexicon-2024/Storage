namespace Storagge.ViewModels
{
    public class CreateOrEditProductViewModel
    {
        [StringLength(50)]
        [Required]
        public string? Name { get; set; }

        [Range(0, double.MaxValue)]
        public int Price { get; set; }

        [DisplayName("Order date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime OrderDate { get; set; }

        [StringLength(20)]
        [Required]
        public string? Category { get; set; }

        [StringLength(5)]
        [Required]
        public string? Shelf { get; set; }

        [Range(0, double.MaxValue)]
        public int Count { get; set; }

        [StringLength(300)]
        [Required]
        public string? Description { get; set; }
    }
}
