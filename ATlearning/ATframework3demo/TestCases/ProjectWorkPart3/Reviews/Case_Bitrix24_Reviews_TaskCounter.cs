using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases.ProjectWorkPart3.Manager
{
    public class Case_Bitrix24_Reviews_TaskCounter : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Изменение счетчика задач у менеджера при назначении ему задачи", homePage => ManagerTaskCounterIncrements_WhenTaskIsAssigned(homePage)));
            return caseCollection;
        }

        public static void ManagerTaskCounterIncrements_WhenTaskIsAssigned(PortalHomePage homePage)
        {
            User testManager = TestCase.RunningTestCase.CreatePortalTestUser(false);

            string userId = testManager.GetDBid(TestCase.RunningTestCase.TestPortal.PortalUri, TestCase.RunningTestCase.TestPortal.PortalAdmin);

            //Предусловие: Удалить задачу с нужным опсианием из списка задач, чтобы не мешать прохождению теста
            var phpExecutor = new PHPcommandLineExecutor(TestCase.RunningTestCase.TestPortal.PortalUri,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.LoginAkaEmail,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.Password);

            Bitrix24Task.RemoveTaskFromWorkflow(phpExecutor);

            //Перейти в отзывы
            homePage
                .LeftMenu
            //Добавить пользователя в поток
                .OpenTasks()
                .OpenFlows()
                .OpenFlowControlMenu()
                .SelectEditItem()
                .AddManager()
                .SelectManager(testManager);

            int tasksCountBefore = homePage
                .LeftMenu
                .OpenReviews()
                .OpenManagers()
                .CheckTaskCountBefore(userId);

            homePage
                .LeftMenu
                .OpenReviews()
            //Назначить менеджера на отзыв
                .SelectReview()
                .AttachReviewToManager(testManager)
            //Открыть привязанную задачу
            //Проверить, что исполнитель задачи верный
               .GoToTaskDetailPage()
               .AssertCorrectAssignee(testManager)
            //Закрыть фреймы детальной страницы отзывов и задачи
               .CloseTaskDetailPage()
               .CloseReviewDetailPage()
            //Перейти во вкладку Менеджеры
            //Проверить, что счетчик задач у менеджера увеличился
               .OpenManagers()
               .CheckTaskCountAfter(userId,tasksCountBefore);
        }
    }
}
