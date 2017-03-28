using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace EthernetShop.Helpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString InputFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var builder = new TagBuilder("input");
            builder.AddCssClass("form-control");
            builder.MergeAttribute("name", name.ToString());
            builder.MergeAttribute("placeholder", name.ToString());
            if (metadata != null)
                builder.MergeAttribute("value", metadata.Model as string);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}