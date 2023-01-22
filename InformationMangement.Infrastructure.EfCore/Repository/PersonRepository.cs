﻿using InformationManagement.Contracts.Person;
using InformationManagement.Domain.PersonAgg;
using InformationMangement.Infrastructure.EfCore.DbContextModel;
using MyFramework.Infrastructure;
using MyFramework.Tools.Conversions;

namespace InformationMangement.Infrastructure.EfCore.Repository
{
    public class PersonRepository : RepositoryBase<long, PersonModel>, IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context) : base(context)
        {
            _context = context;
        }

        public List<PersonViewModel> GetAll()
        {
            return _context.Person.Select(x => new PersonViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                ShortDescription = x.ShortDescription,
                IsFreelancer = x.IsFreelancer,
                CreationDate = x.CreationDate.ToFarsi(),
                Address = x.Address,
                Email = x.Email,
                Mobile = x.Mobile,

            }).ToList();
        }

        public EditPerson GetDetails(long id)
        {
            return _context.Person.Select(x => new EditPerson
            {
                Id = x.Id,
                FullName = x.FullName,
                ShortDescription = x.ShortDescription,
                IsFreelancer = x.IsFreelancer,
                Address = x.Address,
                Email = x.Email,
                Mobile = x.Mobile,

            }).FirstOrDefault(x => x.Id == id);

        }
    }
}