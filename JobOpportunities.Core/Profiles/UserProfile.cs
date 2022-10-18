using AutoMapper;
using JobOpportunities.Core.Features.JobOfferMatches.Models;
using JobOpportunities.Core.Features.SignUp.Commands;
using JobOpportunities.Core.Features.Users.Commands;
using JobOpportunities.Core.Features.Users.Models;
using JobOpportunities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterNewUserCommand, ApplicationUser>().ForSourceMember(x => x.ConfirmPassword, opt => opt.DoNotValidate()).ForMember(x => x.UserName, opt => opt.MapFrom(y => y.Email));
            CreateMap<CreateUserCommand, ApplicationUser>().ForSourceMember(x => x.ConfirmPassword, opt => opt.DoNotValidate()).ForMember(x => x.UserName, opt => opt.MapFrom(y => y.Email));
            CreateMap<UpdateUserCommand, ApplicationUser>().ForSourceMember(x => x.ConfirmPassword, opt => opt.DoNotValidate());
            CreateMap<ApplicationUser, GetUserQueryResponse>();
            CreateMap<ApplicationUser, GetUsersQueryResponse>();
        }
    }
}
