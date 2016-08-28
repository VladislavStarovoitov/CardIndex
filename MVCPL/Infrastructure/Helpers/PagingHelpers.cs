using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MVCPL.Models;

namespace MVCPL.Infrastructure.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                tag.AddCssClass("btn");
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("btn-primary disabled");
                }
                else
                    tag.AddCssClass("btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ShowBook(this HtmlHelper html, Book book)
        {
            TagBuilder[] tagsP = new TagBuilder[2];
            for (int i = 0; i < 2; i++)
            {
                tagsP[i] = new TagBuilder("p");
            }
            tagsP[0].InnerHtml = book.Description;

            TagBuilder[] tagsDiv = new TagBuilder[4];
            for (int i = 0; i < 4; i++)
            {
                tagsDiv[i] = new TagBuilder("div");
            }
           
            TagBuilder tagH1 = new TagBuilder("h1");
            tagH1.InnerHtml = book.Name;

            var base64 = Convert.ToBase64String(book.Image);
            var imgSrc = String.Format($"data:image/gif;base64,{base64}");

            TagBuilder tagImg = new TagBuilder("img");
            tagImg.MergeAttribute("src", imgSrc);
            tagImg.AddCssClass("img-rounded");
            tagImg.AddCssClass("box-image");        

            tagsDiv[0].InnerHtml = tagH1.ToString() + tagImg.ToString() + tagsP[0].ToString();
            tagsDiv[1].AddCssClass("clear");

            TagBuilder tagA = new TagBuilder("a");
            tagA.InnerHtml = "Learn more »";
            tagA.AddCssClass("btn btn-default");
            tagA.MergeAttribute("href", "http://go.microsoft.com/fwlink/?LinkId=301865");

            tagsP[1].InnerHtml = tagA.ToString();

            tagsDiv[2].AddCssClass("col-lg-9");
            tagsDiv[2].AddCssClass("box");
            tagsDiv[2].InnerHtml = tagsDiv[0].ToString() + tagsDiv[1].ToString() + tagsP[1].ToString();

            return new MvcHtmlString(tagsDiv[2].ToString());
        }
    }
}