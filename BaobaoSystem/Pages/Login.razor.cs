using BaobaoSystem.Logics.ILogic;
using BaobaoSystem.Modals;
using BaobaoSystem.Shared;
using Blazored.LocalStorage;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace BaobaoSystem.Pages
{
    public partial class Login
    {
        [Inject]
        public BlazorAuthenticationState blazorAuthenticationState { get; set; }
        [Inject]
        public IBaobaodanLogic? _IbaobaodanLogic { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        [Inject]
        [NotNull]
        private IStringLocalizer<string>? Localizer { get; set; }
        /// <summary>
        /// 弹窗是否显示
        /// </summary>
        [NotNull]
        public bool AlertStatus { get; set; }
        /// <summary>
        /// ShowLoding旋转是否显示
        /// </summary>
        [NotNull]
        public bool Spinneryesornot { get; set; }

        [NotNull]
        private User? Model { get; set; }

        private ConcurrentQueue<ConsoleMessageItem> ColorMessages { get; set; } = new();

        private readonly AutoResetEvent _locker = new(true);

        private CancellationTokenSource? CancelTokenSource { get; set; }
        protected override async void OnInitialized()
        {
            Model = new User() { Account = "", Password = "" };
            
        }

        /// 通过验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task OnValidSubmit(EditContext context)
        {
            Spinneryesornot = true;
            StateHasChanged();
            var account = Model.Account;
            var password = Model.Password;
            User user = new User() 
            { 
                Account = account, 
                Password = password 
            };
            
            var yesornot =  _IbaobaodanLogic?.Getstatus(user);
            Spinneryesornot = false;
            StateHasChanged();
            if (yesornot.Code == 1)
            {
                
                await localStorage.SetItemAsync("account", account);
            }
            else 
            {
                AlertStatus = true;
                StateHasChanged();
            }
            
        }
        /// <summary>
        /// 未通过验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task OnInvalidSubmit(EditContext context)
        {
        }

        /// <summary>
        /// 关闭警告框回调方法
        /// </summary>
        /// <returns></returns>
        private Task DismissClick()
        {
            AlertStatus = false;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
