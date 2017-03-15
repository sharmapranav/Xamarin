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
    class MetaInformationFunctions
    {
        public async Task<string> GetCredibilityRatings()
        {
            var apiURL = $"getCredibilityRatings";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetDescription()
        {
            var apiURL = $"getDescription";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetGeographicValues()
        {
            var apiURL = $"getGeographicValues";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetJurisdictionValues()
        {
            var apiURL = $"getJurisdictionValues";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetJurisdictionalOriginValues()
        {
            var apiURL = $"getJurisdictionalOriginValues";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetKingdomNames()
        {
            var apiURL = $"getKingdomNames";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetLastChangeDate()
        {
            var apiURL = $"getLastChangeDate";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetRankNames()
        {
            var apiURL = $"getRankNames";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetVernacularLanguages()
        {
            var apiURL = $"getVernacularLanguages";
            return await WebService.Instance.GetContent(apiURL);
        }
    }
}
