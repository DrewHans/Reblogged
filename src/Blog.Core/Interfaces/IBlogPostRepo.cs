using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public interface IBlogPostRepo : IRepository<BlogPost, Guid>
    {
        List<BlogPost> ListByAuthorId(Guid id);
    }
}