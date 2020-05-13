using System;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.CustomAuth
{
    public class CustomAuthenticationUserInfo
    {
        public CustomAuthenticationUserInfo(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public Guid Id { get; }

        public string Email { get; }


    }
}
