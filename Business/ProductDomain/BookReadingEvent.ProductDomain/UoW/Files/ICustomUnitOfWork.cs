using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.UoW.Files
{
    public interface ICustomUnitOfWork
    
    {
        Repository.ICreateEventRepositry createEventRepositry { get; }
        Repository.IUserRepository userRepository { get; }
    }

}
