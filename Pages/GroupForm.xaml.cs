using pr12_vUser.Data;
using pr12_vUser.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Логика взаимодействия для GroupForm.xaml
    /// </summary>
    public partial class GroupForm : Page
    {
        InterestGroup _group = new();
        InterestGroupService service = new();
        bool IsEdit = false;

        public GroupForm(InterestGroup? group = null)
        {
            InitializeComponent();

            if (group != null)
            {
                _group = group;
                IsEdit = true;
                titl.IsEdit = IsEdit;
            }

            DataContext = _group;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_group);
            back(sender, e);
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
