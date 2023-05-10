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
    public partial class TariffReferenceWindow : Window
    {
        public TariffReferenceWindow()
        {
            InitializeComponent();
        }

        BdEntities db = BdEntities.GetContext();

        TariffReference o = new TariffReference();

        private void SaveRate_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (!int.TryParse(rateTextBox.Text, out int rate)) errors.AppendLine("Введите ставку");
            if (categoryTextBox.Text.Length == 0) errors.AppendLine("Введите категорию");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            o.rate = rate;
            o.Category = categoryTextBox.Text;

            try
            {
                db.TariffReferences.Add(o);

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
            if (saveRate.Visibility == Visibility.Hidden)
            {
                EditRate.Visibility = Visibility.Visible;
                o = db.TariffReferences.Find(Data.str);
                categoryTextBox.Text = o.Category;
                rateTextBox.Text = o.rate.ToString();
                categoryTextBox.IsEnabled= false;
            }
        }

        private void EditRate_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (!int.TryParse(rateTextBox.Text, out int rate)) errors.AppendLine("Введите ставку");
            //if (categoryTextBox.Text.Length == 0) errors.AppendLine("Введите категорию");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            o.rate = rate;
            //o.Category = categoryTextBox.Text;

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
