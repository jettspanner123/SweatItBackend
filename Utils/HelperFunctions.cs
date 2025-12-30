using SweatitBackEnd.Models.Auth;
using SweatitBackEnd.Models.User;

namespace SweatitBackEnd.Utils;

public class HelperFunctions {
    public static SafeUser GetSafeUserFromBaseUser(BaseUser userData) {
        return new SafeUser(
            id: userData.Id,
            firstName: userData.FirstName,
            lastName: userData.LastName,
            username: userData.Username,
            email: userData.Email,
            personCurrentData: GetEmptyPersonData(),
            personFutureData: GetEmptyPersonData()
        );
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