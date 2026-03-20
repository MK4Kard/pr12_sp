using pr12_vUser.Data;
using pr12_vUser.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для GroupUserPage.xaml
    /// </summary>
    public partial class GroupUserPage : Page
    {
        public UserInterestGroupService service { get; set; } = new();
        public UserInterestGroup uiG = new UserInterestGroup();
        public User user = new User();
        public DateOnly dateJoin { get; set; } = new();
        public bool moderator { get; set; } = new();

        public GroupUserPage(User _user)
        {
            InitializeComponent();
            user = _user;
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItems.Count > 0)
            {
                foreach (InterestGroup item in list.SelectedItems)
                {
                    var userInGr = user.UserInterestGroups.FirstOrDefault(u => u.InterestGroupId == item.Id);
                    uiG = new UserInterestGroup
                    {
                        UserId = user.Id,
                        InterestGroupId = item.Id,
                        JoinedAt = dateJoin,
                        IsModerator = moderator,
                    };
                    if (userInGr == null)
                    {
                        MessageBox.Show("Пользователь добавлен");
                        service.Add(uiG);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь уже в группе");
                    }
                }

                return;
            }
            MessageBox.Show("Выберите группу!");
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView list && list.SelectedItems != null)
            {
                InterestGroup ig = list.SelectedItem as InterestGroup;
                MessageBox.Show($"{ig.Title}");
            }
        }
    }
}
