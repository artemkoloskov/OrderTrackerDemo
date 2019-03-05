using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;

namespace OrderTrackerDemo
{
    /// <summary>
    /// Логика взаимодействия для ClientDataForm.xaml
    /// </summary>
    public partial class ClientDataForm : Window
    {
        private Context db;
        private List<Order> clientOrders = new List<Order>();

        public ClientDataForm(int clientId)
        {
            InitializeComponent();

            db = new Context();
            db.Clients.Load();
            db.Products.Load();
            db.Orders.Load();

            Client client = GetClient(clientId);

            if (client != null)
            {
                idLabel.Content = client.ID;
                clientNameLabel.Content = client.FirstName + " " + client.SecondName;
                phoneNumberLabel.Content = client.PhoneNumber;
                addressLabel.Content = client.Address;
            }
            else
            {
                idLabel.Content = "";
                clientNameLabel.Content = "";
                phoneNumberLabel.Content = "";
                addressLabel.Content = "";
            }

            clientOrders = GetClientOrders(clientId);

            ordersDataGrid.ItemsSource = clientOrders;
        }

        private Client GetClient (int clientId)
        {
            foreach (Client client in db.Clients)
            {
                if (client.ID == clientId)
                {
                    return client;
                }
            }

            return null;
        }

        private List <Order> GetClientOrders (int clientId)
        {
            List<Order> clientOrders = new List<Order>();

            foreach (Order order in db.Orders)
            {
                if (order.ClientID == clientId)
                {
                    Product product = db.Products.Find(order.ProductID);

                    order.Name = product.Name;
                    order.Price = product.Price;

                    clientOrders.Add(order);
                }
            }

            return clientOrders;
        } 
    }
}
