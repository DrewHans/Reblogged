using Blog.Core.Test.Fakes;
using Blog.Core.Test.Mocks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class FileDataAccessTests : IDisposable
    {
        private MockIFileReader _mockFileReader;
        private MockIFileWriter _mockFileWriter;
        private readonly FileDataAccess<FakeBlogModel> _fileDataAccess;

        public FileDataAccessTests()
        {
            _mockFileReader = new MockIFileReader();
            _mockFileWriter = new MockIFileWriter();
            _fileDataAccess = new FileDataAccess<FakeBlogModel>(_mockFileReader, _mockFileWriter);
        }

        public void Dispose() { }

        [Fact]
        public void ClearDatabase_VerifyMockWriteMethodCalled()
        {
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();
            var expected_appendToFile = false;
            var expected_value = "";
            _fileDataAccess.ClearDatabase(param_filePath);
            _mockFileWriter.VerifyWrite(param_filePath, expected_appendToFile, expected_value);
        }

        [Fact]
        public void OverwriteToDatabase_ListOfEntityIsNull_VerifyMockWriteMethodNotCalled()
        {
            var param_filePath = "path/to/the/file.json";
            List<FakeBlogModel> param_listOfEntity = null;
            _fileDataAccess.OverwriteDatabase(param_filePath, param_listOfEntity);
            _mockFileWriter.VerifyWriteNotCalled();
        }

        [Fact]
        public void OverwriteToDatabase_ListOfEntityIsEmpty_VerifyMockWriteMethodNotCalled()
        {
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel>();
            _fileDataAccess.OverwriteDatabase(param_filePath, param_listOfEntity);
            _mockFileWriter.VerifyWriteNotCalled();
        }

        [Fact]
        public void OverwriteDatabase_ListOfEntityIsValid_VerifyMockWriteMethodCalled()
        {
            var stub_fakeBlogModel = new FakeBlogModel();
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { stub_fakeBlogModel };
            var expected_appendToFile = false;
            var expected_value = JsonConvert.SerializeObject(param_listOfEntity);
            _fileDataAccess.OverwriteDatabase(param_filePath, param_listOfEntity);
            _mockFileWriter.VerifyWrite(param_filePath, expected_appendToFile, expected_value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ReadDatabase_FileContentsAreNullOrEmpty_ReturnsEmptyList(string stub_fileContents)
        {
            var param_filePath = "path/to/the/file.json";
            _mockFileReader.StubRead(stub_fileContents);
            var expected = new List<FakeBlogModel>();
            var returned = _fileDataAccess.ReadDatabase(param_filePath);
            Assert.Equal(expected, returned);
            _mockFileReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void ReadDatabase_FileContainsOneObject_ReturnsListWithTheOneObject()
        {
            var param_filePath = "path/to/the/file.json";
            var stub_fakeBlogModel = new FakeBlogModel();
            var stub_listOfEntity = new List<FakeBlogModel> { stub_fakeBlogModel };
            var stub_fileContents = JsonConvert.SerializeObject(stub_listOfEntity);
            _mockFileReader.StubRead(stub_fileContents);
            var expected = JsonConvert.DeserializeObject<List<FakeBlogModel>>(stub_fileContents);
            var returned = _fileDataAccess.ReadDatabase(param_filePath);
            AssertListOfFakeBlogModelAreEqual(expected, returned);
            _mockFileReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteToDatabase_EntityIsNull_VerifyMockWriteMethodNotCalled()
        {
            var param_filePath = "path/to/the/file.json";
            FakeBlogModel param_entity = null;
            _fileDataAccess.WriteToDatabase(param_filePath, param_entity);
            _mockFileWriter.VerifyWriteNotCalled();
            _mockFileReader.VerifyReadNotCalled();
        }

        [Fact]
        public void WriteDatabase_EntityIsValidAndDatabaseIsEmpty_VerifyMockWriteMethodCalled()
        {
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();
            var expected_appendToFile = false;
            var expected_listOfEntity = new List<FakeBlogModel> { param_entity };
            var expected_value = JsonConvert.SerializeObject(expected_listOfEntity);
            _fileDataAccess.WriteToDatabase(param_filePath, param_entity);
            _mockFileWriter.VerifyWrite(param_filePath, expected_appendToFile, expected_value);
            _mockFileReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteDatabase_EntityIsValidAndDatabaseContainsOneObject_VerifyMockWriteMethodCalled()
        {
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();
            var stub_fakeBlogModel = new FakeBlogModel();
            var stub_listOfEntity = new List<FakeBlogModel> { stub_fakeBlogModel };
            var stub_fileContents = JsonConvert.SerializeObject(stub_listOfEntity);
            _mockFileReader.StubRead(stub_fileContents);
            stub_listOfEntity.Add(param_entity);
            var expected_appendToFile = false;
            var expected_listOfEntity = stub_listOfEntity;
            var expected_value = JsonConvert.SerializeObject(expected_listOfEntity);
            _fileDataAccess.WriteToDatabase(param_filePath, param_entity);
            _mockFileWriter.VerifyWrite(param_filePath, expected_appendToFile, expected_value);
            _mockFileReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsNull_VerifyMockWriteMethodNotCalled()
        {
            var param_filePath = "path/to/the/file.json";
            List<FakeBlogModel> param_listOfEntity = null;
            _fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
            _mockFileWriter.VerifyWriteNotCalled();
            _mockFileReader.VerifyReadNotCalled();
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsEmpty_VerifyMockWriteMethodNotCalled()
        {
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel>();
            _fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
            _mockFileWriter.VerifyWriteNotCalled();
            _mockFileReader.VerifyReadNotCalled();
        }

        [Fact]
        public void WriteDatabase_ListOfEntityIsValidAndDatabaseIsEmpty_VerifyMockWriteMethodCalled()
        {
            var stub_fakeBlogModel = new FakeBlogModel();
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { stub_fakeBlogModel };
            var expected_appendToFile = false;
            var expected_value = JsonConvert.SerializeObject(param_listOfEntity);
            _fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
            _mockFileWriter.VerifyWrite(param_filePath, expected_appendToFile, expected_value);
            _mockFileReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteDatabase_ListOfEntityIsValidAndDatabaseContainsOneObject_VerifyMockWriteMethodCalled()
        {
            var stub_fakeBlogModel = new FakeBlogModel();
            var stub_listOfEntity = new List<FakeBlogModel> { stub_fakeBlogModel };
            var stub_fileContents = JsonConvert.SerializeObject(stub_listOfEntity);
            _mockFileReader.StubRead(stub_fileContents);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { stub_fakeBlogModel };
            stub_listOfEntity.AddRange(param_listOfEntity);
            var expected_appendToFile = false;
            var expected_value = JsonConvert.SerializeObject(stub_listOfEntity);
            _fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
            _mockFileWriter.VerifyWrite(param_filePath, expected_appendToFile, expected_value);
            _mockFileReader.VerifyRead(param_filePath);
        }

        private void AssertListOfFakeBlogModelAreEqual(List<FakeBlogModel> expected, List<FakeBlogModel> actual)
        {
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
                Assert.Equal(expected[i].FakeProperty, actual[i].FakeProperty);
        }
    }
}