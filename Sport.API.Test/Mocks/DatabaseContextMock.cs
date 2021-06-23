using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sport.API.Contexts;
using Sport.API.Models;

namespace Sport.API.Test.Mocks
{
    class DatabaseContextMock : DatabaseContext
    {
        public DatabaseContextMock() : 
            base(new DbContextOptionsBuilder<DatabaseContext>()
                         .UseInMemoryDatabase(databaseName: "MemDabatabase")
                         .Options
                )
        {
        }
        public async Task PrepareModalitiesTable()
        {
            Modalities.Add(new Modality("Soccer", true));
            Modalities.Add(new Modality("Basketball", true));
            Modalities.Add(new Modality("Volleyball", true));
            Modalities.Add(new Modality("Swimming", false));
            Modalities.Add(new Modality("Athletics", false));
            await SaveChangesAsync();
        }
    }
}
