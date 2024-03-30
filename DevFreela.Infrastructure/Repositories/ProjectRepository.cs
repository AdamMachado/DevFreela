﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;


        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;


        }
        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            var project = await _dbContext.Projects
                 .Include(p => p.Client)
                 .Include(p => p.Freelancer)
                 .SingleOrDefaultAsync(p => p.Id == id);
            return project;
        }
    }
}