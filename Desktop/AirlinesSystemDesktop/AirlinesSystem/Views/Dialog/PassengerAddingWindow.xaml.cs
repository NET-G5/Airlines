using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirlinesSystem.Views.Dialog;

/// <summary>
/// Interaction logic for PassengerAddingWindow.xaml
/// </summary>
public partial class PassengerAddingWindow : Window
{
    public PassengerAddingWindow()
    {
        InitializeComponent();

        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }
}
