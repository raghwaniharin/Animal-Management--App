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
        
        vm.totalWeight = vm.Animals.Sum(animal => animal.Weight);
        vm.GovernmentTaxDaily = vm.governmentTaxRate * vm.totalWeight;
        vm.avgweight = vm.totalWeight / vm.Animals.Count;
        vm.countSheep = vm.Animals.Count(animal => animal is Sheep);
        vm.countCow = vm.Animals.Count(animal => animal is Cow);

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
        double FarmDailyProfit = totalIncome - totalCost - (vm.GovernmentTaxDaily);
        farmdailyprofit.Text = $"$ {FarmDailyProfit:F2}";
        govttax.Text = $"$ {vm.GovernmentTaxDaily*30:F2}";
        averageweight.Text = $"$ {vm.avgweight:F2}";
               
        double cowprofit = vm.Animals.Sum(animal => 
        {
            if (animal is Cow cow)
            {
                return (cow.Milk * vm.cowMilkPrice)- cow.Cost - (cow.Milk * vm.governmentTaxRate);
            }
            else return 0;
        }
        );
        
        cowdailyprft.Text = $"$ {cowprofit:F2}";
        avgcowdailyprft.Text = $"$ {(cowprofit / vm.countCow):F2}";
        
        double sheepprofit = vm.Animals.Sum(animal =>
        {
            if (animal is Sheep sheep)
            {
                return (sheep.Wool * vm.sheepWoolPrice) - sheep.Cost - (sheep.Wool * vm.governmentTaxRate);
            }
            else return 0;
        }
        );
        sheepdailyprft.Text = $"${sheepprofit:F2}";
        avgsheepdailyprft.Text = $"${(sheepprofit / vm.countSheep):F2}";
    }
}
