namespace Doppler.HelloMicroservice.DopplerSecurity;

public static class Policies
{
    public const string OnlySuperuser = nameof(OnlySuperuser);
    public const string OwnResourceOrSuperuser = nameof(OwnResourceOrSuperuser);
}
