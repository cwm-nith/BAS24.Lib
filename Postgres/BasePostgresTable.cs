using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAS24.Libs.Postgres;

public class BasePostgresTable
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    [Key]
    [Column("id")]
    public Guid Id { get; set; }
}
