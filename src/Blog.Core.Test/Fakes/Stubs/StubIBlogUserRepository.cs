using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public class StubIBlogUserRepository : FakeIBlogUserRepository
    {
        public StubIBlogUserRepository StubGetById(BlogUser stub)
        {
            _mockIBlogUserRepository
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public StubIBlogUserRepository StubGetById(List<BlogUser> listOfStubs)
        {
            var stubSequence = _mockIBlogUserRepository
                .SetupSequence(x => x.GetById(It.IsAny<Guid>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public StubIBlogUserRepository StubList(List<BlogUser> stub)
        {
            _mockIBlogUserRepository
                .Setup(x => x.List())
                .Returns(stub);
            return this;
        }

        public StubIBlogUserRepository StubList(List<List<BlogUser>> listOfStubs)
        {
            var stubSequence = _mockIBlogUserRepository
                .SetupSequence(x => x.List());
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
