using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Shared
{
    public class Make
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Model> Models { get; set; }

    }
}
