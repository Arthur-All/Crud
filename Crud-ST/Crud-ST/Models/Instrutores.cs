using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_ST.Models
{
    [Table("Instrutores")]
    public class Instrutores
    {

        [Column("Id")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }


        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Column("Instagram")]
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }


    }
}
