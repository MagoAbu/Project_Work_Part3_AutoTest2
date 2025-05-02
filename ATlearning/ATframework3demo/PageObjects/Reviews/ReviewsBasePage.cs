
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestCases.ProjectWorkPart3.Manager;

namespace ATframework3demo.PageObjects.Reviews
{
    public class ReviewsBasePage
    {
        WebItem ManagersItem => new WebItem("//a[contains(@href, '/feedback/managers/')]", 
            "Вкладка 'Менеджеры' в хедере страницы 'Отзывы'");

        public ManagersListPage OpenManagers()
        {
            ManagersItem.Click();
            return new ManagersListPage();
        }

        WebItem ReviewItem => new WebItem("//a[contains(@href , '/feedback/detail/') and text()='Great product, fast delivery!']",
            "Отзыв в списке отзывов с текстом 'Great product, fast delivery!'");

        public ReviewDetailPage SelectReview()
        {
            ReviewItem.Click();
            return new ReviewDetailPage();
        }
    }
}
