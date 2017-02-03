using Pliner;
using Pliner.Util;
using System;
using System.IO;
using System.Web;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using System.Threading;
using Newtonsoft.Json.Linq;
namespace EZLF.Class
{
    public class Documents
    {
        public const int freeRentalApplication = 12;
        public const int freeRentalApplicationCanada = 145191;
        public const int freeRentalApplicationPaperless = 295095;
        public const int emailableRentalApplication = 59783;
        public const int emailableRentalApplicationCanada = 144745;
        public const int emailableRentalApplicationCalifornia = 185184;

        public static readonly int[] staticPDFs = { 17, 46509, emailableRentalApplication, emailableRentalApplicationCanada };

        public const int rentalAgreementDocument = 99703;
        public const int freeRentalAgreementDocument = 119949;
        public const int residentialLeaseDocument = 100;
        public const int freeLeaseDocument = 41050;
        public const int storageLeaseDocument = 101;
        public const int residentialSubLeaseDocument = 67494;
        public const int purchaseOptionAgreement = 148;
        public const int editablePurchaseOption = 8838;
        public const int utilityCompanyInformation = 194;
        public const int canadianResidentialLeaseDocument = 101037;
        public const int commercialLeaseDocument = 160868;
        public const int vacationLeaseDocument = 169549;


        public const int freeRentReceipt = 17;
        public const int freeSecurityDepositReceipt = 147;

        #region State Leases
        public enum StateLeases
        {
            [FlagDescription("California", "SortOrder", "-1")]
            CA = 122040,
            [FlagDescription("Florida", "SortOrder", "-1")]
            FL = 112378,
            [FlagDescription("Georgia", "SortOrder", "-1")]
            GA = 128203,
            [FlagDescription("Illinois", "SortOrder", "-1")]
            IL = 127549,
            [FlagDescription("North Carolina", "SortOrder", "-1")]
            NC = 130079,
            [FlagDescription("New York", "SortOrder", "-1")]
            NY = 112377,
            [FlagDescription("Pennsylvania", "SortOrder", "-1")]
            PA = 128811,
            [FlagDescription("Texas", "SortOrder", "-1")]
            TX = 124927,
            [FlagDescription("Virginia", "SortOrder", "-1")]
            VA = 130027,
            [FlagDescription("Washington", "SortOrder", "-1")]
            WA = 129866,

            [FlagDescription("Oregon", "SortOrder", "-1")]
            OR = 151878,
            [FlagDescription("Michigan", "SortOrder", "-1")]
            MI = 131549,
            [FlagDescription("Ohio", "SortOrder", "-1")]
            OH = 132936,
            [FlagDescription("Arizona", "SortOrder", "-1")]
            AZ = 142785,
            [FlagDescription("Massachusetts", "SortOrder", "-1")]
            MA = 142946,
            [FlagDescription("Minnesota", "SortOrder", "-1")]
            MN = 145244,
            [FlagDescription("Wisconsin", "SortOrder", "-1")]
            WI = 145245,

            [FlagDescription("Louisiana", "SortOrder", "-1")]
            LA = 158653,
            [FlagDescription("Kansas", "SortOrder", "-1")]
            KS = 161741,
            [FlagDescription("Colorado", "SortOrder", "-1")]
            CO = 158570,
            [FlagDescription("Connecticut", "SortOrder", "-1")]
            CT = 158574,
            [FlagDescription("Maryland", "SortOrder", "-1")]
            MD = 161625,

            [FlagDescription("Kentucky", "SortOrder", "-1")]
            KY = 165586,
            [FlagDescription("Arkansas", "SortOrder", "-1")]
            AR = 166775,
            [FlagDescription("South Carolina", "SortOrder", "-1")]
            SC = 167186,
            [FlagDescription("Utah", "SortOrder", "-1")]
            UT = 166791,
            [FlagDescription("Nevada", "SortOrder", "-1")]
            NV = 165587,
            [FlagDescription("Mississippi", "SortOrder", "-1")]
            MS = 167192,
            [FlagDescription("Oklahoma", "SortOrder", "-1")]
            OK = 166716,

            [FlagDescription("Vermont", "SortOrder", "-1")]
            VT = 172994,
            [FlagDescription("New Jersey", "SortOrder", "-1")]
            NJ = 173001,
            [FlagDescription("Missouri", "SortOrder", "-1")]
            MO = 173007,
            [FlagDescription("North Dakota", "SortOrder", "-1")]
            ND = 172998,
            [FlagDescription("Rhode Island", "SortOrder", "-1")]
            RI = 172997,
            [FlagDescription("Tennessee", "SortOrder", "-1")]
            TN = 172996,
            [FlagDescription("Delaware", "SortOrder", "-1")]
            DE = 172990,
            [FlagDescription("South Dakota", "SortOrder", "-1")]
            SD = 172995,
            [FlagDescription("Iowa", "SortOrder", "-1")]
            IA = 173010,
            [FlagDescription("Maine", "SortOrder", "-1")]
            ME = 173011,
            [FlagDescription("District of Columbia", "SortOrder", "-1")]
            DC = 172987,
            [FlagDescription("Hawaii", "SortOrder", "-1")]
            HI = 173002,
            [FlagDescription("Montana", "SortOrder", "-1")]
            MT = 173006,
            [FlagDescription("Wyoming", "SortOrder", "-1")]
            WY = 172991,
            [FlagDescription("Alabama", "SortOrder", "-1")]
            AL = 172988,
            [FlagDescription("Idaho", "SortOrder", "-1")]
            ID = 173003,
            [FlagDescription("New Mexico", "SortOrder", "-1")]
            NM = 172999,
            [FlagDescription("Indiana", "SortOrder", "-1")]
            IN = 173008,
            [FlagDescription("West Virginia", "SortOrder", "-1")]
            WV = 172992,
            [FlagDescription("Alaska", "SortOrder", "-1")]
            AK = 172989,
            [FlagDescription("New Hampshire", "SortOrder", "-1")]
            NH = 173004,
            [FlagDescription("Nebraska", "SortOrder", "-1")]
            NE = 173005
        }

        public static readonly List<int> StateLeaseDocuments =
            new List<int>((int[])Enum.GetValues(typeof(StateLeases)));
        #endregion

        #region Province Leases
        public enum ProvinceLeases
        {
            [FlagDescription("Ontario", "SortOrder", "-1")]
            ON = 180661,
            [FlagDescription("Alberta", "SortOrder", "-1")]
            AB = 180792,
            [FlagDescription("British Columbia", "SortOrder", "-1")]
            BC = 180793
        }

        public static readonly List<int> ProvinceLeaseDocuments =
            new List<int>((int[])Enum.GetValues(typeof(ProvinceLeases)));
        #endregion

        public static readonly List<int> FreeLeaseDocuments =
            new List<int>(new[] {
                freeLeaseDocument,
                freeRentalAgreementDocument
            });

        public static readonly List<int> RentalAgreementDocuments =
            new List<int>(new[] {
                rentalAgreementDocument,
                freeRentalAgreementDocument
            });

        public static readonly List<int> ResidentialLeaseDocuments =
            new List<int>(new[] {
                residentialLeaseDocument,
                freeLeaseDocument,
                canadianResidentialLeaseDocument}.Concat(StateLeaseDocuments).Concat(ProvinceLeaseDocuments).Concat(RentalAgreementDocuments)); // all types of documents that are built as residential leases with the residential lease builder wizard

        public static readonly List<int> LeaseDocuments =
            new List<int>(new[] {
                freeLeaseDocument,
                storageLeaseDocument,
                commercialLeaseDocument,
                residentialSubLeaseDocument,
                vacationLeaseDocument}.Concat(ResidentialLeaseDocuments)); // all types of documents that are types of lease documents



        //public static int GetDocumentByLeaseType(Leases.LeaseTypes type)
        //{
        //    switch (type)
        //    {
        //        case Leases.LeaseTypes.Residential:
        //            return residentialLeaseDocument;
        //        case Leases.LeaseTypes.Commercial:
        //            return commercialLeaseDocument;
        //        case Leases.LeaseTypes.ResidentialSubLease:
        //            return residentialSubLeaseDocument;
        //        case Leases.LeaseTypes.GarageOrStorage:
        //            return storageLeaseDocument;
        //        case Leases.LeaseTypes.Vacation:
        //            return vacationLeaseDocument;
        //        default:
        //            return -1;
        //    }
        //}

        public enum PDFType
        {
            FillablePDF = 0,
            EditableDoc = 1,
            StaticPDF = 2
        }

        public enum PseudoCategories
        {
            AllDocuments = -1,
            FreeDocuments = -2,
            CustomDocuments = -3,
            StateSpecific = -4,
            HomePage = -5
        }

