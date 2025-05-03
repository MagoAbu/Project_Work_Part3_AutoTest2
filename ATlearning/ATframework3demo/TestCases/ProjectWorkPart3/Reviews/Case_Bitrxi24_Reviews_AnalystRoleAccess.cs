using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases.ProjectWorkPart3.Reviews
{
    public class Case_Bitrxi24_Reviews_AnalystRoleAccess : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Выдача пользователю доступа к роли Аналитик", homePage => AssigningAnalystPermissionsToUser(homePage)));
            return caseCollection;
        }

        public static void AssigningAnalystPermissionsToUser(PortalHomePage homePage)
        {
            User testAnalyst = TestCase.RunningTestCase.CreatePortalTestUser(false);
            //Добавить юзера в поток
            homePage
                .LeftMenu
                .OpenTasks()
                .OpenFlows()
                .OpenFlowControlMenu()
                .SelectEditItem()
                .AddManager()
                .SelectManager(testAnalyst);
            //Выдать доступ к роли Аналитик
            homePage
                .LeftMenu
                .OpenReviews()
                .OpenAccess()
                .ClickAddAnalystButton()
                 .OpenEmployeesAndDepartmentsTab()
                .ChooseManager(testAnalyst)
                .ApplyChanges();
            //Зайти под пользователем
            WebItem.DefaultDriver.Quit();
            WebItem.DefaultDriver = default;
            new PortalLoginPage(TestCase.RunningTestCase.TestPortal)
                .Login(testAnalyst);
            //Добавить пункт Отзывы в левое меню
            homePage
                .LeftMenu
                .OpenSettingsMenu()
                .AddLinkToMenu()
                .EditMenuItem();
            //Проверить, что вкладка Отзывы доступна
            homePage
                .LeftMenu
                .OpenReviews()
                .CheckReviewsTabVisibility();
        }
    }
}
