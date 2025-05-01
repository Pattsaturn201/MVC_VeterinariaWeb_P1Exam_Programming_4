using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public  Owner? Owner { get; set; }


    }
}
