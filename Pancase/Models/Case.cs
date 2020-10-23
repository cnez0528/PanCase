using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pancase.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string CaseName { get; set; }
        public string CaseSku { get; set; }
        public string Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
  