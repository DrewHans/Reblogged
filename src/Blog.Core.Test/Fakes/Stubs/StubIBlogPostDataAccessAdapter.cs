using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public class StubIBlogPostDataAccessAdapter : FakeIBlogPostDataAccessAdapter
    {
        public StubIBlogPostDataAccessAdapter StubGetById(BlogPost stub)
        {
            _mockIBlogPostDataAccessAdapter
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public StubIBlogPostDataAccessAdapter StubGetById(List<BlogPost> listOfStubs)
        {
            var stubSequence = _mockIBlogPostDataAccessAdapter
                .SetupSequence(x => x.GetById(It.IsAny<Guid>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public StubIBlogPostDataAccessAdapter StubList(List<BlogPost> stub)
        {
            _mockIBlogPostDataAccessAdapter
                .Setup(x => x.List())
                .Returns(stub);
            return this;
        }

        public StubIBlogPostDataAccessAdapter StubList(List<List<BlogPost>> listOfStubs)
        {
            var stubSequence = _mockIBlogPostDataAccessAdapter
                .SetupSequence(x => x.List());
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public StubIBlogPostDataAccessAdapter StubListByAuthorId(List<BlogPost> stub)
        {
            _mockIBlogPostDataAccessAdapter
                .Setup(x => x.ListByAuthorId(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public StubIBlogPostDataAccessAdapter StubListByAuthorId(List<List<BlogPost>> listOfStubs)
        {
            var stubSequence = _mockIBlogPostDataAccessAdapter
                .SetupSequence(x => x.ListByAuthorId(It.IsAny<Guid>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
