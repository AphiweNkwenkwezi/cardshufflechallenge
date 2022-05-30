using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffleChallenge
{
    public class CardShufflingService : ICardShufflingService
    {
        private readonly IConfiguration _config;
        public CardShufflingService(IConfiguration config)
        {
            _config = config;
        }

        public void Run()
        {
            string[] suits = _config.GetValue<string>("Suits").Split(',');
            string[] numbers = _config.GetValue<string>("Numbers").Split(',');

            Log.Information("Getting deck of cards");
            var cards = GetCardDeck(suits, numbers);
            
            Log.Information("Starting - Shuffling deck of cards");
            var shuffledCards = ShuffleCards(cards);

            foreach (string card in shuffledCards)
            {
                Console.WriteLine(card);
            }

            Log.Information("Complete - Shuffling deck of cards");
            Console.ReadLine();
        }

        public string[] ShuffleCards(string[] cards)
        {
            Random random = new Random();
            return cards.OrderBy(x => random.Next()).ToArray();
        }

        public string[] GetCardDeck(string[] suits, string[] numbers)
        {
            List<string> cards = new List<string>();
            foreach (string suit in suits)
            {
                foreach (string n in numbers)
                {
                    cards.Add($"{n} of {suit}");
                }
            }
            return cards.ToArray();
        }
    }
}
