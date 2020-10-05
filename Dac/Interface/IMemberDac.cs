using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IMemberDac: IGenericRepository<MEMBER_MODEL>
    {
        MEMBER_MODEL GetByAccountAndPassword(MEMBER_MODEL mEMBER_MODEL);
    }
}