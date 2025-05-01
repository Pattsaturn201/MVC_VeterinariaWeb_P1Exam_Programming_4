namespace EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models
{
    public class VeterinaryAppointment
    {
        public int Id { get; set; }
        public DateTime AppointentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } // "Scheduled", "Completed", "Cancelled"
        public int PetId { get; set; }
        public int OwnerId { get; set; }
        public Boolean RequiresMedication { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
