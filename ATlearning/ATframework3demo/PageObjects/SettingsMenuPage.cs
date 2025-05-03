
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class SettingsMenuPage
    {
        WebItem AddlinkItem => new WebItem("//span[@class='menu-popup-item-text' and text()='Добавить ссылку в меню']", 
            "Вкладка Добавить ссылку в меню в окне настроек меню");

        public SettingsMenuEditItemWindow AddLinkToMenu()
        {
            AddlinkItem.Click();
            return new SettingsMenuEditItemWindow();
        }
    }
}
