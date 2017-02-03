using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;
using System.ComponentModel;
using Pliner.Util;

namespace EZLF.Class
{
    public class Shared
    {
        public static readonly string filesPath = ConfigurationManager.AppSettings["SiteFilesPath"] ?? "";
        public static readonly string DocFilesPath = ConfigurationManager.AppSettings["DocFilesPath"] ?? "";
        public static readonly string backupStoragePath = ConfigurationManager.AppSettings["BackupDocFilesPath"] ?? "";

        public static readonly string Ip2LocationFilePath = ConfigurationManager.AppSettings["Ip2LocationFilePath"] ?? "";
        public static readonly string Ip2LocationDatabaseFile = ConfigurationManager.AppSettings["Ip2LocationDatabaseFile"] ?? "";
        public static readonly string ErrorEmailsFrom = ConfigurationManager.AppSettings["ErrorEmailsFrom"] ?? "";
        public static readonly string ErrorEmailsTo = ConfigurationManager.AppSettings["ErrorEmailsTo"] ?? "";
        public static readonly string DebugEmailsTo = ConfigurationManager.AppSettings["defaultDebugEmailsTo"] ?? "";

        public static readonly string EvoPdfLicenseKey = ConfigurationManager.AppSettings["EvoPdfLicenseKey"] ?? "";

        public static string storagePath = DocFilesPath;
        public static string documentsDiskPath = storagePath + @"\data\documents\";
        public static string thumbnailsDiskPath = filesPath + @"\media\thumbnails\";
        public static string docLandingPageImagesDiskPath = filesPath + @"\media\docLandingPage\";
        public static string samplesDiskPath = filesPath + @"\media\doc_samples\";

        public static string attorneyPhotoDiskPath = filesPath + @"\media\attorneys\";
        public static string lenderPhotoDiskPath = filesPath + @"\media\lenders\";

        public static string articlePhotosDiskPath = filesPath + @"\media\articles\";
        public static string thumbnailsWebPath = @"/media/thumbnails/";
        public static string docLandingPageImagesWebPath = @"/media/docLandingPage/";
        public static string samplesWebPath = @"/media/doc_samples/";

        public static string attorneysWebPath = @"/media/attorneys/";
        public static string lendersWebPath = @"/media/lenders/";

        public static string articlePhotosWebPath = @"/media/articles/";
        public static string generatedDocsDiskPath = storagePath + @"\generated_docs\";
        public static string tempDocsDiskPath = storagePath + @"\generated_docs\temp\";
        public static string downloadDocsDiskPath = storagePath + @"\generated_docs\download\";

        //public static string CDNUrl = @"//ezlf-plinersolutionsi.netdna-ssl.com";
        public static string CDNUrl = @"//www.ezlandlordforms.com";

        public static string CDNUrlForEmails
        {
            get
            {
                if (IsLiveSite())
                    return "https:" + CDNUrl;
                else
                    return @"https://beta.ezlandlordforms.com";
            }
        }

        public static readonly string[] InternalIpRanges = ConfigurationManager.AppSettings["InternalIpRanges"] != null
            ? ConfigurationManager.AppSettings["InternalIpRanges"].Split(';')
            : new string[] { "127.0.0.1" };
        public static int[] plinerAdminIDs = {
                                                 1, //adam@pliner.com
												 1663250 //jon@pliner.com
											 };

        public static bool IsInternalIp(string ip)
        {
            foreach (string internalIp in InternalIpRanges)
                if (ip.StartsWith(internalIp))
                    return true;
            return false;
        }

        public enum SiteSection
        {
            None = -1,

            Admin,
            Documents,
            Features,
            Forum,
            Help,
            Home,
            Join,
            Leases,
            Print,
            Resources,
            Settings,
            TenantScreening,
            Testimonials
        }
        public enum SiteSubSection
        {
            None,

            Home,

            //Features
            About,
            Benefits,
            DocManager,
            LeaseWizard,
            Testimonials,

            //Help
            Contact,
            DocPrinting,
            FAQ,
            Forum,

            //Resources
            Articles,
            //Forum(again)
            Associations,
            Attorneys,
            Lenders,
            Calculator,
            Links,

            //Settings
            Leases,
            Logo,
            OrderHistory,
            Profile,
            Properties,
            Tenants,
            Utilities
        }

        public enum UserAccess
        {
            NotLoggedIn = 0,
            Deleted = 1,
            Free = 2,      // i.e. Free Membership
            PremierNoLease = 4,
            Basic = 6,
            Premier = 8,
            Admin = 9

            //LeaseOnly = 3,
            //Premier1 = 5,
            //Premier2 = 6,
            //Premier3 = 7,
            //Premier4 = 8,
        }

        public enum PromoMemberType
        {

        }

        public enum ResourceType
        {
            Attorney = 1,
            Association = 2,
            Other = 3,
            Lender = 4,
        }

        public enum CreditCheckServiceStatus
        {
            HasAccount = 2,
            PendingApproval = 1,
            NoAccount = 0
        }

        public enum AutoRenewOption
        {
            Renewing = 0,
            Prepaid = 1,
            Cancelled = -1
        }

        public enum Status
        {
            Active = 1,
            Inactive = 0
        }


        public enum AdType
        {
            GoogleBanner = 1,
            GoogleSkyscraper = 2,
            GoogleHalfSkyscraper = 3,
            GoogleSmallSquare = 4
        }

        public enum MailStatus
        {
            [FlagDescription("NA")]
            NA = 0,
            [FlagDescription("Valid")]
            Good = 1,
            [FlagDescription("Soft Bounce")]
            SoftBounce = -1,
            [FlagDescription("Hard Bounce")]
            HardBounce = -2,
            [FlagDescription("Blocked")]
            Blocked = -3
        }

        public enum TimePeriod
        {
            AM = 0,
            PM = 1
        }

        public static string getUserDocumentPath(int userID, bool isTrial = false)
        {
            if (isTrial)
                return generatedDocsDiskPath + @"trial\";
            return generatedDocsDiskPath + (userID / 1000).ToString() + @"\";
        }
        public static string getBackupDocumentPath(string path)
        {
            string newPath = "";
            if (path.Contains(storagePath))
                newPath = path.Replace(storagePath, backupStoragePath);
            return newPath;
        }

        /// <summary>
        /// Checks the live doc directory and the primary backup, returning the backup path if the live path does not exist
        /// </summary>
        /// <param name="path">The full path to a document in the live documents directory (\\ezlfdocs\ezlfdocs\)</param>
        /// <returns></returns>
        public static string GetExistingFile(string path)
        {
            if (!File.Exists(path))
            {
                if (File.Exists(getBackupDocumentPath(path)))
                    return getBackupDocumentPath(path);
            }
            return path;
        }
        /// <summary>
        /// Looks for the existance of a lease in the trial directory, then falls back to finding a non-trial lease. Returns String.Empty if no existing file was found.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="leaseID"></param>
        /// <returns></returns>
        public static string GetExistingLease(int userID, int leaseID)
        {
            string filename = userID + "-" + leaseID + ".pdf";

            if (File.Exists(getUserDocumentPath(userID, true) + filename))
                return getUserDocumentPath(userID, true) + filename;
            if (File.Exists(GetExistingFile(getUserDocumentPath(userID) + filename)))
                return GetExistingFile(getUserDocumentPath(userID) + filename);

            return String.Empty;
        }

        public static bool DocThumbnailExists(int docID, bool retina = false)
        {
            bool exists = true;
            string cacheKey = Caching.CacheKeys.DocThumbExists(docID, retina);
            if (Caching.CacheExists(cacheKey))
                exists = (bool)Caching.GetCachedValue(cacheKey);
            else
            {
                Thread t = new Thread(
                    new ThreadStart(delegate ()
                    {
                        exists = File.Exists(Shared.GetDocumentThumbnailDiskPath(docID, retina: retina));
                    })
                );
                t.Start();
                bool completed = t.Join(500);
                if (!completed)
                {
                    exists = false;
                    t.Abort();
                }
                Caching.AddToCache(cacheKey, exists, 24);//Cache this for a day
            }
            return exists;
        }


