using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxonomic_Information
{
    /// <summary>
    /// All API descriptions and documentation can be accessed at https://www.itis.gov/ws_description.html
    /// </summary>
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
