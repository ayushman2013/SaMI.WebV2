using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SaMI.Web
{
    public class AppSettings
    {
        public static string GetUserSessionName()
        {
            return ConfigurationManager.AppSettings.Get("UserSession").ToString();
        }

        public static string GetBaseURL()
        {
            return ConfigurationManager.AppSettings.Get("BaseURL").ToString();
        }

        public static string GetCMSAdminURL()
        {
            return ConfigurationManager.AppSettings.Get("CMSAdminURL").ToString();
        }

        public static string GetBannerImageUploadDir()
        {
            return ConfigurationManager.AppSettings.Get("BannerImageUploadDir").ToString();
        }

        public static string GetBannerImageDir()
        {
            return ConfigurationManager.AppSettings.Get("BannerImageDir").ToString();
        }

        public static String GetCMSAdminConnStrName()
        {
            return "ConnectionStringIntra";
        }

        public static String GetPublicConnStrName()
        {
            return "ConnectionStringPublic";
        }

        public static String GetConnStrName()
        {
            return "ConnectionString";
        }

        public static string GetResourceUploadDir()
        {
            return ConfigurationManager.AppSettings.Get("ResourceUploadDir").ToString();
        }

        public static string GetResourceDir()
        {
            return ConfigurationManager.AppSettings.Get("ResourceDir").ToString();
        }
    }
}