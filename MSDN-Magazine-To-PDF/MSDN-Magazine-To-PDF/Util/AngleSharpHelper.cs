using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSDN_Magazine_To_PDF.Util
{
    public class AngleSharpHelper
    {
        public static async Task<IHtmlCollection<IElement>> CssSelectorParse(string cssSelector,string html)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(html));
            var cells = document.QuerySelectorAll(cssSelector);
            return cells;
        }
    }
}
