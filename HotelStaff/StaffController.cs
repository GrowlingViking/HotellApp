using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace StaffApp
{
    class StaffController
    {
        private static ServiceTask activeTask;
        private static List<ServiceTask> tasks = new List<ServiceTask>();

        public static void GetAllTasksFromTheWeb()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("http://localhost:5000/api/tasks/");
            GetTaskListAsync(client, uri);
        }

        public static void UpdateTask(ServiceTask task, string note)
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("http://localhost:5000/api/tasks/" + task.ID.ToString() + "/" + task.Status);
            SetTaskStatusAsync(client, uri, task);
            

            if (note != "")
            {
                uri = new Uri("http://localhost:5000/api/tasks/" + task.ID.ToString() + "/notes");
                AddNoteToTaskAsync(client, uri, note);
            }
            
        }

        public static List<ServiceTask> GetTasks(string type)
        {
            return tasks.FindAll(t => t.ServiceType == type);
        }

        private static async void GetTaskListAsync(HttpClient client, Uri uri)
        {
            string result;
            try
            {
                result = await client.GetStringAsync(uri);
            }
            catch (Exception e)
            {

                throw e;
            }

            tasks = JsonConvert.DeserializeObject<List<ServiceTask>>(result);
        }

        private static async void SetTaskStatusAsync(HttpClient client, Uri uri, ServiceTask task)
        {
            HttpResponseMessage result;

            var data = new HttpFormUrlEncodedContent(
                new Dictionary<string, string>
                {
                    ["status"] = task.Status,
                    ["id"] = task.ID.ToString()
                });
            try
            {
                result = await client.PutAsync(uri, data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async void AddNoteToTaskAsync(HttpClient client, Uri uri, string note)
        {
            HttpResponseMessage result;

            var data = new HttpFormUrlEncodedContent(
                new Dictionary<string, string>
                {
                    ["note"] = note
                });

            try
            {
                result = await client.PostAsync(uri, data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string GetStatusOnActive()
        {
            return activeTask.Status;
        }

        public static void SetActiveTasks(ServiceTask task)
        {
            activeTask = task;
        }

        public static ServiceTask GetActiveTask()
        {
            return activeTask;
        }
    }
}
