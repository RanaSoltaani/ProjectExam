using System.ComponentModel.DataAnnotations;

namespace ProjectExam.Models;

public class User
{
    [Key]
    public int userId { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }


}
