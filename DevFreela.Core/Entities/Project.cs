﻿using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelance, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelance = idFreelance;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get;private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelance { get; private set; }

        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get;private set; }
        public DateTime? StartedAt { get;private set; }
        public DateTime? FinishedAt { get;private set; }
        public ProjectStatusEnum Status { get;private set; }
        public List<ProjectComment> Comments { get;private set; }

    }
}