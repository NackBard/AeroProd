using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        string connectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        public AuthPage()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        private void AuthoriationButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text != null && PasswordBox.Password != null)
            {
                try
                {
                    connection.Open();
                    adapter = new SqlDataAdapter($"select*from Users where Login = '{LoginBox.Text}' and Password = '{PasswordBox.Password}'", connection);
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        switch (ds.Rows[0][4].ToString())
                        {
                            case "1":
                                MainWindow.FrameInstance.Navigate(new ForemanPage());
                                MainWindow.TextInstance.Text = "Меню бригадира";
                                break;
                            case "2":
                                MainWindow.FrameInstance.Navigate(new AdminPage());
                                MainWindow.TextInstance.Text = "Меню администратора";
                                break;
                            case "3":
                                MainWindow.FrameInstance.Navigate(new StaffPage(ds.Rows[0][3].ToString()));
                                MainWindow.TextInstance.Text = "Меню сотрудника";
                                break;
                            case "4":
                                MainWindow.FrameInstance.Navigate(new HeadWorkshopPage(ds.Rows[0][3].ToString()));
                                MainWindow.TextInstance.Text = "Меню начальника цеха";
                                break;
                            case "5":
                                MainWindow.FrameInstance.Navigate(new HeadWorkShopareaPage(ds.Rows[0][3].ToString()));
                                MainWindow.TextInstance.Text = "Меню начальника участка";
                                break;
                            case "6":
                                MainWindow.FrameInstance.Navigate(new TesterPage(ds.Rows[0][3].ToString()));
                                MainWindow.TextInstance.Text = "Меню испытателя";
                                break;    
                        }
                    }
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Не верный логин или пароль");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
