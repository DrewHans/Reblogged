using System;
using System.Collections.Generic;
using System.Globalization;

namespace Blog.Core.Test
{
    public class BlogUserFactory : IFactory<BlogUser>
    {
        private readonly BlogUser _blogUser;

        public BlogUserFactory()
        {
            _blogUser = new BlogUser
            {
                Permissions = new List<string> { "UseTheForce", "UseLightsaber" },
                TimeRegistered = DateTime.Parse("May 19, 2005", new CultureInfo("en-us")),
                UserId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                UserName = "Darth Vader",
            };
        }

        public BlogUser Create()
        {
            return _blogUser;
        }

        public BlogUserFactory StubUserId(Guid id)
        {
            _blogUser.UserId = id;
            return this;
        }
    }
}
