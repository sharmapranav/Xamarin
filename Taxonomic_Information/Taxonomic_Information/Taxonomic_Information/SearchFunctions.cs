using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxonomic_Information;

namespace Taxonomic_Information
{
    class SearchFunctions
    {
        public async Task<string> SearchByCommonName(string searchKey)
        {
            var apiURL = $"searchByCommonName?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> SearchByCommonNameBeginsWith(string searchKey)
        {
            var apiURL = $"searchByCommonNameBeginsWith?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> SearchByCommonNameEndsWith(string searchKey)
        {
            var apiURL = $"searchByCommonNameEndsWith?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> SearchByScientificName(string searchKey)
        {
            var apiURL = $"searchByScientificName?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> SearchForAnyMatch(string searchKey)
        {
            var apiURL = $"searchForAnyMatch?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> SearchForAnyMatchPaged(string searchKey, int pageSize, int pageNumber, bool ascendingOrder)
        {
            var apiURL = $"searchForAnyMatchPaged?srchKey={searchKey}&pageSize={pageSize}&pageNum={pageNumber}&ascend={ascendingOrder}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetAnyMatchCount(string searchKey)
        {
            var apiURL = $"getAnyMatchCount?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetITISTerms(string searchKey)
        {
            var apiURL = $"getITISTerms?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetITISTermsfromCommonName(string searchKey)
        {
            var apiURL = $"getITISTermsFromCommonName?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetITISTermsfromScientificName(string searchKey)
        {
            var apiURL = $"getITISTermsFromScientificName?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetTSNsByVernacularLanguage(string searchKey)
        {
            var apiURL = $"getTsnByVernacularLanguage?srchKey={searchKey}";
            return await WebService.Instance.GetContent(apiURL);
        }
    }
}
