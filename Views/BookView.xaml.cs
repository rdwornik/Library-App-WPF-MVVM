using egui_project.Model;
using egui_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace egui_project.Views
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BookView : UserControl
    {
        MainViewModel mainVM = new MainViewModel();

       
 
        public BookView()
        {
            InitializeComponent();
            this.DataContext = mainVM;  
        }

        private void OpenAddBookWindow_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow(mainVM);
            addBookWindow.ShowDialog();
        }

        private void OpenEditWindow_Click(object sender, RoutedEventArgs e)
        {
            Book item = (Book)dataGrid.SelectedItem;
            EditBookWindow edit = new EditBookWindow(item,mainVM);
            edit.ShowDialog();
        }

        private void DeleteItems_Click(object sender, RoutedEventArgs e)
        {
           System.Collections.IList items = (System.Collections.IList)dataGrid.SelectedItems;

            if (dataGrid.SelectedItems.Count > 0)
            {
                var selectedBooks = items.Cast<Book>().ToList();

                foreach (Book book in selectedBooks)
                {
                    Book toDel = (from bo in mainVM.Books
                                  where bo == book
                                  select bo
                                  ).First();
                    mainVM.Books.Remove(toDel);
                }
            }
            mainVM.UpdateYears();
        }

        private void FilterItems_Click(object sender, RoutedEventArgs e)
        {
            mainVM.BooksView.Refresh();    
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = -1;
            FilterAuthor.Text = "";
            FilterTitle.Text = "";
            mainVM.BooksView.Refresh(); 
        }
    }
}
