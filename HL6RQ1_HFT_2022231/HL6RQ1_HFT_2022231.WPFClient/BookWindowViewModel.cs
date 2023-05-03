using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HL6RQ1_HFT_2022231.WPFClient
{
    public class BookWindowViewModel
    {
        public RestCollection<Book> Books { get; set; }

        public ICommand CreateBookCommand { get; set; }

        public ICommand DeleteBookCommand { get; set; }

        public ICommand UpdateBookCommand { get; set; }

        public BookWindowViewModel()
        {
            Books = new RestCollection<Book>("http://localhost:54941/","book");
        }
    }
}
