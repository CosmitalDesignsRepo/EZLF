﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTION> ACTIONS { get; set; }
        public virtual DbSet<AFFILIATECOMMISSION> AFFILIATECOMMISSIONS { get; set; }
        public virtual DbSet<AFFILIATEPAYMENT> AFFILIATEPAYMENTS { get; set; }
        public virtual DbSet<AFFILIATEPROGRAM> AFFILIATEPROGRAMS { get; set; }
        public virtual DbSet<AFFILIATEPROGRAMS2USERS> AFFILIATEPROGRAMS2USERS { get; set; }
        public virtual DbSet<AFFILIATE> AFFILIATES { get; set; }
        public virtual DbSet<APPLIANCE> APPLIANCES { get; set; }
        public virtual DbSet<ARTICLECOMMENT> ARTICLECOMMENTS { get; set; }
        public virtual DbSet<ARTICLERATING> ARTICLERATINGs { get; set; }
        public virtual DbSet<ARTICLE> ARTICLES { get; set; }
        public virtual DbSet<ARTICLES2RELATEDDOCS> ARTICLES2RELATEDDOCS { get; set; }
        public virtual DbSet<ASSOCIATION> ASSOCIATIONS { get; set; }
        public virtual DbSet<AUTOFILLPROFILE> AUTOFILLPROFILEs { get; set; }
        public virtual DbSet<BUILTDOCUMENT> BUILTDOCUMENTS { get; set; }
        public virtual DbSet<CAMPAIGN> CAMPAIGNs { get; set; }
        public virtual DbSet<CATEGORy> CATEGORIES { get; set; }
        public virtual DbSet<COSIGNER> COSIGNERS { get; set; }
        public virtual DbSet<CUSTOMDOCUMENT> CUSTOMDOCUMENTS { get; set; }
        public virtual DbSet<DOCBUILDERCHECKIN> DOCBUILDERCHECKINs { get; set; }
        public virtual DbSet<DOCS2RELATEDARTICLES> DOCS2RELATEDARTICLES { get; set; }
        public virtual DbSet<DOCS2RELATEDDOCS> DOCS2RELATEDDOCS { get; set; }
        public virtual DbSet<DOCUMENT_PROMPTS> DOCUMENT_PROMPTS { get; set; }
        public virtual DbSet<DOCUMENTEMAIL> DOCUMENTEMAILS { get; set; }
        public virtual DbSet<DOCUMENTEMAILSREAD> DOCUMENTEMAILSREADs { get; set; }
        public virtual DbSet<DOCUMENTFEATURE> DOCUMENTFEATURES { get; set; }
        public virtual DbSet<DOCUMENTRATING> DOCUMENTRATINGs { get; set; }
        public virtual DbSet<DOCUMENT> DOCUMENTS { get; set; }
        public virtual DbSet<DOCUMENTSTOBUILD> DOCUMENTSTOBUILDs { get; set; }
        public virtual DbSet<DOCUMENTSTOBUILD_BATCHES> DOCUMENTSTOBUILD_BATCHES { get; set; }
        public virtual DbSet<ESIGN_ACTIVITYLOG> ESIGN_ACTIVITYLOG { get; set; }
        public virtual DbSet<ESIGN_ACTIVITYTYPE> ESIGN_ACTIVITYTYPE { get; set; }
        public virtual DbSet<ESIGN_REQUEST> ESIGN_REQUEST { get; set; }
        public virtual DbSet<ESIGN_STATUS> ESIGN_STATUS { get; set; }
        public virtual DbSet<ESIGN_WORKFLOW> ESIGN_WORKFLOW { get; set; }
        public virtual DbSet<EXPIREDUSERLEASEPROMOEMAIL> EXPIREDUSERLEASEPROMOEMAILs { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<FAQCATEGORy> FAQCATEGORIES { get; set; }
        public virtual DbSet<FREEUSERSALESEMAIL> FREEUSERSALESEMAILs { get; set; }
        public virtual DbSet<GLOSSARY> GLOSSARies { get; set; }
        public virtual DbSet<GLOSSARY2DOCUMENTS> GLOSSARY2DOCUMENTS { get; set; }
        public virtual DbSet<GUARANTOR> GUARANTORS { get; set; }
        public virtual DbSet<INVESTMENTPERFORMANCE> INVESTMENTPERFORMANCEs { get; set; }
        public virtual DbSet<ISOCOUNTRYCODE> ISOCOUNTRYCODES { get; set; }
        public virtual DbSet<LANDLORD> LANDLORDS { get; set; }
        public virtual DbSet<LATEFEE> LATEFEES { get; set; }
        public virtual DbSet<LEASEOPTIONSBYSTATE> LEASEOPTIONSBYSTATEs { get; set; }
        public virtual DbSet<LEAS> LEASES { get; set; }
        public virtual DbSet<LEASESTOBUILD> LEASESTOBUILDs { get; set; }
        public virtual DbSet<LENDER_STATES> LENDER_STATES { get; set; }
        public virtual DbSet<LINKCATEGORy> LINKCATEGORIES { get; set; }
        public virtual DbSet<LINK> LINKS { get; set; }
        public virtual DbSet<MAILINGLIST> MAILINGLISTs { get; set; }
        public virtual DbSet<MESSAGE> MESSAGES { get; set; }
        public virtual DbSet<MESSAGESUBSCRIPTION> MESSAGESUBSCRIPTIONS { get; set; }
        public virtual DbSet<NEWSLETTERPROGRESS> NEWSLETTERPROGRESSes { get; set; }
        public virtual DbSet<OCCUPANT> OCCUPANTS { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PACKAGE> PACKAGES { get; set; }
        public virtual DbSet<POLLANSWER> POLLANSWERS { get; set; }
        public virtual DbSet<POLLQUESTION> POLLQUESTIONS { get; set; }
        public virtual DbSet<POLL> POLLS { get; set; }
        public virtual DbSet<PROMO> PROMOS { get; set; }
        public virtual DbSet<PROMOUS> PROMOUSES { get; set; }
        public virtual DbSet<PROPERTy> PROPERTIES { get; set; }
        public virtual DbSet<PURCHASEOPTIONAGREEMENT> PURCHASEOPTIONAGREEMENTs { get; set; }
        public virtual DbSet<RA_CONTACT> RA_CONTACT { get; set; }
        public virtual DbSet<RA_EMPLOYER> RA_EMPLOYER { get; set; }
        public virtual DbSet<RA_FINANCIALINFO> RA_FINANCIALINFO { get; set; }
        public virtual DbSet<RA_OCCUPANT> RA_OCCUPANT { get; set; }
        public virtual DbSet<RA_PET> RA_PET { get; set; }
        public virtual DbSet<RA_VEHICLE> RA_VEHICLE { get; set; }
        public virtual DbSet<RESOURCE> RESOURCES { get; set; }
        public virtual DbSet<RETURNEDPAYMENTFEE> RETURNEDPAYMENTFEES { get; set; }
        public virtual DbSet<ROICALCULATOR> ROICALCULATORs { get; set; }
        public virtual DbSet<RULESREG> RULESREGS { get; set; }
        public virtual DbSet<SENDGRIDBLOCKEDDOMAIN> SENDGRIDBLOCKEDDOMAINS { get; set; }
        public virtual DbSet<STATELANDINGPAGE> STATELANDINGPAGEs { get; set; }
        public virtual DbSet<STATELAW> STATELAWS { get; set; }
        public virtual DbSet<SURVEY> SURVEYs { get; set; }
        public virtual DbSet<TA_APPLICANT> TA_APPLICANT { get; set; }
        public virtual DbSet<TA_APPLICATION> TA_APPLICATION { get; set; }
        public virtual DbSet<TA_HOME> TA_HOME { get; set; }
        public virtual DbSet<TA_INCOME> TA_INCOME { get; set; }
        public virtual DbSet<TA_PROPERTY> TA_PROPERTY { get; set; }
        public virtual DbSet<TA_TRANSACTIONS> TA_TRANSACTIONS { get; set; }
        public virtual DbSet<TA_USER> TA_USER { get; set; }
        public virtual DbSet<TEMP_MAILINGLIST> TEMP_MAILINGLIST { get; set; }
        public virtual DbSet<TEMP_MAILINGLIST_EZEP> TEMP_MAILINGLIST_EZEP { get; set; }
        public virtual DbSet<TEMP_MAILINGLIST_EZLF_U> TEMP_MAILINGLIST_EZLF_U { get; set; }
        public virtual DbSet<TENANT> TENANTS { get; set; }
        public virtual DbSet<TENANTS2LEASES> TENANTS2LEASES { get; set; }
        public virtual DbSet<THIRDPARTYMEMBERSREPORT> THIRDPARTYMEMBERSREPORTS { get; set; }
        public virtual DbSet<THREADRATING> THREADRATINGs { get; set; }
        public virtual DbSet<TRANSACTION> TRANSACTIONS { get; set; }
        public virtual DbSet<TRANSUNIONAPPLICANT> TRANSUNIONAPPLICANTs { get; set; }
        public virtual DbSet<TRANSUNIONAPPLICATION> TRANSUNIONAPPLICATIONs { get; set; }
        public virtual DbSet<TRANSUNIONPROPERTy> TRANSUNIONPROPERTIES { get; set; }
        public virtual DbSet<TRUSTPILOTREVIEW> TRUSTPILOTREVIEWS { get; set; }
        public virtual DbSet<TUAPPLICATIONSAVE> TUAPPLICATIONSAVES { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<USERS2EMAILS> USERS2EMAILS { get; set; }
        public virtual DbSet<USERTYPE> USERTYPEs { get; set; }
        public virtual DbSet<UTILITy> UTILITIES { get; set; }
        public virtual DbSet<UTILITYCONTACT2LEASES> UTILITYCONTACT2LEASES { get; set; }
        public virtual DbSet<UTILITYCONTACTINFO> UTILITYCONTACTINFOes { get; set; }
        public virtual DbSet<ZIPCODE> ZIPCODES { get; set; }
    }
}
