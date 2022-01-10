using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_ST.Models
{
    [Table("Live")]
    public class Live
    {

        [Column("Id")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }


        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [Column("Descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        [Column("Instrutor")]
        [Display(Name = "Nome do Instrutor")]
        public string Instrutor { get; set; }


        [Column("Data e Hora de Início")]
        [Display(Name = "Data e Hora de Início")]
        public DateTime Data { get; set; }

        [Column("Duracao")]
        [Display(Name = "Horas Duradas")]
        public int Duracao { get; set; }

        [Column("Valor da Inscrição")]
        [Display(Name = "Valor $")]
        public int Valor { get; set; }
    }
}
