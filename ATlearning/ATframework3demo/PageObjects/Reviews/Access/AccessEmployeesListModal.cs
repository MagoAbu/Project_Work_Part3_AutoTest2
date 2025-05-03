using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.Reviews.Access
{
    public class AccessEmployeesListModal
    {
        WebItem EmployeesAndDepartmentsTab => new WebItem("//a[@class='bx-finder-box-tab bx-lm-tab-last ']", 
            "Вкладка Сотрудники и отделы в окне выбора сотрудников");

        public AccessEmployeesAndDepartmentsListPage OpenEmployeesAndDepartmentsTab()
        {
            EmployeesAndDepartmentsTab.Click();
            return new AccessEmployeesAndDepartmentsListPage();
        }
    }
}
