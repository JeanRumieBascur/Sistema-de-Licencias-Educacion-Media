using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoSC4.Models
{
    public class Admin
    {
        [Key]
        public int id_admin {get; set;}

        public string user_admin{get; set;}

        public string pass_admin{get; set;}

    }
}