using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace egui_project.Model
{
    class BookModel
    {
    }
    public class Book : ObesrvableObject
    {
        private string author;
        private string title;
        private string year;

      
        public string Author
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Author");
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string Title
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Title");
            }
        }

        public string Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

    
    }
}
