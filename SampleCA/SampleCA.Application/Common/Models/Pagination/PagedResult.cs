using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SampleCA.Application.Common.Models.Pagination
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Result { get; set; }
        public PagedResult()
        {
            Result = new List<T>();
            
        }
        public static PagedResult<T> GetPaged<T>( IQueryable<T> query, int pageNumber, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.PageNumber = pageNumber;
            result.PageSize = pageSize;
            result.TotalRecords = query.Count();
            result.FirstPage = pageNumber == 1 ? true : false;
            result.LastPage = pageNumber == pageSize ? true : false;
            var totalPages = (double)result.TotalRecords / (double)pageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            result.NextPage = pageNumber >= 1 && pageNumber < roundedTotalPages
                ? true
                : false;
            result.PreviousPage = pageNumber - 1 >= 1 && pageNumber <= roundedTotalPages
                ? true
                : false;
            
            result.TotalPages = roundedTotalPages;
            result.Result = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return result;
        }
    }
}
