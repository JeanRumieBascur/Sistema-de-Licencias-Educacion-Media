using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoSC4.Models
{
    public class Student
    {
        [Key]
        public int id_stud{get;set;}=0;

        public string number_stud{get;set;}="VACIO";

        public string year_stud{get;set;}="VACIO";

        public string curse_stud{get;set;}="VACIO";

        public string teaching_stud{get;set;}="VACIO";

        public string rut_stud{get;set;}="VACIO";

        public string lastname_stud{get;set;}="VACIO";

        public string mlastname_stud{get;set;}="VACIO";

        public string name_stud{get;set;}="VACIO";
    }
}