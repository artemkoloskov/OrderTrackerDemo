using System;
using System.Windows;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace OrderTrackerDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context db;

        public MainWindow()
        {
            InitializeComponent();

            Update();
            
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Update()
        {
            db = new Context();
            db.Clients.Load();

            clientsDataGrid.ItemsSource = db.Clients.Local.ToBindingList();
        }

        private void OpenClientDetailsButton_Click (object sender, RoutedEventArgs e)
        {
            if (clientsDataGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < clientsDataGrid.SelectedItems.Count; i++)
                {
                    if (clientsDataGrid.SelectedItems[i] is Client client)
                    {
                        ClientDataForm clientDataForm = new ClientDataForm(client.ID);
                        clientDataForm.Show();
                    }
                }
            }
        }

        private void DeleteClientButton_Click (object sender, RoutedEventArgs e)
        {
            if (clientsDataGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < clientsDataGrid.SelectedItems.Count; i++)
                {
                    if (clientsDataGrid.SelectedItems[i] is Client client)
                    {
                        db.Clients.Remove(client);
                    }
                }
            }

            db.SaveChanges();

            Update();
        }

        private void UpdateClientsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in clientsDataGrid.Items)
            {
                if (item is Client client)
                {
                    if (client.PhoneNumber != null)
                    {
                        Match match = Regex.Match(client.PhoneNumber, @"^\+7?\d{10}");

                        if (!(match.Success && client.PhoneNumber.Length == 12))
                        {
                            MessageBox.Show("Проверьте введенный телефонный номер на соответствие шаблону", "ID " + client.ID + " " + client.FirstName + " " + client.SecondName,
                                MessageBoxButton.OK, MessageBoxImage.Error);

                            return;
                        }
                    }
                }
                else
                {
                    Console.Write("вранье, " + item + " не долбанный клиент");
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException exception)
            {
                MessageBox.Show("Имя и фамилия - обязательные поля для заполнения", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);

                Console.Write(exception);
            }

            Update();
        }
    }
}