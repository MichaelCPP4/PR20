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
    /// Логика взаимодействия для WindowListOfWorkshops.xaml
    /// </summary>
    public partial class WindowListOfWorkshops : Window
    {
        public WindowListOfWorkshops()
        {
            InitializeComponent();
        }
        BdEntities db = BdEntities.GetContext();

        ListOfWorkshop o = new ListOfWorkshop();

        private void SaveListOfWorkshop_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (workshopTextBox.Text.Length == 0) errors.AppendLine("Введите цех");
            if (workshopNameTextBox.Text.Length == 0) errors.AppendLine("Введите название цех");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            o.Workshop = workshopTextBox.Text;
            o.WorkshopName = workshopNameTextBox.Text;

            try
            {
                db.ListOfWorkshops.Add(o);

                db.SaveChanges();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void IsEdit()
        {
            if (saveListOfWorkshop.Visibility == Visibility.Hidden)
            {
                editListOfWorkshop.Visibility = Visibility.Visible;
                o = db.ListOfWorkshops.Find(Data.str);
                workshopTextBox.Text = o.Workshop;
                workshopNameTextBox.Text = o.WorkshopName.ToString();
                workshopTextBox.IsEnabled = false;
            }
        }

        private void EditListOfWorkshop_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //if (workshopTextBox.Text.Length == 0) errors.AppendLine("Введите цех");
            if (workshopNameTextBox.Text.Length == 0) errors.AppendLine("Введите название цех");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            //o.Workshop = workshopTextBox.Text;
            o.WorkshopName = workshopNameTextBox.Text;

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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}