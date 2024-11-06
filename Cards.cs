static class Card 
{
        public static List<string> Deck()
        {
            List<string> deck = new List<string>();
            string[] cards = "1 2 3 4 5 6 7 8 9 10 J Q K A".Split(' ').ToArray();
            char[] suits = {'\u2665', '\u2666', '\u2660', '\u2663'};
            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    string result = cards[i] + suits[j];
                    deck.Add(result);
                }
            }
            return deck;
        }
        public static void Shuffle(List<string> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
}