//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EZLF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LEAS
    {
        public decimal ID { get; set; }
        public Nullable<decimal> USERID { get; set; }
        public Nullable<byte> TYPE { get; set; }
        public string STATE { get; set; }
        public string CONTACT_ADDRESS1 { get; set; }
        public string CONTACT_ADDRESS2 { get; set; }
        public string CONTACT_CITY { get; set; }
        public string CONTACT_STATE { get; set; }
        public string CONTACT_ZIP { get; set; }
        public string CONTACT_PHONE { get; set; }
        public string CONTACT_FAX { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public string CONTACT_NOTICEMETHODS { get; set; }
        public Nullable<decimal> PROPERTY { get; set; }
        public Nullable<byte> PROPERTY_CANSUBLEASE { get; set; }
        public Nullable<byte> PROPERTY_HOMEBUSINESS { get; set; }
        public Nullable<byte> TERM { get; set; }
        public Nullable<System.DateTime> STARTDATE { get; set; }
        public Nullable<System.DateTime> ENDDATE { get; set; }
        public Nullable<byte> TERM_AUTORENEW { get; set; }
        public Nullable<decimal> RENT_AMOUNT { get; set; }
        public Nullable<decimal> RENT_TOTAL { get; set; }
        public Nullable<byte> RENT_PERIOD { get; set; }
        public Nullable<byte> RENT_DUEDAY { get; set; }
        public string RENT_PAYABLETO { get; set; }
        public string RENT_NAME { get; set; }
        public string RENT_ADDRESS1 { get; set; }
        public string RENT_ADDRESS2 { get; set; }
        public string RENT_CITY { get; set; }
        public string RENT_STATE { get; set; }
        public string RENT_ZIP { get; set; }
        public Nullable<decimal> SECURITYDEPOSIT_AMOUNT { get; set; }
        public Nullable<byte> SECURITYDEPOSIT_HELDIN { get; set; }
        public string SECURITYDEPOSIT_HELDBY { get; set; }
        public string SECURITYDEPOSIT_ACCOUNTNUM { get; set; }
        public Nullable<byte> SECURITYDEPOSIT_REFUNDDAYS { get; set; }
        public Nullable<byte> LATEFEE_DAYS { get; set; }
        public Nullable<decimal> LATEFEE_AMOUNTSCALAR { get; set; }
        public Nullable<byte> LATEFEE_AMOUNTTYPE { get; set; }
        public Nullable<byte> LATEFEE_MAXTIMESLATE { get; set; }
        public Nullable<decimal> RETURNEDPAYMENTFEE_AMOUNT { get; set; }
        public Nullable<byte> RETURNEDPAYMENTFEE_MAXTIMES { get; set; }
        public string RETURNEDPAYMENTFEE_PAYBY { get; set; }
        public Nullable<decimal> HOLDOVERFEE_AMOUNT { get; set; }
        public Nullable<byte> HOLDOVERFEE_SEEKDAMAGES { get; set; }
        public Nullable<byte> REMEDIES_ATTORNEYFEES { get; set; }
        public Nullable<byte> REMEDIES_BALANCEDUE { get; set; }
        public Nullable<byte> REPAIRS_RESPONSIBLE { get; set; }
        public Nullable<decimal> REPAIRS_TENANTPAYSOVERAMOUNT { get; set; }
        public string REPAIRS_SPECIALARRANGEMENT { get; set; }
        public string PROPERTY_HOMEBUSINESSDETAILS { get; set; }
        public Nullable<byte> REPAIRS_SNOWICE { get; set; }
        public Nullable<byte> REPAIRS_LAWN { get; set; }
        public Nullable<byte> UTILITIES_DAYSTOPAYBILL { get; set; }
        public Nullable<byte> UTILITIES_HEATINGOILCONTRACT { get; set; }
        public Nullable<byte> INSURANCE_MUSTHAVE { get; set; }
        public Nullable<byte> INSURANCE_BREACHESLEASE { get; set; }
        public Nullable<byte> RIGHTOFENTRY_NOTICEDAYS { get; set; }
        public Nullable<byte> TERMS_NOTICEDAYSTOCHANGE { get; set; }
        public string ADDITIONALDOCS { get; set; }
        public Nullable<decimal> UTILITIES_LATEFEE { get; set; }
        public Nullable<byte> PARKING_PROVIDED { get; set; }
        public string PARKING_DESCRIPTION { get; set; }
        public Nullable<byte> PETS_ALLOWED { get; set; }
        public string RULESREGS { get; set; }
        public Nullable<byte> HASCOVERPAGE { get; set; }
        public Nullable<byte> HASTABLEOFCONTENTS { get; set; }
        public Nullable<System.DateTime> SAVEDATE { get; set; }
        public Nullable<bool> ARCHIVED { get; set; }
        public Nullable<bool> ISBASIC { get; set; }
        public Nullable<bool> HAVECOSIGNER { get; set; }
        public Nullable<byte> TERM_NOTICETORENEW { get; set; }
        public Nullable<bool> SHOWREMINDERS { get; set; }
        public Nullable<bool> RENT_DUEDAYPERIOD { get; set; }
        public Nullable<bool> REMEDIES_COURTCOSTS { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<byte> LEASELENGTH_DDL { get; set; }
        public Nullable<byte> REPAIRS_TENANTPAYSPESTCONTROL { get; set; }
        public Nullable<System.DateTime> DOCDATE { get; set; }
        public Nullable<bool> RENT_OCCUPANCYCHANGES { get; set; }
        public string HOLDOVERFEE_PERIOD { get; set; }
        public Nullable<bool> REPAIRS_TENANTSHALLCONTACT { get; set; }
        public Nullable<bool> REPAIRS_MUSTCHANGEFILTERS { get; set; }
        public Nullable<bool> REPAIRS_MAYDEDUCTREPAIRS { get; set; }
        public string REPAIRS_TENANTSHALLCONTACTNAME { get; set; }
        public string UTILITIES_REFILLHEATINGOILAMT { get; set; }
        public Nullable<bool> UTILITIES_REFILLHEATINGOIL { get; set; }
        public string PETS_DESCRIPTION { get; set; }
        public Nullable<decimal> PETS_DEPOSIT { get; set; }
        public string SPECIALTERMS { get; set; }
        public Nullable<bool> USELOGO { get; set; }
        public string CONTACT_COUNTRY { get; set; }
        public string RENT_COUNTRY { get; set; }
        public string COUNTRY { get; set; }
        public Nullable<bool> RENT_PREPAID { get; set; }
        public Nullable<bool> RENT_INCREASE { get; set; }
        public Nullable<decimal> RENT_INCREASEAMOUNT { get; set; }
        public Nullable<System.DateTime> RENT_INCREASEDATE { get; set; }
        public Nullable<bool> PETS_DEPOSITREFUNDABLE { get; set; }
        public Nullable<bool> FUNDS_FIRSTRENT { get; set; }
        public Nullable<byte> FUNDS_FIRSTRENTPERIOD { get; set; }
        public Nullable<byte> FUNDS_FIRSTRENTNUMBER { get; set; }
        public Nullable<bool> FUNDS_LASTRENT { get; set; }
        public Nullable<byte> FUNDS_LASTRENTPERIOD { get; set; }
        public Nullable<byte> FUNDS_LASTRENTNUMBER { get; set; }
        public Nullable<bool> FUNDS_SECURITYDEPOSIT { get; set; }
        public Nullable<bool> FUNDS_PRORATED { get; set; }
        public Nullable<decimal> FUNDS_PRORATEDAMOUNT { get; set; }
        public Nullable<bool> RENT_PAYBY_CERTIFIEDCHECK { get; set; }
        public Nullable<bool> RENT_PAYBY_MONEYORDER { get; set; }
        public Nullable<bool> RENT_PAYBY_CASH { get; set; }
        public Nullable<bool> RENT_PAYBY_CREDITCARD { get; set; }
        public Nullable<bool> RENT_PAYBY_DIRECTDEPOSIT { get; set; }
        public Nullable<bool> RENT_PAYBY_ACH { get; set; }
        public Nullable<bool> RENT_PAYBY_PAYPALONLINE { get; set; }
        public string FUNDS_OTHERDESC { get; set; }
        public Nullable<decimal> FUNDS_OTHERAMOUNT { get; set; }
        public Nullable<bool> RENT_PAYBY_PERSONALCHECK { get; set; }
        public Nullable<bool> TERM_CUSTOM { get; set; }
        public string TERM_CUSTOMTEXT { get; set; }
        public Nullable<bool> SECURITYDEPOSIT_CUSTOM { get; set; }
        public string SECURITYDEPOSIT_CUSTOMTEXT { get; set; }
        public Nullable<bool> REPAIRS_CUSTOM { get; set; }
        public string REPAIRS_CUSTOMTEXT { get; set; }
        public Nullable<System.DateTime> RENT_DUEDATE { get; set; }
        public Nullable<bool> RENT_CUSTOM { get; set; }
        public string RENT_CUSTOMTEXT { get; set; }
        public Nullable<bool> RENT_INCREASE_RECURRING { get; set; }
        public string FUNDS_OTHER2DESC { get; set; }
        public Nullable<decimal> FUNDS_OTHER2AMOUNT { get; set; }
        public Nullable<bool> FUNDS_KEYDEPOSIT { get; set; }
        public Nullable<decimal> FUNDS_KEYDEPOSITAMOUNT { get; set; }
        public Nullable<bool> FUNDS_OTHERREFUNDABLE { get; set; }
        public Nullable<bool> FUNDS_OTHER2REFUNDABLE { get; set; }
        public bool RENT_INCREASETYPE { get; set; }
        public Nullable<decimal> TERM_AUTORENEWMONTHS { get; set; }
        public Nullable<bool> PROPERTY_SPECIFYMEASUREMENTS { get; set; }
        public Nullable<bool> PROPERTY_INCLUDELEGALDESC { get; set; }
        public Nullable<bool> PROPERTY_INCLUDEDIAGRAM { get; set; }
        public Nullable<bool> PROPERTY_INCLUDEFURTHERDESC { get; set; }
        public Nullable<bool> RENT_CUSTOMREPLACECONTENT { get; set; }
        public Nullable<byte> SECURITYDEPOSIT_COLLECTEDBY { get; set; }
        public Nullable<bool> TAXES_INCLUDEINRENT { get; set; }
        public Nullable<decimal> TAXES_AMOUNT { get; set; }
        public Nullable<bool> REPAIRS_LANDLORDUPGRADES { get; set; }
        public string REPAIRS_LANDLORDUPGRADESTEXT { get; set; }
        public Nullable<byte> SERVICES_RESTROOM { get; set; }
        public Nullable<byte> SERVICES_JANITORIAL { get; set; }
        public Nullable<byte> SERVICES_TRASH { get; set; }
        public Nullable<byte> SERVICES_WINDOWWASHING { get; set; }
        public Nullable<byte> SERVICES_PESTCONTROL { get; set; }
        public Nullable<byte> SERVICES_GENERALCLEANING { get; set; }
        public Nullable<bool> SERVICES_TENANTINDOOR { get; set; }
        public Nullable<bool> SERVICES_TENANTOUTDOOR { get; set; }
        public Nullable<bool> SERVICES_CUSTOM { get; set; }
        public string SERVICES_CUSTOMTEXT { get; set; }
        public Nullable<decimal> INSURANCE_AMOUNT { get; set; }
        public Nullable<bool> PROPERTY_PERMITTEDUSE { get; set; }
        public string PROPERTY_PERMITTEDUSETEXT { get; set; }
        public Nullable<bool> PROPERTY_COMMONUSE { get; set; }
        public string PROPERTY_COMMONUSETEXT { get; set; }
        public Nullable<bool> INSURANCE_HAZARD { get; set; }
        public Nullable<decimal> INSURANCE_HAZARDAMOUNT { get; set; }
        public Nullable<bool> INSURANCE_CUSTOM { get; set; }
        public string INSURANCE_CUSTOMTEXT { get; set; }
        public Nullable<bool> PROPERTY_COMMUNITY { get; set; }
        public string PROPERTY_COMMUNITYNAME { get; set; }
        public Nullable<bool> PROPERTY_HASOCCUPANCY { get; set; }
        public Nullable<decimal> PROPERTY_OCCUPANCY { get; set; }
        public Nullable<bool> PROPERTY_CANCELLATION { get; set; }
        public Nullable<decimal> PROPERTY_CANCELLATIONDAYS { get; set; }
        public Nullable<bool> FUNDS_RESERVATION { get; set; }
        public Nullable<decimal> FUNDS_RESERVATIONAMOUNT { get; set; }
        public Nullable<bool> FUNDS_RENTDUE { get; set; }
        public Nullable<decimal> FUNDS_RENTDUEAMOUNT { get; set; }
        public Nullable<bool> FUNDS_DAMAGEDEPOSIT { get; set; }
        public Nullable<decimal> FUNDS_DAMAGEDEPOSITAMOUNT { get; set; }
        public Nullable<bool> FUNDS_CUSTOM { get; set; }
        public string FUNDS_CUSTOMTEXT { get; set; }
        public Nullable<bool> PARKING_VEHICLES { get; set; }
        public string PARKING_VEHICLESDESC { get; set; }
        public Nullable<decimal> LATEFEES_CUSTOM { get; set; }
        public string LATEFEES_CUSTOMTEXT { get; set; }
    }
}
