using projetoFinal.db.Models.PessoaCuidadora;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoFinal.Controllers.inputs
{
    public class PetInput
    {
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("PESO")]
        public decimal Peso { get; set; }
        [Column("PESSOA_CUIDADORA")]
        public virtual PessoaCuidadoraModel PessoaCuidadora { get; set; }
        [Column("HASH_LOCALIZACAO")]
        public string HashLocalizacao { get; set; }
        [Column("IDADE")]
        public int Idade { get; set; }
        [Column("RACA")]
        public string Raca { get; set; }
        [Column("PORTE")]
        public string Porte { get; set; }
    }
}
