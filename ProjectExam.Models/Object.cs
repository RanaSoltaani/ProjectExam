using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectExam.Models;

[Table("object")]
public class MyObject
{
    [Key]
    public int object_id { get; set; }

    public string object_name { get; set; }

    public int user_id { get; set; }

    // Définissez d'autres propriétés selon vos besoins
}
