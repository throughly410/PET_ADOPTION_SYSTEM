using System;
using System.Collections.Generic;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Models
{
    public class ResultModel
    {
        public ResultModel(int responseStatus = 1, string message="", dynamic data=null)
        {
            this.responseStatus = responseStatus;
            this.message = message;
            this.data = data;
        }
        /// <summary>
        /// 回傳狀態 1/成功 2/失敗
        /// </summary>
        public int responseStatus { get; set; }
        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 回傳資料
        /// </summary>
        public object data { get; set; }
    }
}
