using RaceTo21;

namespace MAUICardsGUI;

public partial class NumberPlayers : ContentPage
{
    public int response;
    public NumberPlayers()
	{
		InitializeComponent();
    }
    private void PeopleButton_Clicked(object sender, EventArgs e)
    {
        response = int.Parse(NumberOfPlayers.Text); // this stores the number that the user inputs 


        if (response < 2 || response > 8) // if they type less than 2 or greater than 8, it will not run 
        {
            SemanticScreenReader.Announce("no");
        }
        else
        {
            Navigation.PushAsync(new NamePage()); // after it gets the number of players, it will ask for their names
        }
    }


}