using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EZLF.Models;
namespace EZLF.Class.Helpers
{
    public static class EntityUtil
    {
        public enum Sequence
        {
            AFFILIATECOMMISSIONS_SEQ,
            AFFILIATEPAYMENTS_SEQ,
            AFFILIATEPROGRAMS_SEQ,
            APPLIANCES_SEQ,
            ARTICLECATEGORIES_SEQ,
            ARTICLECOMMENTS_SEQ,
            ARTICLERATING_SEQ,
            ARTICLES_SEQ,
            AUTOFILLPROFILE_SEQ,
            BUILTDOCUMENTS_SEQ,
            CATEGORIES_SEQ,
            COSIGNERS_SEQ,
            DOCBUILDERCHECKIN_SEQ,
            DOCUMENTCHECKSUMS_SEQ,
            DOCUMENTEMAILSREAD_SEQ,
            DOCUMENTEMAILS_SEQ,
            DOCUMENTRATING_SEQ,
            DOCUMENTSTOBUILD_BATCHES_SEQ,
            DOCUMENTSTOBUILD_SEQ,
            DOCUMENTS_SEQ,
            ESIGN_ACTIVITYLOG_SEQ,
            ESIGN_REQUEST_SEQ,
            ESIGN_WORKFLOW_SEQ,
            FAQCATEGORIES_SEQ,
            FAQ_SEQ,
            GLOSSARY_SEQ,
            GUARANTORS_SEQ,
            INVESTMENTPERFORMANCE_SEQ,
            ISOCOUNTRYCODES_SEQ,
            LANDLORDS_SEQ,
            LATEFEES_SEQ,
            LEASESTOBUILD_SEQ,
            LEASES_SEQ,
            LENDER_STATES_SEQ,
            LINKCATEGORIES_SEQ,
            LINKS_SEQ,
            LT_COUNTRY_SEQ,
            LT_STATEPROV_SEQ,
            MAILINGLIST_SEQ,
            MESSAGES_SEQ,
            NEWSLETTERPROGRESS_SEQ,
            NEWSLETTERPROGRESS_SEQ1,
            OCCUPANTS_SEQ,
            ORDERS_SEQ,
            POLLANSWERS_SEQ,
            POLLQUESTIONS_SEQ,
            POLLS_SEQ,
            PROMO15OFFEMAILSSENT_SEQ,
            PROMOS_SEQ,
            PROMOS_SEQ1,
            PROPERTIES_SEQ,
            RA_CONTACT_SEQ,
            RA_EMPLOYER_SEQ,
            RA_FINANCIALINFO_SEQ,
            RA_OCCUPANT_SEQ,
            RA_PET_SEQ,
            RA_VEHICLE_SEQ,
            RESOURCES_SEQ,
            ROICALCULATOR_SEQ,
            RULES_SEQ,
            STATELAWS_SEQ,
            TA_APPLICANT_SEQ,
            TA_APPLICATION_SEQ,
            TA_HOMES_SEQ,
            TA_HOME_SEQ,
            TA_INCOME_SEQ,
            TA_PROPERTY_SEQ,
            TA_TRANSACTIONS_SEQ,
            TA_USER_SEQ,
            TEMPLATED_DOCUMENTS_SEQ,
            TENANTS_SEQ,
            THIRDPARTYMEMBERSREPORTS_SEQ,
            THREADRATING_SEQ,
            TRANSACTIONS_SEQ,
            TRUSTPILOTREVIEWS_SEQ,
            TUAPPLICATIONSAVES_SEQ,
            USERS_SEQ,
            UTILITIES_SEQ,
            UTILITYCONTACTINFO_SEQ
        };

        public static decimal GetNextSequence(this Entities context, Sequence sequence)
        {
            string sql = String.Format("select {0}.nextval from dual", sequence.ToString());
            var testId = context.Database.SqlQuery<decimal>(sql);

            return testId.First();
        }
    }
}