        //public static string GetDocumentThumbnailURL(string docID, int imgNumber = 1, Documents.ImageSize size = Documents.ImageSize.Large, bool retina = false)
        //{
        //    return GetDocumentThumbnailURL(Parser.Parse(docID, -1), imgNumber, size, retina);
        //}
        //public static string GetDocumentThumbnailURL(int docID, int imgNumber = 1, Documents.ImageSize size = Documents.ImageSize.Large, bool retina = false)
        //{
        //    long versionNumber = -1;

        //    string cacheKey = Caching.CacheKeys.DocThumbMod(docID, imgNumber, size);
        //    if (Caching.CacheExists(cacheKey))
        //        versionNumber = (long)Caching.GetCachedValue(cacheKey);
        //    else
        //    {
        //        try
        //        {
        //            FileInfo fi = new FileInfo(GetDocumentThumbnailDiskPath(docID, imgNumber, size, retina));
        //            if (fi.LastWriteTime < DateTime.Now.AddDays(-10))//CDN Caches files for 7 days
        //                versionNumber = -1;
        //            else
        //                versionNumber = fi.LastWriteTime.Ticks % 1000000;
        //        }
        //        catch { }
        //        Caching.AddToCache(cacheKey, versionNumber, 24);
        //    }

        //    return String.Format(CDNUrl + "/{0}{1}-{2}-{3}-{4}{6}.gif{5}",
        //        thumbnailsWebPath.TrimStart('/'),
        //        docID,
        //        GetDocumentThumbnailFileNameBase(docID),
        //        imgNumber,
        //        size.ToString(),
        //        versionNumber > 0 ? "?v=" + versionNumber : String.Empty, //Append a Query String if the thumbnail has been changed in the past week to bust the cache on the CDN and users' computers.
        //        retina ? "@2x" : ""
        //        );
        //}

        public static string GetDocumentThumbnailDiskPath(string docID, int imgNumber = 1, Documents.ImageSize size = Documents.ImageSize.Large, bool retina = false)
        {
            return GetDocumentThumbnailDiskPath(Parser.Parse(docID, -1), imgNumber, size, retina);
        }

        public static string GetDocumentThumbnailDiskPath(int docID, int imgNumber = 1, Documents.ImageSize size = Documents.ImageSize.Large, bool retina = false)
        {
            return String.Format("{0}{1}-{2}-{3}{4}.gif",
                Shared.thumbnailsDiskPath,
                docID,
                imgNumber,
                size.ToString(),
                retina ? "@2x" : "");
        }

        //protected static string GetDocumentThumbnailFileNameBase(int docID)
        //{
        //    string fileNameBase = "";
        //    string cacheKey = Caching.CacheKeys.DocThumbFileName(docID);
        //    if (Caching.CacheExists(cacheKey))
        //        fileNameBase = (string)Caching.GetCachedValue(cacheKey);
        //    else
        //    {
        //        using (DB db = new DB())
        //        {
        //            db.Query = @"SELECT thumbnailfilenamebase FROM Documents WHERE id=:docID";
        //            db.Param("docID", docID);
        //            if (db.Read())
        //            {
        //                fileNameBase = db.GetValue("thumbnailfilenamebase", String.Empty);
        //            }
        //            else
        //            {
        //                fileNameBase = Shared.GetDocumentNameForURL(docID).Replace('-', '_');
        //            }
        //        }
        //        Regex parseExtra = new Regex("[\\s]");
        //        Regex titleForLinks = new Regex("[\\W]");
        //        string url = titleForLinks.Replace(parseExtra.Replace(fileNameBase, "_"), "").Replace("_", "-").Trim('-');
        //        fileNameBase = url.ToLower();
        //        Caching.AddToCache(cacheKey, fileNameBase, 24);//Cache this for a day
        //    }
        //    return fileNameBase;
        //}

        //public static bool DocLandingPageImageExists(int docID)
        //{
        //    bool exists = false;
        //    string cacheKey = Caching.CacheKeys.DocLandingPageImageExists(docID);
        //    if (Caching.CacheExists(cacheKey))
        //        exists = (bool)Caching.GetCachedValue(cacheKey);
        //    else
        //    {
        //        using (DB db = new DB())
        //        {
        //            db.Query = @"SELECT haslandingpageimage FROM Documents WHERE id=:docID";
        //            db.Param("docID", docID);
        //            if (db.Read())
        //            {
        //                exists = db.GetValue("haslandingpageimage", false);
        //            }
        //        }
        //        Caching.AddToCache(cacheKey, exists, 24);//Cache this for a day
        //    }
        //    return exists;
        //}

        //protected static string GetDocumentLandingPageImageFileNameBase(int docID)
        //{
        //    string fileNameBase = "";
        //    string cacheKey = Caching.CacheKeys.DocLandingPageImageFileName(docID);
        //    if (Caching.CacheExists(cacheKey))
        //        fileNameBase = (string)Caching.GetCachedValue(cacheKey);
        //    else
        //    {
        //        using (DB db = new DB())
        //        {
        //            db.Query = @"SELECT landingpagefilenamebase FROM Documents WHERE id=:docID";
        //            db.Param("docID", docID);
        //            if (db.Read())
        //            {
        //                fileNameBase = db.GetValue("landingpagefilenamebase", String.Empty);
        //            }
        //        }
        //        Regex parseExtra = new Regex("[\\s]");
        //        Regex titleForLinks = new Regex("[\\W]");
        //        string url = titleForLinks.Replace(parseExtra.Replace(fileNameBase, "_"), "").Replace("_", "-").Trim('-');
        //        fileNameBase = url.ToLower();
        //        Caching.AddToCache(cacheKey, fileNameBase, 24);//Cache this for a day
        //    }
        //    return fileNameBase;
        //}

        //public static string GetDocumentLandingPageImageURL(int docID, bool retina = false)
        //{
        //    long versionNumber = -1;

        //    string cacheKey = Caching.CacheKeys.DocLandingPageImageMod(docID);
        //    if (Caching.CacheExists(cacheKey))
        //        versionNumber = (long)Caching.GetCachedValue(cacheKey);
        //    else
        //    {
        //        try
        //        {
        //            FileInfo fi = new FileInfo(GetDocumentLandingPageImageDiskPath(docID, retina));
        //            if (fi.LastWriteTime < DateTime.Now.AddDays(-10))//CDN Caches files for 7 days
        //                versionNumber = -1;
        //            else
        //                versionNumber = fi.LastWriteTime.Ticks % 1000000;
        //        }
        //        catch { }
        //        Caching.AddToCache(cacheKey, versionNumber, 24);
        //    }

        //    return String.Format(CDNUrl + "/{0}{1}{2}{3}.jpg{4}",
        //        Shared.docLandingPageImagesWebPath.TrimStart('/'),
        //        docID,
        //        Shared.GetDocumentLandingPageImageFileNameBase(docID).Length > 0 ? "-" + Shared.GetDocumentLandingPageImageFileNameBase(docID) : "",
        //        //Shared.GetDocumentNameForURL(docID).Replace('-', '_'),
        //        retina ? "@2x" : "",
        //        versionNumber > 0 ? "?v=" + versionNumber : String.Empty //Append a Query String if the thumbnail has been changed in the past week to bust the cache on the CDN and users' computers.
        //        );
        //}

        public static string GetDocumentLandingPageImageDiskPath(string docID, bool retina = false)
        {
            return GetDocumentLandingPageImageDiskPath(Parser.Parse(docID, -1), retina);
        }


        public static string GetDocumentLandingPageImageDiskPath(int docID, bool retina = false)
        {
            return String.Format("{0}{1}{2}.jpg",
                Shared.docLandingPageImagesDiskPath,
                docID,
                retina ? "@2x" : "");
        }

        public static string GetDocumentURL(string docID)
        {
            return GetDocumentURL(Parser.Parse(docID, -1));
        }
        public static string GetDocumentURL(int docID)
        {
            return String.Format("/documents/{1}-{0}/", docID, GetDocumentNameForURL(docID));
        }

