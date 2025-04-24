
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.TasksAndProjects.Streams
{
    public class FlowControlMenu
    {
        WebItem EditItem => new WebItem("//span[@class='menu-popup-item-text' and text()='Редактировать']", 
            "Пункт бургер-меню 'Редактировать'");

        public FlowEditPage SelectEditItem()
        {
            EditItem.Click();
            return new FlowEditPage();
        }
    }
}
