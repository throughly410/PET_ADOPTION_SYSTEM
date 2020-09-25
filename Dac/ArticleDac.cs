using Dapper;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public class ArticleDac : IArticleDac
    {
        //public IEnumerable<MEMBER_MODEL> GetAllMembers()
        //{
        //    string sql = @"SELECT * FROM MEMBER";
        //    List<MEMBER_MODEL> members = null;
        //    using (var conn = new SqlConnection("Data Source=(Localdb)\\MSSQLLocalDB;Database=PET_ADOPTION_SYSTEM;Trusted_Connection=True;MultipleActiveResultSets=true;"))
        //    {
        //        members = conn.Query<MEMBER_MODEL>(sql).ToList();
        //    }
        //    return members;
        //}
        private readonly string connectionString = "Data Source=(Localdb)\\MSSQLLocalDB;Database=PET_ADOPTION_SYSTEM;Trusted_Connection=True;MultipleActiveResultSets=true;";
        public int Create(ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            string sql = @"  INSERT INTO ANIMAL_POST
                                        (TITLE, CHIP_NO, ANIMAL_KIND, ANIMAL_SEX, ANIMAL_BREED, AREA_ID, REASON, POST_TYPE, 
                                        MEMO, DATA_STATE, CRT_USER, CRT_DATE, MDF_USER, MDF_DATE)
                             VALUES
                                        (@TITLE, @CHIP_NO, @ANIMAL_KIND, @ANIMAL_SEX, @ANIMAL_BREED, @AREA_ID, @REASON, 1, 
                                        @MEMO, 'N', @CRT_USER, GETDATE(), @MDF_USER, GETDATE());
                             SELECT CAST(SCOPE_IDENTITY() AS INT)";
            using (var conn = new SqlConnection(connectionString))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int id = conn.Query<int>(sql, aNIMAL_POST_MODEL).Single();
                    scope.Complete();
                    return id;
                }
            }
        }

        public void Update(ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            string sql = @"  UPDATE ANIMAL_POST SET
                                    TITLE=@TITLE, CHIP_NO=@CHIP_NO, ANIMAL_KIND=@ANIMAL_KIND, ANIMAL_SEX=@ANIMAL_SEX, 
                                    ANIMAL_BREED=@ANIMAL_BREED, AREA_ID=@AREA_ID, REASON=@REASON, POST_TYPE=POST_TYPE, 
                                    MEMO=@MEMO, MDF_USER=@MDF_USER, MDF_DATE=@MDF_DATE
                             WHERE POST_ID = @POST_ID";
            using (var conn = new SqlConnection(connectionString))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    conn.Execute(sql, aNIMAL_POST_MODEL);
                    scope.Complete();
                }
            }
        }



        public void UpdateImage(ANIMAL_IMAGE_MODEL aNIMAL_IMAGE_MODEL)
        {
            string sql = @"  MERGE INTO ANIMAL_IMAGE AS img
                                USING (VALUES(@POST_ID, @SEQ, @IMAGE_ADDRESS)) AS source (POST_ID, SEQ, IMAGE_ADDRESS)
                                    ON source.POST_ID = img.POST_ID AND source.SEQ = img.SEQ
                              WHEN MATCHED THEN
                                UPDATE SET IMAGE_ADDRESS = @IMAGE_ADDRESS, MDF_USER=@MDF_USER, MDF_DATE=@MDF_DATE
                              WHEN NOT MATCHED THEN
                                INSERT (POST_ID, SEQ, IMAGE_ADDRESS, DATA_STATE, CRT_USER, CRT_DATE, MDF_USER, MDF_DATE)
                                VALUES (@POST_ID,@SEQ,@IMAGE_ADDRESS, 'N', @CRT_USER, GETDATE(), @MDF_USER, GETDATE());";
            using (var conn = new SqlConnection(connectionString))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int id = conn.Execute(sql, aNIMAL_IMAGE_MODEL);
                    scope.Complete();
                }
            }
        }



        /// <summary>
        /// 查詢使用者文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ANIMAL_POST_MODEL> GetANIMAL_POST_ByMember(string CRT_USER)
        {
            string sql = @"SELECT POST_ID, TITLE, POST_TYPE, MDF_DATE
                           FROM ANIMAL_POST
                           WHERE DATA_STATE = 'N' AND CRT_USER = @CRT_USER";
            IEnumerable<ANIMAL_POST_MODEL> result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<ANIMAL_POST_MODEL>(sql, new { CRT_USER });
            }
            return result;
        }

        /// <summary>
        /// 查詢文章詳細
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public ANIMAL_POST_MODEL GetANIMAL_POST_Detail(int POST_ID)
        {
            string sql = @"SELECT ap.*, ar.CITY_ID
                           FROM ANIMAL_POST ap
                           INNER JOIN AREA ar
                               ON ap.AREA_ID = ar.AREA_ID
                           WHERE POST_ID = @POST_ID";
            ANIMAL_POST_MODEL result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<ANIMAL_POST_MODEL>(sql, new { POST_ID }).FirstOrDefault();
            }
            return result;
        }

        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID)
        {
            string sql = @"SELECT POST_ID, SEQ, IMAGE_ADDRESS
                           FROM ANIMAL_IMAGE
                           WHERE POST_ID = @POST_ID AND DATA_STATE = 'N'
                           ORDER BY SEQ";
            IEnumerable<ANIMAL_IMAGE_MODEL> result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<ANIMAL_IMAGE_MODEL>(sql, new { POST_ID });
            }
            return result;
        }


    }
}
