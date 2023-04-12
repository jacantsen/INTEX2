using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumRecords { get; set; }
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //calculates how many pages we need to generate.
        public int TotalPages => (int)Math.Ceiling((double)TotalNumRecords / RecordsPerPage);

        
    }
}
