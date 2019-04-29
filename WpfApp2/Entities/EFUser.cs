using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Entities
{
    [Table("tblBinding")]
    public class EFUser
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(maximumLength: 75)]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required, StringLength(maximumLength: 150)]
        public string ImageUrl { get; set; }

        public static implicit operator EFUser(User u)
        {
            return new EFUser
            {
                Id = u.Id,
                Name = u.Name,
                Birthday = u.Birthday,
                ImageUrl = u.ImageUrl
            };
        }
    }
}
