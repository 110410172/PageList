using System;
using System.Collections.Generic;
using System.Linq;

namespace PageList
{
    public partial class Page
    {
        /// <summary>
        /// Generating list data of Paging 
        /// </summary>
        /// <typeparam name="TEntity">Types of data sources</typeparam>
        /// <typeparam name="TResult">Data type of output source</typeparam>
        /// <param name="source">Data source</param>
        /// <param name="PageSize">Page size</param>
        /// <param name="CurrentPg">Current page</param>
        /// <returns>PageList Class</returns>
        public static PageList<TEntity> Query<TEntity>(
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
            var pageList = new PageList<TEntity>()
            {
                currentPage = CurrentPage,
                recordCount = recordCount,
                pageCount = pageCount,
                rows = source.Skip(StartIndex).Take(PageSize).ToList()
            };
            return pageList;
        }

        /// <summary>
        /// Generating list data of Paging 
        /// </summary>
        /// <typeparam name="TEntity">Types of data sources</typeparam>
        /// <typeparam name="TResult">Data type of output source</typeparam>
        /// <param name="source">Data source</param>
        /// <param name="select">Select the data field of output source</param>
        /// <param name="PageSize">Page size</param>
        /// <param name="CurrentPg">Current page</param>
        /// <returns>PageList Class</returns>
        public static PageList<TResult> Query<TEntity, TResult>(
                IQueryable<TEntity> source,
                Func<TEntity, TResult> select,
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
            var pageList = new PageList<TResult>()
            {
                currentPage = CurrentPage,
                recordCount = recordCount,
                pageCount = pageCount,
                rows = source.Skip(StartIndex).Take(PageSize).AsEnumerable().Select(s => select(s)).ToList()
            };
            return pageList;
        }


    }
}
