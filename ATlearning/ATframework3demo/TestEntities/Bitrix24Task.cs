using System;
using System.Collections.Generic;
using System.Text;
using AquaTestFramework.CommonFramework.BitrixCPinteraction;

namespace atFrameWork2.TestEntities
{
    public class Bitrix24Task
    {
        public Bitrix24Task(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public static void RemoveTaskFromWorkflow(PHPcommandLineExecutor phpExecutor)
        {
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
        }
    }


}
