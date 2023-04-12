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

            output.Content.AppendHtml(divTag.InnerHtml);
        }
    }

}
