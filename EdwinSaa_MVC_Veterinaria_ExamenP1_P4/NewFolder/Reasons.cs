using EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models;

namespace EdwinSaa_MVC_Veterinaria_ExamenP1_P4.NewFolder
{
    public static class Reasons
    {
        public static List<Reason> GetAll()
        {
            return new List<Reason>
            {
                new Reason { Id = 1, Description = "Consulta general" },
                new Reason { Id = 2, Description = "Vacunación" },
                new Reason { Id = 3, Description = "Cirugia" }
            };
        }

    }
}
