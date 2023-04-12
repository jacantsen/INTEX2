using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using INTEX2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace INTEX2.Infrastructure
{
  
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        // Dynamically make the page links for us.
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PaginationTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }

        // Limit the maximum number of pages displayed
        public int PageMax { get; set; } = 5;

        // Styling
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Adding a Next and Previous Button
        public string PrevPageText { get; set; } = "Previous";
        public string NextPageText { get; set; } = "Next";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            var startPage = 1;
            var endPage = PageModel.TotalPages;



            // Limit the number of pages displayed
            if (PageModel.TotalPages > PageMax)
            {
                var middle = PageMax / 2;

                if (PageModel.CurrentPage > middle)
                {
                    startPage = PageModel.CurrentPage - middle;
                }

                if (PageModel.CurrentPage + middle > PageModel.TotalPages)
                {
                    startPage = PageModel.TotalPages - PageMax + 1;
                }

                endPage = startPage + PageMax - 1;
            }

            var divTag = new TagBuilder("div");

            // Add Previous button if we're not on the first page
            if (PageModel.CurrentPage > 1)
            {
                var prevTag = new TagBuilder("a");
                prevTag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = PageModel.CurrentPage - 1 });
                prevTag.InnerHtml.AppendHtml(PrevPageText);
                divTag.InnerHtml.AppendHtml(prevTag);
            }

            for (int i = startPage; i <= endPage; i++)
            {
                var aTag = new TagBuilder("a");

                aTag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });



                if (PageClassesEnabled)
                {
                    aTag.AddCssClass(PageClass);

                    if (i == PageModel.CurrentPage)
                    {
                        aTag.AddCssClass(PageClassSelected);
                    }
                    else
                    {
                        aTag.AddCssClass(PageClassNormal);
                    }
                }

                aTag.InnerHtml.Append(i.ToString());

                divTag.InnerHtml.AppendHtml(aTag);
            }

            // Add "Next" button
            if (PageModel.CurrentPage < PageModel.TotalPages)
            {
                var nextTag = new TagBuilder("a");
                nextTag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = PageModel.CurrentPage + 1 });
                nextTag.InnerHtml.Append(NextPageText);
                divTag.InnerHtml.AppendHtml(nextTag);
            }

            output.Content.AppendHtml(divTag.InnerHtml);
        }
    }

}
