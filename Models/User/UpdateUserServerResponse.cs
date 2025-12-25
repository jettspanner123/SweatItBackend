namespace SweatitBackEnd.Models.User;

public class UpdateUserServerResponse(SafeUser? userPreviousData, SafeUser? userNewData)
{
    public SafeUser? UserPreviousData { get; set; } = userPreviousData;
    public SafeUser? UserNewData { get; set; } = userNewData;
}