namespace task4_1.Pages;

public partial class InsertAnimal : ContentPage
{
    MainViewModel vm;
    private List<Animal> allAnimals1;
    private Animal animal; // Declare the animal variable at the class level

    public InsertAnimal(MainViewModel vm)
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
            animal = new Cow(); // Initialize animal as Cow
        }
        else if (selectedType == "Sheep")
        {
            colourPicker.IsEnabled = true;
            colourPicker.SelectedIndex = 0;
            woolEntry.IsVisible = true;
            woolLabel.IsVisible = true;
            milkEntry.IsVisible = false;
            milkLabel.IsVisible = false;
            animal = new Sheep(); // Initialize animal as Sheep
        }
    }

    private void OnInsertAnimalClicked(object sender, EventArgs e)
    {
        // Initialize milkAmount and woolAmount with default values
        double milkAmount = 0;
        double woolAmount = 0;

        // Validate costEntry
        if (!double.TryParse(costEntry.Text, out double cost))
        {
            DisplayAlert("Error", "Cost must be a valid number", "OK");
            return;
        }

        // Validate weightEntry
        if (!double.TryParse(weightEntry.Text, out double weight))
        {
            DisplayAlert("Error", "Weight must be a valid number", "OK");
            return;
        }

        // Validate milkEntry (if visible)
        if (milkEntry.IsVisible && !double.TryParse(milkEntry.Text, out milkAmount))
        {
            DisplayAlert("Error", "Milk amount must be a valid number", "OK");
            return;
        }

        // Validate woolEntry (if visible)
        if (woolEntry.IsVisible && !double.TryParse(woolEntry.Text, out woolAmount))
        {
            DisplayAlert("Error", "Wool amount must be a valid number", "OK");
            return;
        }

        // Set common properties
        animal.Colour = colourPicker.SelectedItem.ToString();
        animal.Cost = cost;
        animal.Weight = weight;

        // Set specific properties based on type
        if (animal is Cow cow)
        {
            cow.Milk = milkAmount;
        }
        else if (animal is Sheep sheep)
        {
            sheep.Wool = woolAmount;
        }

        // Insert the animal into the list and database
        vm.Animals.Add(animal); // Add to list
        vm._database.InsertItem(animal);

        // Reset the form
        OnResetClicked(sender, e);
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
