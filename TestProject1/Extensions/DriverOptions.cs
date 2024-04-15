using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Extensions
{
    public static class DriverOptionsExtensions
    {
        public static void AddHeadlessArgument(this ChromeOptions options)
        {
            const string ChromeHeadlessArg = "headless";
            AddConditionalHeadlessArgument(() => options.AddArgument(ChromeHeadlessArg));
        }

        private static void AddConditionalHeadlessArgument(Action addArgument)
        {
            if (HeadlessBrowserTestsEnabled())
                addArgument();
        }

        private static bool HeadlessBrowserTestsEnabled()
        {
            var headlessEnvVar = Environment.GetEnvironmentVariable("HeadlessBrowserTests");
            bool.TryParse(headlessEnvVar, out var headless);
            return headless;
        }
    }
}
