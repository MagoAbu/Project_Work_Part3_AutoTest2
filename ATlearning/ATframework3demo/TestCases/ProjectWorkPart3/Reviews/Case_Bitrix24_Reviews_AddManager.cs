using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases.ProjectWorkPart3.Manager
{
    public class Case_Bitrix24_Reviews_AddManager : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление нового сотрудника в список менеджеров", homePage => AddUserToFeedbackManagers(homePage)));
            return caseCollection;
        }

        public static void AddUserToFeedbackManagers(PortalHomePage homePage)
        {
            //Создать сотрудника
            User firstUser = TestCase.RunningTestCase.CreatePortalTestUser(false);

            //Перейти в раздел левого меню "Задачи и проекты"
             homePage
                .LeftMenu
                .OpenTasks()
            //Перейти в потоки
                .OpenFlows()
            //Отредактировать поток "Отзывы"
                .OpenFlowControlMenu()
                .SelectEditItem()
                .AddManager()
                .SelectManager(firstUser);

            //Проверить, что пользователь отображается во вкладке "Менеджеры"
            homePage
                .LeftMenu
                .OpenReviews()
                .OpenManagers()
                .CheckManagerIsAdded(firstUser.LastNameName);
        }
    }
}
