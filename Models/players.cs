using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_players.Models
{
    public class players{

        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string nationality { get; set; }

        public string position { get; set; }

        public string image { get; set; }

    }
}
