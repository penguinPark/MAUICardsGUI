using Microsoft.UI.Xaml.Controls;
using RaceTo21;
using static System.Formats.Asn1.AsnWriter;

namespace MAUICardsGUI;
public partial class MainPage : ContentPage
{
    // need to have draw and stay work
    // need to start new game if people want to
    // scoring and end of game should work
    int numOfPlayers; // number of players in current game
    List<Player> players = new List<Player>(); // list of objects containing player data
    Deck deck = new Deck(); // deck of cards
    int currentPlayer = 0; // current player on list
    public RaceTo21.Task nextTask = RaceTo21.Task.GetNumberOfPlayers; // keeps track of game state through enum Task
    Player previousWinner; // to keep track of the player who won
    public int winningScore; // variable to represent the winning total score
    public bool finishedTask = false;
    public string response;
    int count; // counter
    int fullNumber = 0; // full winning score number
    int numResponse; // response
    int intro = 0;
    public MainPage()
    {
        InitializeComponent();
    }
   
    public void DoNextTask()
    {
        if (nextTask == RaceTo21.Task.GetNumberOfPlayers)
        {
            StartButton.IsVisible = false;
            gameLabel.Text = "How many players?";
            NumberOfPlayers.IsVisible = true;
            NumberPlayersButton.IsVisible = true;
        }
        else if (nextTask == RaceTo21.Task.GetNames)
        {
            InvalidNumbersText.IsVisible = false;
            NumberOfPlayers.IsVisible = false;
            NumberPlayersButton.IsVisible = false;
            gameLabel.Text = "What is your name?";
            NamesOfPlayers.IsVisible = true;
            NameButton.IsVisible = true;
        }
        else if (nextTask == RaceTo21.Task.AgreedScore)
        {
            InvalidName.IsVisible = false;
            NamesOfPlayers.IsVisible = false;
            NameButton.IsVisible = false;
            TotalWinningScore.IsVisible = true;
            ScoreButton.IsVisible = true;
            gameLabel.Text = "What does " + players[intro].Name + " want the winning score to be?";

        }
        else if (nextTask == RaceTo21.Task.Intro)
        {
            deck.Shuffle();
            InvalidScore.IsVisible = false;
            TotalWinningScore.IsVisible = false;
            ScoreButton.IsVisible = false;
            gameLabel.IsVisible = false;
            TotalScore.IsVisible = true;
            NonScoreButton.IsVisible = true;
            TotalScore.Text = "Total Winning Score: " + winningScore;
            while (currentPlayer < players.Count)
            {
                PlayersNames.IsVisible = true;
                PlayersNames.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                currentPlayer++;
                while (currentPlayer < players.Count)
                {
                    PlayersNames2.IsVisible = true;
                    PlayersNames2.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                    currentPlayer++;
                    while (currentPlayer < players.Count)
                    {
                        PlayersNames3.IsVisible = true;
                        PlayersNames3.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                        currentPlayer++;
                        while (currentPlayer < players.Count)
                        {
                            PlayersNames4.IsVisible = true;
                            PlayersNames4.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                            currentPlayer++;
                            while (currentPlayer < players.Count)
                            {
                                PlayersNames5.IsVisible = true;
                                PlayersNames5.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                currentPlayer++;
                                while (currentPlayer < players.Count)
                                {
                                    PlayersNames6.IsVisible = true;
                                    PlayersNames6.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                    currentPlayer++;
                                    while (currentPlayer < players.Count)
                                    {
                                        PlayersNames7.IsVisible = true;
                                        PlayersNames7.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                        currentPlayer++;
                                        while (currentPlayer <= players.Count)
                                        {
                                            PlayersNames8.IsVisible = true;
                                            PlayersNames8.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                            currentPlayer++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (nextTask == RaceTo21.Task.FirstTurn)
        {
            NonScoreButton.IsVisible = false;
            DrawScoreButton.IsVisible = true;
            DrawCard.IsVisible = true;
            StayScoreButton.IsVisible = true;
            currentPlayer = 0;
            DrawCard.Text = "Do you want to draw a card " + players[intro].Name;
            if (players[currentPlayer].cards.Count == 0)
            {
                while (currentPlayer < players.Count)
                {
                    Card card = deck.DealTopCard();
                    players[currentPlayer].cards.Add(card);
                    players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                    PlayersNames.IsVisible = true;
                    PlayersNames.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                    currentPlayer++;
                    while (currentPlayer < players.Count)
                    {
                        card = deck.DealTopCard();
                        players[currentPlayer].cards.Add(card);
                        players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                        PlayersNames2.IsVisible = true;
                        PlayersNames2.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                        currentPlayer++;
                        while (currentPlayer < players.Count)
                        {
                            card = deck.DealTopCard();
                            players[currentPlayer].cards.Add(card);
                            players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                            PlayersNames3.IsVisible = true;
                            PlayersNames3.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                            currentPlayer++;
                            while (currentPlayer < players.Count)
                            {
                                card = deck.DealTopCard();
                                players[currentPlayer].cards.Add(card);
                                players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                PlayersNames4.IsVisible = true;
                                PlayersNames4.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                currentPlayer++;
                                while (currentPlayer < players.Count)
                                {
                                    card = deck.DealTopCard();
                                    players[currentPlayer].cards.Add(card);
                                    players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                    PlayersNames5.IsVisible = true;
                                    PlayersNames5.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                    currentPlayer++;
                                    while (currentPlayer < players.Count)
                                    {
                                        card = deck.DealTopCard();
                                        players[currentPlayer].cards.Add(card);
                                        players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                        PlayersNames6.IsVisible = true;
                                        PlayersNames6.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                        currentPlayer++;
                                        while (currentPlayer < players.Count)
                                        {
                                            card = deck.DealTopCard();
                                            players[currentPlayer].cards.Add(card);
                                            players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                            PlayersNames7.IsVisible = true;
                                            PlayersNames7.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                            currentPlayer++;
                                            while (currentPlayer <= players.Count)
                                            {
                                                card = deck.DealTopCard();
                                                players[currentPlayer].cards.Add(card);
                                                players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                                PlayersNames8.IsVisible = true;
                                                PlayersNames8.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                                currentPlayer++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (nextTask == RaceTo21.Task.PlayerTurn)
        {
            while (players[count].status == PlayerStatus.stay || players[count].status == PlayerStatus.bust)
            {
                count = (count + 1) % players.Count;
            }
            currentPlayer = 0;
            while (currentPlayer < players.Count)
            {
                PlayersNames.Text = "Player 1 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                currentPlayer++;
                while (currentPlayer < players.Count)
                {
                    PlayersNames2.Text = "Player 2 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                    currentPlayer++;
                    while (currentPlayer < players.Count)
                    {
                        PlayersNames3.Text = "Player 3 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                        currentPlayer++;
                        while (currentPlayer < players.Count)
                        {
                            PlayersNames4.Text = "Player 4 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                            currentPlayer++;
                            while (currentPlayer < players.Count)
                            {
                                PlayersNames5.Text = "Player 5 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                currentPlayer++;
                                while (currentPlayer < players.Count)
                                {
                                    PlayersNames6.Text = "Player 6 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                    currentPlayer++;
                                    while (currentPlayer < players.Count)
                                    {
                                        PlayersNames7.Text = "Player 7 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                        currentPlayer++;
                                        while (currentPlayer < players.Count)
                                        {
                                            PlayersNames8.Text = "Player 8 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                            currentPlayer++;
                                        }
                                    }
                                }
                            }
                        }
                    }
               }
        }
            int winningIndex = Reached21();
            if(winningIndex != -1)
            {
                AnnounceWinner(players[winningIndex]);
            }
    }
}

    public int Reached21()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].score == 21)
            {
                return i;
            }
        }
        return -1;
    }

    public void AnnounceWinner(Player player)
    {
        if (player != null)
        {
            Status.IsVisible = true;
            Status.Text = player.Name + " wins this round!"; 
        }
        else
        {
            Status.IsVisible = true;
            Status.Text = "Everyone busted!";
        }
    }



    public int ScoreHand(Player player)
    {
        int score = 0;
        foreach (Card card in player.cards)
        { 
            string faceValue = card.ID[0].ToString(); // made string faceValue to show the cardName string that the player has
            switch (faceValue)
            {
                case "K":
                case "Q":
                case "J":
                case "1": // to make sure that the 10 card will score +10
                    score = score + 10;
                    break;
                case "A":
                    score = score + 1;
                    break;
                default:
                    score = score + int.Parse(faceValue);
                    break;
            }
        }
        return score;
    }




    private void StartButton_Clicked(object sender, EventArgs e)
    {
        DoNextTask();
    }

    private void NumberPlayersButton_Clicked(object sender, EventArgs e)
    {
        response = NumberOfPlayers.Text;
        if (int.TryParse(response, out numOfPlayers) == false || numOfPlayers < 2 || numOfPlayers > 8) // if they type less than 2 or greater than 8, it will not run 
        {
            InvalidNumbersText.IsVisible = true; // it will say that it is invalid if what the user inputs is NOT the numbers 2-8
        }
        else
        {
            finishedTask = true;
            nextTask = RaceTo21.Task.GetNames;
            DoNextTask();
        }
    }

    private void NameButton_Clicked(object sender, EventArgs e)
    {
        string PlayerName = NamesOfPlayers.Text;
        if (PlayerName == null)
        {
            InvalidName.IsVisible = true;
        }
        else if (PlayerName.Length < 1)
        {
            InvalidName.IsVisible = true;
        }
        else
        {
            players.Add(new Player(PlayerName));
            NamesOfPlayers.Text = "";
            count++;
            if (numOfPlayers == count)
            {
                finishedTask = true;
                count = 0;
                intro = 0;
                nextTask = RaceTo21.Task.AgreedScore;
                DoNextTask();
            }
        }
    }
    private void ScoreButton_Clicked(object sender, EventArgs e)
    {
        string response = TotalWinningScore.Text; // their input
        if (int.TryParse(response, out numResponse) == false || numResponse < 50 || numResponse > 500) // if they type less than 2 or greater than 8, it will not run 
        {
            InvalidScore.IsVisible = true; // it will say that it is invalid if what the user inputs is NOT the numbers 2-8
        }
        else
        {
            intro++;
            fullNumber += numResponse;
            TotalWinningScore.Text = "";
            count++;
            if (players.Count == count)
            {
                count = 0;
                intro = 0;
                winningScore = fullNumber / players.Count;
                finishedTask = true;
                nextTask = RaceTo21.Task.Intro;
                DoNextTask();
            }
            DoNextTask();
        }
    }

    private void NonScoreButton_Clicked(object sender, EventArgs e)
    {
            nextTask = RaceTo21.Task.FirstTurn;
            DoNextTask();
 
    }


    private void DrawScoreButton_Clicked(object sender, EventArgs e)
    {
        intro++;
        Card card = deck.DealTopCard();
        players[count].cards.Add(card);
        players[count].score = ScoreHand(players[count]);
        if (players[count].score > 21)
        {
            players[count].status = PlayerStatus.bust;
        }
        nextTask = RaceTo21.Task.PlayerTurn;
        count = (count + 1 ) % players.Count;
        DoNextTask();
    }

    private void StayScoreButton_Clicked(object sender, EventArgs e)
    {
        players[count].status = PlayerStatus.stay;
        nextTask = RaceTo21.Task.PlayerTurn;
        count = (count + 1) % players.Count;
        DoNextTask();
    }


}


