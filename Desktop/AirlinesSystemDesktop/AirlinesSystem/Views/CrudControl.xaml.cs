using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using AirlinesSystem.Data;
using AirlinesSystem.Models;
using AirlinesSystem.Views.Dialog;

namespace AirlinesSystem.Views
{
    public partial class CrudControl : UserControl
    {
        public ObservableCollection<Employee> Items { get; set; }
        private ObservableCollection<Employee> AllItems { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; } = 30;
        public int TotalPages => (Items.Count + ItemsPerPage - 1) / ItemsPerPage;

        public ICommand FirstPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand LastPageCommand { get; }
        public ICommand SearchCommand { get; }

        public CrudControl()
        {
            InitializeComponent();
            DataContext = this;

            AllItems = new ObservableCollection<Employee>();
            // Add sample data here or load from your data source
            for (int i = 1; i <= 200; i++)
            {
                AllItems.Add(DataGenerator.GenerateEmployee());
            }


            Items = new ObservableCollection<Employee>(AllItems);
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
            var pagedItems = new ObservableCollection<Employee>(
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
            Items = new ObservableCollection<Employee>(AllItems.Where(p =>
                p.FirstName.ToLower().Contains(searchText) ||
                p.LastName.ToLower().Contains(searchText) ||
                p.Position.PositionName.ToLower().Contains(searchText) ||
                p.Email.ToLower().Contains(searchText)));
            CurrentPage = 1;
            UpdateItemsSource();
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EmployeeAddingWindow employeeAddingWindow = new();
            employeeAddingWindow.Show();
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}