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
    /// Логика взаимодействия для ReportCardWindow.xaml
    /// </summary>
    public partial class ReportCardWindow : Window
    {
        BdEntities db = BdEntities.GetContext();

        ReportCard o = new ReportCard();

        public ReportCardWindow()
        {
            InitializeComponent();
        }

        private void SaveReportCard_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (!int.TryParse(serviceNumberTextBox.Text, out int serviceNumber)) errors.AppendLine("Введите табельный номер");
            if (!int.TryParse(timeWorkedInHoursTextBox.Text, out int timeWorkedHours)) errors.AppendLine("Введите стоимость тарифа");
            if (!int.TryParse(monthNumberTextBox.Text, out int monthNumber)) errors.AppendLine("Введите номер месяца");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            o.ServiceNumber = serviceNumber;
            o.TimeWorkedInHours = timeWorkedHours;
            o.MonthNumber = monthNumber;

            try
            {
                db.ReportCards.Add(o);

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
            if (saveReportCard.Visibility == Visibility.Hidden)
            {
                editReportCard.Visibility = Visibility.Visible;
                o = db.ReportCards.Find(Data.id);
                serviceNumberTextBox.Text = o.ServiceNumber.ToString();
                timeWorkedInHoursTextBox.Text = o.TimeWorkedInHours.ToString();
                monthNumberTextBox.Text = o.MonthNumber.ToString();
                serviceNumberTextBox.IsEnabled = false;
            }
        }

        private void EditReportCard_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //if (!int.TryParse(serviceNumberTextBox.Text, out int serviceNumber)) errors.AppendLine("Введите табельный номер");
            if (!int.TryParse(timeWorkedInHoursTextBox.Text, out int timeWorkedHours)) errors.AppendLine("Введите стоимость тарифа");
            if (!int.TryParse(monthNumberTextBox.Text, out int monthNumber)) errors.AppendLine("Введите номер месяца");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            //o.ServiceNumber = serviceNumber;
            o.TimeWorkedInHours = timeWorkedHours;
            o.MonthNumber = monthNumber;

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