        /// <summary>
        /// The Categories listed on the site
        /// </summary>
        public enum DocSections
        {
            [FlagDescription("",
                "WebFolder", "")]
            None = -1,
            [FlagDescription("Free Documents",
                "WebFolder", "free-landlord-forms")]
            FreeDocs = -2,
            [FlagDescription("Customized Documents",
                "WebFolder", "custom-documents")]
            CustomDocs = -3,
            [FlagDescription("State-Specific Forms",
                "WebFolder", "state-specific")]
            StateSpecific = -4,
            [FlagDescription("Rental Application Forms",
                "WebFolder", "rental-application-forms")]
            Application = 16,
            [FlagDescription("Rental / Lease Agreements",
                "WebFolder", "rental-lease-agreements")]
            Leases = 34,
            [FlagDescription("Addenda",
                "WebFolder", "addenda")]
            Addenda = 1,
            [FlagDescription("Disclosures",
                "WebFolder", "disclosures")]
            Disclosures = 22,
            [FlagDescription("Information Documents",
                "WebFolder", "information-documents")]
            InfoDocs = 23,
            [FlagDescription("Notices to Tenants",
                "WebFolder", "notices-to-tenants")]
            TenantNotices = 21,
            [FlagDescription("Violation Notices",
                "WebFolder", "violation-notices")]
            ViolationNotices = 32,
            [FlagDescription("Late Notices",
                "WebFolder", "late-notices")]
            LateNotices = 17,
            [FlagDescription("Eviction Notices",
                "WebFolder", "eviction-notice-templates")]
            EvictionNotices = 37,
            [FlagDescription("Move Out",
                "WebFolder", "move-out")]
            MoveOut = 20,
            [FlagDescription("Management Documents",
                "WebFolder", "management-documents")]
            Management = 18,
            [FlagDescription("Envelopes / Labels",
                "WebFolder", "envelopes-and-labels")]
            Envelopes = 26,
            //The following are meta-categories added as part of the DocumentsSubmenu changes detailed in Redmine Ticket #1026
            [FlagDescription("Leasing / Move In",
                "WebFolder", "leasing-and-move-in")]
            LeasingMoveIn = 100, //Contains Categories Leases, Addenda, Disclosures, InfoDocs
            [FlagDescription("Tenant Notice Letters",
                "WebFolder", "notices")]
            Notices = 101, //Contains Categories TenantNotices, ViolationNotices, LateNotices, EvictionNotices
            [FlagDescription("General Management",
                "WebFolder", "landlord-tools")]
            LandlordTools = 102 //Contains Categories Management, Envelopes
        }

        public static DocSections[] MetaSections = { DocSections.LeasingMoveIn, DocSections.Notices, DocSections.LandlordTools };

        //public static string GetCategoryName(DocSections section, UserInfo userInfo)
        //{
        //    string ret = String.Empty;
        //    if (section == DocSections.StateSpecific)
        //    {
        //        if ((userInfo.IPDetectAttempted && userInfo.IPCountry != "USA") || userInfo.PrimaryCountry != "USA" || userInfo.HasInternationalAddress)
        //            if (userInfo.IPCountry == "Canada" || userInfo.PrimaryCountry == "Canada")
        //                ret = "Province-Specific Forms";
        //            else
        //                ret = "Local Forms";
        //        else
        //            ret = FlagDescription.GetFlagDisplayName(section);
        //    }
        //    else
        //        ret = FlagDescription.GetFlagDisplayName(section);
        //    return ret;
        //}

        /// <summary>
        /// Returns the relative url to the category folder in the format "/documents/<category>/"
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        //public static string GetCategoryURL(DocSections section)
        //{
        //    try
        //    {
        //        switch (section)
        //        {
        //            case DocSections.LeasingMoveIn:
        //                return GetCategoryURL(DocSections.Leases);
        //            case DocSections.Notices:
        //                return GetCategoryURL(DocSections.TenantNotices);
        //            case DocSections.LandlordTools:
        //                return GetCategoryURL(DocSections.Management);
        //            default:
        //                string folder = "";
        //                UserInfo userInfo = UserInfo.GetUserInfo();
        //                if (section == DocSections.StateSpecific && ((userInfo.IPDetectAttempted && userInfo.IPCountry != "USA") || userInfo.PrimaryCountry != "USA" || userInfo.HasInternationalAddress))
        //                    folder = "local-forms";
        //                else
        //                    folder = FlagDescription.GetFlagCustomProperties(section)["WebFolder"];
        //                return !String.IsNullOrEmpty(folder) ? String.Format(@"/documents/{0}/", folder) : String.Empty;
        //        }
        //    }
        //    catch
        //    {
        //        return String.Empty;
        //    }
        //}

        public static DocSections GetDocSectionByCategoryID(int catID)
        {
            return Enum.IsDefined(typeof(DocSections), catID) ? (DocSections)catID : DocSections.None;
        }

        public enum ImageSize
        {
            Large = 0,
            Small = 1,
            Both = 2
        }

        public enum CustomDocTemplate
        {
            Blank = 0,
            Mailable = 1
        }

        //--------------------------------------------------
        // Handles streaming a selected file to the user.
        // The "File Download" dialog is explicitly
        // raised, so the user can easily save the file.
        // The filePath is the path to the file on disk,
        // documentName is the name the document should
        // have when the user gets it.
        //
        //public static void streamFile(int builtID, string filePath, string documentName)
        //{
        //    streamFile(builtID, filePath, documentName, -100);
        //}

    /*
		public static void streamFile(string filePath, string documentName)
		{
			streamFile(filePath, documentName, -100);
		}

		public static void streamFile(string filePath, string documentName, int documentID)
		{
			// -- The user cannot have any documents if they are not validated
			if (!Validation.isValidated())
			{
				HttpContext.Current.Response.Redirect("/val.aspx?unval=document");
			}

			if (File.Exists(filePath))
			{
				string fileName = "";
				HttpResponse response = HttpContext.Current.Response;

				// -- Re-check to see if the user now has documents to print
				HttpContext.Current.Session["hasDocsToPrint"] = Documents.HasDocumentsToPrint();

				// -- If this is the tutorial lease (has permissions built in, no need to modify them here
				if (filePath.Contains("0-" + Leases.residentialLeaseTutorialId + ".pdf"))
				{
					fileName = filePath;
				}

				// -- Otherwise, set the permissions dynamically
				else
				{
					fileName = Shared.downloadDocsDiskPath + (int)HttpContext.Current.Session["id"] + "-" + DateTime.Now.Ticks + ".pdf";

					PDFDocument pdf = new PDFDocument(filePath);

					pdf.Security.AllowCopyContent = false;
					pdf.Security.AllowEditContent = false;

					if (userInfo.IsFreeMember() || !Shared.isLoggedIn())
					{
						pdf.Security.AllowPrint = IsDocumentFree(documentID);
					}

					pdf.Save(fileName);

					pdf.Close();
				}

				response.Clear();
				response.Expires = 0;
				response.ContentType = "application/pdf";
				response.AddHeader("Content-Disposition", "attachment; filename=" + documentName.Replace(" ", "_") + ".pdf");

				FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				long bytesLeft = fs.Length;
				long bufferSize = 12800; // ~100K

				while (bytesLeft > 0)
				{
					if (bytesLeft < bufferSize)
						bufferSize = bytesLeft;
					bytesLeft -= bufferSize;

					byte[] buffer = new byte[(int)bufferSize];
					fs.Read(buffer, 0, (int)bufferSize);
					response.BinaryWrite(buffer);
					response.Flush();
				}
				fs.Close();
				response.End();
			}
			else
			{
				HttpContext.Current.Response.Write("File not found.");
			}
		}
		*/

        //public static void documentPostProcessing(string fileName, string outputFileName, bool useWatermark)
        //{
        //    PdfLoadedDocument pdf = OpenPdfLoadedDocument(fileName);

        //    // -- Set the document compression level
        //    pdf.Compression = PdfCompressionLevel.Best;
        //    if (useWatermark)
        //    {
        //        foreach (PdfLoadedPage page in pdf.Pages)
        //        {
        //            PdfGraphics graphics = page.Graphics;

        //            // Draw on the watermark if needed

        //            PdfBitmap watermark = new PdfBitmap(Shared.getWatermarkFile(UserInfo.GetUserInfo().UserAccess));

        //            graphics.SetTransparency(0.5F);
        //            graphics.DrawImage(watermark, 125, 200);
        //            graphics.SetTransparency(0);
        //        }
        //    }

        //    // -- Set the document properties
        //    pdf.DocumentInformation.Title = "ezLandlordForms Custom Document";
        //    pdf.DocumentInformation.Author = "ezLandlordForms";
        //    pdf.DocumentInformation.Keywords = "ezLandlordForms";
        //    pdf.DocumentInformation.Subject = "ezLandlordForms Custom Document";
        //    pdf.DocumentInformation.Producer = "ezLandlordForms Document Library";
        //    pdf.DocumentInformation.CreationDate = DateTime.Now;

        //    pdf.Save(outputFileName);
        //    pdf.Close();
        //}

        ///// <summary>
        /// Opens a PDF loaded document.  If the file is in use, it will make multiple 
        /// attempts with short waits between each attempt.
        /// </summary>
        /// <param name="path">The path to the file to open as a PdfLoadedDocument.</param>
        /// <returns>
        /// Returns the PdfLoadedDocument that was opened.  Throws up the file exception if the 
        /// document could not be opened even after multiple retries, so this return value will 
        /// always exist if you get to the return.
        /// </returns>
        public static PdfLoadedDocument OpenPdfLoadedDocument(string path)
        {
            bool fileCopied = false;
            int fileCopyAttempts = 0;
            string openPath = null;

            do
            {
                openPath = Shared.tempDocsDiskPath + DateTime.Now.Ticks + "-" + fileCopyAttempts + ".pdf";
                fileCopyAttempts++;

                try
                {
                    File.Copy(path, openPath, false);  // open a copy so you don't hold a lock on the original
                    fileCopied = true;
                }
                catch (Exception e)
                {
                    fileCopied = false;

                    if (fileCopyAttempts >= 10)
                        throw e;

                    Thread.Sleep(250);
                }
            }
            while (!fileCopied);

            PdfLoadedDocument pdf = null;
            int attempts = 0;
            bool errorOpening = false;

            do
            {
                attempts++;
                errorOpening = false;

                try
                {
                    pdf = new PdfLoadedDocument(openPath);
                }
                catch (Exception e)
                {
                    errorOpening = true;

                    if (attempts >= 10)
                        throw e;

                    GC.Collect();
                    Thread.Sleep(1000);
                }
            }
            while (errorOpening);

            return pdf;
        }

