
namespace expanseApigateway.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class expanse_limit
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Expanse_limit1 { get; set; }

     
    }
}
