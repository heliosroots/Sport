using Sport.API.Models;
using Sport.API.Repositories;
using Sport.API.Test.Mocks;
using Xunit;

namespace Sport.API.Test.Repositories
{
    public class ModalityRepositoryTest
    {
        [Fact]
        public async void FindAll_WhenCalled_ReturnsAllModalities()
        {
            // Arrange
            var db = new DatabaseContextMock();
            var repo = new ModalityRepository(db);

            await db.PrepareModalitiesTable();

            // Act
            var result = await repo.FindAll();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count > -1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async void FindById_PastKnownId_ReturnAModality(int id)
        {
            // Arrange
            var db = new DatabaseContextMock();
            var repo = new ModalityRepository(db);

            await db.PrepareModalitiesTable();

            // Act
            var result = await repo.FindById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void BuscarPorId_PastUnknownId_ReturnNull()
        {
            // Arrange
            var db = new DatabaseContextMock();
            var repo = new ModalityRepository(db);

            await db.PrepareModalitiesTable();

            // Act
            var result = await repo.FindById(-1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void Add_PastModality_ReturnTrue()
        {
            // Arrange
            var db = new DatabaseContextMock();
            var repo = new ModalityRepository(db);
            var modality = new Modality("Basketball"); 

            // Act
            var result = await repo.Add(modality);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Update_PastModality_ReturnTrue()
        {
            // Arrange
            var db = new DatabaseContextMock();
            var repo = new ModalityRepository(db);

            await db.PrepareModalitiesTable();

            var modality = await repo.FindById(1);
            if (modality != null)
            {
                modality.Name = "Cycling";
                modality.Team = false; 
            } 

            // Act
            var result = await repo.Update(modality);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Remove_PastModality_ReturnTrue()
        {
            // Arrange
            var db = new DatabaseContextMock();
            var repo = new ModalityRepository(db);

            await db.PrepareModalitiesTable();

            var modality = await repo.FindById(3);
 
            // Act
            var result = await repo.Remove(modality);

            // Assert
            Assert.True(result);
        }
    }
}
