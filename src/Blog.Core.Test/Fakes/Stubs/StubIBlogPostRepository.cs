using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public class StubIBlogPostRepository : FakeIBlogPostRepository
    {
        public StubIBlogPostRepository StubGetById(BlogPost stub)
        {
            _mockIBlogPostRepository
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public StubIBlogPostRepository StubGetById(List<BlogPost> listOfStubs)
        {
            var stubSequence = _mockIBlogPostRepository
                .SetupSequence(x => x.GetById(It.IsAny<Guid>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public StubIBlogPostRepository StubList(List<BlogPost> stub)
        {
            _mockIBlogPostRepository
                .Setup(x => x.List())
                .Returns(stub);
            return this;
        }

        public StubIBlogPostRepository StubList(List<List<BlogPost>> listOfStubs)
        {
            var stubSequence = _mockIBlogPostRepository
                .SetupSequence(x => x.List());
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public StubIBlogPostRepository StubListByAuthorId(List<BlogPost> stub)
        {
            _mockIBlogPostRepository
                .Setup(x => x.ListByAuthorId(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public StubIBlogPostRepository StubListByAuthorId(List<List<BlogPost>> listOfStubs)
        {
            var stubSequence = _mockIBlogPostRepository
                .SetupSequence(x => x.ListByAuthorId(It.IsAny<Guid>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
