using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class ItemStore :ModelBase
    {
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Quantity is required!")]
        [Range(0,100)]
        public int Quantity { get; set; }

        public int Balance { get; set; } = 0;

        public Item Item { get; set; }
        public Store Store { get; set; }
    }
}
