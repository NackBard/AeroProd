using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для StaffList.xaml
    /// </summary>
    public partial class StaffList : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public StaffList()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            PostLoad();
            EmployeeGridLoad();
        }
        private void PostLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select*from Position", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                PostBox.ItemsSource = dt.DefaultView;
                PostBox.DisplayMemberPath = "Name";
                PostBox.SelectedValuePath = "ID_Position";
                Filter.ItemsSource = dt.DefaultView;
                Filter.DisplayMemberPath = "Name";
                Filter.SelectedValuePath = "ID_Position";
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
        private void EmployeeGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Staff, LastName as 'Фамилия', FirstName as 'Имя', Patronymic as 'Отчество', Position.Name as 'Должность' , Position_ID from Staff join Position on ID_Position = Position_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                EmployeeGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
                Loaded += (sender, args) => EmployeeGrid.Columns[5].Visibility = Visibility.Hidden;
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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastNameBox.Text == null || NameBox.Text == null || PostBox.SelectedValue == null || EmployeeGrid.SelectedValue == null)
            {
                MessageBox.Show("Не все поля заполнены или сотрудник не выбран");
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Staff set LastName = '{LastNameBox.Text}', FirstName = '{NameBox.Text}', Patronymic = '{PatronymicBox.Text}', Position_ID = {PostBox.SelectedValue} where LastName = '{((DataRowView)EmployeeGrid.SelectedValue)[1]}' and FirstName = '{((DataRowView)EmployeeGrid.SelectedValue)[2]}' and Patronymic = '{((DataRowView)EmployeeGrid.SelectedValue)[3]}' and Position_ID = {((DataRowView)EmployeeGrid.SelectedValue)[5]}", connection);
                    cmd.ExecuteNonQuery();
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
            EmployeeGridLoad();
            EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
            EmployeeGrid.Columns[5].Visibility = Visibility.Hidden;
        }


        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeGrid.SelectedValue != null)
            {
                NameBox.Text = ((DataRowView)EmployeeGrid.SelectedValue)[2].ToString();
                LastNameBox.Text = ((DataRowView)EmployeeGrid.SelectedValue)[1].ToString();
                PatronymicBox.Text = ((DataRowView)EmployeeGrid.SelectedValue)[3].ToString();
                PostBox.SelectedValue = ((DataRowView)EmployeeGrid.SelectedValue)[5].ToString();
            }
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter($"select ID_Staff, LastName as 'Фамилия', FirstName as 'Имя', Patronymic as 'Отчество', Position.Name as 'Должность' , Position_ID from Staff join Position on ID_Position = Position_ID WHERE Position_ID = {Filter.SelectedValue}", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                EmployeeGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
            EmployeeGrid.Columns[5].Visibility = Visibility.Hidden;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }

    }
}
