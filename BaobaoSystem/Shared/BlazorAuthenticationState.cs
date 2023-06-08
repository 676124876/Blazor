using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BaobaoSystem.Shared
{
    public class BlazorAuthenticationState : AuthenticationStateProvider
    {
        //引入缓存localStorage
        protected readonly ILocalStorageService localStorage;
        public BlazorAuthenticationState(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await localStorage.GetItemAsync<string>("account");
            //如果缓存为空说明用户没有登录，返回空
            if (string.IsNullOrEmpty(user))
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
            //给一个随便的固定值用于身份唯一
            var claimsIdentity = new ClaimsIdentity("Custom");
            //把缓存的用户名声明进去
            claimsIdentity.AddClaim(new(ClaimTypes.Name, user));
            //如果用户名等于admin，说明是管理员，给该账号管理员权限,否则给用户权限
            if (user == "admin")
            {
                claimsIdentity.AddClaim(new(ClaimTypes.Role, "Admin"));
            }
            else
            {
                claimsIdentity.AddClaim(new(ClaimTypes.Role, "User"));
            }
            //创建一个包含经过身份验证的用户的 AuthenticationState 对象,以便在以后使用
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var state = new AuthenticationState(claimsPrincipal);
            var taskState = Task.FromResult(state);
            NotifyAuthenticationStateChanged(taskState);
            return new AuthenticationState(claimsPrincipal);
        }
    }
}
