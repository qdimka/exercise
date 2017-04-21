using exercise.Domain;
using exercise.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exercise
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMailService service;
        IDatabaseRepository repo;

        string moderatorEmail = "moder@mail.ru";
        
        public MainWindow()
        {
            InitializeComponent();

            service = new MessageBoxMailService();

            repo = new DataBaseRepository();
        }

        private void postButton_Click(object sender, RoutedEventArgs e)
        {
            string title = postTitle.Text;

            if (String.IsNullOrEmpty(title))
            {
                return;
            }

            if (!repo.isPostExists(title))
            {
                //insert into db
                string message = $"{title} создан!";
                service.SendMessage(message, moderatorEmail);
            }
        }

        private void categoryButton_Click(object sender, RoutedEventArgs e)
        {
            string title = categoryTitle.Text;

            if (String.IsNullOrEmpty(title))
            {
                return;
            }

            if (!repo.isCategoriesExists(title))
            {
                //insert into db
                string message = $"{title} создан!";
                service.SendMessage(message, moderatorEmail);
            }
        }
    }
}
