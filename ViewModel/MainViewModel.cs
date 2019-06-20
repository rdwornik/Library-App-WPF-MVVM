using CsvHelper;
using egui_project.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace egui_project.ViewModel
{
    public class MainViewModel : ObesrvableObject
    {
        public MainViewModel()
        {
            LoadBooksAndYears();
  
            SearchTitle = "";
            SearchAuthor = "";
            SearchYear = "";
            BooksView.Filter = new Predicate<object>(o => Filter(o as Book));
        }

        private ObservableCollection<int> years;
        public ObservableCollection<int> Years
        {
            get { return years; }
            set
            {
                years = value;
                OnPropertyChanged("Years");
            }
        }

        public ObservableCollection<Book> Books
        {
            get;
            set;
        }

        public ICollectionView BooksView
        {
            get { return CollectionViewSource.GetDefaultView(Books);}
        }

        private bool Filter(Book book)
        {
            if (SearchYear == null)
                SearchYear = "";
            return 
            book.Author.IndexOf(SearchAuthor, StringComparison.OrdinalIgnoreCase) != -1
            && book.Title.IndexOf(SearchTitle, StringComparison.OrdinalIgnoreCase) != -1
            && book.Year.IndexOf(SearchYear, StringComparison.OrdinalIgnoreCase) != -1;
        }

        private string searchAuthor;
        public string SearchAuthor
        {
            get { return searchAuthor; }
            set
            {
                
                searchAuthor = value;
                OnPropertyChanged("SearchAuthor");
                   
            }
        }

        private string searchTitle;
        public string SearchTitle
        {
            get { return searchTitle; }
            set
            {      
                searchTitle = value;
                OnPropertyChanged("SearchTitle");
                
            }
        }

        private string searchYear;
        public string SearchYear
        {
            get { return searchYear; }
            set
            {
                searchYear = value;
                OnPropertyChanged("SearchYear");  
            }
        }

        public void LoadBooksAndYears() //loading books from csv files
        {
            using (var reader = new StreamReader("C:\\Users\\01112268\\Documents\\VisualStudio2015\\Projects\\egui-project\\EGUI-Library-in-WPF\\egui-project\\dane2.csv"))
            using (var csv = new CsvReader(reader))
            { 
                List<Book> result = new List<Book>();
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                result = csv.GetRecords<Book>().ToList();
                Books = new ObservableCollection<Book>(result);
                UpdateYears();              
            }
        }

        public void UpdateYears()
        {
            var list = Books.Select(bo => bo.Year).Distinct().ToList().Select(int.Parse).ToList();
            list.Sort();
            Years = new ObservableCollection<int>(list);
        }
      
    }
}
