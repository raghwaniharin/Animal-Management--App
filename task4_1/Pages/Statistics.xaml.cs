namespace task4_1.Pages;

public partial class Statistics : ContentPage
{
    public List<Animal> Animals { get; set; }
    public double GovernmentTaxFor30Days { get; set; }
    public double FarmDailyProfit { get; set; }
    public Statistics(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void CalulateStats(object sender, EventArgs e)
    {
        double governmentTaxRate = 0.02; // Government tax rate per kg per day
        double totalWeight = Animals.Sum(animal => animal.Weight);
        double GovernmentTaxFor30Days = governmentTaxRate * totalWeight * 30;

        // Calculate farm daily profit
        double cowMilkPrice = 9.4; // $ per kg
        double sheepWoolPrice = 6.2; // $ per kg
        double totalIncome = Animals.Sum(animal =>
        {
            if (animal is Cow cow)
                return cow.Milk * cowMilkPrice;
            else if (animal is Sheep sheep)
                return sheep.Wool * sheepWoolPrice;
            else
                return 0;
        });
        double totalCost = Animals.Sum(animal => animal.Cost);
        double FarmDailyProfit = totalIncome - totalCost - GovernmentTaxFor30Days;
    }
}