using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PET_ADOPTION_SYSTEM.Models;
using PET_ADOPTION_SYSTEM.Services;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    public class ShelterController : _Controller
    {
        public IShelterService shelterService { get; }
        public ShelterController(IShelterService shelterService) 
        {
            this.shelterService = shelterService;
        }
        public IActionResult Shelter()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetShelterData([FromBody]SHELTER_PARAM_MODEL sHELTER_PARAM_MODEL)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string queryString = shelterService.JoinQueryParam(sHELTER_PARAM_MODEL);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://data.coa.gov.tw/Service/OpenData/TransService.aspx?UnitId=QcbUEzN6E6DL&$top=100" + queryString);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.Default);//Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                var result = JsonSerializer.Deserialize<List<SHELTER_MODEL>>(retString);
                myStreamReader.Close();
                myResponseStream.Close();
                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
