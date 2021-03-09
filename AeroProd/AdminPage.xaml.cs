using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public AdminPage()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            PostLoad();
            LevelLoad();
            EmployeeLoad();
            UserGridLoad();
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

        private void LevelLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select*from Access_level", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                LevelBox.ItemsSource = dt.DefaultView;
                LevelBox.DisplayMemberPath = "Name";
                LevelBox.SelectedValuePath = "ID_Level";
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

        private void EmployeeLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Staff, LastName + ' ' + FirstName + ' ' + Patronymic + ' - ' + Position.Name as 'Сотрудник' from Staff join Position on ID_Position = Position_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                EmployeeBox.ItemsSource = dt.DefaultView;
                EmployeeBox.DisplayMemberPath = "Сотрудник";
                EmployeeBox.SelectedValuePath = "ID_Staff";
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

        private void UserGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select Login as 'Логин', Password as 'Пароль', LastName + ' ' + FirstName + ' ' + Patronymic 'Сотрудник', ID_Staff, Access_level.Name  as 'Уровень доступа', Access_level_ID from Users join Staff on ID_Staff = Staff_ID join Access_level on ID_Level = Access_level_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                UserGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => UserGrid.Columns[3].Visibility = Visibility.Hidden;
                Loaded += (sender, args) => UserGrid.Columns[5].Visibility = Visibility.Hidden;
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

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserGrid.SelectedValue != null)
            {
                LoginBox.Text = ((DataRowView)UserGrid.SelectedValue)[0].ToString();
                PasswordBox.Text = ((DataRowView)UserGrid.SelectedValue)[1].ToString();
                LevelBox.SelectedValue = ((DataRowView)UserGrid.SelectedValue)[5].ToString();
                EmployeeBox.SelectedValue = ((DataRowView)UserGrid.SelectedValue)[3].ToString();
            }
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

        private void UpdateButtonEmployee_Click(object sender, RoutedEventArgs e)
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

        private void UpdateButtonUser_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == null || PasswordBox.Text == null || LevelBox.SelectedValue == null || EmployeeBox.SelectedValue == null || UserGrid.SelectedValue == null)
            {
                MessageBox.Show("Не все поля заполнены или сотрудник не выбран");
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Users set Login = '{LoginBox.Text}', Password = '{PasswordBox.Text}', Staff_ID = {EmployeeBox.SelectedValue}, Access_level_ID ={LevelBox.SelectedValue} where Login = '{((DataRowView)UserGrid.SelectedValue)[0]}'", connection);
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
            UserGridLoad();
            UserGrid.Columns[3].Visibility = Visibility.Hidden;
            UserGrid.Columns[5].Visibility = Visibility.Hidden;
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedValue == null)
            {
                MessageBox.Show("Не выбран сотрудник");
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"delete Staff where ID_Staff = {((DataRowView)EmployeeGrid.SelectedValue)[0]}", connection);
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

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedValue == null)
            {
                MessageBox.Show("Не выбран сотрудник");
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"delete Users where Login = '{((DataRowView)UserGrid.SelectedValue)[0]}'", connection);
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
            UserGridLoad();
            UserGrid.Columns[3].Visibility = Visibility.Hidden;
            UserGrid.Columns[5].Visibility = Visibility.Hidden;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastNameBox.Text == null || NameBox.Text == null || PostBox.SelectedValue == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($" INSERT INTO Staff (LastName, FirstName, Patronymic,Position_ID, Duration_of_work) values ('{LastNameBox.Text}', '{NameBox.Text}', '{PatronymicBox.Text}', {PostBox.SelectedValue}, '{DateTime.Now}')", connection);
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
                EmployeeGridLoad();
                EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
                EmployeeGrid.Columns[5].Visibility = Visibility.Hidden;
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == null || PasswordBox.Text == null || LevelBox.SelectedValue == null || EmployeeBox.SelectedValue == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($" INSERT INTO Users (Login, Password, Staff_ID, Access_level_ID) values ('{LoginBox.Text}','{PasswordBox.Text}',{EmployeeBox.SelectedValue}, {LevelBox.SelectedValue})", connection);
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
                UserGridLoad();
                UserGrid.Columns[3].Visibility = Visibility.Hidden;
                UserGrid.Columns[5].Visibility = Visibility.Hidden;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGridLoad();
            EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
            EmployeeGrid.Columns[5].Visibility = Visibility.Hidden;
            UserGridLoad();
            UserGrid.Columns[3].Visibility = Visibility.Hidden;
            UserGrid.Columns[5].Visibility = Visibility.Hidden;

        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedValue == null)
            {
                MessageBox.Show("Не выбран сотрудник");
            }
            else
            {
                MainWindow.FrameInstance.Navigate(new ProfilePage(((DataRowView)EmployeeGrid.SelectedValue)[0].ToString(), "Администратор"));
            }
        }
    }
}
