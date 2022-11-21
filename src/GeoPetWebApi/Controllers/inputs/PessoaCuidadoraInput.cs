using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoFinal.Controllers.inputs
{
    public class PessoaCuidadoraInput
    {
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("SENHA", TypeName = "varchar(10)")]
        [MinLength (6)]
        [MaxLength(10)]
        public string senha { get; set; }
        [Column(TypeName = "varchar(11)")]
        [MinLength(11)]
        [MaxLength(11)]
        public string CPF { get; set; }
        [Column(TypeName = "varchar(8)")]
        [MinLength(8)]
        [MaxLength(8)]
        public string CEP { get; set; }
    }
}
