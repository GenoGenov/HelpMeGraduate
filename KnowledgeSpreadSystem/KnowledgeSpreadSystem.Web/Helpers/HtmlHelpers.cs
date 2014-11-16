namespace KnowledgeSpreadSystem.Web.Helpers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;

    public static class HtmlHelpers
    {
        public static MvcHtmlString Rater(
            this HtmlHelper helper,
            string name,
            string urlToAction)
        {
            var wrapper = new TagBuilder("div");
            wrapper.AddCssClass("rating-wrapper");
            wrapper.MergeAttribute("style", "display:inline-block");

            var rating = new TagBuilder("span");
            rating.MergeAttribute("data-url", urlToAction);
            rating.AddCssClass("star-rating");
            for (int i = 1; i <= 5; i++)
            {
                var star = new TagBuilder("input");
                star.MergeAttribute("type", "radio");
                star.MergeAttribute("name", name);
                star.MergeAttribute("value", i.ToString());

                var iTag = new TagBuilder("i");
                rating.InnerHtml += star.ToString() + iTag.ToString();
            }

            var successTag = new TagBuilder("span");
            successTag.MergeAttribute("style", "display:none");
            successTag.AddCssClass("error result label label-danger");

            var errorTag = new TagBuilder("span");
            errorTag.MergeAttribute("style", "display:none");
            errorTag.AddCssClass("success label label-success");
            wrapper.InnerHtml += rating.ToString()+ successTag.ToString() + errorTag.ToString();

            return MvcHtmlString.Create(wrapper.ToString());
        }

        public static MvcHtmlString Rating(this HtmlHelper helper, string name, string rating)
        {
            var ratingSpan = new TagBuilder("span");
            ratingSpan.MergeAttribute("data-rating", rating);
            ratingSpan.AddCssClass("star-rating");
            for (int i = 1; i <= 5; i++)
            {
                var star = new TagBuilder("input");
                star.MergeAttribute("type", "radio");
                star.MergeAttribute("name", name);
                star.MergeAttribute("value", i.ToString());

                var iTag = new TagBuilder("i");
                ratingSpan.InnerHtml += star.ToString() + iTag.ToString();
 
            }
            return MvcHtmlString.Create(ratingSpan.ToString());
        }
    }
}