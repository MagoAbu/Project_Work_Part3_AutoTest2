
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.Reviews;

namespace ATframework3demo.PageObjects.TasksAndProjects
{
    public class TaskDetailPage
    {
        WebItem TaskDetailPageFrame => new WebItem("//iframe[contains(@src,'/workgroups/group/97/tasks/task/view')]",
            "Фрейм детальной страницы задачи");
        
        public TaskDetailPage GoToTaskDetailPage()
        {
            TaskDetailPageFrame.SwitchToFrame();
            return new TaskDetailPage();
        }

        public TaskDetailPage AssertCorrectAssignee(User manager)
        {
            WebItem Assignee = new WebItem($"//a[@class='task-detail-sidebar-info-user-name task-detail-sidebar-info-user-name-link' and text()='{manager.NameLastName}']",
                "Имя менеджера в поле 'Исполнитель'");
            if (manager.NameLastName != Assignee.InnerText())
            {
                Log.Error($"В поле 'Исполнитель' не отображается закрепленный за задачей менеджер. Ожидалось, что за задачей будет закреплен {manager.NameLastName}");
            }
            return new TaskDetailPage();
        }

        WebItem CloseCardIcon => new WebItem("//div[@class='side-panel-label']" +
            "/descendant::div[@class='side-panel-label-icon side-panel-label-icon-close']",
            "Иконка 'крестик' закрытия детальной страницы задачи");

        public ReviewDetailPage CloseTaskDetailPage()
        {
            WebDriverActions.SwitchToDefaultContent();
            CloseCardIcon.Click();
            return new ReviewDetailPage();
        }
    }
}
