using Demo.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Maxth Length of name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of name is 5 Chars")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(50, ErrorMessage = "Maxth Length of name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of name is 5 Chars")]
        public string Description { get; set; }
        public ICollection<ItemStore> ItemStores { get; set; } = new HashSet<ItemStore>();
    }
}
