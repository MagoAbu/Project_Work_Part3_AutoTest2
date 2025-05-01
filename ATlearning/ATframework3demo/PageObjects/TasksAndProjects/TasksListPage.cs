using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.TasksAndProjects.Streams;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Tasks
{
    public class TasksListPage
    {
        public TasksListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        WebItem StreamsItem => new WebItem("//span[@class='main-buttons-item-text-box' " +
            "and text()='Потоки']/ancestor::span[@class='main-buttons-item-text']",
            "Вкладка 'Потоки' на главной странице 'Задачи и проекты'");

        public FlowsBasePage OpenFlows()
        {
            StreamsItem.Click();
            return new FlowsBasePage();
        }
    }
}