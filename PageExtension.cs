using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PageList
{
    public static partial class PageExtension
    {
        public static PageList<TResult> ToPageList<TEntity, TResult>(
            this PageIQueryable<TEntity> queryable
            , Func<IQueryable<TEntity>, IQueryable<TResult>> select = null
            , IDictionary<string, object> parameters = null
        )
        {
            return new PageList<TResult>
            {
                currentPage = queryable.currentPage,
                pageCount = queryable.pageCount,
                recordCount = queryable.recordCount,
                rows = select(queryable.rows).ToList(),
                parameters = parameters,
            };
        }
        public static PageList<TEntity> ToPageList<TEntity>(
            this PageIQueryable<TEntity> queryable
            , IDictionary<string, object> parameters = null
        )
        {
            return new PageList<TEntity>
            {
                currentPage = queryable.currentPage,
                pageCount = queryable.pageCount,
                recordCount = queryable.recordCount,
                rows = queryable.rows.ToList(),
                parameters = parameters,
            };
        }

    }
}
