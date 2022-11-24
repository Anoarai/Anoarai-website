using System.ComponentModel.DataAnnotations;

namespace Website.Models.ComponentModels
{
    public class ComponentPortfolioBlock
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? ShowcaseIcon { get; set; }

        //[DataType(DataType.Upload)]
        //public IFormFile Icon { get; set; }

        [Required]
        public string? LongDescription { get; set; }

        [Required]
        public string? WebAddress { get; set; }
    }
}
