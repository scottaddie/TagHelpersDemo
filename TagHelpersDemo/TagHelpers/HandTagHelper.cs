using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersDemo.TagHelpers
{
    public class HandContext
    {
        public string Player { get; set; }
    }

    [HtmlTargetElement(Constants.HAND_TAG_HELPER_ELEMENT_NAME, Attributes = nameof(Player), TagStructure = TagStructure.NormalOrSelfClosing)]
    [RestrictChildren(Constants.CARD_TAG_HELPER_ELEMENT_NAME)]
    public class HandTagHelper : TagHelper
    {
        public string Player { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Assign the lowercase version of the player's name to the appropriate context property
            var handContext = new HandContext
            {
                Player = Player.Trim().ToLower()
            };
            context.Items.Add(typeof(HandTagHelper), handContext);

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "row");
        }
    }
}
