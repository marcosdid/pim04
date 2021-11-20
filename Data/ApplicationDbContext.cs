using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using pim04.Models;

namespace pim04.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Hospede> Hospedes { get; set; }
        public DbSet<Models.Funcionario> Funcionarios { get; set; }
        public DbSet<Models.Reserva> Reservas { get; set; }
        public DbSet<Models.Quarto> Quartos { get; set; }

        public DbSet<Models.MetodoPagamento> MetodoPagamentos { get; set; }

    }
}
