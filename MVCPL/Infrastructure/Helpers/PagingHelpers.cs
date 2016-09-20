using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MVCPL.Models;
using System.Web.Mvc.Ajax;

namespace MVCPL.Infrastructure.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString AjaxPageLinks(this AjaxHelper ajaxHelper, AjaxOptions ajaxOptions,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            return PageLinks(ajaxOptions, pageInfo, pageUrl: pageUrl);
        }

        public static MvcHtmlString AjaxPageLinks(this AjaxHelper ajaxHelper, AjaxOptions ajaxOptions,
            PageInfo pageInfo, string bookName, Func<int, string, string> searchUrl)
        {
            return PageLinks(ajaxOptions, pageInfo, bookName, searchUrl: searchUrl);
        }

        private static MvcHtmlString PageLinks(AjaxOptions ajaxOptions, PageInfo pageInfo, string bookName = "",
            Func<int, string> pageUrl = null, Func<int, string, string> searchUrl = null)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                if (ReferenceEquals(pageUrl, null))
                {
                    tag.MergeAttribute("href", searchUrl(i, bookName));
                }
                else
                {
                    tag.MergeAttribute("href", pageUrl(i));
                }         
                tag.InnerHtml = i.ToString();
                tag.AddCssClass("btn");
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("btn-primary disabled");
                    tag.MergeAttribute("id", "nonActive");
                }
                else
                    tag.AddCssClass("btn-default");
                tag.MergeAttributes((ajaxOptions ?? new AjaxOptions()).ToUnobtrusiveHtmlAttributes());
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}