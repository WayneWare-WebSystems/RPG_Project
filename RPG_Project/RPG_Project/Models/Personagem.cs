using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_Project.Models
{
    [Table("Personagens")]
    public class Personagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Personagem { get; set; }
        [MaxLength(40)]
        public string Nome { get; set; }
        [MaxLength(40)]
        public string Personalidade { get; set; }
        [MaxLength(100)]
        public string Historia { get; set; }
        [MaxLength(40)]
        public string Classe { get; set; }
        [MaxLength(40)]
        public string Profissao { get; set; }
        
        // Atributos de personagem tipo int
        public int Vida { get; set; }
        public int Sanidade { get; set; }
        public int Mind { get; set; }
        public int Body { get; set; }
        public int Wisdom { get; set; }
        public int Will { get; set; }
        public int Sense { get; set; }

        // Propriedades relacionais (chave estrangeira)
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
