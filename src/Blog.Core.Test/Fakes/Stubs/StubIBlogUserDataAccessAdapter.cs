using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public class StubIBlogUserDataAccessAdapter : FakeIBlogUserDataAccessAdapter
    {
        public StubIBlogUserDataAccessAdapter StubGetById(BlogUser stub)
        {
            _mockIBlogUserDataAccessAdapter
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public StubIBlogUserDataAccessAdapter StubGetById(List<BlogUser> listOfStubs)
        {
            var stubSequence = _mockIBlogUserDataAccessAdapter
                .SetupSequence(x => x.GetById(It.IsAny<Guid>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public StubIBlogUserDataAccessAdapter StubList(List<BlogUser> stub)
        {
            _mockIBlogUserDataAccessAdapter
                .Setup(x => x.List())
                .Returns(stub);
            return this;
        }

        public StubIBlogUserDataAccessAdapter StubList(List<List<BlogUser>> listOfStubs)
        {
            var stubSequence = _mockIBlogUserDataAccessAdapter
                .SetupSequence(x => x.List());
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
