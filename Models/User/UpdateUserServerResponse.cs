namespace SweatitBackEnd.Models.User;

public class UpdateUserServerResponse(SafeUser? userPreviousData, SafeUser? userNewData)
{
    public SafeUser? PreviousUserData { get; set; } = userPreviousData;
    public SafeUser? CurrentUserData { get; set; } = userNewData;
}