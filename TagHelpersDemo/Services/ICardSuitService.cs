using static TagHelpersDemo.TagHelpers.CardTagHelper;

namespace TagHelpersDemo.Services
{
    public interface ICardSuitService
    {
        (string colorClass, string characterCode) GetSuitAttributes(CardSuit suit);
    }
}
