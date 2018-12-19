using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

/// <summary>
/// 使用者帳號會用到的相關資料物件
/// </summary>
namespace MvcApplication2.Models
{
    /// <summary>
    /// 使用者內容物件
    /// </summary>
    public class UsersContext : DbContext
    {
        /// <summary>
        /// 建立資料庫連結 - DB name: DefaultConnection
        /// </summary>
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
    /// <summary>
    /// UserProfile資料表物件
    /// </summary>
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    /// <summary>
    /// 使用者註冊登入時間模組(待確認)
    /// </summary>
    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    /// <summary>
    /// 使用者輸入更換登入密碼回覆結果模組
    /// </summary>
    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "您的密碼與設定不相符! The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// 使用者登入頁面模組
    /// </summary>
    public class LoginModel
    {
        [Required]
        [Display(Name = "使用者帳號 User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "使用者密碼 Password")]
        public string Password { get; set; }

        [Display(Name = "是否記住帳號密碼 Remember me?")]
        public bool RememberMe { get; set; }
    }

    //註冊用模型
    public class RegisterModel
    {
        [Required]
        [Display(Name = "使用者名稱 User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼 Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "再次輸入您的密碼 Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// 持續保留登入資料物件
    /// </summary>
    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
