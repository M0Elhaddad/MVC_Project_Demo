using Demo.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Demo.PL.ViewModels
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code is Required")]
        [MaxLength(50, ErrorMessage = "Maxth Length of name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of name is 5 Chars")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Maxth Length of name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of name is 5 Chars")]
        public string Name { get; set; }
        [Display(Name = "Date of Creation")]
        public DateTime DateOfCreation { get; set; }

        public ICollection<ItemStore> StoreItems { get; set; } = new HashSet<ItemStore>();
    }
}
