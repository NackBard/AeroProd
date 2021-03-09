using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для BrigadesPage.xaml
    /// </summary>
    public partial class BrigadesPage : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        public BrigadesPage(string id)
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter($"select LastName +  ' ' + FirstName + ' ' + Patronymic as 'ФИО' from Last_of_brigade join Staff on ID_Staff = Staff_ID where Brigade_ID = {id}", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BrigadeList.ItemsSource = dt.DefaultView;
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }
    }
}
