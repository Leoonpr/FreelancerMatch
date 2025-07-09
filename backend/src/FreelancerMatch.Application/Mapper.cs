using AutoMapper;
using FreelancerMatch.Application.Dtos;
using FreelancerMatch.Domain.Freelancer;

namespace FreelancerMatch.Application
{
     public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Freelancer, FreelancerDto>();
        }
    }
}