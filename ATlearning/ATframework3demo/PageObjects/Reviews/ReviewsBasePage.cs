
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

        WebItem ReviewItem => new WebItem("//a[@href='/feedback/detail/1/']",
            "Отзыв в списке отзывов с текстом 'Great product, fast delivery!'");

        public ReviewDetailPage SelectReview()
        {
            ReviewItem.Click();
            return new ReviewDetailPage();
        }
    }
}
