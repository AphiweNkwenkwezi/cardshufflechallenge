using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffleChallenge
{
    public class CardShufflingService : ICardShufflingService
    {
        private readonly ILogger<CardShufflingService> _log;
        private readonly IConfiguration _config;
        public CardShufflingService(ILogger<CardShufflingService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void Run()
        {
            string[] suits = _config.GetValue<string>("Suits").Split(',');
            string[] numbers = _config.GetValue<string>("Numbers").Split(',');

            _log.LogInformation("Getting deck of cards");
            var cards = GetCardDeck(suits, numbers);

            _log.LogInformation("Getting deck of cards");
            var shuffledCards = ShuffleCards(cards);

            foreach (string card in shuffledCards)
            {
                Console.WriteLine(card);
            }
            Console.ReadLine();
        }

        public static string[] ShuffleCards(string[] cards)
        {
            Random random = new Random();
            return cards.OrderBy(x => random.Next()).ToArray();
        }

        public static string[] GetCardDeck(string[] suits, string[] numbers)
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
