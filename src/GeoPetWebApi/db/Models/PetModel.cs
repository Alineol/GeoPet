using projetoFinal.db.Models.PessoaCuidadora;
using System.ComponentModel.DataAnnotations.Schema;
using projetoFinal.Controllers.inputs;

namespace projetoFinal.db.Models.Pets;
public class PetModel: PetInput {
    public int Id {get; set;}
   
    [Column("STATUS")]
    public bool Status {get; set;} 
}