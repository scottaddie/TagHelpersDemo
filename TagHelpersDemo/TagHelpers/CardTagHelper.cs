using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpersDemo.Services;
using TagHelpersDemo.ViewModels;

namespace TagHelpersDemo.TagHelpers
{
    [HtmlTargetElement(Constants.CARD_TAG_HELPER_ELEMENT_NAME, 
        ParentTag = Constants.HAND_TAG_HELPER_ELEMENT_NAME, 
        Attributes = nameof(Suit) + "," + nameof(Rank), 
        TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CardTagHelper : TagHelper
    {
        private readonly ICardSuitService _suitService;
        private readonly IHtmlHelper _html;

        public CardTagHelper(IHtmlHelper htmlHelper,
                             ICardSuitService suitService)
        {
            _html = htmlHelper;
            _suitService = suitService;
        }

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

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Contextualize the HTML helper
            (_html as IViewContextAware).Contextualize(ViewContext);

            // Fetch the context, so that we can get the player name to display the appropriate image
            var handContext = (HandContext)context.Items[typeof(HandTagHelper)];

            var suitAttributes = _suitService.GetSuitAttributes(Suit);

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card col-md-3");

            var model = new CardViewModel
            {
                PlayerName = handContext.Player,
                Rank = Rank.ToString(),
                SuitCharacterCode = suitAttributes.characterCode,
                SuitColorClass = suitAttributes.colorClass
            };
            var content = await _html.PartialAsync("~/Pages/Partials/_Card.cshtml", model);
            output.Content.SetHtmlContent(content);
        }
    }
}