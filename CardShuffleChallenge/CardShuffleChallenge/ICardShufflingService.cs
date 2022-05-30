namespace CardShuffleChallenge
{
    public interface ICardShufflingService
    {
        void Run();
        string[] ShuffleCards(string[] cards);
        string[] GetCardDeck(string[] suits, string[] numbers);
    }
}