
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.TasksAndProjects;

namespace ATframework3demo.PageObjects.Reviews
{
    public class ReviewDetailPage
    {
        WebItem ReviewDetailPageFrame => new WebItem("//iframe[contains(@src, '/feedback/detail/1/')]",
            "Фрейм детальной карточки отзыва");

        WebItem AttachReviewToManagerBtn => new WebItem("//span[@class='ui-btn-text']",
            "Кнопка 'Прикрепить отзыв к менеджеру'");

        WebItem OpenLinkedTaskBtn => new WebItem("//span[@class='ui-btn-text' and text()='Открыть привязанную задачу']",
            "Кнопка 'Открыть привязанную задачу'");
        //iframe[contains(@src, '/workgroups/group/97/tasks/task/view')]

        public TaskDetailPage AttachReviewToManager(User manager)
        {
            WebItem ManagerName = new WebItem($"//span[@class='menu-popup-item-text' and text()='{manager.LastNameName}']",
                "Кнопка 'Прикрепить отзыв к менеджеру'");
            ReviewDetailPageFrame.SwitchToFrame();
            AttachReviewToManagerBtn.Click();
            ManagerName.Click();
            OpenLinkedTaskBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new TaskDetailPage();
        }

        WebItem CloseCardIcon => new WebItem("//div[@class='side-panel-label']" +
            "/descendant::div[@class='side-panel-label-icon side-panel-label-icon-close']",
            "Иконка 'крестик' закрытия детальной страницы задачи");

        public ReviewsBasePage CloseReviewDetailPage()
        {
            CloseCardIcon.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ReviewsBasePage();
        }
    }
}
