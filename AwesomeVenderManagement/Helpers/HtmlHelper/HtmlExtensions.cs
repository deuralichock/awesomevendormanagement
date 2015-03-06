using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeVenderManagement.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString RequiredHint(this HtmlHelper helper, string additionalText = null) 
         { 
             // Create tag builder 
             var builder = new TagBuilder("span"); 
             builder.AddCssClass("required"); 
             var innerText = "*"; 
             //add additional text if specified 
             if (!String.IsNullOrEmpty(additionalText)) 
                 innerText += " " + additionalText; 
             builder.SetInnerText(innerText); 
             // Render tag 
             return MvcHtmlString.Create(builder.ToString()); 
         } 

    }
}