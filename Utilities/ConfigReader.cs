using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TestingDME.Utilities
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot config;

        static ConfigReader()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public static string Url => config["app:url"];
        public static string Username => config["credentials:username"];
        public static string Password => config["credentials:password"];
        public static string PrescriberName => config["testdata:prescriberName"];
        public static string NPI => config["testdata:npi"];
        public static string OrgName => config["testdata:organization"];

        // Patient Data
        public static string PFirstName => config["testdata:patient:firstName"];
        public static string PLastName => config["testdata:patient:lastName"];
        public static string PDOB => config["testdata:patient:dob"];
        public static string PGender => config["testdata:patient:gender"];
        public static string PPhone => config["testdata:patient:phone"];
        public static string PAddress => config["testdata:patient:address"];
        public static string PCity => config["testdata:patient:city"];
        public static string PState => config["testdata:patient:state"];
        public static string PZip => config["testdata:patient:zip"];

        // Order Data
        public static string Insurance => config["testdata:order:insurance"];
        public static string PlanType => config["testdata:order:planType"];
        public static string MemberId => config["testdata:order:memberId"];
        public static string Category => config["testdata:order:category"];
    }
}