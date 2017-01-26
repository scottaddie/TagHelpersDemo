using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersDemo.TagHelpers
{
    [HtmlTargetElement("card", ParentTag = "hand", Attributes = nameof(Suit) + "," + nameof(Rank), TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CardTagHelper : TagHelper
    {
        public enum CardSuit
        {
            Club = 0,
            Diamond = 1,
            Heart = 2,
            Spade = 3
        }

        public enum CardRank
        {
            Ace = 0,
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,
            Jack = 10,
            Queen = 11,
            King = 12
        }

        public CardRank Rank { get; set; }

        public CardSuit Suit { get; set; }

        private (string colorClass, string characterCode) GetSuitAttributes()
        {
            var suitColorClass = (Suit == CardSuit.Diamond || Suit == CardSuit.Heart) ? "red" : "black";
            var suitCharacterCode = string.Empty;

            switch (Suit)
            {
                case CardSuit.Club:
                    suitCharacterCode = "&clubs;";
                    break;
                case CardSuit.Diamond:
                    suitCharacterCode = "&diams;";
                    break;
                case CardSuit.Heart:
                    suitCharacterCode = "&hearts;";
                    break;
                case CardSuit.Spade:
                    suitCharacterCode = "&spades;";
                    break;
            }

            return (colorClass: suitColorClass, characterCode: suitCharacterCode);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Fetch the context, so that we can get the player name to display the appropriate image
            var handContext = (HandContext)context.Items[typeof(HandTagHelper)];

            var suitAttributes = GetSuitAttributes();

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card col-md-3");

            // Try to import a CSHTML file here instead of hard-coding the HTML. See:
            // http://stackoverflow.com/questions/40438054/how-to-render-a-razor-template-inside-a-custom-taghelper-in-asp-net-core
            output.Content.SetHtmlContent(
                $"<img src=\"images/{handContext.Player}.png\" alt=\"avatar\" class=\"center-block\" /><div class=\"text-center\"><h2 class=\"{suitAttributes.colorClass}\"><strong>{suitAttributes.characterCode}</strong></h2><p>{Rank}</p></div>");
        }
    }
}