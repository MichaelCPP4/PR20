using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace WPF_BD_PR10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BdEntities db = BdEntities.GetContext();

        DirectoryOfEmployee o = new DirectoryOfEmployee();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.ListOfWorkshops.Load();
            db.ReportCards.Load();
            db.TariffReferences.Load();
            db.DirectoryOfEmployees.Load();
            dataGrid_DirectoryOfEmployees.ItemsSource = db.DirectoryOfEmployees.Local.ToBindingList();
            dataGrid_ReportCard.ItemsSource = db.ReportCards.Local.ToBindingList();
            dataGrid_TariffReference.ItemsSource = db.TariffReferences.Local.ToBindingList();
            dataGrid_ListOfWorkshops.ItemsSource = db.ListOfWorkshops.Local.ToBindingList();
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            ReportCardWindow windowAddRecord = new ReportCardWindow();
            windowAddRecord.Owner = this;
            windowAddRecord.ShowDialog();
        }

        private void Add_DirectoryOfEmployees_Click(object sender, RoutedEventArgs e)
        {
            WindowAddRecord windowAddRecord = new WindowAddRecord();
            windowAddRecord.Owner = this;
            windowAddRecord.ShowDialog();
        }

        private void Add_TariffReference_Click(object sender, RoutedEventArgs e)
        {
            TariffReferenceWindow windowAddRecord = new TariffReferenceWindow();
            windowAddRecord.Owner = this;
            windowAddRecord.ShowDialog();
        }

        private void Add_ListOfWorkshops_Click(object sender, RoutedEventArgs e)
        {
            WindowListOfWorkshops windowAddRecord = new WindowListOfWorkshops();
            windowAddRecord.Owner = this;
            windowAddRecord.ShowDialog();
        }

        private void LinqButton_Click(object sender, RoutedEventArgs e)
        {
            var employeesInDepartment = from ee in db.DirectoryOfEmployees join t in db.TariffReferences on ee.Category equals t.Category
                                        select new
                                        {
                                            WorkshopName = ee.Workshop,
                                            LastName = ee.Surname,
                                            Rank = ee.Category,
                                            Rate = t.rate
                                        };

            dataGrid_ListOfEmployees.ItemsSource = employeesInDepartment.ToList();



            var result = db.ListOfWorkshops
        .Select(d => new
        {
            DepartmentName = d.Workshop,
            WorkersCount = db.DirectoryOfEmployees.Count(w => w.Workshop == d.Workshop)
        }).ToList();


            dataGrid_ListOfEmployees2.ItemsSource = result.ToList();
        }

        private void Edit_TariffReference_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid_TariffReference.SelectedIndex;
            if (indexRow != -1)
            {
                TariffReference row = (TariffReference)dataGrid_TariffReference.Items[indexRow];
                Data.str = row.Category.ToString();
                TariffReferenceWindow windowEdit = new TariffReferenceWindow();
                windowEdit.saveRate.Visibility = Visibility.Hidden;
                windowEdit.IsEdit();
                windowEdit.Owner = this;
                windowEdit.ShowDialog();
            }
        }

        private void Edit_ReportCard_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid_ReportCard.SelectedIndex;
            if (indexRow != -1)
            {
                ReportCard row = (ReportCard)dataGrid_ReportCard.Items[indexRow];
                Data.id = row.ServiceNumber;
                ReportCardWindow windowEdit = new ReportCardWindow();
                windowEdit.saveReportCard.Visibility = Visibility.Hidden;
                windowEdit.IsEdit();
                windowEdit.Owner = this;
                windowEdit.ShowDialog();
            }
        }

        private void Edit_ListOfWorkshops_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid_ListOfWorkshops.SelectedIndex;
            if (indexRow != -1)
            {
                ListOfWorkshop row = (ListOfWorkshop)dataGrid_ListOfWorkshops.Items[indexRow];
                Data.str = row.Workshop;
                WindowListOfWorkshops windowEdit = new WindowListOfWorkshops();
                windowEdit.saveListOfWorkshop.Visibility = Visibility.Hidden;
                windowEdit.IsEdit();
                windowEdit.Owner = this;
                windowEdit.ShowDialog();
            }
        }
        private void Edit_DirectoryOfEmployees_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid_DirectoryOfEmployees.SelectedIndex;
            if (indexRow != -1)
            {
                DirectoryOfEmployee row = (DirectoryOfEmployee)dataGrid_DirectoryOfEmployees.Items[indexRow];
                Data.id = row.ID;
                WindowAddRecord windowEdit = new WindowAddRecord();
                windowEdit.saveDirectoryOfEmployees.Visibility = Visibility.Hidden;
                windowEdit.IsEdit();
                windowEdit.Owner = this;
                windowEdit.ShowDialog();
            }
        }
        private void Delete_TariffReference_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    TariffReference row = (TariffReference)dataGrid_TariffReference.SelectedItems[0];

                    db.TariffReferences.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {

                    MessageBox.Show("Есть связанная таблица");
                }



                /*
                try
                {
                    if (db.DirectoryOfEmployees.Find(o.TariffReference) != null)
                    {
                        TariffReference row = (TariffReference)dataGrid_TariffReference.SelectedItems[0];

                        db.TariffReferences.Remove(row);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Есть связанная таблица");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                    MessageBox.Show("Выберите запись");
                }*/
            }
            }

        private void Delete_ListOfWorkshops_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ListOfWorkshop row = (ListOfWorkshop)dataGrid_ListOfWorkshops.SelectedItem;

                    db.ListOfWorkshops.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Есть связанная таблица");
                }

