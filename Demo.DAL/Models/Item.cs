using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Item:ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ItemStore> ItemStores { get; set; } =new HashSet<ItemStore>();
    }
}
