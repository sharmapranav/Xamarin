using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taxonomic_Information
{
    public partial class SearchPage : ContentPage
    {
        APIItem apiItem;

        public SearchPage(APIItem apiItem)
        {
            InitializeComponent();

            this.apiItem = apiItem;

            Title = $"{apiItem.apiName}";

            for (int i = 0; i < apiItem.placeholderKeyValues.Count; i += 2)
            {
                var label = new Label { Text = apiItem.placeholderKeyValues[i], FontSize = 18, };
                var entry = new Entry { WidthRequest = 200, Placeholder = apiItem.placeholderKeyValues[i + 1] };

                grid.Children.Add(label, 0, i);
                grid.Children.Add(entry, 1, i);
            }
        }

        async void Search_Clicked(object sender, EventArgs e)
        {
            string content = string.Empty;
            output.Text = content;

            var entries = grid.Children.OfType<Entry>().ToList();

            if (entries.Where(x => string.IsNullOrEmpty(x.Text)).Count() > 0)
            {
                await DisplayAlert("Error!", "Fill all values", "OK");
                return;
            }

            activityIndicator.IsVisible = !activityIndicator.IsVisible;

            try
            {
                switch (apiItem.apiGroup)
                {
                    case "Search Functions":
                        string searchKey = entries[0].Text;

                        if (entries.Count == 1)
                        {
                            content = await GetSearchFunctionsContent(searchKey);
                        }
                        else
                        {
                            int pageSize;
                            int pageNumber;
                            bool ascendingOrder;

                            if (!int.TryParse(entries[1].Text, out pageSize))
                            {
                                await DisplayAlert("Error!", $"{entries[1].Text} is not a number", "OK");
                                return;
                            }
                            if (!int.TryParse(entries[2].Text, out pageNumber))
                            {
                                await DisplayAlert("Error!", $"{entries[2].Text} is not a number", "OK");
                                return;
                            }
                            if (!bool.TryParse(entries[3].Text, out ascendingOrder))
                            {
                                await DisplayAlert("Error!", $"{entries[3].Text} is not a valid value, enter 'true' or 'false'", "OK");
                                return;
                            }
                            content = await GetSearchFunctionsContent(searchKey, pageSize, pageNumber, ascendingOrder);
                        }
                        break;
                    case "Retrieve Information By TSN Functions":
                        string itisTSN = entries[0].Text;
                        content = await GetRetrieveInformationByTSNFunctionsContent(itisTSN);
                        break;
                    case "Hierararchy Functions":
                        itisTSN = entries[0].Text;
                        content = await GetHierararchyFunctionsContent(itisTSN);
                        break;
                    case "LSID Functions":
                        string lsid = entries[0].Text;
                        content = await GetLSIDFunctionsContent(lsid);
                        break;
                    case "Meta-Information Functions":
                        content = await GetMetaInformationFunctionsContent();
                        break;
                }

                if (content != null)
                {
                    var obj = JsonConvert.DeserializeObject(content);
                    content = JsonConvert.SerializeObject(obj, Formatting.Indented);
                    output.Text = content;
                }
                else
                {
                    output.Text = "No results found!";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert($"Error! {ex.Message}", ex.StackTrace, "OK");
            }

            activityIndicator.IsVisible = !activityIndicator.IsVisible;
        }

        async Task<string> GetSearchFunctionsContent(string searchKey, int pageSize = 0, int pageNumber = 0, bool ascendingOrder = true)
        {
            var searchFunctions = new SearchFunctions();

            switch (apiItem.apiName)
            {
                case "Search by Common Name":
                    return await searchFunctions.SearchByCommonName(searchKey);
                case "Search by Common Name Begins With":
                    return await searchFunctions.SearchByCommonNameBeginsWith(searchKey);
                case "Search by Common Name Ends With":
                    return await searchFunctions.SearchByCommonNameEndsWith(searchKey);
                case "Search by Scientific Name":
                    return await searchFunctions.SearchByScientificName(searchKey);
                case "Search for Any Match":
                    return await searchFunctions.SearchForAnyMatch(searchKey);
                case "Search for Any Match Paged":
                    return await searchFunctions.SearchForAnyMatchPaged(searchKey, pageSize, pageNumber, ascendingOrder);
                case "Get Any Match Count":
                    return await searchFunctions.GetAnyMatchCount(searchKey);
                case "Get ITIS Terms":
                    return await searchFunctions.GetITISTerms(searchKey);
                case "Get ITIS Terms from Common Name":
                    return await searchFunctions.GetITISTermsfromCommonName(searchKey);
                case "Get ITIS Terms from Scientific Name":
                    return await searchFunctions.GetITISTermsfromScientificName(searchKey);
                case "Get TSNs By Vernacular Language":
                    return await searchFunctions.GetTSNsByVernacularLanguage(searchKey);
            }

            return null;
        }

        async Task<string> GetRetrieveInformationByTSNFunctionsContent(string itisTSN)
        {
            var retrieveInformationByTSNFunctions = new RetrieveInformationByTSNFunctions();

            switch (apiItem.apiName)
            {
                case "Get Accepted Names from TSN":
                    return await retrieveInformationByTSNFunctions.GetAcceptedNamesFromTSN(itisTSN);
                case "Get Comment Detail from TSN":
                    return await retrieveInformationByTSNFunctions.GetCommentDetailFromTSN(itisTSN);
                case "Get Common Names from TSN":
                    return await retrieveInformationByTSNFunctions.GetCommonNamesFromTSN(itisTSN);
                case "Get Core Metadata from TSN":
                    return await retrieveInformationByTSNFunctions.GetCoreMetadataFromTSN(itisTSN);
                case "Get Coverage from TSN":
                    return await retrieveInformationByTSNFunctions.GetCoverageFromTSN(itisTSN);
                case "Get Credibility Rating from TSN":
                    return await retrieveInformationByTSNFunctions.GetCredibilityRatingFromTSN(itisTSN);
                case "Get Currency from TSN":
                    return await retrieveInformationByTSNFunctions.GetCurrencyFromTSN(itisTSN);
                case "Get Date Data from TSN":
                    return await retrieveInformationByTSNFunctions.GetDateDataFromTSN(itisTSN);
                case "Get Experts from TSN":
                    return await retrieveInformationByTSNFunctions.GetExpertsFromTSN(itisTSN);
                case "Get Full Record From TSN":
                    return await retrieveInformationByTSNFunctions.GetFullRecordFromTSN(itisTSN);
                case "Get Geographic Divisions from TSN":
                    return await retrieveInformationByTSNFunctions.GetGeographicDivisionsFromTSN(itisTSN);
                case "Get Global Species Completeness from TSN":
                    return await retrieveInformationByTSNFunctions.GetGlobalSpeciesCompletenessFromTSN(itisTSN);
                case "Get Jurisdictional Origin from TSN":
                    return await retrieveInformationByTSNFunctions.GetJurisdictionalOriginFromTSN(itisTSN);
                case "Get Kingdom Name from TSN":
                    return await retrieveInformationByTSNFunctions.GetKingdomNameFromTSN(itisTSN);
                case "Get Other Sources from TSN":
                    return await retrieveInformationByTSNFunctions.GetOtherSourcesFromTSN(itisTSN);
                case "Get Parent TSN from TSN":
                    return await retrieveInformationByTSNFunctions.GetParentTSNFromTSN(itisTSN);
                case "Get Publications from TSN":
                    return await retrieveInformationByTSNFunctions.GetPublicationsFromTSN(itisTSN);
                case "Get Review Year from TSN":
                    return await retrieveInformationByTSNFunctions.GetReviewYearFromTSN(itisTSN);
                case "Get Scientific Name from TSN":
                    return await retrieveInformationByTSNFunctions.GetScientificNameFromTSN(itisTSN);
                case "Get Synonym Name from TSN":
                    return await retrieveInformationByTSNFunctions.GetSynonymNameFromTSN(itisTSN);
                case "Get Taxon Authorship from TSN":
                    return await retrieveInformationByTSNFunctions.GetTaxonAuthorshipFromTSN(itisTSN);
                case "Get Taxonomic Rank Name from TSN":
                    return await retrieveInformationByTSNFunctions.GetTaxonomicRankNameFromTSN(itisTSN);
                case "Get Taxonomic Usage from TSN":
                    return await retrieveInformationByTSNFunctions.GetTaxonomicUsageFromTSN(itisTSN);
                case "Get Unacceptability Reason from TSN":
                    return await retrieveInformationByTSNFunctions.GetUnacceptabilityReasonFromTSN(itisTSN);
            }

            return null;
        }

        async Task<string> GetHierararchyFunctionsContent(string itisTSN)
        {
            var hierararchyFunctions = new HierararchyFunctions();

            switch (apiItem.apiName)
            {
                case "Get Full Hierarchy From TSN":
                    return await hierararchyFunctions.GetFullHierarchyFromTSN(itisTSN);
                case "Get Hierarchy Down From TSN":
                    return await hierararchyFunctions.GetHierarchyDownFromTSN(itisTSN);
                case "Get Hierarchy Up From TSN":
                    return await hierararchyFunctions.GetHierarchyUpFromTSN(itisTSN);
            }
            return null;
        }

        async Task<string> GetLSIDFunctionsContent(string lsid)
        {
            var lsidFunctions = new LSIDFunctions();

            switch (apiItem.apiName)
            {
                case "Get LSID from TSN":
                    return await lsidFunctions.GetLSIDFromTSN(lsid);
                case "Get TSN from LSID":
                    return await lsidFunctions.GetTSNFromLSID(lsid);
                case "Get Full Record From LSID":
                    return await lsidFunctions.GetFullRecordFromLSID(lsid);
                case "Get Record From LSID":
                    return await lsidFunctions.GetRecordFromLSID(lsid);
            }
            return null;
        }

        async Task<string> GetMetaInformationFunctionsContent()
        {
            var metaInformationFunctions = new MetaInformationFunctions();

            switch (apiItem.apiName)
            {
                case "Get Credibility Ratings":
                    return await metaInformationFunctions.GetCredibilityRatings();
                case "Get Description":
                    return await metaInformationFunctions.GetDescription();
                case "Get Geographic Values":
                    return await metaInformationFunctions.GetGeographicValues();
                case "Get Jurisdiction Values":
                    return await metaInformationFunctions.GetJurisdictionValues();
                case "Get Jurisdictional Origin Values":
                    return await metaInformationFunctions.GetJurisdictionalOriginValues();
                case "Get Kingdom Names":
                    return await metaInformationFunctions.GetKingdomNames();
                case "Get Last Change Date":
                    return await metaInformationFunctions.GetLastChangeDate();
                case "Get Rank Names":
                    return await metaInformationFunctions.GetRankNames();
                case "Get Vernacular Languages":
                    return await metaInformationFunctions.GetVernacularLanguages();
            }
            return null;
        }
    }
}