        public static string GetDocumentNameForURL(string docid)
        {
            return GetDocumentNameForURL(Parser.Parse(docid, -1));
        }
        public static string GetDocumentNameForURL(int docid)
        {
            string name = "";
            switch (docid)
            {
                case Documents.freeRentalApplication:
                    return "free-rental-application-form";
                //case Documents.emailableRentalApplication: 
                //    return "rental_application_electronic";
                case Documents.rentalAgreementDocument:
                    return "month-to-month-lease-agreement";
                case Documents.residentialLeaseDocument:
                    return "residential-lease-agreement";
                case Documents.canadianResidentialLeaseDocument:
                    return "canadian-lease-agreement";
                case Documents.freeLeaseDocument:
                    return "free-lease-agreement-forms";
                case Documents.residentialSubLeaseDocument:
                    return "sublease-agreement-template";
                default: break;
            }
            name = Documents.GetDocumentName(docid);
            Regex parseExtra = new Regex("[\\s]");
            Regex titleForLinks = new Regex("[\\W]");
            string url = titleForLinks.Replace(parseExtra.Replace(name, "_"), "").Replace("_", "-").Trim('-');
            return url.ToLower();
        }

        /// <summary>
        /// Returns the last day of the month if the date entered was past its end.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime FixDate(int year, int month, int day, int hour = 0, int min = 0, Shared.TimePeriod period = TimePeriod.AM)
        {
            switch (period)
            {
                case TimePeriod.PM:
                    if (hour < 12)
                        hour += 12;
                    break;
                case TimePeriod.AM:
                default:
                    if (hour == 12)
                        hour = 0;
                    break;
            }
            if (year < 0 || month < 0 || day < 0)
            {
                if (hour > 0 || min >= 0)
                    return DateTime.MinValue.AddHours(hour).AddMinutes(min);
                else
                    return DateTime.MinValue;
            }
            else
                return new DateTime(year, month, (day < DateTime.DaysInMonth(year, month) ? day : DateTime.DaysInMonth(year, month)), hour, min, 0);
        }

        public static DateTime? GetDateForDB(int year, int month, int day, int hour = 0, int min = 0, Shared.TimePeriod period = TimePeriod.AM)
        {
            if ((year < 0 || month < 0 || day < 0) && (hour == 0 && min == 0))
                return null;
            else
            {
                DateTime date = FixDate(year, month, day, hour, min, period);
                if (date == DateTime.MinValue)
                    return null;
                else
                    return date;
            }
        }

        /// <summary>
        /// Tells whether the given type of access is a premium (paid) type.
        /// </summary>
        /// <param name="userAccess">The type of user access to check.</param>
        /// <returns>Returns true if the given type is a type of premium access, and false otherwise.</returns>
        public static bool IsPremiumMembershipType(Shared.UserAccess userAccess)
        {
            if (userAccess == Shared.UserAccess.PremierNoLease || userAccess == Shared.UserAccess.Basic ||
                 userAccess == Shared.UserAccess.Premier)
                return true;
            else
                return false;
        }

        //public static int getNumPropertiesAllowed(UserInfo userInfo)
        //{
        //    if (userInfo.IsTrial())
        //        return 2;

        //    int propertiesAllowed = 0;
        //    if (!(userInfo.NumPropertiesAllowed.HasValue))
        //    {
        //        using (DB db = new DB())
        //        {
        //            db.Query = "SELECT properties FROM Users WHERE id=:userid";
        //            db.Param("userid", userInfo.ID);

        //            propertiesAllowed = db.GetValue(0);
        //            userInfo.NumPropertiesAllowed = propertiesAllowed;
        //        }
        //    }
        //    else
        //    {
        //        propertiesAllowed = userInfo.NumPropertiesAllowed.Value;
        //    }

        //    return propertiesAllowed;
        //}
        //public static void ClearUserPropertyCache(UserInfo userInfo)
        //{
        //    ClearUserPropertyCache(userInfo.ID);
        //}

        //public static void ClearUserPropertyCache(int userID)
        //{
        //    string cacheKey = Caching.CacheKeys.UserPropertyCount(userID);
        //    Caching.RemoveFromCache(cacheKey);
        //}
        //public static int GetUserPropertyCount(UserInfo userInfo)
        //{
        //    return GetUserPropertyCount(userInfo.ID);
        //}
        //public static int GetUserPropertyCount(int userID)
        //{
        //    int properties = 0;
        //    string cacheKey = Caching.CacheKeys.UserPropertyCount(userID);

        //    if (Caching.CacheExists(cacheKey))
        //        properties = (int)Caching.GetCachedValue(cacheKey);
        //    else
        //    {
        //        using (DB db = new DB())
        //        {
        //            db.Query = "SELECT COUNT(1) AS propCount FROM Properties WHERE userid=:userid";
        //            db.Param("userid", userID);
        //            if (db.Read())
        //                properties = db.GetValue("propCount", 0);
        //        }
        //        Caching.AddToCache(cacheKey, properties, DateTime.UtcNow.AddMinutes(20));
        //    }
        //    return properties;
        //}
        //public static bool IsUserAtPropertyLimit(UserInfo userInfo)
        //{
        //    return IsUserOverPropertyLimit(userInfo, true);
        //}
        //public static bool IsUserOverPropertyLimit(UserInfo userInfo, bool atLimit = false)
        //{
        //    if (userInfo.IsExpired() || userInfo.IsTrial())//treat property limit as infinite for expired and trial users, so they're encouraged to spend more money to renew or purchase
        //        return false;
        //    else
        //    {
        //        if (atLimit)
        //            return GetUserPropertyCount(userInfo) >= getNumPropertiesAllowed(userInfo);
        //        else
        //            return GetUserPropertyCount(userInfo) > getNumPropertiesAllowed(userInfo);
        //    }

        //}

        public static string getWatermarkFile(UserAccess useraccess)
        {
            switch (useraccess)
            {
                case UserAccess.NotLoggedIn:
                case UserAccess.Free:
                //case UserAccess.LeaseOnly:

                case UserAccess.PremierNoLease:
                case UserAccess.Basic:
                case UserAccess.Premier:
                case UserAccess.Admin:
                default:
                    //return @"E:\websites\ezlandlordforms.com\beta\images\ezDocumentWatermark.gif";
                    return HttpContext.Current.Server.MapPath("/images/ezDocumentWatermark.gif");
            }
        }


        /// <summary>
        /// Shows the first n characters of a string. For anything but short strings, it tries to slice between words, 
        /// killing any trailing partial words, unless this would cut off an unreasonable amount of the string.
        /// </summary>
        public static string showPartial(string theString, int numOfChars)
        {
            if (theString.Length <= numOfChars)
                return theString;
            else
            {
                theString = theString.Substring(0, numOfChars - 3);

                if (numOfChars > 15 && theString.LastIndexOf(' ') > 15)
                    theString = theString.Substring(0, theString.LastIndexOf(' '));

                return theString + "...";
            }
        }

        //---------------------------------------------------------------------------
        // Returns a URL-safe name for the article's pretty URL
        //
        public static string GetArticleFolderName(string articleName)
        {
            Regex re = new Regex(@"\W");
            return re.Replace(articleName.ToLower().Replace("&", "and").Replace("/", "and"), "_");
        }



        ///// <summary>
        ///// Gets the 1 month promo message for this user.  Assumes the message is applicable.
        ///// </summary>
        ///// <returns>A string of HTML.</returns>
        //public static string Get2WeekPromoMessage(UserInfo userInfo)
        //{
        //    StringBuilder message = new StringBuilder();
        //    DateTime membershipExp = userInfo.MembershipExpiration;

        //    message.Append("Limited Time Offer! &nbsp;");

        //    if (membershipExp != DateTime.MinValue && membershipExp >= DateTime.Now)
        //        message.Append("You have just " + (membershipExp - DateTime.Now).Days + " days left on your membership. &nbsp;");
        //    else
        //        message.Append("Your membership has expired. &nbsp;");

