using pr12_vUser.Data;
using pr12_vUser.Services;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RoleForm.xaml
    /// </summary>
    public partial class RoleForm : Page
    {
        Role _role = new();
        RoleService service = new();
        bool IsEdit = false;
        public RoleForm(Role? role = null)
        {
            InitializeComponent();

            if (role != null)
            {
                service.LoadRelation(role, "Users");
                _role = role;
                IsEdit = true;
            }

            DataContext = _role;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_role);
            back(sender, e);
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
