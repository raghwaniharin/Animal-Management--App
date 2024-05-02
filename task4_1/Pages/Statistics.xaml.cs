namespace task4_1.Pages;

public partial class Statistics : ContentPage
{
	public Statistics(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}