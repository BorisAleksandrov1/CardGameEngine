static class Blackjack
{
    public static void StartGame()
    {
        List<string> deck = Card.Deck();
        Card.Shuffle(deck);
        
        int playerIndex = 0;
        int dealerIndex = deck.Count() - 1;

        List<string> playerDeck = new(){deck[playerIndex], deck[playerIndex + 1]};
        List<string> dealerDeck = new(){deck[dealerIndex], deck[dealerIndex - 1]};

        int playerScore = 0;
        int dealerScore = 0;
        for (int i = 0; i < playerDeck.Count; i++)
        {
            playerScore += GetCardValue(playerDeck, i);
            dealerScore += GetCardValue(dealerDeck, i);
        }

        playerIndex += 2;
        dealerIndex -= 2;

        bool isPlayerReady = false;
        bool isDealerReady= false;

        while (playerScore < 21 && dealerScore < 21 && !isPlayerReady || !isDealerReady) 
        {
            System.Console.Write("PlayerCards are ");
            PrintDeck(playerDeck);
            System.Console.Write("Dealer Cards are ");
            PrintDeck(dealerDeck);
            
            System.Console.WriteLine("Do you want to hit or stand?");
            string playerMove = Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("Your move is " + playerMove);

            switch(playerMove)
            {
                case "hit":
                    if(!isPlayerReady)
                    {
                    playerDeck.Add(deck[playerIndex]);
                    PrintDeck(playerDeck);
                    System.Console.WriteLine();

                    playerScore += GetCardValue(playerDeck, playerIndex);
                    playerIndex++;
                    }
                    break;
                case "stand":
                    isPlayerReady = true;
                    break;
                default:
                    System.Console.WriteLine("Invalid command. Please try again.");
                    continue;
            }

            string dealerMove = DealerMove(dealerScore);
            System.Console.WriteLine("Dealer's move: " + dealerMove);
            System.Console.WriteLine();
            if(dealerMove == "stand")
            {
                isDealerReady = true;
            }
            else
            {
                if(!isDealerReady)
                {
                dealerDeck.Add(deck[dealerIndex]);
                PrintDeck(dealerDeck);

                dealerScore += GetCardValue(dealerDeck, playerIndex - 1);
                dealerIndex--;
                }
            }

            if(playerScore > 21)
            {
                System.Console.WriteLine("Player busted. Dealer wins.");
                return;
            }
            else if(dealerScore > 21)
            {
                System.Console.WriteLine("Dealer busted. Player wins.");
                return;
            }
            else if(playerScore == dealerScore)
            {
             System.Console.WriteLine("Draw!");
             return;
            }
            else if(playerScore == 21)
            {
             System.Console.WriteLine("Player wins. You have the best hand.");
             return;
            }
            else if(dealerScore == 21)
            {
             System.Console.WriteLine("Dealer wins. Dealer had the best hand.");
             return;
            }
            
        }

        if(playerScore > dealerScore)
        {
        System.Console.WriteLine($"Player wins. The difference {Math.Abs(playerScore - dealerScore)} points");
        }
        else
        {
        System.Console.WriteLine($"Dealer wins. The difference {Math.Abs(playerScore - dealerScore)} points");
        }


    }
    static string DealerMove(int dealerScore)
    {
        Random random = new Random();
        int chance = random.Next(0, 2);
        if(dealerScore > 17)
        {
            return "stand";
        }
        else if(dealerScore < 12)
        {
            return "hit";
        }
        else
        {
            if(chance == 0)
            {
                return "stand";
            }
            {
                return "hit";
            }
        }
    }

    static void PrintDeck(List<string> deck)
    {
        System.Console.WriteLine(String.Join(",", deck));
    }

    static int GetCardValue(List<string> cards, int index)
        {
            string playerCard = cards[index];
            string cardChar = playerCard[0].ToString();

            int cardValue = 0;
                if(!int.TryParse(cardChar, out cardValue))
                {
                    switch(cardChar)
                   {
                        case "J":
                        cardValue = 10;
                        break;
                        case "Q":
                        cardValue = 10;
                        break;
                        case "K":
                        cardValue = 10;
                        break;
                        case "A":
                        cardValue = 1;
                        break;
                   }
                }
            return cardValue;
        }
}