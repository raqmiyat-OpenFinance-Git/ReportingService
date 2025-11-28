namespace ReportingService.Model
{
    public class CustomerProfileReportFilter
    {
        public string? O3ProviderId { get; set; }
        public string? CustomerNumber { get; set; }
        public string? AccountId { get; set; }
        public string? CustomerCategory { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
    }
    public class CustomerProfileReportModel
    {
        // Request Fields
        public int? RequestId { get; set; }
        public Guid? CorrelationId { get; set; }

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
        public string? RequestType { get; set; }
        public string? RequestStatus { get; set; }
        public string? RequestCreatedBy { get; set; }
        public DateTime? RequestCreatedOn { get; set; }
        public string? RequestModifiedBy { get; set; }
        public DateTime? RequestModifiedOn { get; set; }

        // Response Fields
        public int? ResponseId { get; set; }
        public string? ResponseAccountId { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerCategory { get; set; }
        public string? VerifiedClaimTrustFramework { get; set; }
        public string? VerifiedClaimAssuranceLevel { get; set; }
        public string? VerifiedClaimVerificationProcess { get; set; }
        public DateTime? VerifiedClaimVerificationTime { get; set; }
        public string? AssuranceProcessPolicy { get; set; }
        public string? AssuranceProcessProcedure { get; set; }
        public string? AssuranceType { get; set; }
        public string? AssuranceClassification { get; set; }
        public string? EvidenceRefTxn { get; set; }
        public string? EvidenceClassification { get; set; }
        public string? EvidenceType { get; set; }
        public DateTime? EvidenceTime { get; set; }
        public string? CheckDetailCheckMethod { get; set; }
        public string? CheckDetailOrganization { get; set; }
        public string? CheckDetailTxn { get; set; }
        public DateTime? CheckDetailTime { get; set; }
        public string? VerifierOrganization { get; set; }
        public string? VerifierTxn { get; set; }
        public string? DocumentDetailType { get; set; }
        public string? DocumentDetailDocumentNumber { get; set; }
        public string? DocumentDetailPersonalNumber { get; set; }
        public string? DocumentDetailSerialNumber { get; set; }
        public string? DocumentDetailCalendarType { get; set; }
        public DateTime? DocumentDetailDateOfIssuance { get; set; }
        public DateTime? DocumentDetailDateOfExpiry { get; set; }
        public string? IssuerName { get; set; }
        public string? IssuerAddressType { get; set; }
        public string? IssuerAddressLine { get; set; }
        public string? IssuerBuildingNumber { get; set; }
        public string? IssuerBuildingName { get; set; }
        public string? IssuerFloor { get; set; }
        public string? IssuerStreetName { get; set; }
        public string? IssuerDistrictName { get; set; }
        public string? IssuerPostBox { get; set; }
        public string? IssuerTownName { get; set; }
        public string? IssuerCountrySubDivision { get; set; }
        public string? IssuerCountry { get; set; }
        public string? IssuerJurisdiction { get; set; }
        public string? IssuerCountryCode { get; set; }
        public string? AttachmentDescription { get; set; }
        public string? AttachmentContentType { get; set; }
        public string? AttachmentContent { get; set; }
        public string? AttachmentTxn { get; set; }
        public string? ClaimIdentityType { get; set; }
        public string? ClaimFullName { get; set; }
        public string? ClaimGivenName { get; set; }
        public string? ClaimFamilyName { get; set; }
        public string? ClaimMiddleName { get; set; }
        public string? ClaimNickname { get; set; }
        public string? ClaimEmiratesId { get; set; }
        public DateTime? ClaimEmiratesIdExpiryDate { get; set; }
        public DateTime? ClaimBirthDate { get; set; }
        public string? ClaimSourceOfIncome { get; set; }
        public string? ClaimSalary { get; set; }
        public string? ClaimNationality { get; set; }
        public string? ClaimMobileNumber { get; set; }
        public string? ClaimEmail { get; set; }
        public string? ClaimMaritalStatus { get; set; }
        public string? ClaimSalutation { get; set; }
        public string? ClaimLanguage { get; set; }
        public string? ClaimEmployerName { get; set; }
        public DateTime? ClaimEmploymentSinceDate { get; set; }
        public string? ClaimPowerOfAttorney { get; set; }
        public string? ClaimSalaryTransfer { get; set; }
        public string? ClaimProfession { get; set; }
        public DateTime? ClaimUpdatedAt { get; set; }
        public string? ResidentialAddressType { get; set; }
        public string? ResidentialAddressLine { get; set; }
        public string? ResidentialBuildingNumber { get; set; }
        public string? ResidentialBuildingName { get; set; }
        public string? ResidentialFloor { get; set; }
        public string? ResidentialStreetName { get; set; }
        public string? ResidentialDistrictName { get; set; }
        public string? ResidentialPostBox { get; set; }
        public string? ResidentialTownName { get; set; }
        public string? ResidentialCountrySubDivision { get; set; }
        public string? ResidentialCountry { get; set; }
        public string? ClaimOrgName { get; set; }
        public string? CustomerType { get; set; }
        public string? AccountRole { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
        public string? ResponseType { get; set; }
        public string? ResponseStatus { get; set; }
        public string? ResponseCreatedBy { get; set; }
        public DateTime? ResponseCreatedOn { get; set; }
        public string? ResponseModifiedBy { get; set; }
        public DateTime? ResponseModifiedOn { get; set; }

    }
}
