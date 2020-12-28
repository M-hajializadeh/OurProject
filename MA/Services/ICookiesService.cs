using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Services
{
    public interface ICookiesService
    {
        void Set(string key, string value, int? expireTime, bool? edit = false);
        void Remove(string key);
        void Delete(string key, string value);
        string Get(string key);
        List<string> GetListItem(string key);
    }
}
