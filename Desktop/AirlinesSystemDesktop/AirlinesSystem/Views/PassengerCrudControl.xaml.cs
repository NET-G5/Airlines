using AirlinesSystem.Data;
using AirlinesSystem.Models;
using AirlinesSystem.Views.Dialog;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace AirlinesSystem.Views;

public partial class PassengerCrudControl : UserControl
{
    public ObservableCollection<Passenger> Items { get; set; }
    private ObservableCollection<Passenger> AllItems { get; set; }
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; } = 30;
    public int TotalPages => (AllItems.Count + ItemsPerPage - 1) / ItemsPerPage;

    public ICommand FirstPageCommand { get; }
    public ICommand PreviousPageCommand { get; }
    public ICommand NextPageCommand { get; }
    public ICommand LastPageCommand { get; }
    public ICommand SearchCommand { get; }

    public PassengerCrudControl()
    {
        InitializeComponent();
        DataContext = this;

        Items = new ObservableCollection<Passenger>();
        AllItems = new ObservableCollection<Passenger>();

        for (int i = 0; i <= 200; i++)
        {
            AllItems.Add(DataGenerator.GeneratePassenger());
        }

        Items = new ObservableCollection<Passenger>(AllItems);

        CurrentPage = 1;

        FirstPageCommand = new RelayCommand(FirstPage, () => CurrentPage > 1);
        PreviousPageCommand = new RelayCommand(PreviousPage, () => CurrentPage > 1);
        NextPageCommand = new RelayCommand(NextPage, () => CurrentPage < TotalPages);
        LastPageCommand = new RelayCommand(LastPage, () => CurrentPage < TotalPages);
        SearchCommand = new RelayCommand(Search);

        UpdateItemsSource();
    }

    private void UpdateItemsSource()
    {
        var pagedItems = new ObservableCollection<Passenger>(
            Items.Skip((CurrentPage - 1) * ItemsPerPage).Take(ItemsPerPage));
        dataGrid.ItemsSource = pagedItems;
    }

    private void FirstPage()
    {
        CurrentPage = 1;
        UpdateItemsSource();
    }

    private void PreviousPage()
    {
        if (CurrentPage > 1) CurrentPage--;
        UpdateItemsSource();
    }

    private void NextPage()
    {
        if (CurrentPage < TotalPages) CurrentPage++;
        UpdateItemsSource();
    }

    private void LastPage()
    {
        CurrentPage = TotalPages;
        UpdateItemsSource();
    }

    private void Search()
    {
        string searchText = searchTextBox.Text.ToLower();
        Items = new ObservableCollection<Passenger>(AllItems.Where(p =>
            p.FirstName.ToLower().Contains(searchText) ||
            p.LastName.ToLower().Contains(searchText)));
        CurrentPage = 1;
        UpdateItemsSource();
    }

    private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        PassengerAddingWindow passengerAddingWindow = new();
        passengerAddingWindow.Show();
    }
}