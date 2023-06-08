using BaobaoSystem.Modals;

namespace BaobaoSystem.Logics.ILogic
{
    public interface IBaobaodanLogic
    {
        ReturnDatas<object> Getstatus(User user);
    }
}
