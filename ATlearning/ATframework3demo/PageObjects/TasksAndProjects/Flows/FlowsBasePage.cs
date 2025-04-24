
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.TasksAndProjects.Streams
{
    public class FlowsBasePage
    {
        WebItem ControlMenu => new WebItem("//a[@class='main-grid-row-action-button']/ancestor::span", 
            "Бургер меню потока 'Отзывы'");

        public FlowControlMenu OpenFlowControlMenu()
        {
            ControlMenu.Click();
            return new FlowControlMenu();
        }
    }
}
