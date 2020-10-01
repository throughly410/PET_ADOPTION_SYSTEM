using System;
using System.Collections.Generic;
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
        public MemberDac(IOptions<SettingModel> setting):base(setting) { }
        public MEMBER_MODEL GetMember(MEMBER_MODEL mEMBER_MODEL)
        {
            string sql = @"SELECT * FROM MEMBER WHERE ACCOUNT = @ACCOUNT";
            MEMBER_MODEL member = null;
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                member = conn.Query<MEMBER_MODEL>(sql, mEMBER_MODEL).FirstOrDefault();
            }
            return member;
        }

        public void Create(MEMBER_MODEL memberModel)
        {
            string sql = @"  INSERT INTO MEMBER
                                        (ACCOUNT, PASSWARD, [NAME], EMAIL, PHONE, ROLE, 
                                        DATA_STATE, CRT_USER, CRT_DATE, MDF_USER, MDF_DATE)
                             VALUES
                                        (@ACCOUNT, @PASSWARD, @NAME, @EMAIL, @PHONE, 1, 
                                        'N', @CRT_USER, GETDATE(), @MDF_USER, GETDATE());";
            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                using(TransactionScope scope = new TransactionScope())
                {
                    conn.Execute(sql, memberModel);
                    scope.Complete();
                }
            }
        }
    }
}
