using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models.ViewModels
{
    public class MummiesViewModel
    {
        public IQueryable<Mummy>Mummies { get; set; }
        public PageInfo PageInfo { get; set; }
        public SearchSpecifications Search { get; set; }
        public Char Check { get; set; }
    }
}
