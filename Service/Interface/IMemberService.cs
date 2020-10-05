using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Services
{
    public interface IMemberService
    {
        //string GetConnectionString();
        MEMBER_MODEL GetMember(MEMBER_MODEL mEMBER_MODEL);
        MEMBER_MODEL GetMemberByAccountAndPassword(MEMBER_MODEL mEMBER_MODEL);
        ResultModel InsertMember(MEMBER_MODEL memberModel);
    }
}