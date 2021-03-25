using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string day { get; set; }
        public string hourse { get; set; }
        public string job { get; set; }


    }
}
