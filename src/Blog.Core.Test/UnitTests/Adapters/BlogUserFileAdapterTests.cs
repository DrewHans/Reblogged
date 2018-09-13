using Blog.Core.Test.Fakes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserFileAdapterTests
    {
        [Fact]
        public void Add_VerifyDataAccess()
        {
            var fakeConfig = new FakeIConfigurationFactory().StubFakeDataForFileDataAccess().Create();
            var mockFileDataAccess = new MockIFileDataAccess<BlogUser>();
            var fileAdapter = new BlogUserFileAdapter(fakeConfig, mockFileDataAccess);
            var param_entity = new BlogUserFactory().Create();
            var expectedfilePath = fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath];

            fileAdapter.Add(param_entity);

            mockFileDataAccess.VerifyWriteToDatabase(expectedfilePath, param_entity);
        }

        [Fact]
        public void Delete_VerifyDataAccess()
        {
            var fakeConfig = new FakeIConfigurationFactory().StubFakeDataForFileDataAccess().Create();
            var mockFileDataAccess = new MockIFileDataAccess<BlogUser>();
            var fileAdapter = new BlogUserFileAdapter(fakeConfig, mockFileDataAccess);
            var param_entity = new BlogUserFactory().Create();
            var stub_blogUser = new BlogUserFactory().Create();
            stub_blogUser.UserId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogUser> { param_entity, stub_blogUser };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogUser> { stub_blogUser };

            fileAdapter.Delete(param_entity);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
            mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDBfilePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void Edit_VerifyDataAccess()
        {
            var fakeConfig = new FakeIConfigurationFactory().StubFakeDataForFileDataAccess().Create();
            var mockFileDataAccess = new MockIFileDataAccess<BlogUser>();
            var fileAdapter = new BlogUserFileAdapter(fakeConfig, mockFileDataAccess);
            var param_entity = new BlogUserFactory().Create();
            var stub_blogUser = new BlogUserFactory().Create();
            stub_blogUser.UserId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogUser> { param_entity, stub_blogUser };
            mockFileDataAccess.StubReadDatabase(stub_list);
            param_entity.UserName = "This is an edited UserName!";
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogUser> { stub_blogUser, param_entity };

            fileAdapter.Edit(param_entity);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
            mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDBfilePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void GetById_ReturnsExpectedBlogUser()
        {
            var fakeConfig = new FakeIConfigurationFactory().StubFakeDataForFileDataAccess().Create();
            var mockFileDataAccess = new MockIFileDataAccess<BlogUser>();
            var fileAdapter = new BlogUserFileAdapter(fakeConfig, mockFileDataAccess);
            var stub_blogUser1 = new BlogUserFactory().Create();
            var stub_blogUser2 = new BlogUserFactory().Create();
            stub_blogUser2.UserId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogUser> { stub_blogUser1, stub_blogUser2 };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected = stub_blogUser2;

            var actual = fileAdapter.GetById(stub_blogUser2.UserId);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_ReturnsExpectedList()
        {
            var fakeConfig = new FakeIConfigurationFactory().StubFakeDataForFileDataAccess().Create();
            var mockFileDataAccess = new MockIFileDataAccess<BlogUser>();
            var fileAdapter = new BlogUserFileAdapter(fakeConfig, mockFileDataAccess);
            var stub_blogUser = new BlogUserFactory().Create();
            var stub_list = new List<BlogUser> { stub_blogUser };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected = stub_list;

            var actual = fileAdapter.List();

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
            Assert.Equal(expected, actual);
        }
    }
}
