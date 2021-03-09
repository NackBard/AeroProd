using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    public partial class StaffPage : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        string idEmployee;
        DateTime start, end;
        public StaffPage(string id)
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            idEmployee = id;
            StaffGirdLoad();
        }
        private void StaffGirdLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter($"select LastName + ' ' + FirstName+ ' ' + Patronymic as 'Бригадир', Brigade_ID as 'Номер бригады', Workshop_of_area_ID as 'Участок'  from Last_of_brigade join Brigade on ID_Brigade = Brigade_ID join Foreman on ID_Foreman = Foreman_ID JOIN Staff on ID_Staff = Foreman.Staff_ID where Last_of_brigade.Staff_ID = {idEmployee}", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                StaffGrid.ItemsSource = dt.DefaultView;
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

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            end = DateTime.Now;
            try
            {
                connection.Open();
                cmd = new SqlCommand($"INSERT INTO Journal_of_attendance(Begin_shift, Staff_ID, End_Shift) values ('{start}',{idEmployee},'{end}')", connection);
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.Navigate(new ProfilePage(idEmployee, "Работник"));
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            start = DateTime.Now;
        }

    }
}
