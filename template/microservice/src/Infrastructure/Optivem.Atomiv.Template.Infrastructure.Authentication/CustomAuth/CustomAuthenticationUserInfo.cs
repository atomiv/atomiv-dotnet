using System;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.CustomAuth
{
    public class CustomAuthenticationUserInfo
    {
        public CustomAuthenticationUserInfo(Guid id, string email, string locale, string mobile)
        {
            Id = id;
            Email = email;
            Locale = locale;
            Mobile = mobile;
        }

        public Guid Id { get; }

        public string Email { get; }

        public string Locale { get; }

        public string Mobile { get; }
    }
}
