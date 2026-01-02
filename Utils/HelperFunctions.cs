using SweatitBackEnd.Models.Auth;
using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Utils;

public class HelperFunctions {
    public static SafeUser GetSafeUserFromBaseUser(BaseUser userData) {
        return new SafeUser {
            Id = userData.Id,
            Email = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
            Username = userData.Username,
            PersonCurrentData = GetEmptyPersonData(),
            PersonFutureData = GetEmptyPersonData(),
        };
   }

    public static PersonData GetEmptyPersonData() {
        return new PersonData {
            Id = Guid.NewGuid().ToString(),
            Height = 0,
            Weight = 0,
            BodyType = BodyTypeEnum.None,
            Goal = GoalEnum.None,
            Gender = GenderEnum.None,
            Level = LevelEnum.None,
            DailyPoints = 0
        };
    }

    public static PersonData GetPersonDataFromDTO(PersonDataDTO userDetails) {
        return new PersonData {
            Id = Guid.NewGuid().ToString(),
            Height = userDetails.Height,
            Weight = userDetails.Weight,
            BodyType = userDetails.BodyType,
            Goal = userDetails.Goal,
            Gender = userDetails.Gender,
            Level = userDetails.Level,
            DailyPoints = userDetails.DailyPoints
        };
    }
}