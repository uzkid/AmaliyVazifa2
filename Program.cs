using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Manager Application");
            List<Task> tasks = new List<Task>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a Task");
                Console.WriteLine("2. Remove a Task");
                Console.WriteLine("3. Mark a Task as Completed");
                Console.WriteLine("4. Show All Tasks");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        tasks.Add(new Task(description));
                        Console.WriteLine("Task added!");
                        break;

                    case "2":
                        Console.Write("Enter task ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeId))
                        {
                            tasks.RemoveAll(t => t.Id == removeId);
                            Console.WriteLine("Task removed!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case "3":
                        Console.Write("Enter task ID to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int completeId))
                        {
                            Task task = tasks.FirstOrDefault(t => t.Id == completeId);
                            if (task != null)
                            {
                                task.IsCompleted = true;
                                Console.WriteLine("Task marked as completed!");
                            }
                            else
                            {
                                Console.WriteLine("Task not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nTasks:");
                        foreach (var t in tasks)
                        {
                            Console.WriteLine(t);
                        }
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }

    class Task
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string description)
        {
            Id = nextId++;
            Description = description;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"[{Id}] {Description} - {(IsCompleted ? "Completed" : "Not Completed")}";
        }
    }
}