        //--------------------------------------------------
        // Writes out the code for the document preview
        // images for a given document.
        //
        //public static string GetDocumentPreview(string documentID, string documentName, string havePreview, string icon)
        //{
        //	return GetDocumentPreview(documentID, documentName, havePreview, icon, false);
        //}

        //public static string GetDocumentPreview(string documentID, string documentName, string havePreview, string icon, bool fullSizeImageOnly)
        //{
        //	return GetDocumentPreview(documentID, documentName, havePreview, icon, fullSizeImageOnly, "0");
        //}

        //public static string GetDocumentPreview(string documentID, string documentName, string havePreview, string icon, string isEditable)
        //{
        //	return GetDocumentPreview(documentID, documentName, havePreview, icon, false, isEditable);
        //}

        //public static string GetDocumentPreview(string documentID, string documentName, string havePreview, string icon, bool fullSizeImageOnly, string isEditable)
        //{
        //	return GetDocumentPreview(documentID, documentName, havePreview, icon, (fullSizeImageOnly) ? ImageSize.Large : ImageSize.Both, isEditable);
        //}

        //public static string GetDocumentPreview(string documentID, string documentName, string havePreview, string icon, ImageSize imageSize, string isEditable)
        //{
        //	string html = "";
        //	Bitmap smallDocumentImage, largeDocumentImage;

        //	try
        //	{
        //		if (havePreview == Shared.YesNo.No.ToString("D"))
        //		{
        //			if (icon == "1")
        //			{
        //				smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "envelope_icon.gif");
        //				html += "<img src=\"" + Shared.thumbnailsWebPath + "envelope_icon.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" />";
        //				smallDocumentImage.Dispose();
        //			}

        //			else if (icon == "2")
        //			{
        //				smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "label_icon.gif");
        //				html += "<img src=\"" + Shared.thumbnailsWebPath + "label_icon.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" />";
        //				smallDocumentImage.Dispose();
        //			}

        //			else
        //				return "";
        //		}
        //		else if (isEditable == Shared.YesNo.Yes.ToString("D"))
        //		{
        //			if (!Documents.DocumentIsForAllUsers(Parser.Parse(documentID, -1)))
        //			{
        //				smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "customdoc_icon.gif");
        //				html += "<img src=\"" + Shared.thumbnailsWebPath + "customdoc_icon.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" />";
        //				smallDocumentImage.Dispose();
        //			}
        //			else
        //			{
        //				smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "editabledoc_icon.gif");
        //				html += "<img src=\"" + Shared.thumbnailsWebPath + "editabledoc_icon.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" />";
        //				smallDocumentImage.Dispose();
        //			}
        //		}
        //		else
        //		{
        //			smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + documentID + "-1-small.gif");
        //			largeDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + documentID + "-1-large.gif");

        //			string styleAttrs = @"id=""previewImage" + documentID + @""" ";

        //			if (imageSize == ImageSize.Both)
        //				html += "<img src=\""+Shared.thumbnailsWebPath + documentID + "-" + Shared.GetDocumentNameForURL(documentID) + "-1-small.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" " + styleAttrs + " onMouseOver=\"overPreviewImage(this, " + documentID + ", " + largeDocumentImage.Width + ", " + largeDocumentImage.Height + ")\" onMouseOut=\"offPreviewImage(this, " + documentID + ", " + largeDocumentImage.Width + ", " + largeDocumentImage.Height + ")\" onClick=\"clickPreviewImage(this, " + documentID + ", " + largeDocumentImage.Width + ", " + largeDocumentImage.Height + ")\" style=\"cursor: pointer; \" />";
        //			else if (imageSize == ImageSize.Small)
        //				html += "<img src=\""+Shared.thumbnailsWebPath + documentID + "-" + Shared.GetDocumentNameForURL(documentID) + "-1-small.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" " + styleAttrs + " />";
        //			else if (imageSize == ImageSize.Large)
        //				html += "<img src=\""+Shared.thumbnailsWebPath + documentID + "-" + Shared.GetDocumentNameForURL(documentID) + "-1-large.gif\" width=\"" + largeDocumentImage.Width + "\" height=\"" + largeDocumentImage.Height + "\" alt=\"" + documentName + "\" " + styleAttrs + " />";

        //			smallDocumentImage.Dispose();
        //			largeDocumentImage.Dispose();
        //		}
        //	}
        //	catch
        //	{
        //		// fails when the image files do not exist, so just skip it then and return a spacer so the page doesn't render too strangely
        //		html += "<img src=\"//ezlf-plinersolutionsi.netdna-ssl.com/images/spacer.gif\" width=\"1\" height=\"1\" alt=\"\" />";
        //	}

        //	return html;
        //}

     //   public static string GetDocumentPreviewNew(string documentID, string documentName, bool havePreview, string icon, ImageSize imageSize, bool isEditable, bool isStateSpecific)
     //   {
     //       string html = "";
     //       Bitmap smallDocumentImage, largeDocumentImage;

     //       try
     //       {
     //           if (!havePreview)
     //           {
     //               if (icon == "1")
     //               {
     //                   smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "envelope_icon.gif");
     //                   html += "<img src=\"" + Shared.CDNUrl + Shared.thumbnailsWebPath + "envelope_icon.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" style=\"border: 1px solid #CCCCCC;\" />";
     //                   smallDocumentImage.Dispose();
     //               }

     //               else if (icon == "2")
     //               {
     //                   smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "label_icon.gif");
     //                   html += "<img src=\"" + Shared.CDNUrl + Shared.thumbnailsWebPath + "label_icon.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" style=\"border: 1px solid #CCCCCC;\" />";
     //                   smallDocumentImage.Dispose();
     //               }

     //               else
     //                   return "";
     //           }
     //           else if (isEditable && documentID != "26" && documentID != "72")
     //           {
     //               /*
					//smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "customdoc_icon.gif");
					//html += "<img src=\"//ezlf-plinersolutionsi.netdna-ssl.com/images/thumbnails/customdoc_icon.gif\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" />";
					//smallDocumentImage.Dispose();
					//*/

     //               string smallImageFile = (Documents.DocumentIsForAllUsers(Parser.Parse(documentID, -1)) ? "editabledoc_icon.gif" : "customdoc_icon.gif");

     //               smallDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + smallImageFile);
     //               largeDocumentImage = new Bitmap(Shared.thumbnailsDiskPath + "customdoc_icon_bak_big.gif");

     //               string styleAttrs = @"id=""previewImage" + documentID + @""" ";

     //               if (imageSize == ImageSize.Both)
     //                   html += String.Format(@"<img src=""{0}"" width=""{1}"" height=""{2}"" alt=""{3}"" style=""border 1px solid #CCC; cursor: pointer;"" {4} onMouseOver=""overPreviewImage(this,{5},{6},{7})""
					//							onMouseOut=""offPreviewImage(this,{5},{6},{7})"" onClick=""clickPreviewImage(this,{5},{6},{7})"" style=""cursor: pointer;"" />",
     //                                           Shared.CDNUrl + Shared.thumbnailsWebPath + smallImageFile,
     //                                           smallDocumentImage.Width,
     //                                           smallDocumentImage.Height,
     //                                           documentName,
     //                                           styleAttrs,
     //                                           documentID,
     //                                           largeDocumentImage.Width,
     //                                           largeDocumentImage.Height);
     //               else if (imageSize == ImageSize.Small)
     //                   html += String.Format(@"<img src=""{0}"" width=""{1}"" height=""{2}"" alt=""{3}"" style=""border: 1px solid #CCC;"" {4} />",
     //                                           Shared.CDNUrl + Shared.thumbnailsWebPath + smallImageFile,
     //                                           smallDocumentImage.Width,
     //                                           smallDocumentImage.Height,
     //                                           documentName,
     //                                           styleAttrs);
     //               else if (imageSize == ImageSize.Large)
     //                   html += String.Format(@"<img src=""{0}"" width=""{1}"" height=""{2}"" alt=""{3}"" style=""border: 1px solid #CCC;"" {4} />",
     //                                           Shared.CDNUrl + Shared.thumbnailsWebPath + "customdoc_icon_bak_big.gif",
     //                                           largeDocumentImage.Width,
     //                                           largeDocumentImage.Height,
     //                                           documentName,
     //                                           styleAttrs);

     //               smallDocumentImage.Dispose();
     //               largeDocumentImage.Dispose();
     //           }
     //           else
     //           {
     //               smallDocumentImage = new Bitmap(Shared.GetDocumentThumbnailDiskPath(documentID, 1, ImageSize.Small));
     //               largeDocumentImage = new Bitmap(Shared.GetDocumentThumbnailDiskPath(documentID, 1, ImageSize.Large));

     //               string styleAttrs = @"id=""previewImage" + documentID + @""" ";

