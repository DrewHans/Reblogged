using System;

namespace Blog.Core
{
    public interface IBlogUserRepository : IRepository<BlogUser, Guid>
    { }
}