using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _role;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string role)
        {
            _role = role.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _role)
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
