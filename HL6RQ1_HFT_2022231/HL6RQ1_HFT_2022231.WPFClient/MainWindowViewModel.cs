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
    public class MainWindowViewModel: ObservableRecipient
    {
        public RestCollection<Author> Authors { get; set; }

        private Author selectedAuthor;

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set {
                     SetProperty(ref selectedAuthor, value);
                     (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
        }


        public ICommand CreateAuthorCommand { get; set; }

        public ICommand DeleteAuthorCommand { get; set; }

        public ICommand UpdateAuthorCommand { get; set; }

        public MainWindowViewModel()
        {
            Authors = new RestCollection<Author>("http://localhost:54941/", "author");

            CreateAuthorCommand = new RelayCommand(() => {
                Authors.Add(new Author()
                {
                    Name = "Kiss Béla"
                });
            });

            DeleteAuthorCommand = new RelayCommand(() =>
            {
                Authors.Delete(SelectedAuthor.authorId);
            },
            () => 
            {
                return SelectedAuthor != null; 
            }); 
        }
    }
}