        //    if (userInfo.ActivePromoID == (int)Promos.SpecialPromos.Upgrade2Week)       // version of this code valid for 1 year or longer memberships
        //        message.Append("<b>Save $29.95 when you <a href='https://www.ezlandlordforms.com/join/'>upgrade</a> to one-year or greater membership.</b>");
        //    if (userInfo.ActivePromoID == (int)Promos.SpecialPromos.Upgrade2WeekNoLease)       // version of this code valid for 1 year or longer memberships
        //        message.Append("<b>Save $9.99 when you <a href='https://www.ezlandlordforms.com/join/'>upgrade</a> to one-year or greater membership.</b>");
        //    else if (userInfo.ActivePromoID == (int)Promos.SpecialPromos.Renew15Off)       // version of this code valid for 1 year or longer memberships nearing expiration
        //        message.Append("<b>Save 15% when you <a href='https://www.ezlandlordforms.com/join/'>upgrade</a> to one-year or greater membership.</b>");

        //    return message.ToString();
        //}

        ///// <summary>
        ///// Gets the 1 month promo message for this user.  Assumes the message is applicable.
        ///// </summary>
        ///// <returns>A string of HTML.</returns>
        //public static string Get2WeekPromoMessage2(UserInfo userInfo)
        //{
        //    StringBuilder message = new StringBuilder();
        //    DateTime membershipExp = userInfo.MembershipExpiration;

        //    if (membershipExp != DateTime.MinValue && membershipExp >= DateTime.Now)
        //        if (DateTime.Now.AddDays(1) > membershipExp)
        //            message.Append("Your pro membership will expire <b style=\"font-size:120%;\">today</b>.<br />");
        //        else
        //            message.Append("Your pro membership will expire on " + membershipExp.ToString("MM/dd/yy") + ".<br />");

        //    if (userInfo.ActivePromoID == (int)Promos.SpecialPromos.Upgrade2Week)       // version of this code valid for 1 year or longer memberships
        //        message.Append("<b><a href='https://www.ezlandlordforms.com/join/'>Extend your account today</a> and receive a $29.95 credit towards your tax-deductible renewal!</b>");
        //    if (userInfo.ActivePromoID == (int)Promos.SpecialPromos.Upgrade2WeekNoLease)       // version of this code valid for 1 year or longer memberships
        //        message.Append("<b><a href='https://www.ezlandlordforms.com/join/'>Extend your account today</a> and receive a $9.99 credit towards your tax-deductible renewal!</b>");

        //    return message.ToString();
        //}

        //public static string GetUserName(int userID)
        //{
        //    using (DB db = new DB())
        //    {
        //        return GetUserName(db, userID);
        //    }
        //}

        ///// <summary>
        ///// Gets the company or name to call the user by
        ///// </summary>
        //public static string GetUserName(DB db, int userID)
        //{
        //    string userName = String.Empty;
        //    db.Reset();
        //    db.Query = @"SELECT company, first, last
								//FROM Users
								//WHERE id=:id";

        //    db.Param("id", userID);

        //    if (db.Read())
        //    {
        //        string company = db.GetValue("company", "");

        //        if (company != "")
        //            userName = company;
        //        else
        //            userName = ContentShared.FixName(db.GetValue("first", "") + " " + db.GetValue("last", ""));
        //    }
        //    db.Reset();

        //    return userName.Trim();
        //}

        //public static string GetUserCompanyOrFirstName(int userID)
        //{
        //    using (DB db = new DB())
        //    {
        //        return GetUserCompanyOrFirstName(db, userID);
        //    }
        //}

        ///// <summary>
        ///// Gets the company or name to call the user by
        ///// </summary>
        //public static string GetUserCompanyOrFirstName(DB db, int userID)
        //{
        //    string userName = String.Empty;
        //    db.Reset();
        //    db.Query = @"SELECT company, first
								//FROM Users
								//WHERE id=:id";

        //    db.Param("id", userID);

        //    if (db.Read())
        //    {
        //        string company = db.GetValue("company", "");

        //        if (company != "")
        //            userName = company;
        //        else
        //            userName = ContentShared.FixName(db.GetValue("first", ""));
        //    }
        //    db.Reset();

        //    return userName.Trim();
        //}

        //--------------------------------------------------
        // Saves a users referrer to a cookie so we can
        // get it back when they sign up.  Also returns
        // the referrer, just in case you need it.
        //
        public static string SaveReferrer()
        {
            string referrerID = Forms.GetQueryString("r", String.Empty);

            if (referrerID != "" && getSavedReferrer() == String.Empty)
                Forms.SetCookie("referrer", referrerID);

            return referrerID;
        }

        //public static void GetIPStateCountry(UserInfo userInfo)
        //{
        //    bool fileup = true;
        //    string cacheKey = "filesharedownemailsent";
        //    //Check to make sure the site can access the fileshare
        //    try
        //    {
        //        if (Caching.CacheExists(cacheKey))
        //            fileup = false;
        //        else
        //            File.Open(Ip2LocationFilePath + "License.key", FileMode.Open, FileAccess.Read, FileShare.Read);
        //    }
        //    catch
        //    {
        //        if (!Caching.CacheExists(cacheKey))
        //        {
        //            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        //            msg.From = new System.Net.Mail.MailAddress(ErrorEmailsFrom);
        //            msg.To.Add(ErrorEmailsTo);
        //            msg.Subject = @"EZLF Unable to view " + Ip2LocationFilePath;
        //            msg.Body = @"Attempt to access ip2location\License.key failed. This indicates an issue viewing content in its parent directory.";
        //            MailHandling.SendMail(msg, MailHandling.MailServers.Pliner);
        //            Caching.AddToCache(cacheKey, true, (1.0 / 60) * 5.0);
        //        }
        //    }
        //    if (fileup)
        //    {
        //        try
        //        {

        //            IP2Location.IPResult oIPResult = new IP2Location.IPResult();
        //            IP2Location.Component oIP2Location = new IP2Location.Component();

        //            string ipCountryShort = "", ipCountryRegion = "";

        //            StringBuilder returnStr = new StringBuilder();
        //            try
        //            {
        //                if (!String.IsNullOrEmpty(Forms.GetRequesterIpAddress()))
        //                {
        //                    //Set Database Path
        //                    //e.g. C:\Program Files\IP2Location\Database\IP-COUNTRY.BIN
        //                    oIP2Location.IPDatabasePath = Ip2LocationFilePath + Ip2LocationDatabaseFile;
        //                    //Set License Path
        //                    //e.g. C:\Program Files\IP2Location\License.key
        //                    oIP2Location.IPLicensePath = Ip2LocationFilePath + "License.key";

        //                    if (Shared.IsInternalIp(Forms.GetRequesterIpAddress()))
        //                        oIPResult = oIP2Location.IPQuery("100.34.126.2");
        //                    else
        //                        oIPResult = oIP2Location.IPQuery(Forms.GetRequesterIpAddress());

        //                    switch (oIPResult.Status.ToString())
        //                    {
        //                        case "OK":
        //                            returnStr.AppendLine("IP Address: " + oIPResult.IPAddress);
        //                            returnStr.AppendLine("City: " + oIPResult.City);
        //                            returnStr.AppendLine("Country Code: " + oIPResult.CountryShort);
        //                            returnStr.AppendLine("Country Name: " + oIPResult.CountryLong);
        //                            returnStr.AppendLine("Latitude: " + oIPResult.Latitude);
        //                            returnStr.AppendLine("Longitude: " + oIPResult.Longitude);
        //                            returnStr.AppendLine("Region: " + oIPResult.Region);
        //                            //returnStr.AppendLine("Postal Code: " + oIPResult.ZipCode);
        //                            //returnStr.AppendLine("Domain Name: " + oIPResult.DomainName);
        //                            //returnStr.AppendLine("ISP Name: " + oIPResult.InternetServiceProvider);
        //                            //returnStr.AppendLine("Time Zone: " + oIPResult.TimeZone);
        //                            //returnStr.AppendLine("Net Speed: " + oIPResult.NetSpeed);
        //                            //returnStr.AppendLine("IDD Code: " + oIPResult.IDDCode);
        //                            //returnStr.AppendLine("Area Code: " + oIPResult.AreaCode);
        //                            //returnStr.AppendLine("Weather Station Code: " + oIPResult.WeatherStationCode);
        //                            //returnStr.AppendLine("Weather Station Name: " + oIPResult.WeatherStationName);
        //                            //returnStr.AppendLine("MCC: " + oIPResult.MCC);
        //                            //returnStr.AppendLine("MNC: " + oIPResult.MNC);
        //                            //returnStr.AppendLine("Mobile Brand: " + oIPResult.MobileBrand);

