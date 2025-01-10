using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDoList _todoList;

        public MainWindow()
        {
            InitializeComponent();
            _todoList = new ToDoList();
        }

        /// <summary>
        /// Lägger till items i to-do listan
        /// </summary>
        /// <param name="sender">sender från mainwindow</param>
        /// <param name="e">event</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;
            if (!string.IsNullOrEmpty(task))
            {
                _todoList.AddTask(task);
                UpdateTaskList();
                TaskTextBox.Clear();
            }
        }

        /// <summary>
        /// Uppdaterar listan med to-do items
        /// </summary>

        private void UpdateTaskList()
        {
            TasksListBox.Items.Clear();
            foreach (var task in _todoList.GetAllTasks())
            {
                TasksListBox.Items.Add(task);
            }
        }

        /// <summary>
        /// Tar bort items från to-do listan
        /// </summary>
        /// <param name="sender">sender från mainwindow</param>
        /// <param name="e">event</param>

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedIndex >= 0)
            {
                _todoList.RemoveTask(TasksListBox.SelectedIndex);
                UpdateTaskList();
            }
        }
    }
}