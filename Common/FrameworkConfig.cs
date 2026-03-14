using saucedemo_ui_automation.Common;
using saucedemo_ui_automation.Helpers;
using saucedemo_ui_automation.Models;

namespace saucedemo_ui_automation.Constants
{
    public static class FrameworkConfig
    {
        private static readonly EnvSettings _settings =
            TestDataHelper.LoadObjectFromJson<EnvSettings>(TestDataPaths.Config);

        public static readonly string BaseUrl = _settings.BaseUrl!;
        public static readonly BrowserType Browser = Enum.Parse<BrowserType>(_settings.Browser!, true);
        public static readonly bool HeadlessMode = _settings.HeadlessMode;
    }
}