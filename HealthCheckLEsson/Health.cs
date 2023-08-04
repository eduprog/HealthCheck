using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheckLEsson;
[Table("health")]
public class Health
{
    [Key]
    public Guid Id { get; set; }

    public string Nome { get; set; }


}