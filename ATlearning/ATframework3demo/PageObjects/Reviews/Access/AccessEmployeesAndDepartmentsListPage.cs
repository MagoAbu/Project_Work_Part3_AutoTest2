using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.Reviews.Access
{
    public class AccessEmployeesAndDepartmentsListPage
    {

        WebItem WindowCloseIcon => new WebItem($"//span[@class='popup-window-close-icon']",
            "Иконка закрытия окна со списком сотрудников и отделов");

        public AccessBasePage ChooseManager(User testManager)
        {
            WebItem ManagerOnTheList = new WebItem($"//div[@class='bx-finder-company-department-employee-name' and text()='{testManager.NameLastName}']", 
                "Добавленый менеджер в списке сотрудников");
            ManagerOnTheList.Click();
            return new AccessBasePage();
        }
    }
}
