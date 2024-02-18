using Dapper;
using DapperTest.Models;
using System.Data.SqlClient;

namespace DapperTest.Repository
{
    public class CardRepository
    {
        private readonly string _connectString = @"Server=(LocalDB)\MSSQLLocalDB;Database=Newbie;Trusted_Connection=True;";


        // 查詢卡片列表
        public IEnumerable<Card> GetList()
        {
            using(var conn = new SqlConnection(_connectString))
                return conn.Query<Card>("SELECT * FROM Card");
        }

        /// 查詢卡片
        public Card Get(int id)
        {
            var sql =
                    @"
                      SELECT *
                      FROM Card
                      Where Id = @id
                    ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);


            using (var conn = new SqlConnection(_connectString))
            { 
                var result = conn.QueryFirstOrDefault<Card>(sql, parameters);
                return result;
            }
        }


        //新增卡片
        public int Create(CardParameter parameter)
        {
            var sql =
                @"
                    INSERT INTO Card
                    (
                    [Name],
                    [Description],
                    [Attack],
                    [Health],
                    [Cost]
                )
                    VALUES
                (
                    @Name
                   ,@Description
                   ,@Attack
                   ,@Health
                   ,@Cost
                );
        
                SELECT @@IDENTITY;
                ";
            using(var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<int>(sql, parameter);
                return result;
            }
        }

        // 修改卡片
        public bool Update(int id,CardParameter parameter)
        {
            var sql =
                @"
                    UPDATE Card
                    SET 
                         [Name] = @Name
                        ,[Description] = @Description
                        ,[Attack] = @Attack
                        ,[Health] = @Health
                        ,[Cost] = @Cost
                    WHERE 
                        Id = @id
                ";
            var parameters = new DynamicParameters(parameter);
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using(var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }

        // 刪除卡片
        public void Delect(int id)
        {
            var sql =@"DELETE FROM Card WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
            }
        }
    }
}
