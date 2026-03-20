using pr12_vUser.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr12_vUser.Services
{
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        //public ObservableCollection<UserInterestGroup> UserInterestGroups { get; set; } = new();

        public void Add(UserInterestGroup userInterestGroup)
        {
            var _userInterestGroup = new UserInterestGroup
            {
                InterestGroupId = userInterestGroup.InterestGroupId,
                InterestGroup = userInterestGroup.InterestGroup,
                UserId = userInterestGroup.UserId,
                User = userInterestGroup.User,
                JoinedAt = userInterestGroup.JoinedAt,
                IsModerator = userInterestGroup.IsModerator,
            };
            _db.Add<UserInterestGroup>(_userInterestGroup);
            _db.SaveChanges();
        }

        //public void GetAll()
        //{
        //    var interestGroups = _db.UserInterestGroups.ToList();

        //    UserInterestGroups.Clear();
        //    foreach (var interestGroup in interestGroups)
        //    {
        //        UserInterestGroups.Add(interestGroup);
        //    }
        //}

        //public UserInterestGroupService()
        //{
        //    GetAll();
        //}
    }
}
