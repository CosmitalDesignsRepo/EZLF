using System;
using System.Collections;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Caching;


namespace EZLF.Class
{
    /// <summary>
	/// Summary description for Caching
	/// </summary>
	public class Caching
    {
        public class CacheKeys
        {
            public static string ApplicantsListJSON(int userID) { return String.Format("ApplicantsListJSON_{0}", userID); }

            public static string ArticleTitle(int articleID) { return String.Format("ArticleTitle_{0}", articleID); }
            public static string ArticleCategory(int articleID) { return String.Format("ArticleCategory_{0}", articleID); }
            public static string ArticleThumbnail(int articleID) { return String.Format("ArticleThumbnail_{0}", articleID); }
            public static string ArticleThumbnailRetina(int articleID) { return String.Format("ArticleThumbnailRetina_{0}", articleID); }
            public static string ArticleThumbnailFileName(int articleID) { return String.Format("ArticleThumbnailFileName_{0}", articleID); }
            public static string ArticleBanner(int articleID) { return String.Format("ArticleBanner_{0}", articleID); }
            public static string ArticleBannerFileName(int articleID) { return String.Format("ArticleBannerFileName_{0}", articleID); }
            //public static string Articles(Articles.MetaCategories metacategory) { return String.Format("Articles_{0}", metacategory); }
            //public static string ArticlesRecent(Articles.MetaCategories metacategory) { return String.Format("ArticlesRecent_{0}", metacategory); }
            //public static string ArticlesRecentRelated(Articles.RelatedArticlesCategories relatedArticleCategory) { return String.Format("ArticlesRecentRelated_{0}", relatedArticleCategory); }
            //public static string ArticlesLawSidebar(Articles.MetaCategories metacategory) { return String.Format("ArticlesLawSidebar_{0}", metacategory); }
            //public static string ExcludedArticleIDs(Articles.MetaCategories metacategory) { return String.Format("ExcludedArticleIDs_{0}", metacategory); }
            //public static string ExcludedArticleIDsRecent(Articles.MetaCategories metacategory) { return String.Format("ExcludedArticleIDsRecent_{0}", metacategory); }

            public static string HomePageArticles = "HomePageArticles";
            public static string CanadianHomePageArticles = "CanadianHomePageArticles";


            public static string DocCategoryName(int categoryID) { return String.Format("DocCategoryName_{0}", categoryID); }

            public static string DocBuilderStatus = "DocBuilderStatus";

            public static string DocCategoryNameToID(string catName) { return String.Format("DocCatFolderToID_{0}", catName); }

            public static string DocAvailability(int docID) { return String.Format("DocAvailability_{0}", docID); }
            public static string DocCategory(int docID) { return String.Format("DocCategory_{0}", docID); }
            public static string DocFeaturesIcons(int docID) { return String.Format("DocFeaturesIcons_{0}", docID); }
            public static string DocGlossaryEntries(int docID) { return String.Format("DocGlossaryEntries_{0}", docID); }
            public static string DocIsCustomizable(int docID) { return String.Format("DocIsCustomizable_{0}", docID); }
            public static string DocIsEditable(int docID) { return String.Format("DocIsEditable_{0}", docID); }
            public static string DocIsEmailable(int docID) { return String.Format("DocIsEmailable_{0}", docID); }
            public static string DocIsForAllUsers(int docID) { return String.Format("DocIsForAllUsers_{0}", docID); }
            public static string DocIsStatic(int docID) { return String.Format("DocIsStatic_{0}", docID); }
            public static string DocStatus(int docID) { return String.Format("DocStatus_{0}", docID); }
            public static string DocName(int docID) { return String.Format("DocName_{0}", docID); }
            public static string DocOwner(int docID) { return String.Format("DocOwner_{0}", docID); }
            public static string DocRelatedArticles(int docID) { return String.Format("DocRelatedArticles_{0}", docID); }
            public static string DocRelatedDocs(int docID) { return String.Format("DocRelatedDocs_{0}", docID); }
            public static string DocThumbExists(int docID, bool retina = false) { return String.Format("DocThumbExists_{0}{1}", docID, retina ? "_retina" : ""); }
            public static string DocThumbMod(int docID, int imgNumber, Documents.ImageSize size) { return String.Format("DocThumbMod_{0}-{1}-{2:D}", docID, imgNumber, size); }

