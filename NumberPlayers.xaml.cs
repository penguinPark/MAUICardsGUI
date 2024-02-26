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
        response = int.Parse(NumberOfPlayers.Text);


        if (response < 2 || response > 8)
        {
            SemanticScreenReader.Announce("no");
        }
        else
        {
            Navigation.PushAsync(new NamePage());
        }
    }


}