using HL6RQ1_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                //if (value != null)
                //{
                //    selectedAuthor = new Author()
                //    {
                //        Name = value.Name,
                //        authorId = value.authorId,
                //    };

                //}              
            }
        }


        public ICommand CreateBookCommand { get; set; }

        public ICommand DeleteBookCommand { get; set; }

        public ICommand UpdateBookCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BookWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                Books = new RestCollection<Book>("http://localhost:54941/", "book", "hub");

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
}
