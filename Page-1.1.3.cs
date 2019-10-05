using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <param name="parameters">Expansion parameter</param>
        /// <returns>PageList Class</returns>
        public static PageList<TEntity> Query<TEntity>(
                IQueryable<TEntity> source, int PageSize,
                int CurrentPg, IDictionary<string, object> parameters)
        {
            var pageList = Query<TEntity>(source, PageSize, CurrentPg);
            pageList.parameters = parameters;
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
        /// <param name="parameters">Expansion parameter</param>
        /// <returns>PageList Class</returns>
        public static PageList<TResult> Query<TEntity, TResult>(
                IQueryable<TEntity> source,
                Func<TEntity, TResult> select, int PageSize,
                int CurrentPg, IDictionary<string, object> parameters)
        {
            var pageList = Query<TEntity, TResult>(source, select, PageSize, CurrentPg);
            pageList.parameters = parameters;
            return pageList;
        }


    }
}
