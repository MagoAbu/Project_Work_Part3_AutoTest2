
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class SettingsMenuEditItemWindow
    {
        WebItem ItemTitle => new WebItem("//input[@id='menuPageToFavoriteName']", 
            "Поле ввода названия пункта меню");

        WebItem ItemLink => new WebItem("//input[@id='menuPageToFavoriteLink']",
            "Поле ввода ссылки пункта меню");
        
        WebItem CheckBox => new WebItem("//input[@id='menuOpenInNewPage']",
            "Чекбокс открытия пункта меню в новой вкладке");
        
        WebItem SaveBtn => new WebItem("//button[@class='ui-btn ui-btn-success']",
            "Кнопка Сохранить окна редактирования пункта меню");
        public PortalLeftMenu EditMenuItem()
        {
            ItemTitle.SendKeys("Отзывы");
            ItemLink.SendKeys("/feedback/");
            CheckBox.Click();
            SaveBtn.Click();
            return new PortalLeftMenu();
        }
    }
}
