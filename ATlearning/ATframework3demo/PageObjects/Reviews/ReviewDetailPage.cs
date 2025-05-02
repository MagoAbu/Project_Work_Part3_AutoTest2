
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.TasksAndProjects;

namespace ATframework3demo.PageObjects.Reviews
{
    public class ReviewDetailPage
    {
        WebItem ReviewDetailPageFrame => new WebItem("//iframe[contains(@src, '/feedback/detail/')]",
            "Фрейм детальной карточки отзыва");

        WebItem AttachReviewToManagerBtn => new WebItem("//span[@class='ui-btn-text']",
            "Кнопка 'Прикрепить отзыв к менеджеру'");

        public TaskDetailPage AttachReviewToManager(User testManager)
        {
            WebItem ManagerName = new WebItem($"//span[contains(text(), '{testManager.LastNameName}')]",
                "Кнопка 'Прикрепить отзыв к менеджеру'");
            ReviewDetailPageFrame.SwitchToFrame();
            AttachReviewToManagerBtn.Click();
            ManagerName.Click();
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
