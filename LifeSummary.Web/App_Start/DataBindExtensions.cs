using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Whe;

namespace LifeSummary
{
    public static class DataBindExtensions
    {
        public static void LoadResult(this ListControl lb, PagedSearchResult<DataTable> result)
        {
            if (result.IsValid)
            {
                lb.DataSource = result.Records;
                lb.DataBind();
            }
        }
        public static void LoadResult<T>(this ListControl lb, PagedSearchResult<T> result)
        {
            if (result.IsValid)
            {
                lb.DataSource = result.Records;
                lb.DataBind();
            }
        }
    }
}