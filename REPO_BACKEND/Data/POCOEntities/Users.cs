using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backnc.Data.Entities
{
    public class Users
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public int? Dni { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Adress { get; set; }

        public bool Active { get; set; } = true;

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateCreation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDelete { get; set; }
    }
}
