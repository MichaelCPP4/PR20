using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPF_BD_PR10
{
    /// <summary>
    /// Логика взаимодействия для WindowAddRecord.xaml
    /// </summary>
    public partial class WindowAddRecord : Window
    {
        public WindowAddRecord()
        {
            InitializeComponent();
        }

        BdEntities db = BdEntities.GetContext();

        DirectoryOfEmployee o = new DirectoryOfEmployee();

        private void SaveDirectoryOfEmployees_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (!int.TryParse(idTextBox.Text, out int id)) errors.AppendLine("Введите id");
            if (!int.TryParse(serviceNumberTextBox.Text, out int serviceNumber)) errors.AppendLine("Введите табельный номер");
            if (surnameTextBox.Text.Length == 0) errors.AppendLine("Введите фамилия");
            if (categoryTextBox.Text.Length == 0) errors.AppendLine("Введите категорию");
            if (workshopTextBox.Text.Length == 0) errors.AppendLine("Введите цех");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            o.ID = id;
            o.ServiceNumber = serviceNumber;
            o.Surname = surnameTextBox.Text;
            o.Category = categoryTextBox.Text;
            o.Workshop = workshopTextBox.Text;


            try
            {
                db.DirectoryOfEmployees.Add(o);

                db.SaveChanges();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            /*
                        try
                        {
                            db.DirectoryOfEmployees.Add(o);

                            db.SaveChanges();

                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }*/
        }

        public void IsEdit()
        {
            if (saveDirectoryOfEmployees.Visibility == Visibility.Hidden)
            {
                idTextBox.IsEnabled = false;
                EditDirectoryOfEmployees.Visibility = Visibility.Visible;
                o = db.DirectoryOfEmployees.Find(Data.id);
                idTextBox.Text = o.ID.ToString();
                serviceNumberTextBox.Text = o.ServiceNumber.ToString();
                surnameTextBox.Text = o.Surname;
                categoryTextBox.Text = o.Category;
                workshopTextBox.Text = o.Workshop;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditDirectoryOfEmployees_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (!int.TryParse(idTextBox.Text, out int id)) errors.AppendLine("Введите id");
            if (!int.TryParse(serviceNumberTextBox.Text, out int serviceNumber)) errors.AppendLine("Введите табельный номер");
            if (surnameTextBox.Text.Length == 0) errors.AppendLine("Введите фамилия");
            if (categoryTextBox.Text.Length == 0) errors.AppendLine("Введите категорию");
            if (workshopTextBox.Text.Length == 0) errors.AppendLine("Введите цех");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            o.ID = id;
            o.ServiceNumber = serviceNumber;
            o.Surname = surnameTextBox.Text;
            o.Category = categoryTextBox.Text;
            o.Workshop = workshopTextBox.Text;


            try
            {
                db.SaveChanges();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}