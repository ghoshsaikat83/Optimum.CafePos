using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimum.CafePos.Models
{
    public class ItemHead
    {
        public string storeId { get; set; }
        public string dishHeadCode { get; set; }
        public string dishHeadName { get; set; }
        public string imgName { get; set; }
        public bool IsSelected { get; set; }
    }
}