        //                            ipCountryShort = oIPResult.CountryShort;
        //                            ipCountryRegion = oIPResult.Region;

        //                            userInfo.IPCountry = ipCountryShort;
        //                            if (ipCountryShort == "US" || ipCountryShort == "CA")
        //                            {
        //                                switch (ipCountryRegion)
        //                                {
        //                                    case "YUKON TERRITORY":
        //                                        ipCountryRegion = "YUKON";
        //                                        break;
        //                                    default: break;
        //                                }
        //                                string stateabbr = ContentShared.GetStateAbbrev(ipCountryRegion, ipCountryShort);
        //                                userInfo.IPState = stateabbr;
        //                            }
        //                            //userInfo.IPCountry = "CA";
        //                            //userInfo.IPState = "BC";
        //                            if (userInfo.IPCountry == "CA" && !String.IsNullOrEmpty(userInfo.IPState))
        //                            {
        //                                userInfo.PrimaryCountry = "Canada";
        //                                userInfo.PrimaryState = userInfo.IPState;
        //                            }
        //                            break;
        //                        case "EMPTY_IP_ADDRESS":
        //                            returnStr.AppendLine("IP Address cannot be blank.");
        //                            break;
        //                        case "INVALID_IP_ADDRESS":
        //                            returnStr.AppendLine("Invalid IP Address.");
        //                            break;
        //                        case "MISSING_FILE":
        //                            returnStr.AppendLine("Invalid Database Path.");
        //                            break;
        //                    }
        //                }
        //                else
        //                {
        //                    returnStr.AppendLine("IP Address cannot be blank.");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                returnStr.AppendLine(ex.Message);
        //            }
        //            finally
        //            {
        //                oIPResult = null;
        //                oIP2Location = null;
        //            }
        //        }
        //        catch { }
        //    }
        //}

        public static string Get2CharISOCountry(string country)
        {
            switch (country.ToUpper())
            {
                case "CANADA":
                case "CAN":
                case "CA":
                    return "CA";
                case "UK":
                case "GB":
                    return "GB";
                case "AUSTRALIA":
                case "AUS":
                case "AU":
                    return "AU";
                case "USA":
                case "US":
                    return "US";
                default:
                    if (country.Length == 2)
                        return country.ToUpper();
                    return "";
            }
        }


        //--------------------------------------------------
        // Gets the saved referrer from the cookie
        //
        public static string getSavedReferrer()
        {
            return Forms.GetCookie("referrer", "");
        }

        //--------------------------------------------------
        // Gets the side panel for the join/pricing page
        //
        //public static string GetResourcesPanel(bool showFree, string myHeight, bool showHackerSafeLogo)
        //{
        //    return GetResourcesPanel(showFree, myHeight, showHackerSafeLogo, false);
        //}

        //public static string GetResourcesPanel(bool showFree, string myHeight, bool showHackerSafeLogo, bool showGodaddyLogo)
        //{
        //    return GetResourcesPanel(showFree, myHeight, showHackerSafeLogo, showGodaddyLogo, false);
        //}

   //     public static string GetResourcesPanel(bool showFree, string myHeight, bool showHackerSafeLogo, bool showGodaddyLogo, bool showNARPMlogo)
   //     {
   //         string height = myHeight;

   //         if (height == "")
   //             height = ((showFree) ? ("335") : ("243"));

   //         height = (Parser.Parse(height, 300) + 90 + (showGodaddyLogo ? 105 : 0) + (!showFree ? 40 : 0)).ToString();


   //         // Can't think of a reason why height needs to be calculated, so set it to auto for now

   //         //string sidePanel = @"
   //         //	<div style='background-color: #ffffee; padding: 4px; width: 210px; border: #ccc 1px solid;'>
   //         //		<div style='height:" + height + @"px; vertical-align: middle;' class='whatever2'>";

   //         string sidePanel = @"
			//	<div style='background-color: #ffffee; padding: 4px; width: 210px; border: #ccc 1px solid;'>
			//		<div style='height:auto; vertical-align: middle;' class='whatever2'>";


   //         if (showFree)
   //         {
   //             sidePanel += @"
			//			<h3>Free Resources:</h3>
			//				<ul>
			//					<li>Free Documents</li>
			//					<li>Member Newsletter</li>
			//					<li>Landlord Forum</li>
			//					<li>Find Local Attorneys</li>
			//					<li>Real Estate Investment Clubs</li>
			//					<li>Landlording Links</li>
			//					<li>Landlord Tips and Articles</li>
			//					<li>Rental Investment Calculator</li>
			//				</ul>

			//			<br>
			//	";
   //         }

   //         sidePanel += @"
			//			<h3>Pro Resources:</h3>
			//				<ul>
			//					<li>Access to the complete document library</li>
			//					<li>Lease Builder Wizard</li>
			//					<li>State Assist</li>
			//					<li>Auto-fill system</li>
			//					<li>Lease package</li>
			//					<li>Document history log</li>
			//					<li>Free monthly newsletter</li>
			//					<li>Logo on your documents</li>
			//					<li>Create your own forms</li>
			//					<li>Unlimited access</li>
			//					<li>Unlimited free tech support</li>
			//				</ul>
			//";

   //         if (showNARPMlogo)
   //         {
   //             sidePanel += @"
			//			<div style=""text-align: center; margin-right: 5px; margin-top: 8px;"" align='center'>
			//				<a href=""http://www.narpm.org"" target=""_blank"" style=""font-size:80%; text-decoration: none;"" rel=""nofollow"">
			//				Affiliate Member <br />
			//				<img src=""//ezlf-plinersolutionsi.netdna-ssl.com/images/logo-narpm.gif"" width=""100"" height=""53"" alt=""National Association of Residential Property Managers"" border=""0"" align=""absmiddle"" /><br />
			//				National Association of Residential Property Managers
			//				</a>
			//			</div>
			//		";
   //         }

   //         if (showHackerSafeLogo)
   //         {
   //             sidePanel += @"
			//			<div style=""text-align: center; margin-right: 5px; margin-top: 5px;"" align='center'>
			//		";

   //             //if were showing the images and they're buying stuff, show the 100% guarantee
   //             if (!showFree)
   //             {
   //                 sidePanel += @"<img src=""//ezlf-plinersolutionsi.netdna-ssl.com/images/cclogos.gif"" width=""162"" height=""62"" alt=""Accepting Visa, Mastercard, Discover, and American Express"" style=""margin-bottom: 8px;"" />";

   //                 if (showGodaddyLogo)
   //                     sidePanel += "<div style=\"padding-bottom: 3px;\"><span id=\"siteseal\"><a href= \"https://seal.starfieldtech.com/getSeal?sealID=boVbjYcppN00gHJSuykHUd9kv5zWhfFcFvl7ZIuf7W3CSQ88Ktv\" rel=\"nofollow\" target=\"_blank\"><img style=\"cursor:pointer;\" width=\"132\" height=\"31\" src=\"//ezlf-plinersolutionsi.netdna-ssl.com/images/starfield_seal.gif\" onclick=\"verifySeal();\"></a></span></div>";
   //                 else
   //                     sidePanel += @"<br />";

   //                 sidePanel += @"<img src=""//ezlf-plinersolutionsi.netdna-ssl.com/images/guarantee_small.gif"" width=""94"" height=""54"" alt=""100% Money-Back Guarantee"" />";
   //             }

   //             sidePanel += ContentShared.ShowHackerSafeLogo() + @"
			//			</div>
			//	";
   //         }

   //         sidePanel += @"
			//	</div>
			//";

   //         sidePanel += @"
			//		</div>
			//";

   //         return sidePanel;
   //     }