            public static string DocThumbFileName(int docID) { return String.Format("DocThumbFileName_{0}", docID); }
            public static string DocLandingPageImageExists(int docID) { return String.Format("DocLandingPageImageExists_{0}", docID); }
            public static string DocLandingPageImageFileName(int docID) { return String.Format("DocLandingPageImageFileName_{0}", docID); }
            public static string DocLandingPageImageMod(int docID) { return String.Format("DocLandingPageImageMod_{0}", docID); }

            public static string DocPreviewImages(int docID) { return String.Format("DocPreviewImages_{0}", docID); }
            public static string DocPreviewMod(int docID, int imgNumber) { return String.Format("DocPreviewMod_{0}-{1}", docID, imgNumber); }
            public static string DocPreviewRetina(int docID, int imgNumber) { return String.Format("DocPreviewRetina_{0}-{1}", docID, imgNumber); }
            public static string DocPreviewMaxNum(int docID) { return String.Format("DocPreviewMaxNum_{0}", docID); }

            public static string DocRelatedSearches(int categoryID) { return String.Format("DocRelatedSearches_{0}", categoryID); }

            public static string ForumRecentPostsSidebar = "RecentForumPostsSidebar";

            public static string UserEmailExists(string email) { return String.Format("EmailExists_{0}", email.Trim().ToLower()); }

            public static string LandlordsJSON(int userID) { return String.Format("LandlordsJSON_{0}", userID); }

            public static string PopularFormsDocument(int docID) { return String.Format("PopularFormsDoc_{0}", docID); }

            public static string PromoCode(int promoCodeID) { return String.Format("PromoCode_{0}", promoCodeID); }
            public static string PromoCodeID(string promoCode) { return String.Format("PromoCodeID_{0}", promoCode); }

            public static string PropertiesJSON(int userID) { return String.Format("PropertiesJSON_{0}", userID); }
            public static string TenantsJSON(int userID) { return String.Format("TenantsJSON_{0}", userID); }

            public static string StateForms(string stateAbbrev) { return String.Format("StateForms_{0}", stateAbbrev); }


            public static string TestimonialsHome(string location = "") { return "Testimonials_Home" + (!String.IsNullOrEmpty(location) ? "_" + location : location); }
            public static string TestimonialsSpotlight = "Testimonials_Spotlight";
            public static string TestimonialsWhyUs = "Testimonials_WhyUs";

            public static string TenantAppApplicationID(int TransUnionApplicationID) { return String.Format("TA_from_TU_{0}", TransUnionApplicationID); }
            public static string TransUnionApplicationID(int TenantAppApplicationID) { return String.Format("TU_from_TA_{0}", TenantAppApplicationID); }

            public static string TransunionPropertiesJSON(int userID) { return String.Format("TransunionPropertiesJSON_{0}", userID); }
            public static string TransunionOrganizationID(int userID) { return String.Format("TransunionOrganizationID_{0}", userID); }

            public static string TrustPilotFeedJSON = "TrustPilotJSONFeed";
            public static string TrustPilotReviews = "TrustPilotReviews";
            public static string TrustPilotHomeReviews = "TrustPilotHomeReviews";
            public static string TrustPilotCanadianHomeReviews = "TrustPilotCanadianHomeReviews";
            public static string TrustPilotSpotlightReviews = "TrustPilotSpotlightReviews";

            public static string UserEmail(int userID) { return String.Format("UserEmail_{0}", userID); }
            public static string UserLastOrder(int userID) { return String.Format("UserLastOrder_{0}", userID); }
            public static string UserPropertyCount(int userID) { return String.Format("UserPropertyCount_{0}", userID); }
            public static string UserUtilities(int userID) { return String.Format("UserUtils_{0}", userID); }

            public static string UtilityCollection = "UtilityCollection";

            public static string RentalZipCode(int userID, string rentalZipCode) { return String.Format("RentalZipCode_{0}_{1}", userID, rentalZipCode); }
        }

        public static Cache Cache
        {
            get
            {
                return HttpContext.Current.Cache;
            }
        }

        /// <summary>
        /// Detects both if the cache exists and if the cache contains a non-null value at the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool CacheExists(string key)
        {
            return HttpContext.Current.Cache != null && HttpContext.Current.Cache[key] != null;
        }

        /// <summary>
        /// Gets the value with the specified key from the cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCachedValue(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        /// <summary>
        /// Adds a value to the cache
        /// </summary>
        /// <param name="key">The key to be used to retrieve the requested value</param>
        /// <param name="value">The value to be stored</param>
        /// <param name="hoursTilExpiration">The number of hours until the value should be removed from the cache.</param>
        public static void AddToCache(string key, object value, CacheDependency dependency)
        {
            if (HttpContext.Current.Cache != null)
                HttpContext.Current.Cache.Insert(key, value, dependency);
        }

