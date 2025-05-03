
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Reviews.Access
{
    public class AccessBasePage
    {

        WebItem AddBtn => new WebItem("//span[@id='ui-tile-selector-manager_permission_selector']" +
            "/descendant::span[@class='ui-tile-selector-select-container']",
            "Кнопка Добавить в поле Менеджеры");

        public AccessEmployeesListModal ClickAddButton()
        {
            AddBtn.Click();
            return new AccessEmployeesListModal();
        }

        WebItem ApplyBtn => new WebItem("//input[@class='submit-btn ui-btn ui-btn-md ui-btn-primary']",
            "Кнопка Применить на странице Доступ");

        public AccessBasePage ApplyChanges()
        {
            ApplyBtn.Click();
            return new AccessBasePage();
        }
    }
}
