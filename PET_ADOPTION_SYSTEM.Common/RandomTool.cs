using System;

namespace PET_ADOPTION_SYSTEM.Common
{
    public class RandomTool
    {
        /// <summary>
        /// 取得GUID隨機字串
        /// </summary>
        /// <returns></returns>
        public static string GetGuidString()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
