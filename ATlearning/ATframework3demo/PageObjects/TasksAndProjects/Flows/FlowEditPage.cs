using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.TasksAndProjects.Flows;

namespace ATframework3demo.PageObjects.TasksAndProjects.Streams
{
    public class FlowEditPage
    {
        WebItem ContinueBtn => new WebItem("//span[@class='ui-btn-text' and text()='Продолжить']/ancestor::button", 
            "Кнопка 'Продолжить' на первой странице редактирования потока 'О потоке'");

        WebItem AddManagerBtn => new WebItem("//div[@class='tasks-flow__create-distribution-type --himself --active']" +
            "/descendant ::span[@class='ui-tag-selector-item ui-tag-selector-add-button']",
            "Кнопка 'Добавить' пункта 'Самостоятельно'");

        public FlowUserSelectionList AddManager()
        {
            ContinueBtn.Click();
            AddManagerBtn.Click();
            return new FlowUserSelectionList();
        }
    }
}
