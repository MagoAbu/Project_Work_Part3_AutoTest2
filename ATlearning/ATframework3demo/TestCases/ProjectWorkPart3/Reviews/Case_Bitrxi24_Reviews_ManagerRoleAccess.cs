using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases.ProjectWorkPart3.Reviews
{
    public class Case_Bitrxi24_Reviews_ManagerRoleAccess : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Выдача пользователю доступа к роли Менеджер", homePage => AssigningManagerPermissionsToUser(homePage)));
            return caseCollection;
        }

        public static void AssigningManagerPermissionsToUser(PortalHomePage homePage)
        {
            User testManager = TestCase.RunningTestCase.CreatePortalTestUser(false);
            //Добавить юзера в поток
            homePage
                .LeftMenu
                .OpenTasks()
                .OpenFlows()
                .OpenFlowControlMenu()
                .SelectEditItem()
                .AddManager()
                .SelectManager(testManager);
            //Выдать доступ к роли Менеджер
            homePage
                .LeftMenu
                .OpenReviews()
                .OpenAccess()
                .ClickAddManagerButton()
                .OpenEmployeesAndDepartmentsTab()
                .ChooseManager(testManager)
                .ApplyChanges();
            //Зайти под пользователем
            WebItem.DefaultDriver.Quit();
            WebItem.DefaultDriver = default;
            new PortalLoginPage(TestCase.RunningTestCase.TestPortal)
                .Login(testManager);
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
