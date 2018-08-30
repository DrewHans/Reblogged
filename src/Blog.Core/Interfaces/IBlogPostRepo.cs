using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public interface IBlogPostRepo : IRepository<BlogPost, Guid>
    {
        void DeleteAllByAuthorId(Guid id);
        List<BlogPost> ListByAuthorId(Guid id);
    }
}