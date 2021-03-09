using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для ForemanPage.xaml
    /// </summary>
    public partial class ForemanPage : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        string id = "1";
        public ForemanPage()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select LastName +  ' ' + FirstName + ' ' + Patronymic as 'ФИО', Area_of_workshop.ID_Area_of_workshop as 'Номер зоны', ID_Brigade from Brigade join Foreman on ID_Foreman = Foreman_ID join Staff on ID_Staff = Staff_ID join Area_of_workshop on ID_Area_of_workshop = Workshop_of_area_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BrigadeGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => BrigadeGrid.Columns[2].Visibility = Visibility.Hidden;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }

        private void Brigades_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.Navigate(new BrigadesPage(id));
        }

        private void BrigadeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id = ((DataRowView)BrigadeGrid.SelectedValue)[2].ToString();
        }
    }
}
