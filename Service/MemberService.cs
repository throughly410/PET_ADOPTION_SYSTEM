using PET_ADOPTION_SYSTEM.Dacs;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PET_ADOPTION_SYSTEM.Services
{


    public class MemberService:IMemberService
    {
        //private readonly IConfiguration configuration;

        //public MemberService(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        //public string GetConnectionString()
        //{
        //return  configuration.GetValue<string>("connectionString"); 

        //}
        private readonly IMemberDac memberDac;
        public MemberService(IMemberDac memberDac)
        {
            this.memberDac = memberDac;
        }
        public MEMBER_MODEL GetMember(MEMBER_MODEL mEMBER_MODEL)
        {
            return memberDac.GetMember(mEMBER_MODEL);
        }

        public RESULT_MODEL InsertMember(MEMBER_MODEL memberModel)
        {
            memberModel.CRT_DATE = DateTime.Now;
            memberModel.MDF_DATE = DateTime.Now;
            memberModel.CRT_USER = "Kevin";
            memberDac.Create(memberModel);
            RESULT_MODEL result = new RESULT_MODEL(1, "執行成功");
            return result;
        }


    }
}
