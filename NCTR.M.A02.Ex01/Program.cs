internal class Program
{
    private static void Main(string[] args)
    {
        string taskName;
        DateTime taskTime;

        while (true){
            System.Console.WriteLine("Enter the task name: ");
            taskName = Console.ReadLine();
            if (taskName != "" && taskName != null){
                break;
            }
        }

        string[] formats = {"dd/MM/yyyy", "yyyy/MM/dd"};
        while (true){
            System.Console.WriteLine("Enter the task time (dd/MM/yyyy or yyyy/MM/dd): ");
            if(DateTime.TryParseExact(
                Console.ReadLine(),
                formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,out taskTime)
            ){
                break;
            }
        }

        PrintResult(taskName,taskTime, GenerateReminders(taskTime));
    }

    private static List<DateTime> GenerateReminders(DateTime taskTime){
        List<DateTime> result = new List<DateTime>();
        int count = 1;
        while(count <= 5 ){
            if(count == 1){
                taskTime = addWorkingDays(taskTime,7);
            }else if(count == 2){
                taskTime = addWorkingDays(taskTime,2);
            }else{
                taskTime = addWorkingDays(taskTime,1);
            }
            result.Add(taskTime);
            count++;
        }
        return result;
    }

    private static DateTime addWorkingDays(DateTime taskTime, int days){
        while(days > 0){
            taskTime = taskTime.AddDays(1);
            if(!IsWeekend(taskTime)){
                days--;
            }
        }
        return taskTime;
    }

    private static bool IsWeekend(DateTime currentDate){
        return currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate.DayOfWeek == DayOfWeek.Saturday;
    }

    private static void PrintResult(string taskName, DateTime taskTime, List<DateTime> remindedTime){
        foreach (DateTime time in remindedTime){
            System.Console.WriteLine($"Task: {taskName} created on {taskTime:yyyy/MM/dd} - Reminder: {time:yyyy/MM/dd}");
        }
    }
}