     //               if (imageSize == ImageSize.Both)
     //                   html += "<img src=\"" + Shared.CDNUrl + Shared.GetDocumentThumbnailURL(documentID, 1, Documents.ImageSize.Small) + "\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" style=\"border: 1px solid #CCCCCC;\" " + styleAttrs + " onMouseOver=\"overPreviewImage(this, " + documentID + ", " + largeDocumentImage.Width + ", " + largeDocumentImage.Height + ")\" onMouseOut=\"offPreviewImage(this, " + documentID + ", " + largeDocumentImage.Width + ", " + largeDocumentImage.Height + ")\" onClick=\"clickPreviewImage(this, " + documentID + ", " + largeDocumentImage.Width + ", " + largeDocumentImage.Height + ")\" style=\"cursor: pointer;\" />";
     //               else if (imageSize == ImageSize.Small)
     //                   html += "<img src=\"" + Shared.CDNUrl + Shared.GetDocumentThumbnailURL(documentID, 1, Documents.ImageSize.Small) + "\" width=\"" + smallDocumentImage.Width + "\" height=\"" + smallDocumentImage.Height + "\" alt=\"" + documentName + "\" style=\"border: 1px solid #CCCCCC;\" " + styleAttrs + " />";
     //               else if (imageSize == ImageSize.Large)
     //                   html += "<img src=\"" + Shared.CDNUrl + Shared.GetDocumentThumbnailURL(documentID) + "\" width=\"" + largeDocumentImage.Width + "\" height=\"" + largeDocumentImage.Height + "\" alt=\"" + documentName + "\" style=\"border: 1px solid #CCCCCC;\" " + styleAttrs + " />";
     //               smallDocumentImage.Dispose();
     //               largeDocumentImage.Dispose();
     //           }
     //       }
     //       catch
     //       {
     //           if (isStateSpecific)
     //           {
     //               if (imageSize == ImageSize.Small)
     //               {
     //                   //if its a state-specific document then just display sample state-specific thumbnail
     //                   html += "<img src=\"" + Shared.CDNUrl + Shared.thumbnailsWebPath + "statespecificdoc_icon.gif\" width=\"51\" height=\"66\" alt=\"" + documentName + "\" style=\"border: 1px solid #CCCCCC;\" />";
     //               }
     //               else if (imageSize == ImageSize.Large)
     //               {
     //                   html += "<img src=\"" + Shared.CDNUrl + Shared.thumbnailsWebPath + "statespecificdoc_icon_large.gif\" width=\"153\" height=\"198\" alt=\"" + documentName + "\" style=\"border: 1px solid #CCCCCC;\" />";
     //               }
     //           }
     //           else
     //           {
     //               // fails when the image files do not exist, so just skip it then and return a spacer so the page doesn't render too strangely
     //               html += "<img src=\"" + Shared.CDNUrl + "/images/spacer.gif\" width=\"1\" height=\"1\" alt=\"\" />";
     //           }
     //       }

     //       return html;
     //   }

        /// <summary>
        /// Gets the URL of the editing script for the given document
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public static string GetDocumentEditorLink(int userID, int documentID)
        {
            if (ResidentialLeaseDocuments.Contains(documentID))
            {
                //return "/wizards/leases/?isNew=true&leaseID=NEW&defaultSelect=residential";
                if (Documents.RentalAgreementDocuments.Contains(documentID))
                    return "/wizards/rentalagreement/residential/";
                return "/wizards/leases/residential/";
            }
            else if (documentID == storageLeaseDocument)
                return "/wizards/leases/?isNew=true&leaseID=NEW&defaultSelect=storage";
            else if (documentID == residentialSubLeaseDocument)
                //return "/wizards/leases/?isNew=true&leaseID=NEW&defaultSelect=sublease";
                return "/wizards/leases/sublease/";
            else if (documentID == commercialLeaseDocument)
                //return "/wizards/leases/?isNew=true&leaseID=NEW&defaultSelect=sublease";
                return "/wizards/leases/commercial/";
            else if (documentID == vacationLeaseDocument)
                return "/wizards/leases/vacation/";
            else
                return "javascript:(new EZLF.DocumentBuilding.Wizard(" + userID + ", " + documentID + ")).StartWizard();";
        }

        /// <summary>
        /// Redirects the user to the document customization wizard needed for this document
        /// </summary>
        /// <param name="documentID"></param>
        public static void GoToDocumentCustomization(int documentID)
        {
            HttpContext.Current.Response.Redirect(GetDocumentCustomizationLink(documentID));
        }

        /// <summary>
        /// Gets the URL for the customization engine for the given document.
        /// </summary>
        /// <param name="documentID">The document's unique database ID.</param>
        /// <returns>A string of HTML.</returns>
        public static string GetDocumentCustomizationLink(int documentID)
        {
            return "/wizards/documents/customize.aspx?document=" + documentID;
        }

        /// <summary>
        /// Gets the ID of the current document's category.
        /// </summary>
        /// <param name="documentID">The unique database ID of the category.</param>
        /// <returns>Returns the ID of the document's category, or -100 if the document was not found.</returns>
        /// <remarks>Does not deal with pseudo-categories.</remarks>
        public static int GetDocumentCategory(int documentID)
        {
            int categoryID = -1;
            string cacheKey = Caching.CacheKeys.DocCategory(documentID);

            if (Caching.CacheExists(cacheKey))
                return (int)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (int)Caching.GetCachedValue(cacheKey);

            using (DB db = new DB())
            {
                db.Query = @"SELECT category FROM Documents WHERE id=:docid";
                db.Param(":docid", documentID);
                categoryID = db.GetValue(-100);
            }

            Caching.AddToCache(cacheKey, categoryID);

            return categoryID;
        }

        /// <summary>
        /// Gets the name of the document whose ID is given.
        /// </summary>
        /// <param name="documentID">
        /// The unique database ID of the document whose name you want to look up.
        /// </param>
        /// <returns>
        /// Returns the name of the document with the given ID, or -1 if no document 
        /// with this ID is found in the database.
        /// </returns>
        public static string GetDocumentName(int documentID)
        {
            string documentName = "";
            string cacheKey = Caching.CacheKeys.DocName(documentID);

            if (Caching.CacheExists(cacheKey))
                return (string)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (string)Caching.GetCachedValue(cacheKey);

            using (DB db = new DB())
            {
                db.Query = @"SELECT d.name FROM Documents d WHERE d.id=:docid";
                db.Param("docid", documentID);
                documentName = db.GetValue(String.Empty);
            }

            Caching.AddToCache(cacheKey, documentName);
            return documentName;
        }


        //public static string GetExistingDocumentFile(UserInfo userInfo, int builtID, int documentID, int leaseID)
        //{
        //    string fileName = String.Empty;
        //    if (Documents.LeaseDocuments.Contains(documentID))
        //    {
        //        if (Leases.LeaseDocumentSamples.Contains(leaseID))
        //            fileName = Shared.getUserDocumentPath(0) + "0-" + leaseID + ".pdf";
        //        else if (documentID == Documents.freeLeaseDocument)
        //            fileName = Shared.getUserDocumentPath(userInfo.ID) + userInfo.ID + "-" + leaseID + "-free.pdf";
        //        else
        //            fileName = Shared.getUserDocumentPath(userInfo.ID) + userInfo.ID + "-" + leaseID + ".pdf";
        //    }
        //    else if (Documents.DocumentIsCustomizable(documentID))
        //        fileName = Shared.getUserDocumentPath(userInfo.ID) + "docs\\" + userInfo.ID + "-" + builtID + ".pdf";
        //    // if this is a static document, get its source file path
        //    else
        //        fileName = Shared.documentsDiskPath + documentID + ".pdf";
        //    string trialPath = String.Empty;
        //    string fileToUse = String.Empty;
        //    bool trialExists = false;

        //    trialPath = fileName.Replace(Shared.getUserDocumentPath(userInfo.ID), Shared.getUserDocumentPath(userInfo.ID, true));
        //    if (File.Exists(trialPath))
        //        trialExists = true;

        //    if (File.Exists(fileName))
        //        fileToUse = fileName;
        //    else if (File.Exists(Shared.getBackupDocumentPath(fileName)))
        //        fileToUse = Shared.getBackupDocumentPath(fileName);

        //    //if (!File.Exists(fileName) && !String.IsNullOrEmpty(fileToUse))
        //    //{
        //    //	try
        //    //	{
        //    //		File.Copy(fileToUse, fileName);
        //    //	}
        //    //	catch { }
        //    //}

        //    if (String.IsNullOrEmpty(fileToUse))
        //        fileToUse = trialPath;
        //    else if (trialExists && File.GetLastWriteTime(trialPath) > File.GetLastWriteTime(fileToUse))
        //        fileToUse = trialPath;
        //    return fileToUse;
        //}

        /// <summary>
        /// Gets the title of a category from its ID.
        /// </summary>
        /// <param name="categoryID">
        /// The unique database ID of a category, or the ID of a pseudo-category (the 
        /// value of its Documents.PseudoCategories label).
        /// </param>
        /// <returns>
        /// Returns the title of the category for this ID number, 
        /// or a reference to the empty string if the category was not found.
        /// </returns>
        //public static string GetCategoryTitle(int categoryID, UserInfo userInfo)
        //{
        //    if (categoryID == (int)PseudoCategories.AllDocuments)
        //        return "All Documents";
        //    if (categoryID == (int)PseudoCategories.CustomDocuments)
        //        return "My Customized Documents";
        //    if (categoryID == (int)PseudoCategories.FreeDocuments)
        //        return "Free Landlord Forms";
        //    if (categoryID == (int)PseudoCategories.StateSpecific)
        //    {
        //        if (userInfo.IPCountry != "USA" || userInfo.PrimaryCountry != "USA" || userInfo.HasInternationalAddress)
        //            if (userInfo.IPCountry == "Canada" || userInfo.PrimaryCountry == "Canada")
        //                return "Province-Specific Forms";
        //            else
        //                return "Local Forms";
        //        else
        //            return "State-Specific Forms";
        //    }

