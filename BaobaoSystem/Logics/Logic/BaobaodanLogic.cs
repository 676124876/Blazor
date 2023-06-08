using BaobaoSystem.Data;
using BaobaoSystem.Logics.ILogic;
using BaobaoSystem.Modals;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;

namespace BaobaoSystem.Logics.Logic
{
    public class BaobaodanLogic: SqlsugarBase,IBaobaodanLogic
    {
        public ReturnDatas<object> Getstatus(User user)
        {
            var db = GetInstance();
            var yesornot = db.Queryable<User>()
                .WhereIF(!string.IsNullOrWhiteSpace(user.Account), t => t.Account == user.Account && t.Password == user.Password)
                .ToList();
            if (yesornot.Count>0)
            {
                return new ReturnDatas<object>().Success();
            }
            else 
            { 
                return new ReturnDatas<object>().Error();
            }
        }
    }
}
