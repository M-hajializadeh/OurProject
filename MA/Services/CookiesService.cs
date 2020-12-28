using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Services
{
    public class CookiesService : ICookiesService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookiesService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public string Get(string key)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies[key] == null)
            {
                return null;
            }
            return _httpContextAccessor.HttpContext.Request.Cookies[key].ToString();
        }

        public List<string> GetListItem(string key)
        {
            string getContent = Get(key);
            if (getContent == null)
                return null;
            List<string> cookieContent = new List<string>();
            string[] content = getContent.Split(',');
            content = content.Where(r => r != "").ToArray();
            return content.ToList();
        }

        public void Remove(string key)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies[key] != null)
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
        public void Delete(string key, string value)
        {
            List<string> item = GetListItem(key);
            if (item.Count() > 1)
            {
                if (item.Contains(value))
                {
                    item.Remove(value);
                }
                //string[] val = new string[item.Count() - 1];
                //int count = 0;
                string val="";
                foreach (var id in item)
                {
                    val += "," + id + ",";
                }
                Set(key, val, 30,true);
            }
            else
                Remove(key);
        }

        public void Set(string key, string value, int? expireTime, bool? edit=false)
        {
            CookieOptions options = new CookieOptions();
            if (expireTime.HasValue)
                options.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                options.Expires = DateTime.Now.AddMinutes(30);
            if (_httpContextAccessor.HttpContext.Request.Cookies[key] == null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append(key, "," + value + ",", options);
            }
            else
            {
                if (edit == false)
                {
                    string content = Get(key);
                    if (!content.Contains("," + value + ","))
                    {
                        content += "," + value + ",";
                        _httpContextAccessor.HttpContext.Response.Cookies.Append(key, content, options);
                    }
                }
                else
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
                }

            }
        }

    }
}
