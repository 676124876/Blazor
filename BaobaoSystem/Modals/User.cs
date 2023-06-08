using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace BaobaoSystem.Modals
{
    public class User
    {
        [NotNull]
        [Display(Name = "账号")]
        [Required(ErrorMessage = "笨")]
        public string Account { get; set; }
        [NotNull]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "蛋")]
        public string Password { get; set; }
        
    }
}
