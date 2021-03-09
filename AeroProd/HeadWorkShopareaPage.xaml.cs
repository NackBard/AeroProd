using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{

    public partial class HeadWorkShopareaPage : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public HeadWorkShopareaPage(string id)
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            AreaGridLoad();
            BrigadeGridLoad();
            EmployeeGridLoad();
        }

        private void AreaGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Area_of_workshop as 'Номер участка', Workshop_ID as 'Номер цеха', LastName + ' ' + FirstName + ' ' + Patronymic as 'Начальник участка' from Area_of_workshop join Head_of_workshop_area on ID_Head_of_workshop_area = Head_of_workshop_area_ID join Staff on ID_Staff = Staff_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                AreaGrid.ItemsSource = dt.DefaultView;
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
        private void BrigadeGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Brigade as 'Номер бригады', Workshop_of_area_ID as 'Номер участка', LastName + ' ' + FirstName + ' ' + Patronymic as 'Бригадир' from Brigade join Area_of_workshop on ID_Area_of_workshop = Workshop_of_area_ID join Foreman on ID_FOreman = Foreman_ID join Staff on ID_Staff = Staff_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BrigadeGrid.ItemsSource = dt.DefaultView;
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
                adapter = new SqlDataAdapter("select ID_Staff, LastName as 'Фамилия', FirstName as 'Имя', Patronymic as 'Отчество', Position.Name as 'Должность', Brigade_ID as 'Номер бригады' from Staff join Position on ID_Position = Position_ID join Last_of_brigade on Staff_ID = ID_Staff", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                EmployeeGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => EmployeeGrid.Columns[0].Visibility = Visibility.Hidden;
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

        private void AddtoBrigade_Click(object sender, RoutedEventArgs e)
        {
            if(BrigadeGrid.SelectedValue != null && EmployeeGrid.SelectedValue != null)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Last_of_brigade set Brigade_ID = {((DataRowView)BrigadeGrid.SelectedValue)[0]} where Staff_ID = {((DataRowView)EmployeeGrid.SelectedValue)[0]} ", connection);
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
            }
            else
            {
                MessageBox.Show("Выберите бригаду и сотрудника");
            }
        }

        private void AddtoArea_Click(object sender, RoutedEventArgs e)
        {
            if (BrigadeGrid.SelectedValue != null && AreaGrid.SelectedValue != null)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Brigade set Workshop_of_area_ID = {((DataRowView)AreaGrid.SelectedValue)[0]} where ID_Brigade = {((DataRowView)BrigadeGrid.SelectedValue)[0]} ", connection);
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
                BrigadeGridLoad();
                BrigadeGrid.Columns[0].Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Выберите бригаду и сотрудника");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }
    }
}
