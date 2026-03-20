using pr12_vUser.Data;
using pr12_vUser.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr12_vUser.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupList.xaml
    /// </summary>
    public partial class GroupList : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public InterestGroupService service { get; set; } = new();
        private InterestGroup? _current;
        public InterestGroup? current
        {
            get => _current;
            set
            {
                if (_current != value)
                {
                    _current = value;
                    OnPropertyChanged();
                }
            }
        }

        public GroupList()
        {
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupForm());
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new GroupForm(current));
            }
            else
            {
                MessageBox.Show("Выберите роль");
            }
        }
        private void remove(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить группу?", "Удалить группу?",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите роль для удаления", "Выберите роль",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
