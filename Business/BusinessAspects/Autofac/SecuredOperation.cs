using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation:MethodInterception
    { // for Jason Web Token=JWT
        
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // Herkese bir httpcontext oluşur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(","); // Bu tanımlama metni benim tanımladığım şeklinde ayırıp array'e atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