        //    string categoryTitle = GetCategoryName((DocSections)categoryID, userInfo);
        //    string cacheKey = Caching.CacheKeys.DocCategoryName(categoryID);

        //    if (Caching.CacheExists(cacheKey))
        //        return (string)Caching.GetCachedValue(cacheKey);

        //    if (String.IsNullOrEmpty(categoryTitle))
        //    {
        //        using (DB db = new DB())
        //        {
        //            db.Query = @"SELECT name FROM Categories WHERE id=:catid";
        //            db.Param("catid", categoryID);
        //            categoryTitle = db.GetValue(String.Empty);
        //        }
        //    }

        //    Caching.AddToCache(cacheKey, categoryTitle, DateTime.UtcNow.AddDays(1));

        //    return categoryTitle;
        //}

        /// <summary>
        /// Gets the group for the given category.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static string GetCategoryGroup(int categoryID)
        {
            switch (categoryID)
            {
                case (int)PseudoCategories.AllDocuments:
                case (int)PseudoCategories.CustomDocuments:
                case (int)PseudoCategories.FreeDocuments:
                case (int)PseudoCategories.StateSpecific:
                    return "Miscellaneous";
                case 1:
                    return "Leasing / Move In";
                case 16:
                    return "Applicant Forms";
                case 17:
                    return "Tenant Notices";
                case 18:
                    return "Landlord Tools";
                case 20:
                    return "Moving Out";
                case 21:
                    return "Tenant Notices";
                case 22:
                    return "Leasing / Move In";
                case 23:
                    return "Leasing / Move In";
                case 26:
                    return "Landlord Tools";
                case 32:
                    return "Tenant Notices";
                case 34:
                    return "Leasing / Move In";
            }

            return "All Documents";
        }

        //--------------------------------------------------
        // Gets the directory-safe name for a category
        //
        public static string GetCategoryFolderName(string categoryName)
        {
            if (categoryName.ToLower().Trim() == "rental / lease agreements")
                return "rental-lease-agreements";
            Regex re = new Regex(@"\W");
            return re.Replace(categoryName.ToLower().Replace("&", "and").Replace("/", "and"), "-");
        }

        //---------------------------------------------------------------------------
        // Determines is a specific document is available to the user.  This accounts
        // for the status of the user, and the status of the document.  Use this to
        // handle availability of free documents, etc.
        //public static bool IsDocumentAvailable(int documentID, UserInfo userInfo)
        //{
        //    if (!userInfo.IsLoggedIn())
        //        return false;

        //    if (userInfo.IsFreeMember())
        //        return IsDocumentFree(documentID);

        //    return !IsDocumentInTrialMode(documentID, userInfo);
        //}

        //---------------------------------------------------------------------------
        // Decides if the user gets a document in trial mode or not.
        //
        //public static bool IsDocumentInTrialMode(int documentID, UserInfo userInfo)
        //{
        //    if (documentID == -1)
        //        return false;

        //    if (!userInfo.IsLoggedIn())  // || (userInfo.IsFreeMember() && !userInfo.IsTrial()))
        //        return false;

        //    if (IsDocumentFree(documentID))
        //        return false;

        //    if (userInfo.IsTrial() || userInfo.IsFreeMember() || (LeaseDocuments.Contains(documentID) && userInfo.IsDocOnly()))
        //        return true;

        //    int availability = GetDocAvailability(documentID);
        //    if (availability <= -1)
        //        return false;

        //    if ((int)userInfo.UserAccess < availability)
        //        return true;

        //    return false;
        //}

        /// <summary>
        /// Returns the availability of a provided document as determined in the database
        /// </summary>
        /// <param name="documentID">The document's database ID</param>
        /// <returns>Returns the availability of a provided document as determined in the database. Returns -100 if there is no availability set.</returns>
        public static int GetDocAvailability(int documentID)
        {
            int availability = -100;
            string cacheKey = Caching.CacheKeys.DocAvailability(documentID);

            if (Caching.CacheExists(cacheKey))
                return (int)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (int)Caching.GetCachedValue(cacheKey);

            // Get the document's availability
            using (DB db = new DB())
            {
                db.Query = @"SELECT availability FROM Documents WHERE id=:document";
                db.Param("document", documentID);
                if (db.Read())
                    availability = db.GetValue("availability", -100);
            }

            Caching.AddToCache(cacheKey, availability);

            return availability;
        }

        /// <summary>
        /// Decides if a document is a free document
        /// </summary>
        /// <param name="documentID">The document's database ID</param>
        /// <returns>returns true if the document is free</returns>
        public static bool IsDocumentFree(int documentID)
        {
            if (documentID == -1)
                return false;

            if (GetDocAvailability(documentID) == -1)
                return true;

            return false;
        }
        /// <summary>
        /// Decides if a document is available to $9.99 doc-only accounts
        /// </summary>
        /// <param name="documentID">The document's database ID</param>
        /// <returns>returns true if the document is available to the $9.99 account option</returns>
        public static bool IsDocument999(int documentID)
        {
            if (documentID == -1)
                return false;

            if (GetDocAvailability(documentID) == (int)(Shared.UserAccess.PremierNoLease))
                return true;

            return false;
        }
        /// <summary>
        /// Decides if a document is available to $25 accounts
        /// </summary>
        /// <param name="documentID">The document's database ID</param>
        /// <returns>returns true if the document is available to $25 accounts</returns>
        public static bool IsDocument25(int documentID)
        {
            if (documentID == -1)
                return false;

            int availability = GetDocAvailability(documentID);

            if (availability <= (int)(Shared.UserAccess.Premier) && availability > (int)(Shared.UserAccess.PremierNoLease))
                return true;

            return false;
        }

        /// <summary>
        /// Determines if the document is a public document, or one of the
        /// user's private custom documents.
        /// </summary>
        /// <param name="documentID">The unique database ID of the document to check.</param>
        /// <returns>Returns true if the document is publicly visible, and false otheriwse.</returns>
        public static bool DocumentIsForAllUsers(int documentID)
        {
            bool isForAllUsers = false;
            string cacheKey = Caching.CacheKeys.DocIsForAllUsers(documentID);

            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            using (DB db = new DB())
            {
                db.Query = @"SELECT forAllUsers FROM Documents WHERE id=:document";
                db.Param("document", documentID);
                isForAllUsers = db.GetValue(false);
            }
            Caching.AddToCache(cacheKey, isForAllUsers);

            return isForAllUsers;
        }

        /// <summary>
        /// Determines if the document is a customizable document or a static document
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public static bool DocumentIsCustomizable(int documentID)
        {
            bool isCustomizable = false;
            string cacheKey = Caching.CacheKeys.DocIsCustomizable(documentID);

            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            using (DB db = new DB())
            {
                db.Query = @"SELECT customizable FROM Documents WHERE id=:document";
                db.Param("document", documentID);
                isCustomizable = db.GetValue(false);
            }

            Caching.AddToCache(cacheKey, isCustomizable);

            return isCustomizable;
        }
        /// <summary>
        /// Returns whether or not the selected document is locked as a non-editable PDF
        /// </summary>
        /// <param name="documentID">The document's unique database ID</param>
        /// <returns></returns>
        public static bool isDocumentStatic(int documentID)
        {
            bool isLocked = false;
            string cacheKey = Caching.CacheKeys.DocIsStatic(documentID);

            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            using (DB db = new DB())
            {
                db.Query = @"SELECT pdftype FROM Documents WHERE id=:document";
                db.Param("document", documentID);
                isLocked = db.GetValue("pdftype", Documents.PDFType.FillablePDF) == Documents.PDFType.StaticPDF;
            }

            Caching.AddToCache(cacheKey, isLocked);

            return isLocked;
        }

        /// <summary>
        /// Tells whether a document is an editable document that is editable by the user with the given 
        /// user access.
        /// </summary>
        /// <param name="documentID">The document's unique database ID.</param>
        /// <param name="userAccess">The user access level to check.</param>
        /// <param name="userID">The ID of the user who wants to edit this document, or -1 if this lookup is not for a specific user.</param>
        /// <returns>True if the document is editable at the given user access level.</returns>
        public static bool IsDocumentEditable(int documentID, Shared.UserAccess userAccess, int userID)
        {
            bool isEditable = false;
            int ownerID = -1;
            string cacheKeyIsEditable = Caching.CacheKeys.DocIsEditable(documentID);
            string cacheKeyOwner = Caching.CacheKeys.DocOwner(documentID);

            if (Caching.CacheExists(cacheKeyIsEditable) && Caching.CacheExists(cacheKeyOwner))
            {
                isEditable = (bool)Caching.GetCachedValue(cacheKeyIsEditable);
                ownerID = (int)Caching.GetCachedValue(cacheKeyOwner);
            }
            else
            {
                LoadDocumentCacheValues(documentID);
                if (Caching.CacheExists(cacheKeyIsEditable) && Caching.CacheExists(cacheKeyOwner))
                {
                    isEditable = (bool)Caching.GetCachedValue(cacheKeyIsEditable);
                    ownerID = (int)Caching.GetCachedValue(cacheKeyOwner);
                }
                else
                {
                    using (DB db = new DB())
                    {
                        db.Query = @"SELECT isEditable, userid
						 FROM Documents
						 WHERE id=:document";
                        db.Param("document", documentID);

                        if (db.Read())
                        {
                            isEditable = db.GetValue("isEditable", false);
                            ownerID = db.GetValue("userid", -1);
                        }
                    }

                    Caching.AddToCache(cacheKeyIsEditable, isEditable);
                    Caching.AddToCache(cacheKeyOwner, ownerID);
                }
            }

            if (isEditable && (ownerID == -1 || (ownerID > 0 && ownerID != userID)))
                isEditable = Shared.IsPremiumMembershipType(userAccess) || userAccess == Shared.UserAccess.Admin;

            return isEditable;
        }

