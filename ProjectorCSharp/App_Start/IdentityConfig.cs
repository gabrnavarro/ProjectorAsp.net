using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using ProjectorCSharp.Models;

namespace ProjectorCSharp
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new CustomUserValidator(manager)
            {
                
                RequireUniqueEmail = true,
                MaxLength = 200,
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 7,
                MaxLength = 11,
            };

            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }


    public class CustomPasswordValidator : PasswordValidator
    {
        public int MaxLength { get; set; }

        public override async Task<IdentityResult> ValidateAsync(string item)
        {
            IdentityResult result = await base.ValidateAsync(item);

            var errors = result.Errors.ToList();

            if (string.IsNullOrEmpty(item) || item.Length > MaxLength)
            {
                errors.Add(string.Format("Password length can't exceed {0}", MaxLength));
            }

            return await Task.FromResult(errors.Count() == 0
             ? IdentityResult.Success
             : IdentityResult.Failed(errors.ToArray()));
        }
    }

    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public int MaxLength { get; set; }
        public CustomUserValidator(ApplicationUserManager manager)
            : base(manager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            var errors = result.Errors.ToList();

            if (string.IsNullOrEmpty(user.Email) || user.Email.Length > MaxLength || user.Email.Length < 5)
            {
                errors.Add(string.Format("Email length must be between 5 and {0}", MaxLength));
            }
            result = new IdentityResult(errors);
            return result;


        }
    }

}



