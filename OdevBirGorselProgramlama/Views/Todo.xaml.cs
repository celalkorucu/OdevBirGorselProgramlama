using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace OdevBirGorselProgramlama.Views;

public partial class Todo : ContentPage
{
    private ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

    public Todo()
	{
        InitializeComponent();
        taskListView.ItemsSource = tasks;
    }

    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        string taskTitle = taskEntry.Text;
        if (!string.IsNullOrEmpty(taskTitle))
        {
            tasks.Add(new TaskItem { Title = taskTitle });
            taskEntry.Text = string.Empty;
        }
    }

    


    private async void OnEditClick(object sender, EventArgs e)
    {

      
        
        if (sender is ImageButton button && button.CommandParameter is TaskItem task)
        {
          
            string newTitle = await DisplayPromptAsync("Edit Task", "Enter new task title:", initialValue: task.Title);

            if (newTitle != null)
            {
                task.Title = newTitle;
                tasks.Remove(task);
                tasks.Add(task);
            }
        }
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.CommandParameter is TaskItem task)
        {
            tasks.Remove(task);
        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
    }

    
}
