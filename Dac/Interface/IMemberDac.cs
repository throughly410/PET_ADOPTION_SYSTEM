using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IMemberDac
    {
        MEMBER_MODEL GetMember(MEMBER_MODEL mEMBER_MODEL);
        void Create(MEMBER_MODEL memberModel);
    }
}