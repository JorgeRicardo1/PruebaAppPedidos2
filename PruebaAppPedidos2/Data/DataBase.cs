using PruebaAppPedidos2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAppPedidos2.Data
{
    public  class DataBase
    {
        readonly SQLiteAsyncConnection Connection;
        public DataBase(string dbPath, SQLiteAsyncConnection liteConnection)
        {
            liteConnection = new SQLiteAsyncConnection(dbPath);
            liteConnection .CreateTableAsync<EmpresaModel>().Wait();
            Connection = liteConnection;
        }

        public async Task<int> insertEmpresaAsync(EmpresaModel empresa)
        {
            return await Connection.InsertAsync(empresa);
        }
        public async Task<List<EmpresaModel>> getEmpresaAsync()
        {
            return await Connection.Table<EmpresaModel>().ToListAsync().ConfigureAwait(false);
        }
        public async Task<int> updateEmpresaAsync(EmpresaModel empresa)
        {
            return await Connection.UpdateAsync(empresa);
        }
    }
}
