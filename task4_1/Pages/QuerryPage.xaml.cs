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
        //typePicker.SelectedIndex = 0;
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

        int totalLivestockCount = matchingAnimals.Count;
        double percentage = (double)totalLivestockCount / allAnimals.Count * 100;

        double totalIncome = 0;
        double totalCost = 0;
        double totalTax = 0;
        double totalWeight = 0;
        double totalProduceAmount = 0;
        

        foreach (var animal in matchingAnimals)
        {
            double weight = CalculateWeight(animal);
            double produceAmountPerDay = CalculateProduceAmount(animal);

            double income = 0;
            if (animal is Cow cow)
            {
                income = produceAmountPerDay * 9.4;
                
            }
            else if (animal is Sheep sheep)
            {
                income = produceAmountPerDay * 6.2; 
            }

            double cost = weight * 0.02; 
            double tax = produceAmountPerDay * 0.02; 

            totalIncome += income;
            totalCost += cost;
            totalTax += tax;
            totalWeight += weight;
            totalProduceAmount += produceAmountPerDay;
        }

        double averageWeight = totalWeight / totalLivestockCount;

        // Display results
        totalProduceAmountLabel.Text = $"{totalProduceAmount:F2}";
        averageWeightLabel.Text = $"{averageWeight:F2}";
        totalTaxLabel.Text = $"${totalTax:F2}";
        totalCostLabel.Text = $"${totalCost:F2}";
        totalIncomeLabel.Text = $"${totalIncome:F2}";
        percentageLabel.Text = $"{percentage:F2}";
        totalCountLabel.Text = $"{totalLivestockCount}";
        label1.Text = $"Number of livestock( {selectedType} in {selectedColour} colour)";

    }
    

    private double CalculateWeight(Animal animal)
    {
        // Implement weight calculation based on the type and any other relevant data
        return animal.Weight; // Placeholder, replace with actual calculation
    }

    private double CalculateProduceAmount(Animal animal)
    {

        
        if (animal is Cow cow)
        {
            return cow.Milk;
        }
        else if (animal is Sheep sheep)
        {
            return sheep.Wool;
        }
        return 0;
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        totalProduceAmountLabel.Text =string.Empty;
        averageWeightLabel.Text = string.Empty;
        totalTaxLabel.Text = string.Empty;
        totalCostLabel.Text = string.Empty;
        totalIncomeLabel.Text = string.Empty;
        percentageLabel.Text =  string.Empty;
        totalCountLabel.Text = string.Empty;
    }
}



