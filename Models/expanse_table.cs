
namespace expanseApigateway.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;

    public partial class expanse_table
    {
        [Required]
        public int id { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Amount { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
