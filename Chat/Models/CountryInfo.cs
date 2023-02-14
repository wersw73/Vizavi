using System.Collections.Generic;

namespace Chat.Models {
    internal class CountryInfo: PlaceInfo {
        public IEnumerable<ProvinceInfo>? ProvincesCounts { get; set; }
    }
}
