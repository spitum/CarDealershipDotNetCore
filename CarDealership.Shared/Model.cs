using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Shared
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
    }
}
