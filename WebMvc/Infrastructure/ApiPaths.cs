namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }
            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }
            public static string GetAllDates(string baseUri)
            {
                return $"{baseUri}eventdatess";
            }
            public static string GetAllCatalogItems(string baseUri, int page,
                int take, int? type, int? location, int? date)
            {
                var filterQs = string.Empty;

                if (location.HasValue || type.HasValue || date.HasValue)
                {
                    var locationQs = (location.HasValue) ? location.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    var dateQs = (date.HasValue) ? date.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/location/{locationQs}/date/{dateQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize{take}";
            }
        }
    }
}
