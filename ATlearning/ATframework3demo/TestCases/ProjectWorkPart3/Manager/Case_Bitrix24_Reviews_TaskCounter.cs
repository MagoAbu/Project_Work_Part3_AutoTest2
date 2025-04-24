using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;

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
            var manager = new User()
            {
                LastName = "ЧёXXIIIIVXXXXVXXIXLIII",
                Name = "ИванIIIIVXXXXVXXIXLIII"
            };

            var taskCount = new Bitrix24Reviews()
            {
                CurrentTaskCount = 0
            };

            //Предусловие: Удалить задачу с нужным опсианием из списка задач, чтобы не мешать прохождению теста
            var phpExecutor = new PHPcommandLineExecutor(TestCase.RunningTestCase.TestPortal.PortalUri,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.LoginAkaEmail,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.Password);

            string taskDeletionPhpCode = $"\\Bitrix\\Main\\Loader::includeModule('tasks');" +
                $"\r\n$taskTitle = 'Отзыв: id=1';" +
                $"\r\n$taskEntity = new \\CTasks();" +
                $"\r\n$res = \\CTasks::GetList(\r\n    " +
                                $"array(),\r\n    " +
                                $"array('TITLE' => $taskTitle),\r\n    " +
                                $"array('ID', 'TITLE') \r\n);" +
                $"\r\nif ($task = $res->Fetch()) {{\r\n    " +
                                $"$taskId = $task['ID'];\r\n    " +
                                $"$result = $taskEntity->Delete($taskId);\r\n" +
                $"}};";
            phpExecutor.Execute(taskDeletionPhpCode);

            //Перейти в отзывы
            homePage
                .LeftMenu
                .OpenReviews()
            //Назначить менеджера на отзыв
                .SelectReview()
                .AttachReviewToManager(manager)
            //Открыть привязанную задачу
            //Проверить, что исполнитель задачи верный
               .GoToTaskDetailPage()
               .AssertCorrectAssignee(manager)
            //Закрыть фреймы детальной страницы отзывов и задачи
               .CloseTaskDetailPage()
               .CloseReviewDetailPage()
            //Перейти во вкладку Менеджеры
            //Проверить, что счетчик задач у менеджера увеличился
               .GoToManagers()
               .CheckCurrentTaskCount(taskCount);
        }
    }
}
