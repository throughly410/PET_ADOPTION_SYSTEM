using Dapper;
using Microsoft.Extensions.Options;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public class ArticleDac : _Dac, IArticleDac
    {
        public ArticleDac(IOptions<SettingModel> setting) : base(setting) { }
        //private readonly string connectionString = "Data Source=(Localdb)\\MSSQLLocalDB;Database=PET_ADOPTION_SYSTEM;Trusted_Connection=True;MultipleActiveResultSets=true;";
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <returns></returns>
        public int Create(ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            string sql = @"  INSERT INTO ANIMAL_POST
                                        (TITLE, CHIP_NO, ANIMAL_KIND, ANIMAL_SEX, ANIMAL_BREED, AREA_ID, REASON, POST_TYPE, 
                                        MEMO, DATA_STATE, CRT_USER, CRT_DATE, MDF_USER, MDF_DATE)
                             VALUES
                                        (@TITLE, @CHIP_NO, @ANIMAL_KIND, @ANIMAL_SEX, @ANIMAL_BREED, @AREA_ID, @REASON, @POST_TYPE, 
                                        @MEMO, 'N', @CRT_USER, GETDATE(), @MDF_USER, GETDATE());
                             SELECT CAST(SCOPE_IDENTITY() AS INT)";
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int id = conn.Query<int>(sql, aNIMAL_POST_MODEL).Single();
                    scope.Complete();
                    return id;
                }
            }
        }
        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        public void Update(ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            string sql = @"  UPDATE ANIMAL_POST SET
                                    TITLE=@TITLE, CHIP_NO=@CHIP_NO, ANIMAL_KIND=@ANIMAL_KIND, ANIMAL_SEX=@ANIMAL_SEX, 
                                    ANIMAL_BREED=@ANIMAL_BREED, AREA_ID=@AREA_ID, REASON=@REASON, POST_TYPE=POST_TYPE, 
                                    MEMO=@MEMO, MDF_USER=@MDF_USER, MDF_DATE=@MDF_DATE
                             WHERE POST_ID = @POST_ID";
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    conn.Execute(sql, aNIMAL_POST_MODEL);
                    scope.Complete();
                }
            }
        }


        /// <summary>
        /// 更新文章照片
        /// </summary>
        /// <param name="aNIMAL_IMAGE_MODEL"></param>
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
            using (var conn = new SqlConnection(setting.ConnectionString))
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
            using (var conn = new SqlConnection(setting.ConnectionString))
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
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                result = conn.Query<ANIMAL_POST_MODEL>(sql, new { POST_ID }).FirstOrDefault();
            }
            return result;
        }
        /// <summary>
        /// 取得動物照片
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID)
        {
            string sql = @"SELECT POST_ID, SEQ, IMAGE_ADDRESS
                           FROM ANIMAL_IMAGE
                           WHERE POST_ID = @POST_ID AND DATA_STATE = 'N'
                           ORDER BY SEQ";
            IEnumerable<ANIMAL_IMAGE_MODEL> result = null;
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                result = conn.Query<ANIMAL_IMAGE_MODEL>(sql, new { POST_ID });
            }
            return result;
        }
        /// <summary>
        /// 刪除文章
        /// </summary>
        /// <param name="POST_ID"></param>
        public void DeleteANIMAL_POST(int POST_ID)
        {
            string sql = @"UPDATE ANIMAL_POST 
                           SET DATA_STATE = 'D' 
                           WHERE POST_ID = @POST_ID";
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    conn.Execute(sql, new { POST_ID });
                    scope.Complete();
                }
            }
        }
        public IEnumerable<ANIMAL_POST_MODEL> GetANIMLA_POST_ByPage(ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            string sql = @"SELECT ap.POST_ID, ap.TITLE, kind.PARAM_DESC AS ANIMAL_KIND,
                                  sex.PARAM_DESC AS ANIMAL_SEX, breed.ANIMAL_BREED_NAME , area.AREA_NAME,
                                  TOTAL = COUNT(0) OVER()
	                      FROM ANIMAL_POST ap 
	                      LEFT JOIN SET_PARAM kind ON kind.SET_TYPE = 'AnimalKind' AND kind.PARAM_VALUE = ap.ANIMAL_KIND
	                      LEFT JOIN SET_PARAM sex ON sex.SET_TYPE = 'AnimalSex' AND sex.PARAM_VALUE = ap.ANIMAL_SEX
	                      LEFT JOIN ANIMAL_BREED breed ON breed.ANIMAL_BREED_ID = ap.ANIMAL_BREED
	                      LEFT JOIN AREA area ON area.AREA_ID = ap.AREA_ID
	                      WHERE ap.POST_TYPE = @POST_TYPE AND ap.DATA_STATE = 'N'
	                      ORDER BY POST_ID DESC
	                      OFFSET @SKIP ROWS 
	                      FETCH NEXT @TAKE ROWS ONLY";
            IEnumerable<ANIMAL_POST_MODEL> result = null;
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                result = conn.Query<ANIMAL_POST_MODEL>(sql, aNIMAL_POST_MODEL);
            }
            return result;
        }

        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE_ByPage(List<int> postIds)
        {
            string sql = @"SELECT POST_ID, SEQ, IMAGE_ADDRESS
                           FROM ANIMAL_IMAGE
                           WHERE POST_ID IN @postIds AND DATA_STATE = 'N'
                           ORDER BY SEQ";
            IEnumerable<ANIMAL_IMAGE_MODEL> result = null;
            var P = new List<int>() { 3000, 3001, 3002, 3003, 3004 };
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                result = conn.Query<ANIMAL_IMAGE_MODEL>(sql, new { postIds });
            }
            return result;
        }
    }
}
