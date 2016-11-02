using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Alvo.Common.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            var scripts = htmlHelper.ViewContext.HttpContext.Items["Scripts"] as IList<string>;
            string scriptsAtual = String.Empty;
            if (scripts != null)
            {
                var builder = new StringBuilder();
                foreach (var script in scripts)
                {
                    if (!script.Equals(scriptsAtual))
                    {
                        scriptsAtual = script;
                        builder.AppendLine(script);
                    }
                    
                }
                return new MvcHtmlString(builder.ToString());
            }
            return null;
        }
    }
}