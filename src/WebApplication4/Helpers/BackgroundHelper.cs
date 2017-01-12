using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace WebApplication4.Helpers
{
    public static class BackgroundHelper
    {
        public static HtmlString SetBackgroundImage(string url)
        {
            string code = @"body {
                                background - image: linear - gradient(to bottom, rgba(255, 255, 255, 0.85) 0 %, rgba(255, 255, 255, 0.85) 100 %), url('" + url + @"');
                                background - repeat: no - repeat;
                                background - attachment: fixed;
                                background - position: center;
                            }";
            return new HtmlString(code);
        }

        public static HtmlString MakeNote(string note)
        {
            string code = @"<div class='note'
                    style='border: 1px solid red; width: 90%; padding: 5px;'>
                    <p>
                       " + note + @" 
                    </p>
                    </div>";
            return new HtmlString(code);
        }
    }
}
