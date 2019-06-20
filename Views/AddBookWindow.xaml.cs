using egui_project.Model;
using egui_project.ViewModel;
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
using egui_project.ViewModel;

namespace egui_project.Views
{
    /// <summary>
    /// Interaction logic for DialogView.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        MainViewModel mainVM;
        Book book;

        public AddBookWindow(MainViewModel mainVM)
        {
            InitializeComponent();
            this.mainVM = mainVM;
            this.book = new Book();
            this.DataContext = book;          
        }

        private void AddBook_Clicked(object sender, RoutedEventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(TextBoxYear.Text) || String.IsNullOrEmpty(TextBoxAuthor.Text) || String.IsNullOrEmpty(TextBoxTitle.Text ))
                MessageBox.Show("non of fields can be empty");
            else if ((!(Int32.TryParse(TextBoxYear.Text, out number))))
                MessageBox.Show("The year must be integer");
            else if (number < 10 || number > 3000)
                MessageBox.Show("The age must be between 10 and 3000");
            else
            {
                Book item = (Book)(this.DataContext);
                mainVM.Books.Insert(0, item);
                mainVM.BooksView.Refresh();
                mainVM.UpdateYears();
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            mainVM.BooksView.Refresh();
            this.Close();
        }
    }
}
