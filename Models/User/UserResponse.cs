using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SweatitBackEnd.Models.Base;

namespace SweatitBackEnd.Models.User;

public class UserResponse(bool status, string message, SafeUser? user, List<string>? errors) : BaseResponse(status, message)
{
    public SafeUser? User = user;
    public List<string>? Errors = errors;
}