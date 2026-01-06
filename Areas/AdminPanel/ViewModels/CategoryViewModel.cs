using System.ComponentModel.DataAnnotations;

namespace TimeZone.Areas.AdminPanel.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