        /// <summary>
        /// Tells whether a document is an email-able document.
        /// </summary>
        /// <param name="documentID">The document's unique database ID.</param>
        /// <returns>True if the document is emailable.</returns>
        public static bool IsDocumentEmailable(int documentID)
        {
            bool isEmailable = false;
            string cacheKey = Caching.CacheKeys.DocIsEmailable(documentID);

            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (bool)Caching.GetCachedValue(cacheKey);

            using (DB db = new DB())
            {
                db.Query = @"SELECT isEmailable FROM Documents WHERE id=:document";
                db.Param("document", documentID);

                if (db.Read())
                    isEmailable = db.GetValue("isEmailable", false);
            }

            Caching.AddToCache(cacheKey, isEmailable);

            return isEmailable;
        }

        /// <summary>
        /// Tells whether a document is visible or not.
        /// </summary>
        /// <param name="documentID">The document's unique database ID.</param>
        /// <returns>The status of the document.</returns>
        public static Shared.Status GetDocumentStatus(int documentID)
        {
            Shared.Status status = Shared.Status.Inactive;
            string cacheKey = Caching.CacheKeys.DocStatus(documentID);

            if (Caching.CacheExists(cacheKey))
                return (Shared.Status)Caching.GetCachedValue(cacheKey);

            LoadDocumentCacheValues(documentID);
            if (Caching.CacheExists(cacheKey))
                return (Shared.Status)Caching.GetCachedValue(cacheKey);

            using (DB db = new DB())
            {
                db.Query = @"SELECT status FROM Documents WHERE id=:document";
                db.Param("document", documentID);

                if (db.Read())
                    status = db.GetValue("status", Shared.Status.Inactive);
            }

            Caching.AddToCache(cacheKey, status);

            return status;
        }

        public static void LoadDocumentCacheValues(int documentID)
        {
            using (DB db = new DB())
            {
                db.Query = @"SELECT category, name, availability, forAllUsers, customizable, pdftype, isEditable, userid, isEmailable, status
							FROM Documents WHERE id=:docid";
                db.Param(":docid", documentID);

                if (db.Read())
                {
                    Caching.AddToCache(Caching.CacheKeys.DocCategory(documentID), db.GetValue("category", -100));
                    Caching.AddToCache(Caching.CacheKeys.DocName(documentID), db.GetValue("name", String.Empty));
                    Caching.AddToCache(Caching.CacheKeys.DocAvailability(documentID), db.GetValue("availability", -100));
                    Caching.AddToCache(Caching.CacheKeys.DocIsForAllUsers(documentID), db.GetValue("forAllUsers", false));
                    Caching.AddToCache(Caching.CacheKeys.DocIsCustomizable(documentID), db.GetValue("customizable", false));
                    Caching.AddToCache(Caching.CacheKeys.DocIsStatic(documentID), db.GetValue("pdftype", Documents.PDFType.FillablePDF) == Documents.PDFType.StaticPDF);
                    Caching.AddToCache(Caching.CacheKeys.DocIsEditable(documentID), db.GetValue("isEditable", false));
                    Caching.AddToCache(Caching.CacheKeys.DocOwner(documentID), db.GetValue("userid", -1));
                    Caching.AddToCache(Caching.CacheKeys.DocIsEmailable(documentID), db.GetValue("isEmailable", false));
                    Caching.AddToCache(Caching.CacheKeys.DocStatus(documentID), db.GetValue("status", Shared.Status.Active));
                }
            }
        }

        /// <summary>
        /// Streams a static document to the user after watermarking it.
        /// </summary>
        /// <param name="docID">The document's unique database ID.</param>
       // public static void StreamStaticDocument(UserInfo userInfo, int docID)
       // {
       //     string outputFileName = Shared.downloadDocsDiskPath + userInfo.ID + "-" + DateTime.Now.Ticks + "STATIC.pdf";

       //     bool isStatic = false;
       //     using (DB db = new DB())
       //     {
       //         db.Query = @"SELECT pdftype FROM Documents WHERE id=:id";
       //         db.Param("id", docID);
       //         if (db.Read())
       //         {
       //             isStatic = db.GetValue("pdftype", Documents.PDFType.FillablePDF) == Documents.PDFType.StaticPDF;
       //         }
       //     }

       //     if (!(staticPDFs.Contains(docID) || isStatic))
       //     {
       //         // do we need watermark?
       //         bool useWatermark = userInfo.IsTrial();

       //         if (!useWatermark)
       //         {
       //             int availability = GetDocAvailability(docID);

       //             if ((int)userInfo.UserAccess < availability)
       //                 useWatermark = true;
       //         }

       //         if (useWatermark && Documents.IsDocumentFree(docID))
       //             useWatermark = false;

       //         try
       //         {
       //             Documents.documentPostProcessing(Shared.documentsDiskPath + docID + ".pdf", outputFileName, useWatermark);
       //         }
       //         catch
       //         {
       //             File.Copy(Shared.documentsDiskPath + docID + ".pdf", outputFileName, true);
       //         }
       //         Documents.streamFile(outputFileName, Documents.GetDocumentName(docID), docID, false, !useWatermark, !useWatermark);
       //     }
       //     else
       //     {
       //         File.Copy(Shared.documentsDiskPath + docID + ".pdf", outputFileName, true);
       //         Documents.streamFile(outputFileName, Documents.GetDocumentName(docID), docID, true, true, true, DateTime.MaxValue);
       //     }


       // }

       //// /// <summary>
       // /// Figures out if the user has documents waiting to be printed.
       // /// </summary>
       // /// <returns>True if the user has documents waiting to print, which are from within the last 48 hours; false otherwise.</returns>
       // public static bool HasDocumentsToPrint(UserInfo userInfo)
       // {
       //     if (!userInfo.IsLoggedIn())
       //         return false;

       //     bool hasDocsToPrint = false;
       //     using (DB db = new DB())
       //     {
       //         db.Query = @"SELECT
							//COUNT(DISTINCT id)
						 //FROM
							//BuiltDocuments built
						 //WHERE
							//userid=:userid
							//AND created >= (sysdate - 2)
							//AND printing=1
							//AND isprinted=0
							//AND status=:active
							//AND built.latest=1
							//AND
							//(
							//	( built.islease=0 AND built.document != :freeLease)
							//	OR (built.islease=1)
							//)";

       //         db.Param("userid", userInfo.ID);
       //         //db.Param("resLease", Documents.residentialLeaseDocument);
       //         db.Param("freeLease", Documents.freeLeaseDocument);
       //         //db.Param("storLease", Documents.storageLeaseDocument);
       //         //db.Param("subLease", Documents.residentialSubLeaseDocument);
       //         db.Param("active", Shared.Status.Active);

       //         hasDocsToPrint = db.GetValue(0) > 0;
       //     }

       //     return hasDocsToPrint;
       // }

        /// <summary>
        /// Gets the tag to include this document's auto-generated preview image with the ability to 
        /// </summary>
        /// <param name="documentID">The unique database ID of the document.</param>
        /// <param name="documentName">The human-readable name for this document.</param>
        /// <param name="havePreview">Should we use the auto-generated document preview?  If not, the specified icon will be used instead.</param>
        /// <param name="icon">The icon to use for this document if an auto-generated document image is ot available.</param>
        /// <param name="isEditable">Is this document user editable?  If it is, the editable icon will be substituted for an auto-generated image.</param>
        /// <param name="extraHeaderHtml">A string of extra HTML to include above the large sample image when it is being displayed.</param>
        /// <param name="imageSize">The size of auto-generated image to display.</param>
        /// <returns>A string of HTML.</returns>
        //public static string GetDocumentImage(string documentID, string documentName, bool havePreview, string icon, bool isEditable,
        //                                        bool isStateSpecific, string extraHeaderHtml, Documents.ImageSize imageSize)
        //{
        //    StringBuilder html = new StringBuilder();
        //    string imageTag = Documents.GetDocumentPreviewNew(documentID, documentName, havePreview, icon, imageSize, isEditable, isStateSpecific);
        //    bool zoomable = (
        //                        havePreview &&
        //                        !Documents.LeaseDocuments.Contains(Parser.Parse(documentID, -1)) &&
        //                        File.Exists(Shared.samplesDiskPath + documentID + ".gif")
        //                    );

        //    if (zoomable)
        //    {
        //        //onMouseOver=\"showPreviewImage(this, {0}, 'left');\" onMouseOut=\"hidePreviewImage();\"
        //        int _num_pics = MaxPreviewPicNum(documentID);
        //        html.Append(@"<div ");

        //        if (imageSize == Documents.ImageSize.Large)
        //            html.Append(@"style=""background-image: url(//ezlf-plinersolutionsi.netdna-ssl.com/images/zoom-bg.gif);background-position: top right;background-repeat: no-repeat; text-align:center;position:relative; cursor:pointer; border-right:1px solid #C4D2EC;"" ");
        //        else if (imageSize == Documents.ImageSize.Small)
        //            html.Append(@"style=""margin:0 auto;padding:0;border-right:1px solid #C4D2EC;text-align:center;float:left;clear:both;background-image: url(//ezlf-plinersolutionsi.netdna-ssl.com/images/small_zoom-bg.gif);background-position: top right;background-repeat: no-repeat;position:relative; cursor:pointer;"" ");

