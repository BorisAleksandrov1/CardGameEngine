static class War
{
    public static void StartGame()
    {
            List<string> deck = Card.Deck();
            Card.Shuffle(deck);
            string[] playerOneCards = PlayerOneDeck(deck);
            string[] playerTwoCards = PlayerTwoDeck(deck);
            int playerOnePoints = 0;
            int playerTwoPoints = 0;

            for(int i = 0; i < playerOneCards.Length; i++)
            {
                //player 1
                int playerOneCardValue = GetCardValue(playerOneCards, i);

                System.Console.WriteLine("Player one card: " + playerOneCards[i]); 
                Console.ReadKey(); System.Console.WriteLine();

                //player 2

                int playerTwoCardValue = GetCardValue(playerTwoCards, i);

                System.Console.WriteLine("Player two card: " + playerTwoCards[i]);
                Console.ReadKey(); System.Console.WriteLine();
                
                int sum = playerOneCardValue + playerTwoCardValue;

                if(playerTwoCardValue == playerOneCardValue)
                {
                    System.Console.WriteLine("It's a war!");
                    Console.ReadKey(); System.Console.WriteLine();
                    int playerOneWarValue = 0;
                    int playerTwoWarValue = 0;
                    string playerOneWarCards = string.Empty;
                    string playerTwoWarCards = string.Empty;
                    //if enough cards
                    for(int j = i + 1; j < 4; j++)
                    {
                        playerOneWarValue += GetCardValue(playerOneCards, j);
                        playerTwoWarValue += GetCardValue(playerTwoCards, j);

                        playerOneWarCards += $"{playerOneCards[j]}, ";
                        playerTwoWarCards += $"{playerTwoCards[j]}, ";
                    }

                    Console.WriteLine($"Player one war cards: {playerOneWarCards}");
                    Console.WriteLine($"Player two war cards: {playerTwoWarCards}");

                    int warPoints = playerOneWarValue + playerTwoWarValue;

                    if(playerOneWarValue > playerTwoWarValue)
                    {
                        playerOnePoints += warPoints;
                        System.Console.WriteLine("Player one gets the war cards!");
                    }
                    else if(playerOneWarValue < playerTwoWarValue)
                    {
                        playerTwoPoints += warPoints;
                        System.Console.WriteLine("Player two gets the war cards!");
                    }
                    else
                    {
                        System.Console.WriteLine("Draw!");
                    }
                    i += 3;
                }
                else if(playerOneCardValue > playerTwoCardValue)
                {
                    playerOnePoints += sum;
                    System.Console.WriteLine("Player one gets the cards!");
                }
                else
                {
                    playerTwoPoints += sum;
                    System.Console.WriteLine("Player two gets the cards!");
                }
                
                System.Console.WriteLine("Player one points: " + playerOnePoints);
                System.Console.WriteLine("Player two points: " + playerTwoPoints);
                System.Console.WriteLine();
            }
            
            if(playerOnePoints > playerTwoPoints)
            {
                Console.Clear();
                System.Console.WriteLine("Player one wins!");
            }
            else if(playerOnePoints < playerTwoPoints)
            {
                Console.Clear();
                System.Console.WriteLine("Player two wins!");
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("It's a draw!");
            }

            System.Console.WriteLine("Player one points: " + playerOnePoints);
            System.Console.WriteLine("Player two points: " + playerTwoPoints);
    }
    
            public static int GetCardValue(string[] cards, int index)
        {
            string playerTwoCard = cards[index];
            string cardChar = playerTwoCard[0].ToString();

            int cardValue = 0;
                if(!int.TryParse(cardChar, out cardValue))
                {
                    switch(cardChar)
                   {
                    case "J":
                        cardValue = 11;
                        break;
                        case "Q":
                        cardValue = 12;
                        break;
                        case "K":
                        cardValue = 13;
                        break;
                        case "A":
                        cardValue = 14;
                        break;
                   }
                }
            return cardValue;
        }
    static string[] PlayerOneDeck(List<string> deck)
        {
            List<string> result = new List<string>();
            for(int i = 0; i < deck.Count; i++)
            {
                if(i % 2 == 0)
                {
                    result.Add(deck[i]);
                }
            }
            return result.ToArray();
        }
    static string[] PlayerTwoDeck(List<string> deck)
        {
            List<string> result = new List<string>();
            for(int i = 0; i < deck.Count; i++)
            {
                if(i % 2 != 0)
                {
                    result.Add(deck[i]);
                }
            }
            return result.ToArray();
        }
}