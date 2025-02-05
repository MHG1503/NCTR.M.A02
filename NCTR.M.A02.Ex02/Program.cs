internal class Program
{
    private static void Main(string[] args)
    {
        int personCount;
        while(true){
            System.Console.WriteLine("Enter the number of person");
            if(int.TryParse(Console.ReadLine(), out personCount)){
                break;
            }
        }
        string[] persons = new string[personCount];
        string[] formats = {"dd/MM/yyyy", "yyyy/MM/dd"};

        System.Console.WriteLine("Enter the names and birthdates in the format: Name - dd/MM/yyyy");
        int count = 1;

        while(count <= personCount){
            System.Console.WriteLine($"Enter the name and birthdate of person {count}");
            string infoInput = Console.ReadLine();

            if(infoInput != "" && infoInput != null){
                try{
                    string[] splitInfo = infoInput.Trim().Split(" - ");
                    string name = splitInfo[0];
                    string birthDateStr = splitInfo[1];
                    DateTime birthDate;

                    if(!(splitInfo[0] != "" && 
                        DateTime.TryParseExact(
                            birthDateStr,
                            formats,
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,out birthDate)))
                    {
                        System.Console.WriteLine("Invalid Input for Birthdate");
                        continue;
                    }
                    persons[count - 1] = $"{name} - {birthDate:yyyy/MM/dd}";
                    count++;
                }catch(Exception e){
                    System.Console.WriteLine("Invalid Input. Please enter again");
                    continue;
                }
            }
        }

        for(int i = 0; i < personCount; i++){
            System.Console.WriteLine($"Person {i + 1}: {persons[i]}");
        }  
    }
}