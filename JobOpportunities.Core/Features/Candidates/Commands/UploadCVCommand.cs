using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.Candidates.Commands
{
    public class UploadCVCommand : IRequest<Unit>
    {
        public Guid CandidateId { get; set; }
        public IFormFile File { get; set; }
    }

    public class UploadCVCommandHandler : IRequestHandler<UploadCVCommand, Unit>
    {
        private readonly UserManager<Candidate> _userManager;

        public UploadCVCommandHandler(UserManager<Candidate> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(UploadCVCommand request, CancellationToken cancellationToken)
        {
            var dbObject = await _userManager.FindByIdAsync(request.CandidateId.ToString());

            if (dbObject is null)
            {
                throw new NotFoundException();
            }

            IFormFile file = request.File;

            long length = file.Length;
            if (length < 0)
                throw new BadHttpRequestException("You should attach a valid pdf file");

            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);

            dbObject.Curriculum = bytes;

            await _userManager.UpdateAsync(dbObject);

            return Unit.Value;
        }
    }
}
