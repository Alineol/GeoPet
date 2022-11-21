using projetoFinal.db.Models.Pets;
using System.ComponentModel.DataAnnotations.Schema;
using projetoFinal.Controllers.inputs;

namespace projetoFinal.db.Models.PessoaCuidadora;

public class PessoaCuidadoraModel: PessoaCuidadoraInput{
    public int Id {get; set;}
    public ICollection<PetModel> Pets { get; set;}
    [Column("STATUS")]
    public bool Status { get; set; }
}