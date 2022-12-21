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
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="paginated"></param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPg"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static async Task<PageList<TResult>> QueryAsync<TEntity, TResult>(
              IQueryable<TEntity> source,
              Func<IQueryable<TEntity>, Task<List<TResult>>> paginated, int PageSize,
              int CurrentPg, IDictionary<string, object> parameters = null)
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
                rows = await paginated(source.Skip(StartIndex).Take(PageSize))
            };
            pageList.parameters = parameters;
            return pageList;
        }


    }
}
