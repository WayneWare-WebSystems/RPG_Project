using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_Project.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool IsAdm { get; set; } = false;

        // Relacionamento 1/N (1 para muitos)
        public List<Personagem> Personagens { get; set; }
    }
}