        //--------------------------------------------------
        // Gets ads of various sizes
        //
        public static string GetAd(AdType a)
        {
            if (a == AdType.GoogleBanner)
            {
                return @"<script type=""text/javascript""><!--
							google_ad_client = ""pub-5227786084969105"";
							google_ad_width = 468;
							google_ad_height = 60;
							google_ad_format = ""468x60_as"";
							google_ad_type = ""text"";
							google_ad_channel = """";
							//--></script>
							<script type=""text/javascript""
							  src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">
							</script>";
            }
            else if (a == AdType.GoogleSkyscraper)
            {
                return @"<script type=""text/javascript""><!--
							google_ad_client = ""pub-5227786084969105"";
							google_alternate_color = ""ffffff"";
							google_ad_width = 120;
							google_ad_height = 600;
							google_ad_format = ""120x600_as"";
							google_ad_type = ""text"";
							google_ad_channel = """";
							//--></script>
							<script type=""text/javascript""
							  src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">
							</script>";
            }
            else if (a == AdType.GoogleHalfSkyscraper)
            {
                return @"<script type=""text/javascript""><!--
							google_ad_client = ""pub-5227786084969105"";
							google_alternate_color = ""ffffff"";
							google_ad_width = 120;
							google_ad_height = 240;
							google_ad_format = ""120x240_as"";
							google_ad_type = ""text"";
							google_ad_channel = """";
							//--></script>
							<script type=""text/javascript""
							  src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">
							</script>";
            }
            else if (a == AdType.GoogleSmallSquare)
            {
                return @"<script type=""text/javascript""><!--
							google_ad_client = ""pub-5227786084969105"";
							google_alternate_color = ""ffffff"";
							google_ad_width = 200;
							google_ad_height = 200;
							google_ad_format = ""200x200_as"";
							google_ad_type = ""text"";
							google_ad_channel = """";
							//--></script>
							<script type=""text/javascript""
							  src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">
							</script>";
            }
            else
                return "";
        }

        //--MARKETING STUFF BEGIN--
        public static string referrerid = "";
        public static string referrerurl = "";
        public static string referralkeywords = "";
        public static string referrerFromURL = "";
        public static string referrerDomain = "";
        public static string actualid = "";
        public static string campaignid = "";

        //public static void setReferrerInfo()
        //{

        //    referrerid = PlinerMarketingUtils.GetReferrer().ToString();
        //    referrerurl = PlinerMarketingUtils.GetReferrerURL();
        //    referralkeywords = PlinerMarketingUtils.GetKeywords();
        //    referrerFromURL = PlinerMarketingUtils.GetReferrerFromURL(referrerurl).ToString();
        //    referrerDomain = PlinerMarketingUtils.GetReferrerDomain();
        //    //campaignid = PlinerMarketingUtils.GetCampaign().ToString();

        //    actualid = referrerid;

        //    if (actualid == "0")
        //        actualid = referrerFromURL;
        //}
        ////--MARKETING STUFF END--

        //---------------------------------------------------------------------------
        public static bool userHasCookiesDisabled()
        {
            return Forms.GetCookie("cookie-detection", 0) != 1;
        }

        public static void DetectCookieRedirect()
        {
            if (userHasCookiesDisabled())
            {
                HttpContext.Current.Response.Redirect("/errors/nocookies.aspx");
                return;
            }
        }

        //public static DateTime? GetLast1MonthOrderDate(UserInfo userInfo)
        //{
        //    DateTime? lastOrderDate = null;

        //    using (DB db = new DB())
        //    {

        //        db.Query = @"SELECT package, totalprice, properties, months, orderdate FROM Orders WHERE userid=:userid AND status=:processed AND type IN (:new, :renewal) ORDER BY orderdate DESC";
        //        db.Param("userid", userInfo.ID);
        //        db.Param("processed", OrdersShared.Status.Processed);
        //        db.Param("new", OrdersShared.OrderType.New);
        //        db.Param("renewal", OrdersShared.OrderType.Renewal);
        //        if (db.Read())
        //        {
        //            if ((new List<Shared.UserAccess>() { Shared.UserAccess.Premier, Shared.UserAccess.PremierNoLease }).Contains((Shared.UserAccess)db.GetValue("package", -1)))
        //            {
        //                if (Math.Abs(db.GetValue("months", 0)) == 1 || Math.Abs(db.GetValue("months", 0)) == 2)
        //                {
        //                    lastOrderDate = db.GetValue<DateTime?>("orderdate", null);
        //                }
        //            }
        //        }
        //    }
        //    return lastOrderDate;
        //}

        ///// <summary>
        ///// Gets the amount of money a user has spent on a one-month account in the past 45 days. Counts property upgrades made to the account past its original purchase. 
        ///// This is used for calculating how much discount a user would get upon renewing to an account of 1 year or longer.
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <returns></returns>
        //public static decimal GetPaymentOnOneMonthAccounts(int userid)
        //{
        //    decimal existingPaymentWithinTimeFrame = 0M;
        //    using (DB db = new DB())
        //    {
        //        db.Query = @"SELECT package, totalprice, properties, months, orderdate FROM Orders WHERE userid=:userid AND status=:processed AND type IN (:new, :renewal) AND orderdate > (sysdate-45) ORDER BY orderdate DESC";
        //        db.Param("userid", userid);
        //        db.Param("processed", OrdersShared.Status.Processed);
        //        db.Param("new", OrdersShared.OrderType.New);
        //        db.Param("renewal", OrdersShared.OrderType.Renewal);
        //        bool mostRecentNewOrRenewalIsOneMonth = false;
        //        DateTime getUpgradesAfterDate = DateTime.Now;
        //        if (db.Read())//Check the first record of this query to see if it's a valid one-month order. If so, use its price as a base.
        //        {
        //            if ((new List<Shared.UserAccess>() { Shared.UserAccess.Premier, Shared.UserAccess.PremierNoLease }).Contains((Shared.UserAccess)db.GetValue("package", -1)))
        //            {
        //                if (Math.Abs(db.GetValue("months", 0)) == 1 || Math.Abs(db.GetValue("months", 0)) == 2)
        //                {
        //                    mostRecentNewOrRenewalIsOneMonth = true;
        //                    existingPaymentWithinTimeFrame += db.GetValue("totalprice", 0M);
        //                    getUpgradesAfterDate = db.GetValue("orderdate", DateTime.Now);
        //                }
        //            }
        //        }
        //        db.Reset();
        //        if (mostRecentNewOrRenewalIsOneMonth)
        //        {
        //            db.Query = @"SELECT totalprice FROM Orders WHERE userid=:userid AND months <=2 AND type=:upgrade AND status=:processed AND orderdate > :minorderdate";
        //            db.Param("userid", userid);
        //            db.Param("upgrade", OrdersShared.OrderType.Upgrade);
        //            db.Param("processed", OrdersShared.Status.Processed);
        //            db.Param("minorderdate", getUpgradesAfterDate);
        //            while (db.Read())
        //            {
        //                existingPaymentWithinTimeFrame += db.GetValue("totalprice", 0M);
        //            }
        //        }

        //    }
        //    return existingPaymentWithinTimeFrame;
        //}

        /// <summary>
        /// Shifts an input date into the user's timezone.
        /// </summary>
        /// <param name="theDate">The input date (at server time) to shift.</param>
        /// <returns>The input date in the user's time zone, as known.</returns>
        public static DateTime ShiftToTimezone(DateTime theDate)
        {
            try
            {
                return theDate.AddMinutes(Forms.GetCookie("tzo", 0));
            }
            catch { return theDate; }
        }

       // /// <summary>
       // /// Returns the number of properties a user is currently managing (NOT the
       // /// number they have purchased)
       // /// </summary>
       // /// <param name="userID">The user's unique database ID number.</param>
       // /// <returns>Returns the property count</returns>
       // public static int GetUsersPropertyCount(int userID)
       // {
       //     int propertyCount = 0;
       //     using (DB db = new DB())
       //     {
       //         db.Query = @"SELECT COUNT(1)
						 //FROM Properties
						 //WHERE userid=:userid";

       //         db.Param("userid", userID);

       //         try { propertyCount = db.GetValue(0); }
       //         catch { propertyCount = 0; }
       //     }
       //     return propertyCount;
       // }

