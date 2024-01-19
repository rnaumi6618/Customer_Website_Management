/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Assignment3Rafia.TagHelpers
{
    [HtmlTargetElement("last-action-message")]
    public class LastActionMessageTagHelper : TagHelper
    {
        // Defines a custom tag helper for displaying last action messages
        [ViewContext()]
        [HtmlAttributeNotBound()]
        public ViewContext ViewContext { get; set; }
        /*public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Checks if TempData contains a message for the last action

            if (ViewContext.TempData.TryGetValue("LastActionMessage", out var message))
            {
                // Sets the tag name and attributes for the output HTML
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "alert alert-success alert-dismissible fade show");
                output.Attributes.SetAttribute("role", "alert");
                output.Content.SetHtmlContent(message.ToString());
                // Checks for an UndoCustomerId in TempData for undo functionality
                if (ViewContext.TempData.TryGetValue("UndoCustomerId", out var undoCustomerId))
                {
                    // Creates an undo URL and appends it to the output content
                    string undoUrl = $"/invoiceManage/UndoDeleteCustomer/{undoCustomerId}";
                    output.Content.AppendHtml($"<a href='{undoUrl}' class='alert-link'>Undo</a>");
                }

                // Adds a close button to the alert message
                output.Content.AppendHtml("<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>");
            }
            else
            {
                // Suppresses the output if there is no message in TempData
                output.SuppressOutput();
            }
        }*/

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext.TempData.ContainsKey("LastActionMessage"))
            {
                
                // first build a child button:
                var childBtn = new TagBuilder("button");
                childBtn.Attributes.Add("class", "btn-close");
                childBtn.Attributes.Add("data-bs-dismiss", "alert");
                childBtn.Attributes.Add("aria-label", "close");

                // And a child span:
                var childSpan = new TagBuilder("span");
                childSpan.InnerHtml.AppendHtml(ViewContext.TempData["LastActionMessage"].ToString());

                // set ouptput content to be a div:
                output.TagName = "div";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                output.Attributes.Add("role", "alert");


                // Checks for an UndoCustomerId in TempData for undo functionality
                if (ViewContext.TempData.TryGetValue("UndoCustomerId", out var undoCustomerId))
                {
                    // Creates an undo URL and appends it to the output content
                    string undoUrl = $"/invoiceManage/UndoDeleteCustomer/{undoCustomerId}";
                    output.Content.AppendHtml($"<a href='{undoUrl}' class='alert-link'>Undo</a>    ");
                }
                // append btn & span to div:
                output.Content.AppendHtml(childBtn);
                output.Content.AppendHtml(childSpan);
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}
