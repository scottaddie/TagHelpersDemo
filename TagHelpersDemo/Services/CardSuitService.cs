using System;
using static TagHelpersDemo.TagHelpers.CardTagHelper;

namespace TagHelpersDemo.Services
{
    public class CardSuitService : ICardSuitService
    {
        public (string colorClass, string characterCode) GetSuitAttributes(CardSuit suit)
        {
            var suitColorClass = (suit == CardSuit.Diamond || suit == CardSuit.Heart) ? "red" : "black";
            var suitCharacterCode = string.Empty;

            switch (suit)
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
                default:
                    throw new IndexOutOfRangeException($"Invalid suit {suit} detected");
            }

            return (colorClass: suitColorClass, characterCode: suitCharacterCode);
        }
    }
}