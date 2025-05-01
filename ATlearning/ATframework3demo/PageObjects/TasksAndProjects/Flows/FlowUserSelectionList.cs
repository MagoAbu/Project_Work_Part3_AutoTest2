
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.TasksAndProjects.Streams;

namespace ATframework3demo.PageObjects.TasksAndProjects.Flows
{
    public class FlowUserSelectionList
    {
        WebItem SaveBtn => new WebItem("//span[@class='ui-btn-text' and text()='Сохранить изменения']",
            "Кнопка 'Сохранить изменения' на второй странице редактирования потока 'Настройки'");

        public FlowsBasePage SelectManager(User manager)
        {
            WebItem Manager = new WebItem($"//div[@class='ui-selector-item-title' and text()='{manager.NameLastName}']/ancestor::div[@class='ui-selector-item-box']", 
                "Добавленный менеджер в общем списке");
            Manager.Click();
            SaveBtn.Click();
            return new FlowsBasePage();
        }
    }
}
