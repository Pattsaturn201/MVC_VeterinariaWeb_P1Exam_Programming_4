using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models;

    public class SQLServerContextSJCP : DbContext
    {
        public SQLServerContextSJCP (DbContextOptions<SQLServerContextSJCP> options)
            : base(options)
        {
        }

        public DbSet<EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models.Owner> Owner { get; set; } = default!;

public DbSet<EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models.Pet> Pet { get; set; } = default!;

public DbSet<EdwinSaa_MVC_Veterinaria_ExamenP1_P4.Models.VeterinaryAppointment> VeterinaryAppointment { get; set; } = default!;
    }
