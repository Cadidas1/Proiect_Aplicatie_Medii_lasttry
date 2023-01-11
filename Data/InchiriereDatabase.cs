using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proiect_Aplicatie_Medii_lasttry.Models;
namespace Proiect_Aplicatie_Medii_lasttry.Data
{
    public class InchiriereDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public InchiriereDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Inchiriere>().Wait();
            _database.CreateTableAsync<Masina>().Wait();
            _database.CreateTableAsync<ListaMasina>().Wait();
        }
        public Task<int> SaveMasinaAsync(Masina masina)
        {
            if (masina.ID != 0)
            {
                return _database.UpdateAsync(masina);
            }
            else
            {
                return _database.InsertAsync(masina);
            }
        }
        public Task<int> DeleteMasinaAsync(Masina masina)
        {
            return _database.DeleteAsync(masina);
        }
        public Task<List<Masina>> GetMasiniAsync()
        {
            return _database.Table<Masina>().ToListAsync();
        }
        public Task<List<Inchiriere>> GetInchiriereAsync()
        {
            return _database.Table<Inchiriere>().ToListAsync();
        }
        public Task<Inchiriere> GetInchiriereAsync(int id)
        {
            return _database.Table<Inchiriere>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveInchiriereAsync(Inchiriere slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteInchiriereAsync(Inchiriere slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveListaMasinaAsync(ListaMasina listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Masina>> GetListaMasiniAsync(int inchiriereid)
        {
            return _database.QueryAsync<Masina>(
            "select P.ID, P.Descriere from Masina P"
            + " inner join ListaMasina LP"
            + " on P.ID = LP.MasinaID where LP.InchiriereID = ?",
            inchiriereid);
        }
    }
}
