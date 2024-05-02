namespace task4_1.Pages;

public partial class Statistics : ContentPage
{
    
    
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
        double GovernmentTaxDaily = vm.governmentTaxRate * totalWeight;
        double avgwght = totalWeight / vm.Animals.Count;

        // Calculate farm daily profit
        
        double totalIncome = vm.Animals.Sum(animal =>
        {
            if (animal is Cow cow)
                return cow.Milk * vm.cowMilkPrice;
            else if (animal is Sheep sheep)
                return sheep.Wool * vm.sheepWoolPrice;
            else
                return 0;
        });
        double totalCost = vm.Animals.Sum(animal => animal.Cost);
        double FarmDailyProfit = totalIncome - totalCost - (GovernmentTaxDaily);
        farmdailyprofit.Text = $"$ {FarmDailyProfit}";
        govttax.Text = $"$ {GovernmentTaxDaily*30}";
        averageweight.Text = $"{avgwght}";
    }
}
