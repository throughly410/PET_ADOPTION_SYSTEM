using System;
using System.Collections.Generic;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IRepository<T>
    {
        void Create();
        void Update();
        void Delete();
        T Get();

    }
}
