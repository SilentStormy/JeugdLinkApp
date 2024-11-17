using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Entities
{
    public class Mentor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specizialiton { get; set; }
        public bool Availability { get; set; }
    }
}
