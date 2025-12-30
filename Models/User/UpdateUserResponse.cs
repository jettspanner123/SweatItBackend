using SweatitBackEnd.Models.Base;
using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Models.User;

public class UpdateUserResponse(bool status, string message, SafeUser? previousUserData, SafeUser? currentUserData) : BaseResponse(status, message)
{
    SafeUser? PreviousUserData { set; get; } = previousUserData;
    SafeUser? CurrentUserDat { set; get; } = currentUserData;
}