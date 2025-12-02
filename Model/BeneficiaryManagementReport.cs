namespace ReportingService.Model
{
    public class BeneficiaryManagementReportFilter
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public string? O3ProviderId { get; set; }
        public string? AccountId { get; set; }
        public string? BeneficiaryId { get; set; }
        public string? BeneficiaryType { get; set; }
        public string? AccountHolderName { get; set; }
        public string? Status { get; set; }
    }

    public class BeneficiaryManagementReport
    {

        public int? RequestId { get; set; }
        public Guid? RequestCorrelationId { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? O3ProviderId { get; set; }
        public string? O3AspspId { get; set; }
        public string? O3CallerOrgId { get; set; }
        public string? O3CallerClientId { get; set; }
        public string? O3CallerSoftwareStatementId { get; set; }
        public string? O3ApiUri { get; set; }
        public string? O3ApiOperation { get; set; }
        public string? O3ConsentId { get; set; }
        public string? O3CallerInteractionId { get; set; }
        public string? O3OzoneInteractionId { get; set; }
        public string? O3PsuIdentifier { get; set; }

        public string? RequestAccountId { get; set; }
        public string? RequestStatus { get; set; }
        public string? RequestCreatedBy { get; set; }
        public DateTime? RequestCreatedOn { get; set; }
        public string? RequestModifiedBy { get; set; }
        public DateTime? RequestModifiedOn { get; set; }

        public int? ResponseId { get; set; }
        public Guid? ResponseCorrelationId { get; set; }
        public string? ResponseAccountId { get; set; }

        public string? BeneficiaryId { get; set; }
        public string? BeneficiaryType { get; set; }
        public bool? AddedViaOF { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? Reference { get; set; }

        public string? ServicerSchemeName { get; set; }
        public string? ServicerIdentification { get; set; }
        public string? ServicerName { get; set; }

        public string? AddressType { get; set; }
        public string? AddressLine { get; set; }
        public string? BuildingNumber { get; set; }
        public string? BuildingName { get; set; }
        public string? Floor { get; set; }
        public string? StreetName { get; set; }
        public string? DistrictName { get; set; }
        public string? PostBox { get; set; }
        public string? TownName { get; set; }
        public string? CountrySubDivision { get; set; }
        public string? Country { get; set; }

        public string? CreditorSchemeName { get; set; }
        public string? CreditorIdentification { get; set; }

        public decimal? TotalPages { get; set; }
        public decimal? TotalRecords { get; set; }

        public string? ResponseStatus { get; set; }
        public string? ResponseCreatedBy { get; set; }
        public DateTime? ResponseCreatedOn { get; set; }
        public string? ResponseModifiedBy { get; set; }
        public DateTime? ResponseModifiedOn { get; set; }
    }



}
