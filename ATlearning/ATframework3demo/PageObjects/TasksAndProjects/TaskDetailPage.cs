﻿
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.Reviews;

namespace ATframework3demo.PageObjects.TasksAndProjects
{
    public class TaskDetailPage
    {
        WebItem TaskDetailPageFrame => new WebItem("//iframe[contains(@src, '/workgroups/group')]",
            "Фрейм детальной страницы задачи");

        WebItem OpenLinkedTaskBtn => new WebItem("//span[@class='ui-btn-text' and text()='Открыть привязанную задачу']",
            "Кнопка 'Открыть привязанную задачу'");

        public TaskDetailPage OpenTaskDetailPage()
        {
            OpenLinkedTaskBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            TaskDetailPageFrame.SwitchToFrame();
            return new TaskDetailPage();
        }

        public TaskDetailPage AssertCorrectAssignee(User testManager)
        {
            WebItem Assignee = new WebItem($"//a[@class='task-detail-sidebar-info-user-name task-detail-sidebar-info-user-name-link' and text()='{testManager.NameLastName}']",
                "Имя менеджера в поле 'Исполнитель'");
            if (testManager.NameLastName != Assignee.InnerText())
            {
                Log.Error($"В поле 'Исполнитель' не отображается закрепленный за задачей менеджер. Ожидалось, что за задачей будет закреплен {testManager.NameLastName}");
            }
            else
            {
                Log.Info($"В поле 'Исполнитель' отображается закрепленный за задачей менеджер: {testManager.NameLastName}");
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
