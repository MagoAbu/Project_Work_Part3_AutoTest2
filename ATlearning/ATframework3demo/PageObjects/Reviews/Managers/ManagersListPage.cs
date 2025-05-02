
using System.Drawing;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases.ProjectWorkPart3.Manager
{
    public class ManagersListPage
    {
        public ManagersListPage CheckManagerIsAdded(string ManagerLastNameName)
        {
            WebItem managerName = new WebItem($"//span[@class='main-grid-cell-content' and text()='{ManagerLastNameName}']",
                "Строка с именем и фамилией в списке менеджеров");
            if (managerName.InnerText() != ManagerLastNameName)
                Log.Error($"Менеджер не отображается в списке. Ожидалось, что в спике появится менеджер с именем {ManagerLastNameName}");
            return new ManagersListPage();
        }

        public int CheckTaskCountBefore(string userId)
        {
            WebItem TaskOnWorkBefore = new WebItem($"//span[@id='current-tasks-{userId}']",
                "Поле с количеством отзывов в работе");
            int taskCountBefore = int.Parse(TaskOnWorkBefore.InnerText());

            return taskCountBefore;
        }

        public void CheckTaskCountAfter(string userId, int tasksCountBefore)
        {
            WebItem TaskOnWorkAfter = new WebItem($"//span[@id='current-tasks-{userId}']",
                "Поле с количеством отзывов в работе");
            int taskCountAfter = int.Parse(TaskOnWorkAfter.InnerText());

            if (taskCountAfter - tasksCountBefore == 1)
            {
                Log.Info($"Значение поля 'Отзывов в работе' увеличилось на {taskCountAfter}");
            }
            else
            {
                Log.Error("Значение поля 'Отзывов в работе' не изменилось либо изменилось неверно");
            }
        }
    }
}
