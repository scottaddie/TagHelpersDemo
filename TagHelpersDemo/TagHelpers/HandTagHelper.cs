using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersDemo.TagHelpers
{
    public class HandContext
    {
        public string Player { get; set; }
    }

    //[HtmlTargetElement("hand", Attributes = nameof(NumCards) + "," + nameof(Player), TagStructure = TagStructure.NormalOrSelfClosing)]
    [HtmlTargetElement("hand", Attributes = nameof(Player), TagStructure = TagStructure.NormalOrSelfClosing)]
    [RestrictChildren("card")]
    public class HandTagHelper : TagHelper
    {
        //public int NumCards { get; set; }

        public string Player { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Assign the lowercase version of the player's name to the appropriate context property
            var handContext = new HandContext()
            {
                Player = Player.Trim().ToLower()
            };
            context.Items.Add(typeof(HandTagHelper), handContext);

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "row");
        }
    }
}
