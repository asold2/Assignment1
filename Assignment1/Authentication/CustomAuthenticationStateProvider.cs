using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment1.Data;
using Assignment1.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.JSInterop;



namespace Assignment1.Authentication
{
    public class CustomAuthenticationStateProvider: AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IUserService userService;

        private LoginUser currentUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService)
        {
            this.jsRuntime = jsRuntime;
            this.userService = userService;
            currentUser = new LoginUser();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (currentUser == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    LoginUser temp = JsonSerializer.Deserialize<LoginUser>(userAsJson);
                    ValidateLogin(temp.UserName, temp.Password);
                }
                else
                {
                    identity = SetupClaimsForUser(currentUser);
                }
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));

        }

        private ClaimsIdentity SetupClaimsForUser(LoginUser loginUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, loginUser.UserName));
            claims.Add(new Claim("Password", loginUser.Password));
            claims.Add(new Claim("Role", loginUser.Role));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        public void LogOut()
        {
            currentUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        internal void ValidateLogin(string tempUserName, string tempPassword)
        {
            Console.WriteLine("-------->Validating log in");
            if (string.IsNullOrEmpty(tempUserName)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(tempPassword)) throw new Exception("Enter password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                LoginUser user = userService.ValidateUser(tempUserName, tempPassword);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                currentUser = user;
            }
            catch (Exception e)
            {
                throw e;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
    }
}