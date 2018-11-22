namespace DziennikTreningowy.Core.Interfaces
{
    public interface IOAuthService
    {
        string GetUserAuthToken(string username, string userId);
    }
}
