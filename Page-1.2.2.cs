using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageList
{
    public partial class Page
    {
        /// <summary>
        /// Generating list data of Paging 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPg"></param>
        /// <returns></returns>
        public static PageIQueryable<TEntity> QueryAsync<TEntity>(
              IQueryable<TEntity> source, 
              int PageSize,
              int CurrentPg)
        {
            if (PageSize == 0)
                throw new PageListException("Invalid parameter");

            int CurrentPage = (CurrentPg <= 0) ? 1 : CurrentPg;
            var recordCount = source.Count();
            var pageCount = (recordCount + PageSize - 1) / PageSize;
            if (pageCount <= 0) pageCount = 1;
            if (pageCount < CurrentPage) CurrentPage = pageCount;
            int StartIndex = (CurrentPage - 1) * PageSize;
            var pageList = new PageIQueryable<TEntity>()
            {
                currentPage = CurrentPage,
                recordCount = recordCount,
                pageCount = pageCount,
                rows = source.Skip(StartIndex).Take(PageSize)
            };
            return pageList;
        }


    }
}
