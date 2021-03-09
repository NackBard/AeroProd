using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для WorkshopList.xaml
    /// </summary>
    public partial class WorkshopList : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public WorkshopList()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            AreaEmployeeBoxLoad();
            EmployeeBoxLoad();
            EmployeeGridLoad();
            AreaGridLoad();
        }

        private void AreaEmployeeBoxLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Head_of_workshop_area, LastName + ' ' + FirstName + ' ' + Patronymic AS 'ФИО' from Head_of_workshop_area join Staff on ID_Staff =Staff_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                AreaEmployeeBox.ItemsSource = dt.DefaultView;
                AreaEmployeeBox.DisplayMemberPath = "ФИО";
                AreaEmployeeBox.SelectedValuePath = "ID_Head_of_workshop_area";
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
        private void EmployeeBoxLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Staff, LastName + ' ' + FirstName + ' ' + Patronymic + ' - ' + Position.Name AS 'Сотрудник' from Staff join Position on ID_Position = Position_ID", connection);
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
        private void EmployeeGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Head_of_workshop_area,Staff_ID,LastName + ' ' + FirstName + ' ' + Patronymic as 'ФИО'  from Head_of_workshop_area join Staff on ID_Staff =Staff_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                EmployeeGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
                Loaded += (sender, args) => EmployeeGrid.Columns[1].Visibility = Visibility.Hidden;
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
        private void AreaGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Area_of_workshop as 'Участок',Workshop_ID as 'Номер цеха',Staff_ID,Head_of_workshop_area_ID,LastName + ' ' + FirstName + ' ' + Patronymic as 'Начальник участка', Target as 'Задача'  from Area_of_workshop join Head_of_workshop_area on ID_Head_of_workshop_area = Head_of_workshop_area_ID join Staff on ID_Staff = Head_of_workshop_area.Staff_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                AreaGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => AreaGrid.Columns[2].Visibility = Visibility.Hidden;
                Loaded += (sender, args) => AreaGrid.Columns[3].Visibility = Visibility.Hidden;
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

        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeGrid.SelectedValue != null)
            {
                EmployeeBox.SelectedValue = ((DataRowView)EmployeeGrid.SelectedValue)[0].ToString();
            }
        }

        private void AreaGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AreaGrid.SelectedValue != null)
            {
                AreaEmployeeBox.SelectedValue = ((DataRowView)AreaGrid.SelectedValue)[2].ToString();
            }
        }

        private void UpdateAreaButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreaEmployeeBox.SelectedValue != null && AreaGrid.SelectedValue != null)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Area_of_workshop set Head_of_workshop_area_ID = {AreaEmployeeBox.SelectedValue} where Head_of_workshop_area_ID = '{((DataRowView)AreaGrid.SelectedValue)[2]}'", connection);
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
                AreaGridLoad();
                AreaGrid.Columns[2].Visibility = Visibility.Hidden;
                AreaGrid.Columns[3].Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Не был выбран начальник или участок");
            }
        }

        private void UpdateEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeBox.SelectedValue != null && EmployeeGrid.SelectedValue != null)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Head_of_workshop_area set Staff_ID = {EmployeeBox.SelectedValue} where ID_Head_of_workshop_area = {((DataRowView)EmployeeGrid.SelectedValue)[0]}", connection);
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
                AreaGridLoad();
                AreaEmployeeBoxLoad();
                EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
                EmployeeGrid.Columns[1].Visibility = Visibility.Hidden;
                AreaGrid.Columns[2].Visibility = Visibility.Hidden;
                AreaGrid.Columns[3].Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Не был выбран сотрудник или начальник");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }
    }
}
