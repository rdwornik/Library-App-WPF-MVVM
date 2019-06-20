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
using System.Windows.Shapes;

namespace egui_project.Views
{
    /// <summary>
    /// Interaction logic for EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        MainViewModel mainVM;

        public EditBookWindow(Book book, MainViewModel mainVM)
        {
            this.InitializeComponent();
            this.mainVM = mainVM;
            this.DataContext = book;
        }

        private void EditBook_Clicked(object sender, RoutedEventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(TextBoxYear.Text) || String.IsNullOrEmpty(TextBoxAuthor.Text) || String.IsNullOrEmpty(TextBoxTitle.Text))
                MessageBox.Show("non of fields can be empty");
            else if ((!(Int32.TryParse(TextBoxYear.Text, out number))))
                MessageBox.Show("The year must be integer");
            else if (number < 10 || number > 3000)
                MessageBox.Show("The age must be between 10 and 3000");
            else
            {
                BindingExpression author = TextBoxAuthor.GetBindingExpression(TextBox.TextProperty);
                BindingExpression title = TextBoxTitle.GetBindingExpression(TextBox.TextProperty);
                BindingExpression year = TextBoxYear.GetBindingExpression(TextBox.TextProperty);

                author.UpdateSource();
                title.UpdateSource();
                year.UpdateSource();
                mainVM.BooksView.Refresh();
                mainVM.UpdateYears();
                this.Close();
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
