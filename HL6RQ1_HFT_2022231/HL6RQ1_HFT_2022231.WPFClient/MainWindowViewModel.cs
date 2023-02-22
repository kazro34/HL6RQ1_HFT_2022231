using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.WPFClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Book> Books { get; set; }

        public MainWindowViewModel()
        {
            Books = new RestCollection<Book>("http://localhost:54941/", "book");
        }
    }
}