        //        html.AppendFormat(@"id=""containerFor{0}"" onClick=""togglePreviewImage(this, {0}, 'left', " + ((!String.IsNullOrEmpty(extraHeaderHtml)) ? ("'" + extraHeaderHtml + "'") : "null") + @", " + _num_pics + @", 1);"">", documentID);
        //    }

        //    html.Append(imageTag);

        //    if (zoomable)
        //    {
        //        if (imageSize == Documents.ImageSize.Large)
        //            html.Append("<img style='position:relative;' src='//ezlf-plinersolutionsi.netdna-ssl.com/images/zoom_sidebar.gif' alt='Larger Preview' />");
        //        else if (imageSize == Documents.ImageSize.Small)
        //            html.Append(@"<img src=""//ezlf-plinersolutionsi.netdna-ssl.com/images/small_zoom_sidebar.gif"" width=""10"" height=""50"" alt=""Larger Preview"" />");

        //        html.Append("</div>");
        //    }

        //    return html.ToString();
        //}

        /// <summary>
        /// Handles showing the document thumbnail image for
        /// the current type of document
        /// </summary>
        /// <param name="documentID">The unique database ID of the document.</param>
        /// <returns>The number of large sample photos uploaded for this document.</returns>
        public static int MaxPreviewPicNum(string documentID)
        {
            if (!System.IO.File.Exists(Shared.samplesDiskPath + documentID + ".gif"))
                return 0;
            for (int i = 1; i < 10000; i++)
            {
                string _fn = Shared.samplesDiskPath + documentID + "-" + i + ".gif";
                if (!System.IO.File.Exists(_fn))
                {
                    return i;
                }
            }
            return 10001;
        }

        /// <summary>
        /// Sets the created document with the given created documents log ID as having 
        /// been downloaded for printing, so that the user is no longer notified to download 
        /// this document for printing.
        /// </summary>
        /// <param name="builtID">The unique database created documents log ID for this customized document file.</param>
        public static void MarkDocumentAsPrinted(int builtID)
        {
            using (DB db = new DB())
            {
                db.Query = "UPDATE BuiltDocuments SET isPrinted=:yes WHERE id=:builtId";
                db.Param("yes", true);
                db.Param("builtId", builtID);

                db.RunNonQuery();
            }
        }

        /// <summary>
        /// Sets the created document for the given lease ID as having been downloaded for printing, 
        /// so that the user is no longer notified to download this lease for printing.
        /// </summary>
        /// <param name="leaseID">The unique database ID for this lease.</param>
        /// <param name="documentID">The type of document for this lease to mark as printed.</param>
        public static void MarkLeaseAsPrinted(int userID, int leaseID, int documentID)
        {
            using (DB db = new DB())
            {
                db.Query = @"UPDATE BuiltDocuments
						 SET
							isPrinted=:yes
						 WHERE
							lease=:lease AND document=:document AND userid=:userid";

                db.Param("yes", true);
                db.Param("userid", userID);
                db.Param("lease", leaseID);
                db.Param("document", documentID);

                db.RunNonQuery();
            }
        }

        /// <summary>
        /// Gets the number of documents in a given category for a given user, in a given state.
        /// </summary>
        /// <param name="categoryID">The documents category to check.</param>
        /// <param name="userID">The ID of the user whose categorized custom documents we want to include, or -1 to include no custom documents.</param>
        /// <param name="state">The state to filter state-specific documents for, or null to display no state-specific documents.</param>
        /// <param name="db">The database connection to use for the lookup.</param>
        /// <returns>Returns the number of documents in the given category, with the given filters.</returns>
        public static int GetNumOfDocumentsInCategory(int categoryID, int userID, string state, DB db)
        {
            System.Collections.Generic.List<string> states = new System.Collections.Generic.List<string>();

            if (!String.IsNullOrEmpty(state))
                states.Add(state);

            return GetNumOfDocumentsInCategory(categoryID, userID, states.ToArray(), db);
        }

        /// <summary>
        /// Gets the number of documents in a given category for a given user, in a given state.
        /// </summary>
        /// <param name="categoryID">The documents category to check.</param>
        /// <param name="userID">The ID of the user whose categorized custom documents we want to include, or -1 to include no custom documents.</param>
        /// <param name="states">The states to filter state-specific documents for, or null to display no state-specific documents.</param>
        /// <param name="db">The database connection to use for the lookup.</param>
        /// <returns>Returns the number of documents in the given category, with the given filters.</returns>
        public static int GetNumOfDocumentsInCategory(int categoryID, int userID, string[] states, DB db)
        {
            if (categoryID == (int)PseudoCategories.CustomDocuments)
                return GetTotalNumOfCustomDocuments(userID, db);
            else if (categoryID == (int)PseudoCategories.FreeDocuments)
                return GetTotalNumOfFreeDocuments(states, db);
            else if (categoryID == (int)PseudoCategories.StateSpecific)
                return GetTotalNumOfStateSpecificDocuments(states, db);

            int numOfDocuments = 0;
            db.Reset();  // just in case

            db.Query = @"SELECT COUNT(1) 
						 FROM Documents 
						 WHERE category=:category AND status=:active AND (forallusers=:yes OR userid=:userid) ";

            db.Param("category", categoryID);
            db.Param("active", Shared.Status.Active);
            db.Param("yes", true);
            db.Param("userid", userID);

            if (states != null && states.Length > 0)
            {
                db.Query += " AND (states IS NULL OR LENGTH(states)<=1 ";
                for (int s = 0; s < states.Length; s++)
                {
                    db.Query += " OR INSTR(states, :statestring" + s + ")>0";
                    db.Param("statestring" + s, states[s]);
                }
                db.Query += ")";
            }


            /* replaced this logic so that we can use multiple states
			if (!String.IsNullOrEmpty(state))
				db.Param("statestring", "," + state);
			else
				db.Param("statestring", "WONT_FIND_THIS");   // if they have no state set, this means they won't match any state-specific documents (as this isn't a state)
			*/

            numOfDocuments = db.GetValue(0);
            db.Reset();

            return numOfDocuments;
        }

        /// <summary>
        /// Gets the total number of free documents available to users.
        /// </summary>
        /// <param name="states">The states to filter state-specific documents for, or null to display no state-specific documents.</param>
        /// <param name="db">The database connection to use for the lookup.</param>
        /// <returns>Returns the total number of free documents available to users.</returns>
        private static int GetTotalNumOfFreeDocuments(string[] states, DB db)
        {
            int numOfDocuments = 0;
            db.Reset();  // just in case

            db.Query = @"SELECT
							COUNT(1)
						 FROM
							Documents
						 WHERE
							status=:active AND availability=:free ";

            if (states != null && states.Length > 0)
            {
                db.Query += " AND (states IS NULL OR LENGTH(states)<=1 ";
                for (int s = 0; s < states.Length; s++)
                {
                    db.Query += " OR INSTR(states, :statestring" + s + ")>0";
                    db.Param("statestring" + s, states[s]);
                }
                db.Query += " )";
            }


            db.Param("active", (int)Shared.Status.Active);
            db.Param("free", -1);

            numOfDocuments = db.GetValue(0);
            db.Reset();

            return numOfDocuments;
        }

        /// <summary>
        /// Gets the total number of custom documents the user has created.
        /// </summary>
        /// <param name="userID">The ID number of the user whose custom documents we want to count.</param>
        /// <param name="db">The database connection to use for the lookup.</param>
        /// <returns>Returns the total number of custom documents the user has created.</returns>
        private static int GetTotalNumOfCustomDocuments(int userID, DB db)
        {
            int numOfDocuments = 0;
            db.Reset();  // just in case

            db.Query = @"SELECT
							COUNT(1)
						 FROM
							Documents
						 WHERE
							status=:active AND forAllUsers=:no AND userid=:userid";

            db.Param("active", Shared.Status.Active);
            db.Param("no", false);
            db.Param("userid", userID);

            numOfDocuments = db.GetValue(0);
            db.Reset();

            return numOfDocuments;
        }

