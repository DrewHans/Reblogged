using System;

namespace Blog.Core
{
    public interface IBlogUserRepo : IRepository<BlogUser, Guid>
    { }
}