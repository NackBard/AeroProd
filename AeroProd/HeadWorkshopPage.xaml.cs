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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для HeadWorkshopPage.xaml
    /// </summary>
    public partial class HeadWorkshopPage : Page
    {
        public HeadWorkshopPage(string id)
        {
            InitializeComponent();
        }

        private void EmployeeList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.Navigate(new StaffList());
        }

        private void LabList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.Navigate(new LaboratoryList());
        }

        private void WorkshopList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.Navigate(new WorkshopList());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }
    }
}
