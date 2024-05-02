namespace task4_1.Pages;

public partial class QueryPage : ContentPage
{
	MainViewModel vm;
	public QueryPage(MainViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
	}
    private void OnResetClicked(object sender, EventArgs e)
    {
        TypeEntry.Text = string.Empty;
        ResultLabel.Text = string.Empty;
    }

    private void IdEntryBtn_click(object sender, EventArgs e)
    {

    }
}