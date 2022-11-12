using BookReadingEvent.ProductDomain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.UoW.Files
{
    public class CustomUnitOfWork:ICustomUnitOfWork
    {
        public Data.DBContext.ProductDomainDbContext _obj;
        public AutoMapper.IMapper _mapper;
        public Microsoft.Extensions.Logging.ILogger<CreateEventRepositry> _Ilogger;
        private ICreateEventRepositry _createEventRepositry;
        private IUserRepository _userRepository;
        public CustomUnitOfWork(Data.DBContext.ProductDomainDbContext context, AutoMapper.IMapper mapper, Microsoft.Extensions.Logging.ILogger<CreateEventRepositry> Ilogger)
        {
            _obj = context;
            _Ilogger = Ilogger;
            _mapper = mapper;
        }
        public ICreateEventRepositry createEventRepositry
        {
            get
            {
                return _createEventRepositry = _createEventRepositry ?? new CreateEventRepositry(_obj, _mapper, _Ilogger);
            }
        }



        public IUserRepository userRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_obj);
            }
        }
    }
}
