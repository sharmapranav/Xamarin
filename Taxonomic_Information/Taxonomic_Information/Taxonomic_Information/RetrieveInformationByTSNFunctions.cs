using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxonomic_Information
{
    class RetrieveInformationByTSNFunctions
    {
        public async Task<string> GetAcceptedNamesFromTSN(string itisTSN)
        {
            var apiURL = $"getAcceptedNamesFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetCommentDetailFromTSN(string itisTSN)
        {
            var apiURL = $"getCommentDetailFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetCommonNamesFromTSN(string itisTSN)
        {
            var apiURL = $"getCommonNamesFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetCoreMetadataFromTSN(string itisTSN)
        {
            var apiURL = $"getCoreMetadataFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetCoverageFromTSN(string itisTSN)
        {
            var apiURL = $"getCoverageFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetCredibilityRatingFromTSN(string itisTSN)
        {
            var apiURL = $"getCredibilityRatingFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetCurrencyFromTSN(string itisTSN)
        {
            var apiURL = $"getCurrencyFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetDateDataFromTSN(string itisTSN)
        {
            var apiURL = $"getDateDataFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetExpertsFromTSN(string itisTSN)
        {
            var apiURL = $"getExpertsFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetFullRecordFromTSN(string itisTSN)
        {
            var apiURL = $"getFullRecordFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetGeographicDivisionsFromTSN(string itisTSN)
        {
            var apiURL = $"getGeographicDivisionsFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetGlobalSpeciesCompletenessFromTSN(string itisTSN)
        {
            var apiURL = $"getGlobalSpeciesCompletenessFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetJurisdictionalOriginFromTSN(string itisTSN)
        {
            var apiURL = $"getJurisdictionalOriginFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetKingdomNameFromTSN(string itisTSN)
        {
            var apiURL = $"getKingdomNameFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetOtherSourcesFromTSN(string itisTSN)
        {
            var apiURL = $"getOtherSourcesFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetParentTSNFromTSN(string itisTSN)
        {
            var apiURL = $"getParentTSNFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetPublicationsFromTSN(string itisTSN)
        {
            var apiURL = $"getPublicationsFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetReviewYearFromTSN(string itisTSN)
        {
            var apiURL = $"getReviewYearFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetScientificNameFromTSN(string itisTSN)
        {
            var apiURL = $"getScientificNameFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetSynonymNameFromTSN(string itisTSN)
        {
            var apiURL = $"getSynonymNamesFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetTaxonAuthorshipFromTSN(string itisTSN)
        {
            var apiURL = $"getTaxonAuthorshipFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetTaxonomicRankNameFromTSN(string itisTSN)
        {
            var apiURL = $"getTaxonomicRankNameFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetTaxonomicUsageFromTSN(string itisTSN)
        {
            var apiURL = $"getTaxonomicUsageFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }

        public async Task<string> GetUnacceptabilityReasonFromTSN(string itisTSN)
        {
            var apiURL = $"getUnacceptabilityReasonFromTSN?tsn={itisTSN}";
            return await WebService.Instance.GetContent(apiURL);
        }
    }
}
