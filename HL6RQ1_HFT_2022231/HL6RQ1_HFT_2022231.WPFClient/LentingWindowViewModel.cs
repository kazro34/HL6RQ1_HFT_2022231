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
    public class LentingWindowViewModel
    {
        public RestCollection<Lenting> Lentings { get; set; }
        public ICommand CreateLentingCommand { get; set; }

        public ICommand DeleteLentingCommand { get; set; }

        public ICommand UpdateLentingCommand { get; set; }

        public LentingWindowViewModel()
        {
            Lentings = new RestCollection<Lenting>("http://localhost:54941/", "lenting");

            CreateLentingCommand = new RelayCommand(() =>
            {
                Lentings.Add(new Author()
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
