namespace ReportingService.Model
{
    public class DataSharingReport
    {
        public List<DataSharingReportTemplate>? ModulesList { get; set; }
        public string? Module { get; set; }
        public string? ReportName { get; set; }
        public DataSharingReportFields? dataSharingReportField { get; set; }
        public CustomerDetails? dataSharingCustomerDetails { get; set; }
        public BalanceDetails? balanceDetails { get; set; }
        public BeneficiaryDetails? beneficiaryDetails { get; set; }
        public DirectDebit? directDebit { get; set; }
        public ProductDetails? productDetails { get; set; }
        public List<DataSharingTemplateList>? templateLists { get; set; }

    }
    public class DataSharingTemplateList
    {
        public int TemplateId { get; set; }
        public string? TemplateName { get; set; }
    }
    public class DataSharingReportTemplate
    {
        public string? Value { get; set; }
        public string? DisplayName { get; set; }
        public string? FieldType { get; set; }
    }
    public class DataSharingColumnInfo
    {
        public string? ColumnName { get; set; }
        public string? AliasName { get; set; }

    }
    public class DataSharingReportFields
    {
        public int Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Columndetails { get; set; }
        public string? TemplateName { get; set; }
        public string? ReportName { get; set; }
        public string? CorrelationId { get; set; }

        public string? AccountId { get; set; }
        public string? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public string? Currency { get; set; }
        public string? AccountStatus { get; set; }
        public string? AccountHolderName { get; set; }
        public string? ServicerSchemeName { get; set; }
        public string? ServicerIdentification { get; set; }
        public string? AccountNumberName { get; set; }
        public string? AccountNumberSchemeName { get; set; }
        public string? AccountNumberIdentification { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }


        public string? BusinessCustomerId { get; set; }
        public string? BusinessCustomerName { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? StatusUpdateDateTime { get; set; }
        public string? Description { get; set; }
        public string? NickName { get; set; }
        public string? OpeningDate { get; set; }
        public string? MaturityDate { get; set; }


        //Balance
        public int BalanceId { get; set; }
        public string? AccountBalanceCreditDebitIndicator { get; set; }
        public string? AccountBalanceType { get; set; }
        public string? AccountBalanceTimestamp { get; set; }
        public decimal AccountBalanceAmount { get; set; }
        public string? AccountBalanceCurrency { get; set; }
        public bool BalanceCreditLineIncluded { get; set; }
        public string? BalanceCreditLineCreditType { get; set; }
        public decimal BalanceCreditLineAmount { get; set; }
        public string? BalanceCreditLineCurrency { get; set; }
        public decimal TotalPages { get; set; }
        public decimal TotalRecords { get; set; }

        //Beneficiary

        public string? BeneficiaryId { get; set; }
        public string? BeneficiaryType { get; set; }
        public string? ServicerName { get; set; }
        public string? Reference { get; set; }
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


        //DirectDebit

        public string? DirectDebitId { get; set; }
        public string? MandateIdentification { get; set; }
        public string? DirectDebitStatusCode { get; set; }
        public string? Name { get; set; }
        public string? Frequency { get; set; }
        public string? PreviousPaymentDateTime { get; set; }
        public string? PreviousPaymentAmount { get; set; }
        public string? PreviousPaymentCurrency { get; set; }
      

        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? Jsonstring { get; set; }
    }

    public class CustomerDetails
    {
        public string? CustomerNumber { get; set; }
        public string? CustomerCategory { get; set; }
        public string? AssuranceType { get; set; }
        public string? EvidenceType { get; set; }
        public string? CheckDetailTime { get; set; }
        public string? DocumentDetailType { get; set; }
        public string? DocumentDetailDocumentNumber { get; set; }
        public string? DocumentDetailDateOfExpiry { get; set; }
        public string? IssuerName { get; set; }
        public string? IssuerDistrictName { get; set; }
        public string? ClaimEmiratesId { get; set; }
        public string? ClaimEmiratesIdExpiryDate { get; set; }
        public string? ClaimFullName { get; set; }
        public string? ClaimEmail { get; set; }
        public string? ResidentialAddressType { get; set; }
        public string? ResidentialTownName { get; set; }
        public string? ResidentialBuildingName { get; set; }
        public string? ResidentialStreetName { get; set; }
        public string? ResidentialDistrictName { get; set; }
        public string? ClaimOrgName { get; set; }
        public string? CustomerType { get; set; }
        public string? AccountRole { get; set; }
    }

    public class BalanceDetails
    {
        public int BalanceId { get; set; }
        public string? AccountBalanceCreditDebitIndicator { get; set; }
        public string? AccountBalanceType { get; set; }
        public string? AccountBalanceTimestamp { get; set; }
        public decimal AccountBalanceAmount { get; set; }
        public string? AccountBalanceCurrency { get; set; }
        public bool BalanceCreditLineIncluded { get; set; }
        public string? BalanceCreditLineCreditType { get; set; }
        public decimal BalanceCreditLineAmount { get; set; }
        public string? BalanceCreditLineCurrency { get; set; }
        public decimal TotalPages { get; set; }
        public decimal TotalRecords { get; set; }

    }

    public class BeneficiaryDetails
    {
        public string? BeneficiaryId { get; set; }
        public string? BeneficiaryType { get; set; }
        public string? AccountHolderName { get; set; }
        public string? Reference { get; set; }
        public string? AccountHolderShortName { get; set; }
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

    }
    public class DirectDebit
    {
        public string? DirectDebitId { get; set; }
        public string? MandateIdentification { get; set; }
        public string? DirectDebitStatusCode { get; set; }
        public string? Name { get; set; }
        public string? Frequency { get; set; }
        public string? PreviousPaymentDateTime { get; set; }
        public string? PreviousPaymentAmount { get; set; }
        public string? PreviousPaymentCurrency { get; set; }
    }

    public class ProductDetails
    {
        public string? ChargeName { get; set; }
        public string? ChargeDescription { get; set; }
        public string? ChargeAmount { get; set; }
        public string? ChargeCurrency { get; set; }
        public string? ChargeRate { get; set; }
        public string? ChargeApplicationFrequency { get; set; }
        public string? ChargeJustification { get; set; }
        public string? ChargeFrequency { get; set; }
        public string? ChargeNotes { get; set; }
        public string? ChargeConditions { get; set; }
        public string? LendingType { get; set; }
        public string? LendingStartDate { get; set; }
        public string? LendingEndDate { get; set; }
        public string? DepositType { get; set; }
        public string? DepositRate { get; set; }
        public string? DepositStartDate { get; set; }
        public string? DepositEndDate { get; set; }
        public string? RewardName { get; set; }
        public string? RewardDescription { get; set; }
        public string? RewardAmount { get; set; }
        public string? RewardRate { get; set; }
        public string? CollateralType { get; set; }
        public string? CollateralValuationDate { get; set; }
        public string? CollateralValuationAmount { get; set; }
    }
}
