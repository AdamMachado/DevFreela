using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsDTO>
    {
        private readonly IProjectRepository _projectRepositoy;
        public GetProjectByIdQueryHandler(IProjectRepository projectRepositoy)
        {
            _projectRepositoy = projectRepositoy;
        }

        public async Task<ProjectDetailsDTO> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)

        {

            var project = await _projectRepositoy.GetById(request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsDTO(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }

}
