﻿namespace task4_1.ViewModels;

public class MainViewModel
{
    public ObservableCollection<Animal> Animals { get; set; }
    public readonly Database _database;
    

    public MainViewModel()
    {
        _database = new();
        Animals = new();
        _database.ReadItems().ForEach(x => Animals.Add(x));
    }
    
}
