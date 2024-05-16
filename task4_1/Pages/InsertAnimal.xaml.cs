namespace task4_1.Pages;

public partial class InsertAnimal : ContentPage
{
    MainViewModel vm;
    private List<Animal> allAnimals;
    public InsertAnimal()
	{
		InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
        allAnimals = vm.Animals.ToList();
    }
    private void OnTypeSelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedType = typePicker.SelectedItem.ToString();
        typePicker.SelectedIndex = 0;
        colourPicker.SelectedIndex = 0;


        if (selectedType == "Cow")
        {
            colourPicker.IsEnabled = true;
        }
        else if (selectedType == "Sheep")
        {
            colourPicker.IsEnabled = true;
            colourPicker.SelectedIndex = 0;

        }
    }
    private void OnInsertAnimalClicked(object sender, EventArgs e)
    {

    }

    private void OnResetClicked(object sender, EventArgs e)
    {

    }

   
}