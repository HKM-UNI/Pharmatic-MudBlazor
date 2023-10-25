using Microsoft.AspNetCore.Authorization;

namespace Pharmatic.Authorization
{
    public class AuthorizationPolicies
    {
        public static AuthorizationPolicy CreateScopeAuthorizationPolicy(string scope)
        {
            return new AuthorizationPolicyBuilder()
                .RequireAssertion(context =>
                {
                    var scopesClaim = context.User.FindFirst("scopes");
                    if (scopesClaim != null)
                    {
                        var scopes = scopesClaim.Value;
                        return scopes.Contains(scope);
                    }
                    return false;
                })
                .Build();
        }
    }

}
