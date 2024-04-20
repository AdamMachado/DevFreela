using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id,string title, string description, decimal totalCost, DateTime createAt)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            CreateAt = createAt;

        }
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}
