using HL6RQ1_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HL6RQ1_HFT_2022231.WPFClient
{
    public class AuthorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Author> Authors { get; set; }

        private Author selectedAuthor;

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                if (value != null)
                {
                    selectedAuthor = new Author()
                    {
                        Name = value.Name,
                        authorId = value.authorId
                    };
                    SetProperty(ref selectedAuthor, value);
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }

        public ICommand CreateAuthorCommand { get; set; }

        public ICommand DeleteAuthorCommand { get; set; }

        public ICommand UpdateAuthorCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AuthorWindowViewModel()
        {
            if(!IsInDesignMode)
            {
                Authors = new RestCollection<Author>("http://localhost:54941/", "author", "hub");

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
}
