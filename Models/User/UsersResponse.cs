using SweatitBackEnd.Models.Base;

namespace SweatitBackEnd.Models.User;

public class UsersResponse(bool status, string message, List<SafeUser>? users): BaseResponse(status, message) {
    public List<SafeUser>? Users { get; set; } = users;
}