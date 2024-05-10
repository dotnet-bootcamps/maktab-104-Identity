using Microsoft.AspNetCore.Authorization;

public class GenderRequirement : IAuthorizationRequirement
{
    public GenderRequirement(int genderType)
    {
        GenderType = genderType;
    }

    public int GenderType { get; set; }
}