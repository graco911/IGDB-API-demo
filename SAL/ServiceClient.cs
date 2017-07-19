using System;
using System.Collections.Generic;
using Entities;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace SAL
{
    public class ServiceClient
    {
        public async Task<List<Game>> GetGamesAsync(string parameter)
        {
            string url = string.Format("https://igdbcom-internet-game-database-v1.p.mashape.com/games/?fields=name,cover&limit=50&offset=0&search={0}", parameter);
            List<Game> results = new List<Game>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Mashape-Key", "ST9UYMoHmBmshZox79IfndCOAaPrp1JNpnZjsn8d9drmwqa6FK");
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        var tem = res.Content.ReadAsStringAsync().Result;
                        if (tem.Length > 0)
                        {
                            JsonConvert.PopulateObject(tem, results);
                        }
                    }
                }
            }
            catch (Exception e){}
            return results;
        }

        public async Task<List<GameDetailInfo>> GetGameDetailAsync(int id)
        {
            List<GameDetailInfo> detailinfo = new List<GameDetailInfo>();
            var url = string.Format("https://igdbcom-internet-game-database-v1.p.mashape.com/games/{0}?fields=name,summary,cover,videos", id);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Mashape-Key", "ST9UYMoHmBmshZox79IfndCOAaPrp1JNpnZjsn8d9drmwqa6FK");
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        var tem = res.Content.ReadAsStringAsync().Result;
                        if (tem.Length > 0)
                        {
                            JsonConvert.PopulateObject(tem, detailinfo);
                        }
                    }
                }
            }
            catch (Exception e){}
            return detailinfo;
        }
    }
}