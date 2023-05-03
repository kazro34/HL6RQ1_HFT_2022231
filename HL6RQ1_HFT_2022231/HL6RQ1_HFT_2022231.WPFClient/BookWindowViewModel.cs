using HL6RQ1_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HL6RQ1_HFT_2022231.WPFClient
{
    public class BookWindowViewModel : ObservableRecipient
    {
        public RestCollection<Book> Books { get; set; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                SetProperty(ref selectedBook, value);
                (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateBookCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateBookCommand { get; set; }

        public ICommand DeleteBookCommand { get; set; }

        public ICommand UpdateBookCommand { get; set; }

        public BookWindowViewModel()
        {
            Books = new RestCollection<Book>("http://localhost:54941/","book");

            CreateBookCommand = new RelayCommand(() =>
            {
                Books.Add(new Book()
                {
                    Title = SelectedBook.Title
                });
            });

            UpdateBookCommand = new RelayCommand(() =>
            {
                Books.Update(SelectedBook);
            });

            DeleteBookCommand = new RelayCommand(() =>
            {
                Books.Delete(SelectedBook.Id);
            },
            () =>
            {
                return SelectedBook != null;
            });
        }
    }
}
