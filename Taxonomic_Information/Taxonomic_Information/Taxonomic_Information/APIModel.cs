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

        public APIItem(string apiGroup, string apiName)
        {
            this.apiGroup = apiGroup;
            this.apiName = apiName;
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
                new APIItem("Search Functions","Search by Common Name"),
                new APIItem("Search Functions","Search by Common Name Begins With"),
                new APIItem("Search Functions","Search by Common Name Ends With"),
                new APIItem("Search Functions","Search by Scientific Name"),
                new APIItem("Search Functions","Search for Any Match"),
                new APIItem("Search Functions","Search for Any Match Paged"),
                new APIItem("Search Functions","Get Any Match Count"),
                new APIItem("Search Functions","Get ITIS Terms"),
                new APIItem("Search Functions","Get ITIS Terms from Common Name"),
                new APIItem("Search Functions","Get ITIS Terms from Scientific Name"),
                new APIItem("Search Functions","Get TSNs By Vernacular Language"),

                new APIItem("Retrieve Information By TSN Functions", "Get Accepted Names from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Comment Detail from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Common Names from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Core Metadata from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Coverage from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Credibility Rating from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Currency from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Date Data from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Experts from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Full Record From TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Geographic Divisions from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Global Species Completeness from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Jurisdictional Origin from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Kingdom Name from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Other Sources from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Parent TSN from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Publications from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Review Year from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Scientific Name from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Synonym Name from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Taxon Authorship from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Taxonomic Rank Name from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Taxonomic Usage from TSN"),
                new APIItem("Retrieve Information By TSN Functions", "Get Unacceptability Reason from TSN"),

                new APIItem("Hierararchy Functions", "Get Full Hierarchy From TSN"),
                new APIItem("Hierararchy Functions", "Get Hierarchy Down From TSN"),
                new APIItem("Hierararchy Functions", "Get Hierarchy Up From TSN"),

                new APIItem("LSID Functions", "Get LSID from TSN"),
                new APIItem("LSID Functions", "Get TSN from LSID"),
                new APIItem("LSID Functions", "Get Full Record From LSID"),
                new APIItem("LSID Functions", "Get Record From LSID"),

                new APIItem("Meta-Information Functions", "Get Credibility Ratings"),
                new APIItem("Meta-Information Functions", "Get Description"),
                new APIItem("Meta-Information Functions", "Get Geographic Values"),
                new APIItem("Meta-Information Functions", "Get Jurisdiction Values"),
                new APIItem("Meta-Information Functions", "Get Jurisdictional Origin Values"),
                new APIItem("Meta-Information Functions", "Get Kingdom Names"),
                new APIItem("Meta-Information Functions", "Get Last Change Date"),
                new APIItem("Meta-Information Functions", "Get Rank Names"),
                new APIItem("Meta-Information Functions", "Get Vernacular Languages"),
            };
        }
    }
}
