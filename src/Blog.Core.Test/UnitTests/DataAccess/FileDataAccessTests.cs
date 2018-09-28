using Blog.Core.Test.Fakes;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class FileDataAccessTests
    {
        [Fact]
        public void ClearDatabase_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";

            fileDataAccess.ClearDatabase(param_filePath);
        }

        [Fact]
        public void ClearDatabase_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";

            fileDataAccess.ClearDatabase(param_filePath);

            mockWriter.VerifyWrite(param_filePath, false, "");
        }

        [Fact]
        public void OverwriteToDatabase_ListOfEntityIsNull_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            List<FakeBlogModel> param_listOfEntity = null;

            fileDataAccess.OverwriteDatabase(param_filePath, param_listOfEntity);

            mockWriter.VerifyWriteNeverCalled();
        }

        [Fact]
        public void OverwriteToDatabase_ListOfEntityIsEmpty_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel>();

            fileDataAccess.OverwriteDatabase(param_filePath, param_listOfEntity);

            mockWriter.VerifyWriteNeverCalled();
        }

        [Fact]
        public void OverwriteDatabase_ListOfEntityIsValid_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };

            fileDataAccess.OverwriteDatabase(param_filePath, param_listOfEntity);
        }

        [Fact]
        public void OverwriteDatabase_ListOfEntityIsValid_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };

            fileDataAccess.OverwriteDatabase(param_filePath, param_listOfEntity);

            mockWriter.VerifyWrite(param_filePath, false, JsonConvert.SerializeObject(param_listOfEntity));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ReadDatabase_FileContentsAreNullOrEmpty_ReturnsEmptyList(string stub_fileContents)
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            stubReader.StubRead(stub_fileContents);
            var param_filePath = "path/to/the/file.json";
            var expected_return = new List<FakeBlogModel>();

            var actual_return = fileDataAccess.ReadDatabase(param_filePath);

            Assert.Equal(expected_return, actual_return);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ReadDatabase_FileContentsAreNullOrEmpty_VerifyReader(string stub_fileContents)
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            mockReader.StubRead(stub_fileContents);
            var param_filePath = "path/to/the/file.json";

            fileDataAccess.ReadDatabase(param_filePath);

            mockReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void ReadDatabase_FileContainsOneObject_ReturnsListWithTheOneObject()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var stub_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            var stub_fileContents = JsonConvert.SerializeObject(stub_listOfEntity);
            stubReader.StubRead(stub_fileContents);
            var expected_return = JsonConvert.DeserializeObject<List<FakeBlogModel>>(stub_fileContents);

            var actual_return = fileDataAccess.ReadDatabase(param_filePath);

            Assert.Equal(expected_return.Count, actual_return.Count);
            Assert.Equal(expected_return[0].FakeProperty, actual_return[0].FakeProperty);
        }

        [Fact]
        public void ReadDatabase_FileContainsOneObject_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var stub_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            var stub_fileContents = JsonConvert.SerializeObject(stub_listOfEntity);
            mockReader.StubRead(stub_fileContents);

            fileDataAccess.ReadDatabase(param_filePath);

            mockReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteToDatabase_EntityIsNull_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            FakeBlogModel param_entity = null;

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);
        }

        [Fact]
        public void WriteToDatabase_EntityIsNull_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            FakeBlogModel param_entity = null;

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);

            mockReader.VerifyReadNeverCalled();
        }

        [Fact]
        public void WriteToDatabase_EntityIsNull_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            FakeBlogModel param_entity = null;

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);

            mockWriter.VerifyWriteNeverCalled();
        }

        [Fact]
        public void WriteToDatabase_EntityIsValidAndDatabaseIsEmpty_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);
        }

        [Fact]
        public void WriteToDatabase_EntityIsValidAndDatabaseIsEmpty_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);

            mockReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteToDatabase_EntityIsValidAndDatabaseIsEmpty_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            FakeBlogModel param_entity = new FakeBlogModel();
            var expected_listOfEntity = new List<FakeBlogModel> { param_entity };

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);

            mockWriter.VerifyWrite(param_filePath, false, JsonConvert.SerializeObject(expected_listOfEntity));
        }

        [Fact]
        public void WriteToDatabase_EntityIsValidAndDatabaseContainsOneObject_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();
            var stub_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            stubReader.StubRead(JsonConvert.SerializeObject(stub_listOfEntity));

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);
        }

        [Fact]
        public void WriteToDatabase_EntityIsValidAndDatabaseContainsOneObject_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();
            var stub_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            mockReader.StubRead(JsonConvert.SerializeObject(stub_listOfEntity));

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);

            mockReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteToDatabase_EntityIsValidAndDatabaseContainsOneObject_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            var param_entity = new FakeBlogModel();
            var stub_fakeBlogModel = new FakeBlogModel();
            var stub_listOfEntity = new List<FakeBlogModel> { stub_fakeBlogModel };
            var stub_fileContents = JsonConvert.SerializeObject(stub_listOfEntity);
            stubReader.StubRead(stub_fileContents);
            stub_listOfEntity.Add(param_entity);

            fileDataAccess.WriteToDatabase(param_filePath, param_entity);

            mockWriter.VerifyWrite(param_filePath, false, JsonConvert.SerializeObject(stub_listOfEntity));
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsNull_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            List<FakeBlogModel> param_listOfEntity = null;

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsNull_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            List<FakeBlogModel> param_listOfEntity = null;

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockReader.VerifyReadNeverCalled();
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsNull_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            List<FakeBlogModel> param_listOfEntity = null;

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockWriter.VerifyWriteNeverCalled();
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsEmpty_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel>();

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsEmpty_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel>();

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockReader.VerifyReadNeverCalled();
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsEmpty_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel>();

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockWriter.VerifyWriteNeverCalled();
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsValidAndDatabaseIsEmpty_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsValidAndDatabaseIsEmpty_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsValidAndDatabaseIsEmpty_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockWriter.VerifyWrite(param_filePath, false, JsonConvert.SerializeObject(param_listOfEntity));
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsValidAndDatabaseContainsOneObject_Returns()
        {
            var stubReader = new StubIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            stubReader.StubRead(JsonConvert.SerializeObject(param_listOfEntity));

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsValidAndDatabaseContainsOneObject_VerifyReader()
        {
            var mockReader = new MockIFileReader();
            var stubWriter = new StubIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(mockReader, stubWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            mockReader.StubRead(JsonConvert.SerializeObject(param_listOfEntity));

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockReader.VerifyRead(param_filePath);
        }

        [Fact]
        public void WriteToDatabase_ListOfEntityIsValidAndDatabaseContainsOneObject_VerifyWriter()
        {
            var stubReader = new StubIFileReader();
            var mockWriter = new MockIFileWriter();
            var fileDataAccess = new FileDataAccess<FakeBlogModel>(stubReader, mockWriter);
            var param_filePath = "path/to/the/file.json";
            var param_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            var stub_listOfEntity = new List<FakeBlogModel> { new FakeBlogModel() };
            stubReader.StubRead(JsonConvert.SerializeObject(stub_listOfEntity));
            stub_listOfEntity.AddRange(param_listOfEntity);

            fileDataAccess.WriteToDatabase(param_filePath, param_listOfEntity);

            mockWriter.VerifyWrite(param_filePath, false, JsonConvert.SerializeObject(stub_listOfEntity));
        }
    }
}
