using System;
using System.Collections.Generic;
using System.Text;

namespace PageList
{
    /// <summary>
    /// Data model of the paging
    /// </summary>
    /// <typeparam name="TEntity">list data of Paging</typeparam>
    public partial class PageList<TEntity>
    {
        public int currentPage { get; set; }
        public int recordCount { get; set; }
        public int pageCount { get; set; }
        public List<TEntity> rows { get; set; }
    }
}