/*
 * 
 * 
                try
                {
                    if (db.DirectoryOfEmployees.Find((ListOfWorkshop)dataGrid_ListOfWorkshops.SelectedItems[0]) == null)
                    {
                        ListOfWorkshop row = (ListOfWorkshop)dataGrid_ListOfWorkshops.SelectedItems[0];

                        db.ListOfWorkshops.Remove(row);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Есть связанная таблица");
                    }

                    *//*
                                        ListOfWorkshop row = (ListOfWorkshop)dataGrid_ListOfWorkshops.SelectedItems[0];

                                        db.ListOfWorkshops.Remove(row);
                                        db.SaveChanges();*//*

                }
                catch (ArgumentOutOfRangeException)
                {

                    MessageBox.Show("Выберите запись");
                }*/
            }
        }

        private void Delete_ReportCard_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            ReportCard o = new ReportCard();
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ReportCard row = (ReportCard)dataGrid_ReportCard.SelectedItems[0];

                    db.ReportCards.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {

                    MessageBox.Show("Есть связанная таблица");
                }

                /*try
                {
                    if (db.DirectoryOfEmployees.Find(o.ServiceNumber) != null)
                    {
                        ReportCard row = (ReportCard)dataGrid_ReportCard.SelectedItems[0];

                        db.ReportCards.Remove(row);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Есть связанная таблица");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                    MessageBox.Show("Выберите запись");
                }*/
            }
        }

        private void Delete_DirectoryOfEmployees_CLick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                        DirectoryOfEmployee row = (DirectoryOfEmployee)dataGrid_DirectoryOfEmployees.SelectedItems[0];

                        db.DirectoryOfEmployees.Remove(row);
                        db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {

                    MessageBox.Show("Есть связанная таблица");
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автор: Иванов Михаил ИСП-31\n1. Спроектировать и создать многотабличную БД в SQL server. Для удобства дальнейшей \r\nразработки заполните БД несколькими связанными записями (5-10 в зависимости от \r\nлогики важности информации).\r\n2. Разработать интерфейс программы Visual Studio C#, который содержит:\r\n• Главную форму. \r\n• Формы справочников. Для форм справочников реализовать операции \r\nдобавления, удаления записей. \r\n3. Разработать SQL запросы с участием одной или нескольких таблиц по заданию.\r\nИспользовать представления или LINQ.\r\n4. Реализовать функцию Поиск \r\n", "О программе");
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid_DirectoryOfEmployees.Items.Count; i++)
            {
                var row = (DirectoryOfEmployee)dataGrid_DirectoryOfEmployees.Items[i];
                string findContent = row.Surname;
                try
                {
                    if (findContent != null && findContent.Contains(txtFind.Text))
                    {
                        object item = dataGrid_DirectoryOfEmployees.Items[i];
                        dataGrid_DirectoryOfEmployees.SelectedItem = item;
                        dataGrid_DirectoryOfEmployees.ScrollIntoView(item);
                        dataGrid_DirectoryOfEmployees.Focus();
                        break;
                    }
                }
                catch { }
            }
        }

        private void FindReportCard_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid_ReportCard.Items.Count; i++)
            {
                var row = (ReportCard)dataGrid_ReportCard.Items[i];
                string findContent = row.MonthNumber.ToString();
                try
                {
                    if (findContent != null && findContent.Contains(txtFindRepordCard.Text))
                    {
                        object item = dataGrid_ReportCard.Items[i];
                        dataGrid_ReportCard.SelectedItem = item;
                        dataGrid_ReportCard.ScrollIntoView(item);
                        dataGrid_ReportCard.Focus();
                        break;
                    }
                }
                catch { }
            }
        }

        private void FindListOfWorkshops_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid_ListOfWorkshops.Items.Count; i++)
            {
                var row = (ListOfWorkshop)dataGrid_ListOfWorkshops.Items[i];
                string findContent = row.WorkshopName;
                try
                {
                    if (findContent != null && findContent.Contains(txtFind_ListOfWorkshops.Text))
                    {
                        object item = dataGrid_ListOfWorkshops.Items[i];
                        dataGrid_ListOfWorkshops.SelectedItem = item;
                        dataGrid_ListOfWorkshops.ScrollIntoView(item);
                        dataGrid_ListOfWorkshops.Focus();
                        break;
                    }
                }
                catch { }
            }
        }
    }
}
