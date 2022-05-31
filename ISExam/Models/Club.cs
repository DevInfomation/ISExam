using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISExam.Models
{
    public class Club
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Owner { get; set; }
        public string Country { get; set; }
    }
}
