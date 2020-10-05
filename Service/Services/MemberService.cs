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

        private readonly IUnitOfWork uow;
        public MemberService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="mEMBER_MODEL"></param>
        /// <returns></returns>
        public MEMBER_MODEL GetMember(MEMBER_MODEL mEMBER_MODEL)
        {
            return uow.memberDac.GetById(mEMBER_MODEL);
        }
        /// <summary>
        /// 取得登入者資料
        /// </summary>
        /// <param name="mEMBER_MODEL"></param>
        /// <returns></returns>
        public MEMBER_MODEL GetMemberByAccountAndPassword(MEMBER_MODEL mEMBER_MODEL)
        {
            return uow.memberDac.GetByAccountAndPassword(mEMBER_MODEL);
        }
        /// <summary>
        /// 新增會員
        /// </summary>
        /// <param name="memberModel"></param>
        /// <returns></returns>
        public ResultModel InsertMember(MEMBER_MODEL memberModel)
        {
            memberModel.CRT_DATE = DateTime.Now;
            memberModel.MDF_DATE = DateTime.Now;
            uow.Begin();
            uow.Open();
            uow.memberDac.Create(memberModel);
            uow.Commit();
            ResultModel result = new ResultModel(1, "執行成功");
            return result;
        }
    }
}
