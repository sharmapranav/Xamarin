using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxonomic_Information
{
    public class APIItem
    {
        public string apiGroup { get; set; }
        public string apiName { get; set; }

        public List<string> placeholderKeyValues;

        public APIItem(string apiGroup, string apiName, List<string> placeholderKeyValues)
        {
            this.apiGroup = apiGroup;
            this.apiName = apiName;
            this.placeholderKeyValues = placeholderKeyValues;
        }
    }

    class APICollection : ObservableCollection<APIItem>
    {
        public string apiGroup { get; private set; }
        List<APIItem> apiItems;

        public APICollection()
        {
            FillList();
        }

        public APICollection(string apiGroup)
        {
            this.apiGroup = apiGroup;
            FillList();
        }

        public List<APICollection> GetGroupedList()
        {
            var groupedList = new List<APICollection>();

            foreach (var listItem in apiItems)
            {
                var listGroup = groupedList.FirstOrDefault(x => x.apiGroup == listItem.apiGroup);

                if (listGroup == null)
                {
                    listGroup = new APICollection(listItem.apiGroup);

                    listGroup.Add(listItem);
                    groupedList.Add(listGroup);
                }
                else
                {
                    listGroup.Add(listItem);
                }
            }

            return groupedList;
        }

        public List<APICollection> GetAlphabeticalList()
        {
            var alphabeticalList = new List<APICollection>();

            apiItems.Sort((x, y) => x.apiName.CompareTo(y.apiName));

            foreach (var listItem in apiItems)
            {
                var listGroup = alphabeticalList.FirstOrDefault(x => x.apiGroup == "A-Z");

                if (listGroup == null)
                {
                    listGroup = new APICollection("A-Z");

                    listGroup.Add(listItem);
                    alphabeticalList.Add(listGroup);
                }
                else
                {
                    listGroup.Add(listItem);
                }
            }

            return alphabeticalList.OrderBy(x => x.apiGroup).ToList();
        }

        void FillList()
        {
            apiItems = new List<APIItem>
            {
                new APIItem("Search Functions","Search by Common Name", new List<string> { "Search Key", "american bullfrog" }),
                new APIItem("Search Functions","Search by Common Name Begins With", new List<string> { "Search Key", "inch" }),
                new APIItem("Search Functions","Search by Common Name Ends With", new List<string> { "Search Key", "bear" }),
                new APIItem("Search Functions","Search by Scientific Name", new List<string> { "Search Key", "Tardigrada" }),
                new APIItem("Search Functions","Search for Any Match", new List<string> { "Search Key", "dolphin" }),
                new APIItem("Search Functions","Search for Any Match Paged", new List<string> { "Search Key", "Zy", "Page Size", "100", "Page Num", "1", "Ascending", "false" }),
                new APIItem("Search Functions","Get Any Match Count", new List<string> { "Search Key", "dolphin" }),
                new APIItem("Search Functions","Get ITIS Terms", new List<string> { "Search Key", "bear" }),
                new APIItem("Search Functions","Get ITIS Terms from Common Name", new List<string> { "Search Key", "buya" }),
                new APIItem("Search Functions","Get ITIS Terms from Scientific Name", new List<string> { "Search Key", "ursidae" }),
                new APIItem("Search Functions","Get TSNs By Vernacular Language", new List<string> { "Search Key", "french" }),

                new APIItem("Retrieve Information By TSN Functions", "Get Accepted Names from TSN", new List<string> { "ITIS TSN", "183671" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Comment Detail from TSN", new List<string> { "ITIS TSN", "180543" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Common Names from TSN", new List<string> { "ITIS TSN", "531894" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Core Metadata from TSN", new List<string> { "ITIS TSN", "28727" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Coverage from TSN", new List<string> { "ITIS TSN", "28727" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Credibility Rating from TSN", new List<string> { "ITIS TSN", "526852" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Currency from TSN", new List<string> { "ITIS TSN", "28727" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Date Data from TSN", new List<string> { "ITIS TSN", "180543" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Experts from TSN", new List<string> { "ITIS TSN", "180544" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Full Record From TSN", new List<string> { "ITIS TSN", "183833" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Geographic Divisions from TSN", new List<string> { "ITIS TSN", "180543" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Global Species Completeness from TSN", new List<string> { "ITIS TSN", "180541" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Jurisdictional Origin from TSN", new List<string> { "ITIS TSN", "180543" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Kingdom Name from TSN", new List<string> { "ITIS TSN", "202385" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Other Sources from TSN", new List<string> { "ITIS TSN", "182662" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Parent TSN from TSN", new List<string> { "ITIS TSN", "202385" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Publications from TSN", new List<string> { "ITIS TSN", "70340" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Review Year from TSN", new List<string> { "ITIS TSN", "180541" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Scientific Name from TSN", new List<string> { "ITIS TSN", "531894" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Synonym Name from TSN", new List<string> { "ITIS TSN", "183671" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Taxon Authorship from TSN", new List<string> { "ITIS TSN", "183671" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Taxonomic Rank Name from TSN", new List<string> { "ITIS TSN", "202385" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Taxonomic Usage from TSN", new List<string> { "ITIS TSN", "526852" }),
                new APIItem("Retrieve Information By TSN Functions", "Get Unacceptability Reason from TSN", new List<string> { "ITIS TSN", "183671" }),

                new APIItem("Hierararchy Functions", "Get Full Hierarchy From TSN", new List<string> { "ITIS TSN", "558090" }),
                new APIItem("Hierararchy Functions", "Get Hierarchy Down From TSN", new List<string> { "ITIS TSN", "178265" }),
                new APIItem("Hierararchy Functions", "Get Hierarchy Up From TSN", new List<string> { "ITIS TSN", "1378" }),

                new APIItem("LSID Functions", "Get LSID from TSN", new List<string> { "TSN", "155166" }),
                new APIItem("LSID Functions", "Get TSN from LSID", new List<string> { "LSID", "urn:lsid:itis.gov:itis_tsn: 28726 " }),
                new APIItem("LSID Functions", "Get Full Record From LSID", new List<string> { "LSID", "urn:lsid:itis.gov: itis_tsn:180543" }),
                new APIItem("LSID Functions", "Get Record From LSID", new List<string> { "LSID", "urn:lsid:itis.gov:itis_tsn: 180543" }),

                new APIItem("Meta-Information Functions", "Get Credibility Ratings", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Description", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Geographic Values", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Jurisdiction Values", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Jurisdictional Origin Values", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Kingdom Names", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Last Change Date", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Rank Names", new List<string> { }),
                new APIItem("Meta-Information Functions", "Get Vernacular Languages", new List<string> { }),
            };
        }
    }
}
