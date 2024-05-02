namespace task4_1.Pages;

public partial class Statistics : ContentPage
{
    
    double cowMilkPrice = 9.4; // $ per kg
    double sheepWoolPrice = 6.2; // $ per kg
    double governmentTaxRate = 0.02; // Government tax rate per kg per day
    MainViewModel vm;

    public Statistics(MainViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;   
		BindingContext = vm;
	}

    //comment from jessie 
    private void CalulateStats(object sender, EventArgs e)
    {
        
        double totalWeight = vm.Animals.Sum(animal => animal.Weight);
        double GovernmentTaxFor30Days = governmentTaxRate * totalWeight * 30;

        // Calculate farm daily profit
        
        double totalIncome = vm.Animals.Sum(animal =>
        {
            if (animal is Cow cow)
                return cow.Milk * cowMilkPrice;
            else if (animal is Sheep sheep)
                return sheep.Wool * sheepWoolPrice;
            else
                return 0;
        });
        double totalCost = vm.Animals.Sum(animal => animal.Cost);
        double FarmDailyProfit = totalIncome - totalCost - GovernmentTaxFor30Days;
        farmdailyprofit.Text = $"Type of Employee:: {FarmDailyProfit}\n ";
        govttax.Text = $"$ {GovernmentTaxFor30Days}";
    }
}
