using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для LaboratoryList.xaml
    /// </summary>
    public partial class LaboratoryList : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public LaboratoryList()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            TargetBoxLoad();
            LabGridLoad();
            TargetGridLoad();
        }
        private void TargetBoxLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select*from Target_of_laboratory", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                TargetBox.ItemsSource = dt.DefaultView;
                TargetBox.DisplayMemberPath = "Name";
                TargetBox.SelectedValuePath = "ID_Target";
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
        private void LabGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select ID_Laboratory, Laboratory.Name as 'Лаборатория',Target_ID,Target_of_laboratory.Name as 'Назначение'  from Laboratory join Target_of_laboratory on ID_Target =Target_ID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                LabGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => LabGrid.Columns[0].Visibility = Visibility.Hidden;
                Loaded += (sender, args) => LabGrid.Columns[2].Visibility = Visibility.Hidden;
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
        private void TargetGridLoad()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select*from Target_of_laboratory", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                TargetGrid.ItemsSource = dt.DefaultView;
                Loaded += (sender, args) => TargetGrid.Columns[0].Visibility = Visibility.Hidden;
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

        private void TargetGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TargetGrid.SelectedValue != null)
            {
                NameTargetBox.Text = ((DataRowView)TargetGrid.SelectedValue)[1].ToString();
            }
        }

        private void LabGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LabGrid.SelectedValue != null)
            {
                LabName.Text = ((DataRowView)LabGrid.SelectedValue)[1].ToString();
                TargetBox.SelectedValue = ((DataRowView)LabGrid.SelectedValue)[2];
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameInstance.GoBack();
        }

        private void UpdateLabButton_Click(object sender, RoutedEventArgs e)
        {
            if (TargetBox.SelectedValue != null && LabGrid.SelectedValue != null && LabName.Text != null)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Laboratory set Target_ID = {TargetBox.SelectedValue}, Name = {LabName.Text} where ID_Laboratory = '{((DataRowView)LabGrid.SelectedValue)[0]}'", connection);
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
                LabGridLoad();
                LabGrid.Columns[0].Visibility = Visibility.Hidden;
                LabGrid.Columns[2].Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Не была выбрана лаборатория или не введены все данные");
            }
        }

        private void UpdateTargetButton_Click(object sender, RoutedEventArgs e)
        {
            if (TargetGrid.SelectedValue != null && NameTargetBox.Text != null)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand($"update Target_of_laboratory set  Name = {NameTargetBox.Text} where ID_Target = '{((DataRowView)TargetGrid.SelectedValue)[0]}'", connection);
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
                TargetGridLoad();
                TargetGrid.Columns[0].Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Не была выбрана лаборатория или не введены все данные");
            }
        }
    }
}
