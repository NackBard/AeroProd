using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AeroProd
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        string ident;
        public ProfilePage(string id, string level)
        {
            InitializeComponent();
            ident = id;
            if (level == "Администратор")
            {
                PhoneBox.IsReadOnly = false;
                AttributeBox.IsReadOnly = false;
                TimeBox.IsReadOnly = false;
                EmailBox.IsReadOnly = false;
                SerialPassport.IsReadOnly = false;
                PassportNumber.IsReadOnly = false;
                LastBox.IsReadOnly = false;
                NameBox.IsReadOnly = false;
                PatronymicBox.IsReadOnly = false;
            }
            else
            {
                PhoneBox.IsReadOnly = true;
                AttributeBox.IsReadOnly = true;
                TimeBox.IsReadOnly = true;
                EmailBox.IsReadOnly = true;
                SerialPassport.IsReadOnly = true;
                PassportNumber.IsReadOnly = true;
                LastBox.IsReadOnly = true;
                NameBox.IsReadOnly = true;
                PatronymicBox.IsReadOnly = true;
            }
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter($"select*from Staff where ID_Staff = {id}", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                PhoneBox.Text = dt.Rows[0][8].ToString();
                AttributeBox.Text = dt.Rows[0][6].ToString();
                TimeBox.Text = dt.Rows[0][10].ToString();
                EmailBox.Text = dt.Rows[0][7].ToString();
                string numpassport = dt.Rows[0][9].ToString();
                PassportNumber.Text = numpassport.Substring(0, 4);
                SerialPassport.Text = numpassport.Substring(4, 5);
                LastBox.Text = dt.Rows[0][1].ToString();
                NameBox.Text = dt.Rows[0][2].ToString();
                PatronymicBox.Text = dt.Rows[0][3].ToString();
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
            try
            {
                connection.Open();
                cmd = new SqlCommand($"update Staff set LastName = '{LastBox.Text}', FirstName = '{NameBox.Text}', Patronymic = '{PatronymicBox.Text}', Attribute = '{AttributeBox.Text}', Mail = '{EmailBox.Text}', Phone_number = '{PhoneBox.Text}',Passport = '{PassportNumber.Text + SerialPassport.Text}' where ID_Staff = {ident}", connection);
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
            MainWindow.FrameInstance.GoBack();
        }
    }
}
