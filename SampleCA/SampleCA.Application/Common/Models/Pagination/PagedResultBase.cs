using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Common.Models.Pagination
{
    public abstract class PagedResultBase 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool FirstPage { get; set; }
        public bool LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public bool NextPage { get; set; }
        public bool PreviousPage { get; set; }

    }
}
