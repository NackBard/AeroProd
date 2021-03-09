
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для TesterPage.xaml
    /// </summary>
    public partial class TesterPage : Page
    {
        string FilePath, NewFilePath, employee;
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public TesterPage(string id)
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            MessageGridLoad();
            employee = id;
        }
        public void MessageGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("SELECT ID_Report,Report_Name + ' - ' + LastName + ' ' + FirstName + ' ' + Patronymic as 'Отчёты' from Report join Staff on ID_Staff = Staff_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                MessageGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => MessageGrid.Columns[0].Visibility = Visibility.Hidden;
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

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a file";

                bool? myResult;
                myResult = op.ShowDialog();
                if (myResult != null && myResult == true)
                {
                    string filePath = @"C:\Users\Артём\source\repos\AeroProd\AeroProd\Files\" + System.IO.Path.GetFileName(op.FileName);
                    NewFilePath = filePath;
                    FilePath = op.FileName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void MessageGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter($"SELECT Content_of_report from Report where ID_Report = {((DataRowView)MessageGrid.SelectedValue)[0]}", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                LoadMessage.Text = dt.Rows[0][0].ToString();
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

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameMessage.Text == null || Message.Text == null || FilePath == null)
            {
                MessageBox.Show("Не все данные были опубликованы");
            }
            else
            {
                File.Copy(FilePath, NewFilePath, true);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"INSERT INTO Report (Content_of_report, Staff_ID, Path_to_file, Report_Name) values ('{Message.Text}', {employee}, '{NewFilePath}', '{NameMessage.Text}')", connection);
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
                MessageGridLoad();
                MessageGrid.Columns[0].Visibility = Visibility.Hidden;
            }
        }
        }
    }

