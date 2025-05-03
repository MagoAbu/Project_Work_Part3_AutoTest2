
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Reviews.Access;
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

        WebItem AccessTab => new WebItem("//span[text()='Доступ']/ancestor::span[@class='main-buttons-item-text']",
            "Отзыв в списке отзывов с текстом 'Great product, fast delivery!'");

        public AccessBasePage OpenAccess()
        {
            AccessTab.Click();
            return new AccessBasePage();
        }

        WebItem ReviewsTab = new WebItem(new List<string> { "//div[@id='feedback-nav-menu']/descendant::span[@class='main-buttons-item-text-box' and text()='Отзывы']" },
            "Таб 'Отзывы'");

        public bool CheckReviewsTabVisibility()
        {
            bool isVisible = ReviewsTab.WaitElementDisplayed();
            if (isVisible)
            {
                Log.Info("Таб 'Отзывы' отображается на странице.");
            }
            else
            {
                Log.Info("Таб 'Отзывы' не найден или скрыт.");
            }

            return isVisible;
        }


        WebItem AnalyticsTab = new WebItem(new List<string> { "//div[@id='feedback-nav-menu']/descendant::span[@class='main-buttons-item-text-box' and text()='Аналитика']" },
            "Таб 'Аналитика'");

        public bool CheckAnalyticsTabVisibility()
        {
            bool isVisible = AnalyticsTab.WaitElementDisplayed();
            if (isVisible)
            {
                Log.Info("Таб 'Аналитика' отображается на странице.");
            }
            else
            {
                Log.Info("Таб 'Аналитика' не найден или скрыт.");
            }

            return isVisible;
        }
    }
}
