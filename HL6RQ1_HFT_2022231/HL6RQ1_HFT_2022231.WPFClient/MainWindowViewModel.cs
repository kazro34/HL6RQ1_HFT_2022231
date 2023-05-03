using HL6RQ1_HFT_2022231.Models;
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
    public class MainWindowViewModel
    {
        public ICommand AuthorCommand { get; set; }

        public ICommand BookCommand { get; set; }

        public ICommand LentingCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {



                AuthorCommand = new RelayCommand(() =>
                {
                    AuthorWindow AW = new AuthorWindow();
                });

                BookCommand = new RelayCommand(() =>
                {
                    Bookeditor BW = new Bookeditor();
                });

                LentingCommand = new RelayCommand(() =>
                {
                   // Authors.Delete(SelectedAuthor.authorId);
                });


            }
        }
    }
}
