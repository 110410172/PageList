using System;
using System.Collections.Generic;
using System.Text;

namespace PageList
{
    public partial class PageList<TEntity>
    {
        /// <summary>
        /// Other Extensible Parameters
        /// </summary>
        public IDictionary<string, object> parameters { get; set; }
    }
}
