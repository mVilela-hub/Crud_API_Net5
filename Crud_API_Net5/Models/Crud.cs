
using Dapper;
using Microsoft.AspNetCore.Cors;
using System.Data;
using System.Data.SqlClient;

namespace Crud_API_Net5.Models
{
    public class Crud
    {

        SqlConnection connectionString = new SqlConnection(@"Data Source=.;Initial Catalog=ClienteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public IDbConnection Connection
        {
            get
            {
                return connectionString;
            }
        }
        [DisableCors]
        public void Add(Cliente crud)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string insertQuerry = @"INSERT INTO [ClienteTable] (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";
                dbConnection.Open();
                dbConnection.Execute(insertQuerry, crud);

            }
        }
        [DisableCors]
        public IEnumerable<Cliente> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string selectQuerry = @"SELECT * FROM [ClienteTable]";
                dbConnection.Open();
                return dbConnection.Query<Cliente>(selectQuerry);
            }
        }
        [EnableCors("AnotherPolicy")]
        public Cliente GetById(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string selectQuerry = @"SELECT * FROM [ClienteTable] WHERE id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Cliente>(selectQuerry, new { id = Id }).FirstOrDefault();
            }
        }
        [EnableCors("AnotherPolicy")]
        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string deleteQuerry = @"DELETE FROM [ClienteTable] WHERE id = @Id";
                dbConnection.Open();
                dbConnection.Execute(deleteQuerry, new { id = Id });
            }
        }
        [DisableCors]
        public void Update(Cliente crud)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string updateQuerry = @"UPDATE [ClienteTable] SET Nome=@Nome, Sobrenome=@Sobrenome WHERE id=@id";
                dbConnection.Open();
                dbConnection.Execute(updateQuerry, crud);
            }
        }


    }
}
