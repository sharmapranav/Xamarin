using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxonomic_Information
{
    class HierararchyFunctions
    {
        public async Task<string> GetFullHierarchyFromTSN(string itisTSN)
        {
            var apiURL = $"getFullHierarchyFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetHierarchyDownFromTSN(string itisTSN)
        {
            var apiURL = $"getHierarchyDownFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetHierarchyUpFromTSN(string itisTSN)
        {
            var apiURL = $"getHierarchyUpFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }
    }
}
