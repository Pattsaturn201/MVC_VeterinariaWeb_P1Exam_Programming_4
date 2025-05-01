using System.ComponentModel.DataAnnotations;

namespace EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsAfiliated { get; set; }

        public int PetId { get; set; }
        [ForeingnKey("PetId")]
        public Pet? Pet { get; set; }
    }
}
