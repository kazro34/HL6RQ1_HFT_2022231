using HL6RQ1_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HL6RQ1_HFT_2022231.WPFClient
{
    public class AuthorWindowViewModel
    {
        public RestCollection<Author> Authors { get; set; }
        public ICommand CreateAuthorCommand { get; set; }

        public ICommand DeleteAuthorCommand { get; set; }

        public ICommand UpdateAuthorCommand { get; set; }

        public AuthorWindowViewModel()
        {
            Authors = new RestCollection<Author>("http://localhost:54941/", "author");

            CreateAuthorCommand = new RelayCommand(() =>
            {
                Authors.Add(new Author()
                {
                    Name = SelectedAuthor.Name
                });
            });

            UpdateAuthorCommand = new RelayCommand(() =>
            {
                Authors.Update(SelectedAuthor);
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
