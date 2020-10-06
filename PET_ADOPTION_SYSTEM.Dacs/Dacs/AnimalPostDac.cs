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
    public class AnimalPostDac : _Dac, IAnimalPostDac
    {
        public AnimalPostDac(IOptions<SettingModel> setting) : base(setting) { }
        //private readonly string connectionString = "Data Source=(Localdb)\\MSSQLLocalDB;Database=PET_ADOPTION_SYSTEM;Trusted_Connection=True;MultipleActiveResultSets=true;";
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <returns></returns>
        public int Create(ANIMAL_POST_MODEL entity)
        {
            string sql = @"  INSERT INTO ANIMAL_POST
                                        (TITLE, CHIP_NO, ANIMAL_KIND, ANIMAL_SEX, ANIMAL_BREED, AREA_ID, REASON, POST_TYPE, 
                                        MEMO, DATA_STATE, CRT_USER, CRT_DATE, MDF_USER, MDF_DATE)
                             VALUES
                                        (@TITLE, @CHIP_NO, @ANIMAL_KIND, @ANIMAL_SEX, @ANIMAL_BREED, @AREA_ID, @REASON, @POST_TYPE, 
                                        @MEMO, 'N', @CRT_USER, GETDATE(), @MDF_USER, GETDATE());
                             SELECT CAST(SCOPE_IDENTITY() AS INT)";

                    int id = conn.Query<int>(sql, entity).Single();
                    return id;
        }
        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        public void Update(ANIMAL_POST_MODEL entity)
        {
            string sql = @"  UPDATE ANIMAL_POST SET
                                    TITLE=@TITLE, CHIP_NO=@CHIP_NO, ANIMAL_KIND=@ANIMAL_KIND, ANIMAL_SEX=@ANIMAL_SEX, 
                                    ANIMAL_BREED=@ANIMAL_BREED, AREA_ID=@AREA_ID, REASON=@REASON, POST_TYPE=POST_TYPE, 
                                    MEMO=@MEMO, MDF_USER=@MDF_USER, MDF_DATE=@MDF_DATE
                             WHERE POST_ID = @POST_ID";
                    conn.Execute(sql, entity);
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
            result = conn.Query<ANIMAL_POST_MODEL>(sql, new { CRT_USER });
            return result;
        }
        /// <summary>
        /// 查詢文章詳細
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public ANIMAL_POST_MODEL GetById(ANIMAL_POST_MODEL entity)
        {
            string sql = @"SELECT ap.*, ar.CITY_ID
                           FROM ANIMAL_POST ap
                           INNER JOIN AREA ar
                               ON ap.AREA_ID = ar.AREA_ID
                           WHERE POST_ID = @POST_ID";
            ANIMAL_POST_MODEL result = null;
            result = conn.Query<ANIMAL_POST_MODEL>(sql, entity).FirstOrDefault();
            return result;
        }
       
        /// <summary>
        /// 刪除文章
        /// </summary>
        /// <param name="POST_ID"></param>
        public void Delete(ANIMAL_POST_MODEL entity)
        {
            string sql = @"UPDATE ANIMAL_POST 
                           SET DATA_STATE = 'D' 
                           WHERE POST_ID = @POST_ID";
                    conn.Execute(sql, entity);
        }
        /// <summary>
        /// 一次取得頁面文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <returns></returns>
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
            result = conn.Query<ANIMAL_POST_MODEL>(sql, aNIMAL_POST_MODEL);
            return result;
        }
    }
}
