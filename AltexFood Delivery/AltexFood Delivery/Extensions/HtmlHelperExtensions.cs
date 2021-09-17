using System.Collections.Generic;
using System.Globalization;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AltexFood_Delivery.Api.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent FillProductTable(this IHtmlHelper html, IEnumerable<Product> products)
        {
            IHtmlContentBuilder result = new HtmlContentBuilder();
            foreach (var product in products)
            {
                var tr = new TagBuilder("tr");
                var tdName = new TagBuilder("td");
                tdName.InnerHtml.AppendHtml(html.ActionLink(product.Name, "GetProduct", "ProductMvc", new {id=product.Id}));

                var tdPrice = new TagBuilder("td");
                tdPrice.InnerHtml.Append(product.Price.ToString(CultureInfo.InvariantCulture));

                var tdCategory = new TagBuilder("td");
                tdCategory.InnerHtml.Append(product.Category.Name);

                var tdSupplier = new TagBuilder("td");
                tdSupplier.InnerHtml.Append(product.Supplier.Name);
                
                var tdEdit = new TagBuilder("td");
                tdEdit.InnerHtml.AppendHtml(html.ActionLink("Edit", "Edit", "ProductMvc", new {id=product.Id}));

                var tdDelete = new TagBuilder("td");
                var formPost = new TagBuilder("form");
                formPost.MergeAttribute("method", "post");
                formPost.InnerHtml.AppendHtml(html.TextBox("Delete", "Delete", new { type="submit", formaction=$"/mvc/Product?id={product.Id}" }));
                tdDelete.InnerHtml.AppendHtml(formPost);

                tr.InnerHtml.AppendHtml(tdName);
                tr.InnerHtml.AppendHtml(tdPrice);
                tr.InnerHtml.AppendHtml(tdCategory);
                tr.InnerHtml.AppendHtml(tdSupplier);
                tr.InnerHtml.AppendHtml(tdEdit);
                tr.InnerHtml.AppendHtml(tdDelete);
                result = result.AppendHtml(tr);
            }

            return result;
        }
    }
}
