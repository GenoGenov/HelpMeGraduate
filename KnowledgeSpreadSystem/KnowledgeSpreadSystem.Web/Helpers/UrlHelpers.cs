namespace KnowledgeSpreadSystem.Web.Helpers
{
    using System;
    using System.Web.Mvc;

    public static class UrlHelpers
    {
        public static string MakeActive(this UrlHelper urlHelper, string controllerName)
        {
            string result = "bigger label label-success";

            string controller = urlHelper.RequestContext.RouteData.Values["controller"].ToString();

            if (!controller.Equals(controllerName, StringComparison.OrdinalIgnoreCase))
            {
                result = null;
            }

            return result;
        }

        public static string MakeActive(this UrlHelper urlHelper, string areaName, string controllerName)
        {
            string result = "bigger label label-success";

            string controller = urlHelper.RequestContext.RouteData.Values["controller"].ToString();

            string area = urlHelper.RequestContext.RouteData.DataTokens.ContainsKey("area")
                              ? urlHelper.RequestContext.RouteData.DataTokens["area"].ToString()
                              : string.Empty;

            if (area.Equals(areaName, StringComparison.OrdinalIgnoreCase)
                && (string.IsNullOrEmpty(controllerName) || controller.Equals(controllerName)))
            {
                return result;
            }

            return null;
        }

        public static string GetImagePath(this UrlHelper urlHelper, string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".pdf":
                    return urlHelper.Content("~/Content/images/icons/PDF-icon.png");
                case ".doc":
                case ".docx":
                    return urlHelper.Content("~/Content/images/icons/Doc-File-icon.png");
                case ".png":
                case ".jpeg":
                    return urlHelper.Content("~/Content/images/icons/Graphics-icon.png");
                case ".zip":
                case ".rar":
                    return urlHelper.Content("~/Content/images/icons/Archive-icon.png");
            }

            return urlHelper.Content("~/Content/images/icons/file-icon.png");
        }
    }
}