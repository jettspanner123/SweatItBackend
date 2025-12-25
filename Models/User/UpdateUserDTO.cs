using System.ComponentModel.DataAnnotations;

namespace SweatitBackEnd.Models.User;


public class UpdateUserDTO
{
    [Required(ErrorMessage = "User Id Not Provided!")]
    [MinLength(1, ErrorMessage = "User Id Cannot Be Empty!")]
    public required string ForId { get; set; }

    [Required(ErrorMessage = "User Updation Data Not Provided!")]
    public required PartialUserDTO UpdationData { get; set; }
}