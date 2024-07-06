using AirlinesSystem.Views;
using System.Windows;
using System.Windows.Controls;

namespace AirlinesSystem;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ToggleButton_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void ToggleButton_Checked_1(object sender, RoutedEventArgs e)
    {

    }

    private void CustomerWindow_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!(sender is ListBox listBox))
        {
            return;
        }

        if (crudControl == null)
        {
            return;
        }

        if (!(listBox.SelectedItem is ListBoxItem selectedItem))
        {
            return;
        }

        string content = selectedItem.Content?.ToString(); // проверяем на null перед вызовом ToString()
        if (content == null)
        {
            return;
        }

        switch (content)
        {
            case "Passengers":
                passengerCrudControl.Visibility = Visibility.Visible;
                crudControl.Visibility = Visibility.Collapsed;
                break;
            case "Employees":
                crudControl.Visibility = Visibility.Visible;
                passengerCrudControl.Visibility = Visibility.Collapsed;
                break;
            default:
                passengerCrudControl.Visibility = Visibility.Collapsed;
                crudControl.Visibility = Visibility.Collapsed;
                break;
        }
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}