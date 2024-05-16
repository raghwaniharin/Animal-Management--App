namespace task4_1.Pages;

public partial class InsertAnimal : ContentPage
{
    MainViewModel vm;
    private List<Animal> allAnimals1;
    public InsertAnimal( MainViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
        allAnimals1 = vm.Animals.ToList();
    }
    private void OnTypeSelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedType = typePicker.SelectedItem.ToString();
        typePicker.SelectedIndex = 0;
        colourPicker.SelectedIndex = 0;


        if (selectedType == "Cow")
        {
            colourPicker.IsEnabled = true;
            milkEntry.IsVisible = true;
            milkLabel.IsVisible = true;
            woolEntry.IsVisible = false;
            woolLabel.IsVisible = false;
        }
        else if (selectedType == "Sheep")
        {
            colourPicker.IsEnabled = true;
            colourPicker.SelectedIndex = 0;
            woolEntry.IsVisible = true;
            woolLabel.IsVisible = true;
            milkEntry.IsVisible = false;
            milkLabel.IsVisible = false;

        }
        

    }
    private void OnInsertAnimalClicked(object sender, EventArgs e)
    {
        // Validate costEntry
        if (!double.TryParse(costEntry.Text, out double cost))
        {
            DisplayAlert("Error", "Cost must be a valid number", "OK");
            return;
        }

        // Validate milkEntry (if visible)
        if (milkEntry.IsVisible && !double.TryParse(milkEntry.Text, out double milkAmount))
        {
            DisplayAlert("Error", "Milk amount must be a valid number", "OK");
            return;
        }

        // Validate woolEntry (if visible)
        if (woolEntry.IsVisible && !double.TryParse(woolEntry.Text, out double woolAmount))
        {
            DisplayAlert("Error", "Wool amount must be a valid number", "OK");
            return;
        }

        // Insert the animal into the list and database
        var animal = new Animal
        {};
        vm.Animals.Add(animal); // Add to list
                                // Insert into database (You need to implement this logic)

    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        // Clear all entries
        weightEntry.Text = string.Empty;
        costEntry.Text = string.Empty;
        milkEntry.Text = string.Empty;
        woolEntry.Text = string.Empty;

        // Reset pickers
        typePicker.SelectedIndex = 0;
        colourPicker.SelectedIndex = 0;

        // Hide milk and wool entries and labels
        milkEntry.IsVisible = false;
        milkLabel.IsVisible = false;
        woolEntry.IsVisible = false;
        woolLabel.IsVisible = false;
    }

   
}