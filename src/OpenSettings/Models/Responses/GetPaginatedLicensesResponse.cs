using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedLicensesResponse
    {
        public GetPaginatedLicensesResponse(GetPaginatedInput input, int itemCount, GetPaginatedLicensesResponseLicense[] licenses)
        {
            Licenses = licenses ?? Array.Empty<GetPaginatedLicensesResponseLicense>();
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
        }

        public PagingInfo PagingInfo { get; }

        public GetPaginatedLicensesResponseLicense[] Licenses { get; }
    }
}