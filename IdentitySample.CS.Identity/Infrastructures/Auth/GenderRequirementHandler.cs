using Microsoft.AspNetCore.Authorization;

namespace IdentitySample.CS.Identity.Infrastructures.Auth;

public class GenderRequirementHandler : AuthorizationHandler<GenderRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GenderRequirement requirement)
    {
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}