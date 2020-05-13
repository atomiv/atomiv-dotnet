using System;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication
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
