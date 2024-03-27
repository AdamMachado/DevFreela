using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt,string clienteFullName,string freelancerFullName)
        {
            this.id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClienteFullName = clienteFullName;
            FreelancerFullName = freelancerFullName;
        }

        public int id { get;private set; }
        public string Title { get;private set; }
        public string Description { get;private set; }
        public decimal TotalCost { get;private set; }
        public DateTime? StartedAt { get;private set; }
        public DateTime? FinishedAt { get;private set; }
        public string ClienteFullName { get; set; }
        public string FreelancerFullName { get; set; }
    }
}