       // /// <summary>
       // /// Checks the given user's account to see if it's document form-filling address is complete.
       // /// </summary>
       // /// <param name="userID">The ID of the user whose document form-filling address we want to check.</param>
       // /// <returns>Returns true if this is enough information for a usable address, and false if it is not.</returns>
       // public static bool UserHasCompleteAddress(int userID)
       // {
       //     bool returnVal = false;
       //     using (DB db = new DB())
       //     {
       //         db.Query = "SELECT last, company, address1, city, state, zip FROM Users WHERE id=:userid";
       //         db.Param("userid", userID);

       //         if (db.Read())
       //         {
       //             return UserHasCompleteAddress(db.GetValue("last", ""), db.GetValue("company", ""),
       //                 db.GetValue("address1", ""), db.GetValue("city", ""), db.GetValue("state", ""), db.GetValue("zip", ""));
       //         }
       //         else
       //         {
       //             returnVal = false;
       //         }
       //     }

       //     return returnVal;
       // }

        /// <summary>
        /// Checks the given data to see if it contains a complete address.
        /// </summary>
        /// <param name="lastName">The address last name, if one is given.</param>
        /// <param name="company">The address company, if one is given.</param>
        /// <param name="address1">The address street address line, if one is given.</param>
        /// <param name="city">The address city, if one is given.</param>
        /// <param name="state">The address state, if one is given.</param>
        /// <param name="zip">The address zip code, if one is given.</param>
        /// <returns>Returns true if this is enough information for a usable address, and false if it is not.</returns>
        public static bool UserHasCompleteAddress(string lastName, string company, string address1, string city, string state, string zip)
        {
            // complete addresses have either a last name of company.
            if (String.IsNullOrEmpty(lastName) && String.IsNullOrEmpty(company))
                return false;

            // complete addresses have at least a street address, city, state, and zip (country=US assumed)
            if (String.IsNullOrEmpty(address1) || String.IsNullOrEmpty(city) || String.IsNullOrEmpty(state) || String.IsNullOrEmpty(zip))
                return false;

            return true;
        }

        ///// <summary>
        ///// Takes a string that is to be placed into a page's HTML inside of a JavaScript 
        ///// string and escapes any characters that cannot be written out to a JavaScript 
        ///// string in a page's HTML.
        ///// </summary>
        ///// <param name="str">The original string.</param>
        ///// <returns>Returns the escaped string.</returns>
        //public static string EscapeForJavascriptString(string str)
        //{
        //    string quotedEscapedStr = new JValue(str).ToString(Formatting.None, null);
        //    return quotedEscapedStr.Substring(1, quotedEscapedStr.Length - 2);//remove quotes added by JValue ToString to enforce existing behavior of this function
        //                                                                      //return str.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r", String.Empty).Replace("\n", "\\n");
        //}

        /// <summary>
        /// Tells whether the current site is the live site or a test site.
        /// </summary>
        /// <returns>
        /// Returns true if the current site is the live site, and false otherwise.
        /// </returns>
        public static bool IsLiveSite()
        {
            return GetSiteInstance().StartsWith("www");
        }

        /// <summary> 
        /// Tells the current instance of the site you are viewing. 
        /// </summary> 
        /// <returns>Returns the current instance of the site you are viewing.</returns> 
        public static string GetSiteInstance()
        {
            return (new System.IO.DirectoryInfo(HttpContext.Current.Request.PhysicalApplicationPath)).Name.ToLower();
        }

        /// <summary>
        /// Tells whether the current site is the live site or a test site.
        /// </summary>
        /// <returns>
        /// Returns true if the current site is the live site, and false otherwise.
        /// </returns>
        public static bool IsTrunkSite()
        {
            return HttpContext.Current.Request.PhysicalApplicationPath.Contains(@"\ezlandlordforms.com\trunk\");
        }


        /// <summary>
        /// Gets the website's software version number.
        /// </summary>
        /// <param name="qualifyByDeploymentTime">
        /// If true, the version is qualified by an extra string that includes the deployment time ticks. This may be necessary 
        /// because the version number only updates when core classes are modified, whereas the deployment time changes for any 
        /// changed file.
        /// </param>
        /// <returns>Returns the website's software version number.</returns>
        public static string GetSiteVersionNumber(bool qualifyByDeploymentTime = true)
        {
            string versionNumber = Assembly.GetAssembly(typeof(Shared)).GetName().Version.ToString();

            if (qualifyByDeploymentTime && HttpContext.Current != null && HttpContext.Current.Application != null &&
                HttpContext.Current.Application["DeploymentTime"] != null)
            {
                DateTime deploymentTime = (DateTime)HttpContext.Current.Application["DeploymentTime"];
                versionNumber = versionNumber.Substring(versionNumber.LastIndexOf('.') + 1, versionNumber.Length - (versionNumber.LastIndexOf('.') + 1));
                versionNumber += "." +
                    (IsLiveSite() ? (deploymentTime.Ticks % 1000000) : deploymentTime.Ticks);
            }

            return versionNumber;
        }


        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetEnumDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }

        /// <summary>
        /// Determines if the user's current browser is IE7
        /// </summary>
        /// <returns></returns>
        public static bool IsIE7()
        {
            if (HttpContext.Current.Request.Browser == null || String.IsNullOrEmpty(HttpContext.Current.Request.Browser.Browser))
                return false;
            if (HttpContext.Current.Request.Browser.Browser == "IE")
                if (HttpContext.Current.Request.Browser.MajorVersion <= 7)
                    return true;

            return false;
        }

        /// <summary>
        /// Determines if the user's current browser is IE8
        /// </summary>
        /// <returns></returns>
        public static bool IsIE8()
        {
            if (HttpContext.Current.Request.Browser == null || String.IsNullOrEmpty(HttpContext.Current.Request.Browser.Browser))
                return false;
            if (HttpContext.Current.Request.Browser.Browser == "IE")
                if (HttpContext.Current.Request.Browser.MajorVersion <= 8)
                    return true;
            return false;
        }

