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
    public class LentingWindowViewModel : ObservableRecipient
    {
        public RestCollection<Lenting> Lentings { get; set; }

        private Lenting selectedLenting;

        public Lenting SelectedLenting
        {
            get { return selectedLenting; }
            set
            {
                if (value != null)
                {
                    selectedLenting = new Lenting()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    SetProperty(ref selectedLenting, value);
                    (DeleteLentingCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateLentingCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateLentingCommand { get; set; }

        public ICommand DeleteLentingCommand { get; set; }

        public ICommand UpdateLentingCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public LentingWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Lentings = new RestCollection<Lenting>("http://localhost:54941/", "lenting", "hub");

                CreateLentingCommand = new RelayCommand(() =>
                {
                    Lentings.Add(new Lenting()
                    {
                        Name = SelectedLenting.Name
                    });
                });

                UpdateLentingCommand = new RelayCommand(() =>
                {
                    Lentings.Update(SelectedLenting);
                });

                DeleteLentingCommand = new RelayCommand(() =>
                {
                    Lentings.Delete(SelectedLenting.Id);
                },
                () =>
                {
                    return SelectedLenting != null;
                });
            }

            
        }
    }
}
