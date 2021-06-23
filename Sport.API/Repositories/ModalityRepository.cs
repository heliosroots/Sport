using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sport.API.Contexts;
using Sport.API.Models;

namespace Sport.API.Repositories
{
    public class ModalityRepository
    {
        private readonly DatabaseContext _database; 

        public ModalityRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<IList<Modality>> FindAll()
        {
            return await _database.Modalities.AsNoTracking().Where(p => p.Id > 0).ToListAsync();
        }
        
        public async Task<Modality> FindById(int id)
        {
            return await _database.Modalities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Add(Modality modality)
        {
            if (modality == null) 
            {
                return false;
            }

            _database.Modalities.Add(modality);
            return (await _database.SaveChangesAsync() > 0);
        }

        public async Task<bool> Update(Modality modality)
        {
            if (modality == null || modality.Id < 1)
            {
                return false;
            }

            _database.Modalities.Update(modality);
            return (await _database.SaveChangesAsync() > 0);
        }

        public async Task<bool> Remove(Modality modality)
        {
            if (modality == null || modality.Id < 1)
            {
                return false;
            }

            _database.Modalities.Remove(modality);
            return (await _database.SaveChangesAsync() > 0);
        }
    }
}