        /// <summary>
        /// Adds a value to the cache
        /// </summary>
        /// <param name="key">The key to be used to retrieve the requested value</param>
        /// <param name="value">The value to be stored</param>
        /// <param name="hoursTilExpiration">The number of hours until the value should be removed from the cache.</param>
        public static void AddToCache(string key, object value, double hoursTilExpiration)
        {
            AddToCache(key, value, DateTime.UtcNow.AddHours(hoursTilExpiration));
        }

        /// <summary>
        /// Adds a value to the cache
        /// </summary>
        /// <param name="key">The key to be used to retrieve the requested value</param>
        /// <param name="value">The value to be stored</param>
        /// <param name="absoluteExpiration">The time at which the value should be removed from the cache. For this value to work, the expiration must be set to NoSlidingExpiration.</param>
        /// <param name="slidingExpiration">The Sliding Expiration value for the cache</param>
        /// <param name="priority">The priority of the item in the cache.</param> 
        public static void AddToCache(string key, object value, DateTime? absoluteExpiration = null, TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal)
        {
            if (!absoluteExpiration.HasValue)
                absoluteExpiration = DateTime.UtcNow.AddHours(1);
            if (!slidingExpiration.HasValue)
                slidingExpiration = Cache.NoSlidingExpiration;

            DateTime _absoluteExpiration = absoluteExpiration.Value;
            TimeSpan _slidingExpiration = slidingExpiration.Value;

            if (HttpContext.Current.Cache != null)
                HttpContext.Current.Cache.Insert(key, value, null, _absoluteExpiration, _slidingExpiration, priority, null);
        }

        public static void FlushAll()
        {
            foreach (DictionaryEntry entry in Caching.Cache)
            {
                Caching.RemoveFromCache((string)entry.Key);
            }
        }

        /// <summary>
        /// Removes a value from the cache
        /// </summary>
        /// <param name="key">The key to be used to retrieve the requested value</param>
        /// <param name="isCallExternal">Set to true when calling from removeFromCache.ashx, leave false otherwise</param>
        public static void RemoveFromCache(string key, bool isCallExternal = false)
        {

            if (HttpContext.Current.Cache != null)
                HttpContext.Current.Cache.Remove(key);

            if (!isCallExternal && Shared.IsLiveSite())
            {
                CacheRemovalThread att = new CacheRemovalThread(System.Environment.MachineName, key);
                ThreadPool.QueueUserWorkItem(att.Go);
                //try
                //{
                //	string cacheRemovalUrl = String.Format(
                //		"http://<domain>.ezlandlordforms.com/services/removefromcache.ashx?key={0}", key);

                //	string[] domainList = { "web1", "web2" };

                //	foreach (string s in domainList)
                //	{
                //		if (System.Environment.MachineName.ToLower().Contains(s))
                //			continue;
                //		HttpWebRequest cacheRemovalRequest = (HttpWebRequest)WebRequest.Create(cacheRemovalUrl.Replace("<domain>", s));
                //		cacheRemovalRequest.Timeout = 2000;
                //		HttpWebResponse cacheRemovalResponse = (HttpWebResponse)cacheRemovalRequest.GetResponse();
                //		cacheRemovalResponse.Close();
                //	}
                //}
                //catch { }
            }
        }


        private class CacheRemovalThread
        {
            private string _machineName;
            private string _cacheKey;

            public CacheRemovalThread(string machineName, string cacheKey)
            {
                _machineName = machineName;
                _cacheKey = cacheKey;
            }

            public void Go(Object stateInfo)
            {
                try
                {
                    string cacheRemovalUrl = String.Format(
                        "http://<domain>.ezlandlordforms.com/services/removefromcache.ashx?key={0}", _cacheKey);

                    string[] domainList = { "web1", "web2", "web3", "web4" };

                    foreach (string s in domainList)
                    {
                        if (_machineName.ToLower().Contains(s))
                            continue;
                        try
                        {
                            HttpWebRequest cacheRemovalRequest = (HttpWebRequest)WebRequest.Create(cacheRemovalUrl.Replace("<domain>", s));
                            cacheRemovalRequest.Timeout = 2000;
                            HttpWebResponse cacheRemovalResponse = (HttpWebResponse)cacheRemovalRequest.GetResponse();
                            cacheRemovalResponse.Close();
                        }
                        catch
                        {
                        }
                    }
                }
                catch { }
            }
        }
    }
}