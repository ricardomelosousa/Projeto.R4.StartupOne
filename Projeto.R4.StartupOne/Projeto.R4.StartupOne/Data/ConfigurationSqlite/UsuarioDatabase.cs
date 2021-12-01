using Projeto.R4.StartupOne.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.R4.StartupOne.Data.ConfigurationSqlite
{
    public class UsuarioDatabase
    {
        static SQLiteAsyncConnection Database;


        public static readonly AsyncLazy<UsuarioDatabase> Instance = new AsyncLazy<UsuarioDatabase>(async () =>
        {
            var instance = new UsuarioDatabase();
            CreateTableResult result = await Database.CreateTableAsync<LoginRequest>();
            return instance;
        });

        public UsuarioDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<LoginRequest>> GetItemsAsync()
        {
            return Database.Table<LoginRequest>().ToListAsync();
        }

        public Task<List<LoginRequest>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<LoginRequest>("SELECT * FROM [LoginRequest] WHERE [Ativo] = 0");
        }

        public Task<LoginRequest> GetItemAsync(int id)
        {
            return Database.Table<LoginRequest>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<LoginRequest> GetItemAsync(string login, string password)
        {
            return Database.Table<LoginRequest>().Where(i => i.Login == login && i.Password == password).FirstOrDefaultAsync();
        }

        public Task<LoginRequest> GetLastItemAsync()
        {
            return Database.FindAsync<LoginRequest>("SELEC top 1 FROM [LoginRequest]");
        }

        public Task<int> SaveItemAsync(LoginRequest item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(LoginRequest item)
        {
            return Database.DeleteAsync(item);
        }



    }
}
