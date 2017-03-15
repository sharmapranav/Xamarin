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
    class LSIDFunctions
    {
        public async Task<string> GetLSIDFromTSN(string itisTSN)
        {
            var apiURL = $"getLSIDFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetTSNFromLSID(string lsid)
        {
            var apiURL = $"getTSNFromLSID?lsid={lsid}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetFullRecordFromLSID(string lsid)
        {
            var apiURL = $"getFullRecordFromLSID?lsid={lsid}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetRecordFromLSID(string lsid)
        {
            var apiURL = $"getRecordFromLSID?lsid={lsid}";
            return await WebService.Instance.GetContent(apiURL);
        }
    }
}
