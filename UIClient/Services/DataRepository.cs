using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using UIClient.DataService;
using System.Xml;

namespace UIClient.Services
{
    public class DataRepository : IDataRepository
    {
        public async Task<string> GetUserLinks(string userGuid)
        {
            try
            {
                using (var service = new DataServiceClient())
                {
                    var response = await service.GetUserLinksAsync(userGuid);
                    return response.ConvertToJson();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> InsertLinkOrCreateUser(string fullLink, int? userId)
        {
            try
            {
                using (var service = new DataServiceClient())
                {
                    var response = await service.InsertLinkOrCreateUserAsync(fullLink,userId);
                    return response.ConvertToJson();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}