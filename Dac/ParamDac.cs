using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using PET_ADOPTION_SYSTEM.Models;
namespace PET_ADOPTION_SYSTEM.Dacs
{
    public class ParamDac : IParamDac
    {
        private readonly string connectionString = "Data Source=(Localdb)\\MSSQLLocalDB;Database=PET_ADOPTION_SYSTEM;Trusted_Connection=True;MultipleActiveResultSets=true;";
        /// <summary>
        /// 取得單一參數下的資料
        /// </summary>
        /// <param name="SET_TYPE"></param>
        /// <returns></returns>
        public IEnumerable<SET_PARAM_Model> GetSET_PARAM(string SET_TYPE)
        {
            string sql = @"SELECT SET_TYPE, SET_ITEM, PARAM_VALUE, PARAM_DESC 
                           FROM SET_PARAM
                           WHERE SET_TYPE = @SET_TYPE";
            List<SET_PARAM_Model> result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<SET_PARAM_Model>(sql, new { SET_TYPE }).ToList();
            }
            return result;
        }
        /// <summary>
        /// 取得縣市資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CITY_MODEL> GetCITY()
        {
            string sql = @"SELECT *
                           FROM CITY";
            IEnumerable<CITY_MODEL> result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<CITY_MODEL>(sql);
            }
            return result;
        }
        /// <summary>
        /// 取得單一縣市中的鄉鎮市區
        /// </summary>
        /// <param name="CITY_ID"></param>
        /// <returns></returns>
        public IEnumerable<AREA_MODEL> GetSET_PARAM(int CITY_ID)
        {
            string sql = @"SELECT *
                           FROM AREA
                           WHERE CITY_ID = @CITY_ID";
            List<AREA_MODEL> result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<AREA_MODEL>(sql,new { CITY_ID }).ToList();
            }
            return result;
        }
        /// <summary>
        /// 取得單一動物種類下的品種資料
        /// </summary>
        /// <param name="ANIMAL_KIND"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_BREED_MODEL> GetANIMAL_BREED(string ANIMAL_KIND)
        {
            string sql = @"SELECT ANIMAL_BREED_ID, ANIMAL_KIND, ANIMAL_BREED_NAME
                           FROM ANIMAL_BREED
                           WHERE ANIMAL_KIND = @ANIMAL_KIND AND DATA_STATE = 'N'";
            List<ANIMAL_BREED_MODEL> result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<ANIMAL_BREED_MODEL>(sql, new { ANIMAL_KIND }).ToList();
            }
            return result;
        }


        public IEnumerable<AREA_MODEL> GetAREA(int CITY_ID)
        {
            string sql = @"SELECT *
                           FROM AREA
                           WHERE CITY_ID = @CITY_ID";
            IEnumerable<AREA_MODEL> result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                result = conn.Query<AREA_MODEL>(sql, new { CITY_ID});
            }
            return result;
        }

    }
}
