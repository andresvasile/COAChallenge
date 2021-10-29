using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using COAChallenge.Entidades;
using Microsoft.EntityFrameworkCore.Internal;

namespace COAChallenge.Datos
{
    public class AppDbContextSeed
    {
        internal static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Usuarios.Any())
                {
                    var usuarios = new List<Usuario>();

                    var usuario1 = new Usuario
                    {
                        Email = "mail1@gmail.com",
                        Nombre = "roberto",
                        Telefono = "123456789"
                    };
                    var usuario2 = new Usuario
                    {
                        Email = "mail2@gmail.com",
                        Nombre = "juan",
                        Telefono = "143456789"
                    };
                    var usuario3 = new Usuario
                    {
                        Email = "mail3@gmail.com",
                        Nombre = "esteban",
                        Telefono = "653142323"
                    };

                    usuarios.Add(usuario1);
                    usuarios.Add(usuario2);
                    usuarios.Add(usuario3);

                    foreach (var usuario in usuarios)
                    {
                        context.Usuarios.Add(usuario);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(e.Message);
            }
        }
    }
}