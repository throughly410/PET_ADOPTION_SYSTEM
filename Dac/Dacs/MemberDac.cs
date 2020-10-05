using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PET_ADOPTION_SYSTEM.Models;
namespace PET_ADOPTION_SYSTEM.Dacs
{
    public class MemberDac : _Dac, IMemberDac
    {
        //public IDbConnection connection { get; set; }

        public MemberDac(IOptions<SettingModel> setting):base(setting) { }
        public MEMBER_MODEL GetById(MEMBER_MODEL mEMBER_MODEL)
        {
            string sql = @"SELECT * FROM MEMBER WHERE ACCOUNT = @ACCOUNT";
            MEMBER_MODEL member = null;
            member = conn.Query<MEMBER_MODEL>(sql, mEMBER_MODEL).FirstOrDefault();
            return member;
        }
        public int Create(MEMBER_MODEL entity)
        {
            string sql = @"  INSERT INTO MEMBER
                                        (ACCOUNT, PASSWORD, [NAME], EMAIL, PHONE, ROLE, 
                                        DATA_STATE, CRT_USER, CRT_DATE, MDF_USER, MDF_DATE)
                             VALUES
                                        (@ACCOUNT, @PASSWORD, @NAME, @EMAIL, @PHONE, 1, 
                                        'N', @ACCOUNT, GETDATE(), @ACCOUNT, GETDATE());
                            SELECT CAST(SCOPE_IDENTITY() AS INT)";
            int id = conn.Query<int>(sql, entity).Single();
            return id;
        }

        public void Update(MEMBER_MODEL entity)
        {
            string sql = @"UPDATE MEMBER SET 
                           NAME=@NAME, EMAIL=@EMAIL, PHONE=@PHONE, 
                           MDF_USER = @MDF_USER, MDF_DATE = GETDATE()
                           WHERE ACCOUNT = @ACCOUNT";
            conn.Execute(sql, entity);
        }

        public void Delete(MEMBER_MODEL entity)
        {
            string sql = @"UPDATE MEMBER SET 
                           DATA_STATE = 'D', 
                           MDF_USER = @MDF_USER, MDF_DATE = GETDATE()
                           WHERE ACCOUNT = @ACCOUNT";
            conn.Execute(sql, entity);
        }

        public MEMBER_MODEL GetByAccountAndPassword(MEMBER_MODEL mEMBER_MODEL)
        {
            string sql = @"SELECT * FROM MEMBER WHERE ACCOUNT = @ACCOUNT AND PASSWORD = @PASSWORD";
            MEMBER_MODEL member = null;
            member = conn.Query<MEMBER_MODEL>(sql, mEMBER_MODEL).FirstOrDefault();
            return member;
        }
    }
}
