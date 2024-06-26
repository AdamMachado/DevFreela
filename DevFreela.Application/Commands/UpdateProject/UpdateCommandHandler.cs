﻿using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }



        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            project.Update(request.Title, request.Description, request.TotalCost);
            await _projectRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
