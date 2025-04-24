
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestCases.ProjectWorkPart3.Manager;

namespace ATframework3demo.PageObjects.Reviews
{
    public class ReviewsBasePage
    {
        WebItem ManagersItem => new WebItem("//a[contains(@href, '/feedback/managers/')]", 
            "Вкладка 'Менеджеры' в хедере страницы 'Отзывы'");

        public ManagersListPage GoToManagers()
        {
            ManagersItem.Click();
            return new ManagersListPage();
        }
    }
}
