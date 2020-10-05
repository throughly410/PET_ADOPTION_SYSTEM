using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public class _Dac: IDisposable
    {
        public IDbConnection conn { get; set; }
        protected SettingModel setting { get; set; }
        public _Dac(IOptions<SettingModel> setting)
        {
            this.setting = setting.Value;
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~_Dac()
        {
            Dispose(false);
        }
    }
}