        /// <summary>
        /// Determines if the user's current browser is in iOS
        /// </summary>
        /// <returns></returns>
        public static bool IsIOS()
        {
            if (!String.IsNullOrEmpty(HttpContext.Current.Request.UserAgent))
            {
                if (HttpContext.Current.Request.UserAgent.ToLower().Contains("ipad") ||
                    HttpContext.Current.Request.UserAgent.ToLower().Contains("iphone") ||
                    HttpContext.Current.Request.UserAgent.ToLower().Contains("ipod"))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool DoesBrowserLackSpellcheck()
        {
            if (HttpContext.Current.Request.Browser == null || String.IsNullOrEmpty(HttpContext.Current.Request.Browser.Browser))
                return false;
            if (HttpContext.Current.Request.Browser.Browser == "IE")
                if (HttpContext.Current.Request.Browser.MajorVersion < 10)
                    return true;

            return false;
        }

        public static string GetCKEditorScript()
        {
            if (IsIE7())
                return GetCacheBustedScript("/media/ckeditor4.1.2/ckeditor.js");
            else
                return GetCDNScript("/ckeditor4.5.9/ckeditor.js");
        }

        public static string GetCacheBustedScript(string script)
        {
            return script + "?v=" + Shared.GetSiteVersionNumber();
        }

        public static string GetCDNScript(string url, bool includeCacheBusting = true)
        {
            if (includeCacheBusting)
                return "//ezlf-plinersolutionsi.netdna-ssl.com/" + GetCacheBustedScript(url.TrimStart('/'));
            else
                return "//ezlf-plinersolutionsi.netdna-ssl.com/" + url.TrimStart('/');
        }

        public static string GetDetailedErrorMessageStringForDiagnostics(Exception baseError, HttpContext context = null)
        {
            StringBuilder errorReport = new StringBuilder();
            string errorName = String.Empty;
            string siteName = String.Empty;

            Exception objErr = baseError.GetBaseException();

            if (context == null)
            {
                context = HttpContext.Current;
            }

            try
            {
                errorReport.AppendFormat("<u>File URL</u>:<br />{0} ({1})<br /><br />", context.Request.Url.ToString(), context.Request.HttpMethod);
                siteName = context.Request.Url.Host;

                errorReport.AppendFormat("<u>File Path</u>:<br />{0} ({1})<br /><br />", context.Request.PhysicalPath, System.Environment.MachineName);
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                errorReport.AppendFormat("<u>Exception Type</u>:<br />{0}<br /><br />", objErr.GetType());
                errorReport.AppendFormat("<u>Message</u>:<br />{0}<br /><br />", objErr.Message);

                errorName = String.Format("{0} - {1}", objErr.GetType().ToString(), objErr.Message);
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                errorReport.AppendFormat("<u>Browser Type</u>:<br />{0} ({1})<br /><br />", context.Request.Browser.Type, context.Request.Browser.Platform);
                errorReport.AppendFormat("<u>User IP</u>:<br />{0}<br /><br />", Forms.GetRequesterIpAddress());
                errorReport.AppendFormat("<u>User Agent</u>:<br />{0}<br /><br />", context.Request.UserAgent);
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                if (context.Request != null && context.Request.Headers != null && context.Request.Headers.Count > 0)
                {
                    errorReport.AppendFormat("<u>HTTP Request Headers [{0}]</u>:<br />", context.Request.QueryString.Count);
                    for (int i = 0; i < context.Request.Headers.Count; i++)
                        errorReport.AppendFormat("{0} = {1}<br />", context.Request.Headers.Keys[i], context.Request.Headers[i]);

                    errorReport.Append("<br />");
                }
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                if (context.Request != null && context.Request.QueryString != null && context.Request.QueryString.Count > 0)
                {
                    errorReport.AppendFormat("<u>QueryString Elements [{0}]</u>:<br />", context.Request.QueryString.Count);
                    for (int i = 0; i < context.Request.QueryString.Count; i++)
                        errorReport.AppendFormat("{0} = {1}<br />", context.Request.QueryString.Keys[i], context.Request.QueryString[i]);

                    errorReport.Append("<br />");
                }
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                if (context.Request != null && context.Request.Form != null && context.Request.Form.Count > 0)
                {
                    errorReport.AppendFormat("<u>Form Elements [{0}]</u>:<br />", context.Request.Form.Count);
                    for (int i = 0; i < context.Request.Form.Count; i++)
                        errorReport.AppendFormat("{0} = {1}<br />", context.Request.Form.Keys[i], context.Request.Form[i]);

                    errorReport.Append("<br />");
                }
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                if (context.Session != null && context.Session.Count > 0)
                {
                    errorReport.AppendFormat("<u>Session Elements [{0}]</u>:<br />", context.Session.Count);
                    for (int i = 0; i < context.Session.Count; i++)
                        if (context.Session.Keys.Count > i && context.Session.Keys[i] != null)
                            errorReport.AppendFormat("{0} = {1}<br />", context.Session.Keys[i], (context.Session[i] == null ? "(null)" : context.Session[i]).ToString());

                    errorReport.Append("<br />");
                }
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                errorReport.AppendFormat("<u>Stack Trace</u>:<br />{0}<br /><br />", objErr.StackTrace.Replace("\n", "<br />"));
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            try
            {
                errorReport.AppendFormat("<u>Top Level Exception Trace</u>:<br />{0}<br /><br />", baseError.ToString().Replace("\n", "<br />"));
            }
            catch (Exception exception)
            {
                errorReport.AppendFormat("Report Section Failed: <br />{0}<br />{1}<br /><br />",
                    exception.Message, exception.StackTrace.Replace("\n", "<br />"));
            }

            return errorReport.ToString();
        }

        /// <summary>
        /// Formats a social security number, assumed to be a string of digits, for display
        /// Should be the same behavior as FormatSSNField in shared.js
        /// </summary>
        /// <param name="ssn">The social security number to be formatted</param>
        /// <returns>Returns the formatted social security number, if formatting was possible, and the original if it was not.</returns>
        public static string FormatSocialSecurityNumberForDisplay(string ssn)
        {
            if (string.IsNullOrEmpty(ssn))
            {
                return string.Empty;
            }

            // Valid SSN length
            if (ssn.Length == 9)
            {
                return ssn.Substring(0, 3) + "-" + ssn.Substring(3, 2) + "-" + ssn.Substring(5, 4);
            }
            else
            {
                return ssn;
            }
        }

        /// <summary>
        /// Strips a social security number of all non-numeric characters
        /// Formats social security number to be saved in the database.
        /// This will only be invoked when saving a value to the database.
        /// </summary>
        /// <param name="ssn">The social security number to format.</param>
        /// <returns>Returns the formatted social security number.</returns>
        public static string FormatSocialSecurityNumberForDatabase(string ssn)
        {
            if (string.IsNullOrEmpty(ssn))
                return string.Empty;

            ssn = Regex.Replace(ssn, "[^0-9+]", "");

            return ssn;
        }

        public static string FormatSocialSecurityNumberForSecureDisplay(string ssn)
        {
            if (string.IsNullOrEmpty(ssn))
            {
                return string.Empty;
            }

            // Valid SSN length
            if (ssn.Length == 9)
            {
                return "***-**-" + ssn.Substring(5, 4);
            }

            return ssn;
        }

        /// <summary>
        /// Formats a phone number, assumed to be a string of digits, for display.
        /// Should exhibit identical behavior as FormatPhoneField in shared.js
        /// </summary>
        /// <param name="phone">The phone number to format.</param>
        /// <returns>Returns the formatted phone number, if formatting was possible, and the original if it was not.</returns>
        public static string FormatPhoneForDisplay(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return string.Empty;

            StringBuilder formattedPhone = new StringBuilder();

            // replace 011 with + at beginning of phone number
            if (phone.StartsWith("011"))
                phone = phone.Replace(phone.Substring(0, 3), "+");

            // strip the leading +1 for North American numbers
            if (phone.StartsWith("+1"))
                phone = phone.Substring(2);

            // assume numbers without the + are North American numbers
            if (!phone.StartsWith("+"))
            {
                // strip the leading 1 if there
                if (phone.StartsWith("1"))
                    phone = phone.Substring(1);

                // if the phone number has at least 10 digits, it contains an area code, so display that and then get rid of it
                if (phone.Length >= 10)
                {
                    formattedPhone.AppendFormat("({0}) ", phone.Substring(0, 3));
                    phone = phone.Substring(3);
                }

                // if the phone number has at least 7 digits, this is the local portion of the number, so display that and then get rid of it
                if (phone.Length >= 7)
                {
                    formattedPhone.AppendFormat("{0}-{1}", phone.Substring(0, 3), phone.Substring(3, 4));
                    phone = phone.Substring(7);
                }

                // if we didn't at least have a local portion of the number, then we can't format it in any useful way, so just send it back as-is
                else
                    return phone;

                // if there is anything left after the local portion of the number, it must be an extension
                if (phone.Length > 0)
                    formattedPhone.AppendFormat(" Ext: {0}", phone);
            }
            else
                return phone;

            return formattedPhone.ToString();
        }

        /// <summary>
        /// Strips a phone number of all non-numeric characters except for +
        /// Formats phone number to be saved in the database.
        /// This will only be invoked when saving a value to the database.
        /// </summary>
        /// <param name="phoneNumber">The phone number to format.</param>
        /// <returns>Returns the formatted phone number.</returns>
        public static string FormatPhoneForDatabase(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return string.Empty;

            phoneNumber = Regex.Replace(phoneNumber, "[^0-9+]", "");

            // replace 011 with + at beginning of phone number
            if (phoneNumber.StartsWith("011"))
                phoneNumber = phoneNumber.Replace(phoneNumber.Substring(0, 3), "+");

            // strip the leading +1 for North American numbers
            if (phoneNumber.StartsWith("+1"))
                phoneNumber = phoneNumber.Substring(2);

            if (phoneNumber.StartsWith("1"))
                phoneNumber = phoneNumber.Substring(1);

            if (!phoneNumber.StartsWith("+") || (phoneNumber.StartsWith("+") && phoneNumber.Length > 1))
                return phoneNumber;
            else
                return String.Empty;
        }
    }
}