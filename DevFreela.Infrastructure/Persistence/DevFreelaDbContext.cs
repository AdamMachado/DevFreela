using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto Asp Net Core 1", "Minha Descreção de Projeto 1",1,1,100000),
                new Project("Meu projeto Asp Net Core 2", "Minha Descreção de Projeto 2",1,1,200000),
                new Project("Meu projeto Asp Net Core 3", "Minha Descreção de Projeto 3",1,1,300000)
            };

            Users = new List<User>
            {
                new User("Adam", "adam@gmail.com",new DateTime(1992,9,2)),
                new User("Luis", "Luis@gmail.com",new DateTime(1992,9,2)),
                new User("Felipe", "Felipe@gmail.com",new DateTime(1992,9,2))
            };

            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };

        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
