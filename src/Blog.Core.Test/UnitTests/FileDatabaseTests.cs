using Blog.Core;
using Blog.Core.Test.Fakes;
using Blog.Core.Test.Mocks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class FileDatabaseTests : IDisposable
    {
        private MockIFileReader _mockFileReader;
        private MockIFileWriter _mockFileWriter;
        private readonly FileDatabase<FakeBlogModel> _fileDatabase;

        public FileDatabaseTests()
        {
            _mockFileReader = new MockIFileReader();
            _mockFileWriter = new MockIFileWriter();
            _fileDatabase = new FileDatabase<FakeBlogModel>(_mockFileReader, _mockFileWriter);
        }

        public void Dispose() { }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ReadDatabase_FileContentsAreNullOrEmpty_ReturnsEmptyList(string stub_fileContents)
        {
            var param_filePath = "path/to/the/file.json";
            _mockFileReader.StubRead(stub_fileContents);
            var expected = new List<FakeBlogModel>();
            var returned = _fileDatabase.ReadDatabase(param_filePath);
            Assert.Equal(expected, returned);
            _mockFileReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void ReadDatabase_FileContainsOneObject_ReturnsListWithTheOneObject()
        {
            var param_filePath = "path/to/the/file.json";
            var stub_fakeBlogModel = new FakeBlogModel();
            var stub_listOfT = new List<FakeBlogModel> { stub_fakeBlogModel };
            var stub_fileContents = JsonConvert.SerializeObject(stub_listOfT);
            _mockFileReader.StubRead(stub_fileContents);
            var expected = JsonConvert.DeserializeObject<List<FakeBlogModel>>(stub_fileContents);
            var returned = _fileDatabase.ReadDatabase(param_filePath);
            AssertListOfFakeBlogModelAreEqual(expected, returned);
            _mockFileReader.VerifyRead(param_filePath);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WriteDatabase_ListIsNull_VerifyMockWriteMethodNotCalled(bool stub_appendToFile)
        {
            var param_filePath = "path/to/the/file.json";
            var param_appendToFile = stub_appendToFile;
            List<FakeBlogModel> param_listOfT = null;
            _fileDatabase.WriteDatabase(param_filePath, param_appendToFile, param_listOfT);
            _mockFileWriter.VerifyWriteNotCalled();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WriteDatabase_ListIsEmpty_VerifyMockWriteMethodNotCalled(bool stub_appendToFile)
        {
            var param_filePath = "path/to/the/file.json";
            var param_appendToFile = stub_appendToFile;
            var param_listOfT = new List<FakeBlogModel>();
            _fileDatabase.WriteDatabase(param_filePath, param_appendToFile, param_listOfT);
            _mockFileWriter.VerifyWriteNotCalled();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WriteDatabase_ListContainsOneObject_VerifyMockWriteMethodCalled(bool stub_appendToFile)
        {
            var stub_fakeBlogModel = new FakeBlogModel();
            var param_filePath = "path/to/the/file.json";
            var param_appendToFile = stub_appendToFile;
            var param_listOfT = new List<FakeBlogModel> { stub_fakeBlogModel };
            var expected_value = JsonConvert.SerializeObject(param_listOfT);
            _fileDatabase.WriteDatabase(param_filePath, param_appendToFile, param_listOfT);
            _mockFileWriter.VerifyWrite(param_filePath, param_appendToFile, expected_value);
        }

        private void AssertListOfFakeBlogModelAreEqual(List<FakeBlogModel> expected, List<FakeBlogModel> actual)
        {
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
                Assert.Equal(expected[i].FakeProperty, actual[i].FakeProperty);
        }
    }
}