using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GuestForm
{
    public class GuestComment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime Added { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }
    }
}