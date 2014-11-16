namespace KnowledgeSpreadSystem.Web.Helpers
{
    using System.Web.Mvc;

    public static class HtmlHelpers
    {
        public static MvcHtmlString Rater(this HtmlHelper helper, object htmlAttributes, int stars = 5)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("star-rating");
            for (int i = 1; i <= stars; i++)
            {
                var star = new TagBuilder("input");
                star.MergeAttribute("type", "radio");
                star.MergeAttribute("name", "rating");
                star.MergeAttribute("value", i.ToString());

                var iTag = new TagBuilder("i");
                tagBuilder.InnerHtml += star.ToString() + iTag.ToString();
            }

            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        //public static MvcHtmlString Rating(this HtmlHelper helper, int stars = 5)
        //{
        //    helper.Rater(stars).
        //}
    }
}