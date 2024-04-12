namespace Storagge.ViewModels
{
    public class DeleteProductViewModel
    {
        [Required]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Category { get; set; }
    }
}
