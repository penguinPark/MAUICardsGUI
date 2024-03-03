using RaceTo21;

namespace MAUICardsGUI;
public partial class MainPage : ContentPage
{

    int numOfPlayers; // number of players in current game
    List<Player> players = new List<Player>(); // list of objects containing player data
    Deck deck = new Deck(); // deck of cards
    int currentPlayer = 0; // current player on list
    public RaceTo21.Task nextTask = RaceTo21.Task.GetNumberOfPlayers; // keeps track of game state through enum Task
    private bool cheating = false; // lets you cheat for testing purposes if true
    Player previousWinner; // to keep track of the player who won
    public int winningScore; // variable to represent the winning total score
    public bool finishedTask = false;
    public string response;
    int count;
    int fullNumber = 0;
    int numResponse;
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
            NumberOfPlayers.IsVisible = false;
            NumberPlayersButton.IsVisible = false;
            gameLabel.Text = "What is your name?";
            NamesOfPlayers.IsVisible = true;
            NameButton.IsVisible = true;
        }
        else if (nextTask == RaceTo21.Task.AgreedScore)
        {
            NamesOfPlayers.IsVisible = false;
            NameButton.IsVisible = false;
            gameLabel.Text = "What do you want the winning score to be?";
            TotalWinningScore.IsVisible = true;
            ScoreButton.IsVisible = true;
        }
        else if (nextTask == RaceTo21.Task.PlayerTurn)
        {
            InvalidScore.IsVisible = false;
            TotalWinningScore.IsVisible = false;
            ScoreButton.IsVisible = false;
            gameLabel.IsVisible = false;
            TotalScore.IsVisible = true;
            TotalScore.Text = "Total Winning Score: " + winningScore;
            while(currentPlayer < players.Count )
            {
                PlayersNames.IsVisible = true;
                PlayersNames.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
                currentPlayer++;
                while (currentPlayer < players.Count)
                {
                    PlayersNames2.IsVisible = true;
                    PlayersNames2.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
                    currentPlayer++;
                    while (currentPlayer < players.Count)
                    {
                        PlayersNames3.IsVisible = true;
                        PlayersNames3.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
                        currentPlayer++;
                        while (currentPlayer < players.Count)
                        {
                            PlayersNames4.IsVisible = true;
                            PlayersNames4.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
                            currentPlayer++;
                            while (currentPlayer < players.Count)
                            {
                                PlayersNames5.IsVisible = true;
                                PlayersNames5.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
                                currentPlayer++;
                                while (currentPlayer < players.Count)
                                {
                                    PlayersNames6.IsVisible = true;
                                    PlayersNames6.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
                                    currentPlayer++;
                                    while (currentPlayer < players.Count)
                                    {
                                        PlayersNames7.IsVisible = true;
                                        PlayersNames7.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
                                        currentPlayer++;
                                        while (currentPlayer <= players.Count)
                                        {
                                            PlayersNames8.IsVisible = true;
                                            PlayersNames8.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name;
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
            fullNumber += numResponse;
            TotalWinningScore.Text = "";
            count++;
            if (players.Count == count)
            {
                winningScore = fullNumber / players.Count;
                finishedTask = true;
                nextTask = RaceTo21.Task.PlayerTurn;
                DoNextTask();
            }
        }
    }
}


