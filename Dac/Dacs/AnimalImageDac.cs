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
    public class AnimalImageDac : _Dac, IAnimalImageDac
    {
        public AnimalImageDac(IOptions<SettingModel> setting) : base(setting) { }
        //private readonly string connectionString = "Data Source=(Localdb)\\MSSQLLocalDB;Database=PET_ADOPTION_SYSTEM;Trusted_Connection=True;MultipleActiveResultSets=true;";

        /// <summary>
        /// 更新文章照片
        /// </summary>
        /// <param name="aNIMAL_IMAGE_MODEL"></param>
        public void Update(ANIMAL_IMAGE_MODEL aNIMAL_IMAGE_MODEL)
        {
            string sql = @"  MERGE INTO ANIMAL_IMAGE AS img
                                USING (VALUES(@POST_ID, @SEQ, @IMAGE_ADDRESS)) AS source (POST_ID, SEQ, IMAGE_ADDRESS)
                                    ON source.POST_ID = img.POST_ID AND source.SEQ = img.SEQ
                              WHEN MATCHED THEN
                                UPDATE SET IMAGE_ADDRESS = @IMAGE_ADDRESS, MDF_USER=@MDF_USER, MDF_DATE=@MDF_DATE
                              WHEN NOT MATCHED THEN
                                INSERT (POST_ID, SEQ, IMAGE_ADDRESS, DATA_STATE, CRT_USER, CRT_DATE, MDF_USER, MDF_DATE)
                                VALUES (@POST_ID,@SEQ,@IMAGE_ADDRESS, 'N', @CRT_USER, GETDATE(), @MDF_USER, GETDATE());";

                    int id = conn.Execute(sql, aNIMAL_IMAGE_MODEL);
        }

        /// <summary>
        /// 取得動物照片
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGEs_ById(int POST_ID)
        {
            string sql = @"SELECT POST_ID, SEQ, IMAGE_ADDRESS
                           FROM ANIMAL_IMAGE
                           WHERE POST_ID = @POST_ID AND DATA_STATE = 'N'
                           ORDER BY SEQ";
            IEnumerable<ANIMAL_IMAGE_MODEL> result = null;
            result = conn.Query<ANIMAL_IMAGE_MODEL>(sql, new { POST_ID});
            return result;
        }
      
        /// <summary>
        /// 一次取得頁面圖片
        /// </summary>
        /// <param name="postIds"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE_ByPage(List<int> postIds)
        {
            string sql = @"SELECT POST_ID, SEQ, IMAGE_ADDRESS
                           FROM ANIMAL_IMAGE
                           WHERE POST_ID IN @postIds AND DATA_STATE = 'N'
                           ORDER BY SEQ";
            IEnumerable<ANIMAL_IMAGE_MODEL> result = null;
            var P = new List<int>() { 3000, 3001, 3002, 3003, 3004 };
            result = conn.Query<ANIMAL_IMAGE_MODEL>(sql, new { postIds });
            return result;
        }

        public void Delete(ANIMAL_IMAGE_MODEL entity)
        {
            string sql = @"UPDATE ANIMAL_IMAGE 
                           SET DATA_STATE = 'D', MDF_USER = @MDF_USER, MDF_DATE = @MDF_DATE
                           WHERE POST_ID = @POST_ID";
            conn.Execute(sql, entity);
        }

        public int Create(ANIMAL_IMAGE_MODEL entity)
        {
            throw new NotImplementedException();
        }



        public ANIMAL_IMAGE_MODEL GetById(ANIMAL_IMAGE_MODEL entity)
        {
            throw new NotImplementedException();
        }
    }
}
