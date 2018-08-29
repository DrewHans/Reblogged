using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public interface IBlogUserRepo : IRepository<BlogUser, Guid>
    {
        string GetPasswordHashById(Guid id);
        string GetPasswordSaltById(Guid id);
    }
}