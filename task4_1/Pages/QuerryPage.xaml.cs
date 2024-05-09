namespace task4_1.Pages;

public partial class QuerryPage : ContentPage
{
    MainViewModel vm;
    private List<Animal> allAnimals;
    public QuerryPage(MainViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
        allAnimals = vm.Animals.ToList();
    }
    private void OnTypeSelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedType = typePicker.SelectedItem.ToString();

        // Clear previous selections
        colourPicker.SelectedIndex = 0;

        // Enable/disable colour options based on selected type
        if (selectedType == "Cow")
        {
            colourPicker.IsEnabled = true;
        }
        else if (selectedType == "Sheep")
        {
            colourPicker.IsEnabled = true;
            colourPicker.SelectedIndex = 0;
            // Disable "All" option and select "White" by default
            //colourPicker.Items.Remove("All");
            //colourPicker.SelectedItem = "White";
        }
    }

    private void OnColourSelectedIndexChanged(object sender, EventArgs e)
    {
        if (colourPicker.SelectedItem != null)
        {
            string selectedColour = colourPicker.SelectedItem.ToString();
            //DisplayAlert("Selected Colour", $"You selected: {selectedColour}", "OK");
        }
        
    }

    private void OnSearchClicked(object sender, EventArgs e)
    {
        // Get selected type and colour
        string selectedType = typePicker.SelectedItem.ToString();
        string selectedColour = colourPicker.SelectedItem.ToString();

        // Filter animals based on selected criteria
        List<Animal> matchingAnimals = allAnimals.Where(animal =>
        {
            // Check if the animal matches the selected type and colour
            bool isMatch = false;
            if (selectedType == "Cow" && animal is Cow cow)
            {
                isMatch = selectedColour == "All" || cow.Colour.ToLower() == selectedColour.ToLower();
            }
            else if (selectedType == "Sheep" && animal is Sheep sheep)
            {
                isMatch = selectedColour == "All" || sheep.Colour.ToLower() == selectedColour.ToLower();
            }
            return isMatch;
        }).ToList();
        animalListContainer.Children.Clear();
        foreach (var animal in matchingAnimals)
        {
            // Create a label to display animal information
            Label animalLabel = new Label
            {
                Text = animal.ToString(),
                Margin = new Thickness(0, 10),
              };


        }

    }
}