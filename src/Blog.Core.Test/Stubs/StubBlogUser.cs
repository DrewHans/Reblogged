using System;
using System.Collections.Generic;
using System.Globalization;

namespace Blog.Core.Test.Stubs
{
    public class StubBlogUser : BlogUser
    {
        public StubBlogUser()
        {
            Permissions = new List<string> { "UseTheForce", "UseLightsaber" };
            TimeRegistered = DateTime.Parse("May 19, 2005", new CultureInfo("en-us"));
            UserId = Guid.Parse("44444444-4444-4444-4444-444444444444");
            UserName = "Darth Vader";
        }
    }
}