        /// <summary>
        /// Gets the total number of state-specific documents
        /// </summary>
        /// <param name="userID">The ID number of the user whose custom documents we want to count.</param>
        /// <param name="db">The database connection to use for the lookup.</param>
        /// <returns>Returns the total number of custom documents the user has created.</returns>
        private static int GetTotalNumOfStateSpecificDocuments(string[] states, DB db)
        {
            int numOfDocuments = 0;
            db.Reset();  // just in case

            db.Query = @"SELECT
							COUNT(1)
						 FROM
							Documents
						 WHERE
							status=:active AND 
							(id = 100 ";

            if (states != null && states.Length > 0)
            {
                for (int s = 0; s < states.Length; s++)
                {
                    db.Query += " OR INSTR(states, :statestring" + s + ")>0";
                    db.Param("statestring" + s, states[s]);
                }
            }
            else
            {
                db.Query += " OR LENGTH(states) > 0";
            }

            db.Query += ")";

            db.Param("active", (int)Shared.Status.Active);

            numOfDocuments = db.GetValue(0);
            db.Reset();

            return numOfDocuments;
        }

     //   /// <summary>
     //   /// Loads the features icons settings for this document.
     //   /// </summary>
     //   /// <param name="userInfo">The user's state collection.</param>
     //   /// <param name="documentID">The ID number of the document to get the features icons for.</param>
     //   /// <param name="isEditable">Tells whether the document is editable.</param>
     //   /// <param name="isStateSpecific">Tells whether the document is state-specific.</param>
     //   /// <returns>Returns a dictionary of the features for this document.</returns>
     //   public static Dictionary<string, object> LoadDocumentFeatures(UserInfo userInfo, int documentID, bool isEditable, bool isStateSpecific)
     //   {
     //       string[] states = StateSelection.GetAllStates(userInfo);
     //       string stateQuery = String.Empty;
     //       string cacheKey = Caching.CacheKeys.DocFeaturesIcons(documentID);

     //       if (Caching.CacheExists(cacheKey))
     //           return (Dictionary<string, object>)Caching.GetCachedValue(cacheKey);

     //       Dictionary<string, object> iconsSettings = new Dictionary<string, object>();

     //       iconsSettings.Add("isAutoFill", false);
     //       iconsSettings.Add("worksWithWindowEnv", false);
     //       iconsSettings.Add("isEmailable", false);
     //       iconsSettings.Add("usesCustomLogo", false);
     //       iconsSettings.Add("hasWizard", false);
     //       iconsSettings.Add("hasStateAssist", false);
     //       iconsSettings.Add("numberOfPages", 0);

     //       using (DB db = new DB())
     //       {
     //           db.Query = @"
					//SELECT 
					//	f.autoFill, f.windowEnv, d.isEmailable, f.customLogo, f.pages
					//FROM 
					//	Documents d, DocumentFeatures f 
					//WHERE 
					//	d.id=:document AND f.document=:document";
     //           db.Param("document", documentID);

     //           if (db.Read())
     //           {
     //               iconsSettings["isAutoFill"] = db.GetValue("autoFill", false);
     //               iconsSettings["worksWithWindowEnv"] = db.GetValue("windowEnv", false);
     //               iconsSettings["isEmailable"] = db.GetValue("isEmailable", false);
     //               iconsSettings["usesCustomLogo"] = db.GetValue("customLogo", false);
     //               iconsSettings["numberOfPages"] = db.GetValue("pages", 0);
     //           }
     //           else if (!Documents.DocumentIsForAllUsers(documentID))
     //           {
     //               iconsSettings["isAutoFill"] = true;
     //               iconsSettings["worksWithWindowEnv"] = true;
     //               iconsSettings["isEmailable"] = true;
     //               iconsSettings["usesCustomLogo"] = true;
     //           }

     //           if (Documents.LeaseDocuments.Contains(documentID))
     //               iconsSettings["hasWizard"] = true;

     //           db.Reset();

     //           if (Documents.LeaseDocuments.Contains(documentID))
     //           {
     //               iconsSettings["hasStateAssist"] = true;
     //           }
     //           else
     //           {
     //               for (int s = 0; s < states.Length; s++)
     //               {
     //                   if (!String.IsNullOrEmpty(stateQuery))
     //                       stateQuery += ",";
     //                   stateQuery += ":state" + s;

     //                   db.Param("state" + s, states[s]);
     //               }

     //               if (!String.IsNullOrEmpty(stateQuery))
     //                   stateQuery = " state IN(" + stateQuery + ") AND ";

     //               db.Query = @"SELECT COUNT(1) FROM StateLaws WHERE header=:header AND " + stateQuery + @" text IS NOT NULL AND NVL(LENGTH(text),0)>0";
     //               db.Param("header", documentID + 1000000);

     //               iconsSettings["hasStateAssist"] = db.GetValue(0) > 0;
     //               db.Reset();
     //           }

     //           if (isEditable)
     //           {
     //               db.Query = "SELECT cd.template FROM CustomDocuments cd WHERE id=:documentId";
     //               db.Param("documentId", documentID);

     //               if (db.Read())
     //               {
     //                   if (db.GetValue("template", 1) == 0) // blank template
     //                   {
     //                       iconsSettings["worksWithWindowEnv"] = false;
     //                       iconsSettings["usesCustomLogo"] = false;
     //                   }
     //                   else // mailable template
     //                   {
     //                       iconsSettings["worksWithWindowEnv"] = true;
     //                       iconsSettings["usesCustomLogo"] = true;
     //                   }
     //               }
     //               // TODO check the template used to determine window envelope / custom logo features
     //           }
     //       }

     //       Caching.AddToCache(cacheKey, iconsSettings);

     //       return iconsSettings;
     //   }

        public class DocPreviewImage
        {
            public string ImageURL = "";
            public string ImageDiskPath = "";
            public bool IsRetina = false;

            public DocPreviewImage(string imageURL)
            {
                ImageURL = imageURL;
            }
        }

        /// <summary>
        /// Gets the list of preview image files available for the given document.
        /// </summary>
        /// <param name="documentID">The unique database ID of the document to get the preview images for.</param>
        /// <returns>
        /// Returns an array of URLs of preview images for this document, or a 0-length array 
        /// if there are no preview images or if the document ID is invalid.
        /// </returns>
        public static DocPreviewImage[] GetDocumentPreviewImages(int documentID)
        {
            int imageIndex = 0;
            bool imageFound = true;
            List<DocPreviewImage> docPreviewImages = new List<DocPreviewImage>();
            DocPreviewImage[] returnVal = docPreviewImages.ToArray();

            string previewImagesCacheKey = Caching.CacheKeys.DocPreviewImages(documentID);
            if (Caching.CacheExists(previewImagesCacheKey))
                returnVal = (DocPreviewImage[])Caching.GetCachedValue(previewImagesCacheKey);
            else
            {

                while (imageFound)
                {
                    string imagePath, imageUrl, formatString;

                    if (imageIndex == 0)
                        formatString = "{0}{1}.gif";
                    else
                        formatString = "{0}{1}-{2}.gif";

                    imagePath = String.Format(formatString, Shared.samplesDiskPath, documentID, imageIndex);
                    imageUrl = String.Format(formatString, Shared.samplesWebPath, documentID, imageIndex);
                    imageFound = File.Exists(imagePath);


                    if (imageFound)
                    {
                        long versionNumber = -1;
                        string versionCacheKey = Caching.CacheKeys.DocPreviewMod(documentID, imageIndex);
                        if (Caching.CacheExists(versionCacheKey))
                            versionNumber = (long)Caching.GetCachedValue(versionCacheKey);
                        else
                        {
                            try
                            {
                                FileInfo fi = new FileInfo(imagePath);
                                if (fi.LastWriteTime < DateTime.Now.AddDays(-10))//CDN Caches files for 7 days
                                    versionNumber = -1;
                                else
                                    versionNumber = fi.LastWriteTime.Ticks % 1000000;
                            }
                            catch { }
                            Caching.AddToCache(versionCacheKey, versionNumber, 24);
                        }
                        imageUrl = Shared.CDNUrl + imageUrl + (versionNumber > 0 ? "?v=" + versionNumber : String.Empty);
                        DocPreviewImage previewImage = new DocPreviewImage(imageUrl);
                        previewImage.ImageDiskPath = imagePath;

                        bool retinaExists = true;
                        string retinaCacheKey = Caching.CacheKeys.DocPreviewRetina(documentID, imageIndex);
                        if (Caching.CacheExists(retinaCacheKey))
                            retinaExists = (bool)Caching.GetCachedValue(retinaCacheKey);
                        else
                        {
                            //Check for Retina Image

                            Thread t = new Thread(
                            new ThreadStart(delegate ()
                            {
                                retinaExists = File.Exists(imagePath.Replace(".gif", "@2x.gif"));
                            })
                            );
                            t.Start();
                            bool completed = t.Join(500);
                            if (!completed)
                            {
                                retinaExists = false;
                                t.Abort();
                            }
                            Caching.AddToCache(retinaCacheKey, retinaExists, 24);
                        }
                        previewImage.IsRetina = retinaExists;
                        docPreviewImages.Add(previewImage);
                    }

                    imageIndex++;
                }

                string maxNumCacheKey = Caching.CacheKeys.DocPreviewMaxNum(documentID);
                if (!Caching.CacheExists(maxNumCacheKey))
                {
                    Caching.AddToCache(maxNumCacheKey, imageIndex, 24);
                }
                returnVal = docPreviewImages.ToArray();
                Caching.AddToCache(previewImagesCacheKey, returnVal, 24);
            }

            return returnVal;
        }

        public static JArray GetDocumentPreviewImagesJArray(int documentID)
        {
            JArray previews = new JArray();
            foreach (DocPreviewImage dpi in GetDocumentPreviewImages(documentID))
            {
                JObject previewImage = new JObject();
                previewImage.Add("ImageURL", dpi.ImageURL);
                previewImage.Add("IsRetina", dpi.IsRetina);
                previews.Add(previewImage);
            }
            return previews;
        }

        public static void ClearDocumentPreviewImageCache(int documentID)
        {
            string previewImagesCacheKey = Caching.CacheKeys.DocPreviewImages(documentID);
            Caching.RemoveFromCache(previewImagesCacheKey);

            string maxNumCacheKey = Caching.CacheKeys.DocPreviewMaxNum(documentID);
            if (Caching.CacheExists(maxNumCacheKey))
            {
                int previewImageCount = (int)Caching.GetCachedValue(maxNumCacheKey);
                for (var i = 0; i < previewImageCount; i++)
                {
                    string versionCacheKey = Caching.CacheKeys.DocPreviewMod(documentID, i);
                    Caching.RemoveFromCache(versionCacheKey);
                    string retinaCacheKey = Caching.CacheKeys.DocPreviewRetina(documentID, i);
                    Caching.RemoveFromCache(retinaCacheKey);
                }
                Caching.RemoveFromCache(maxNumCacheKey);
            }

        }
    }
}