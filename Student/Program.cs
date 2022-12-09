using System;

namespace ChallengeApp
{
	class Program
	{
		static void Main(string[] args)
		{
            bool end = false;

            Console.WriteLine($"Welcome to Students Grade book program");

            while (!end)
            {
                Console.WriteLine();
                Console.WriteLine("1: If you want to add grades to txt and show the statistics");
                Console.WriteLine("2: If you want to add grades to memory and show the statistics");
                Console.WriteLine("3: End the program");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddGradesToFile();
                        break;

                    case "2":
                        AddGradesToMemory();
                        break;

                    case "3":
                        end = true;
                        break;

                    default:
                        Console.WriteLine("Wrong input data, try again");
                        continue;
                }
            }
        }

		private static void AddGradesToMemory()
		{
            Console.WriteLine("Enter name of student");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname of student");
            string surname = Console.ReadLine();
			if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
			{
                var newStudentInMemory = new InMemoryStudent(name, surname);
                newStudentInMemory.LowGradeAdded += OnLowGradeAdd;
                EnterGrade(newStudentInMemory);
                newStudentInMemory.ShowStatistics();
            }
			else
			{
                Console.WriteLine("Pls add name and surname for the student");
			}
        }

		private static void AddGradesToFile()
		{
            Console.WriteLine("Enter name of student");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname of student");
            string surname = Console.ReadLine();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                var newStudentInFile = new InFileStudent(name, surname);
                newStudentInFile.LowGradeAdded += OnLowGradeAdd;
                EnterGrade(newStudentInFile);
                newStudentInFile.ShowStatistics();
            }
            else
            {
                Console.WriteLine("Pls add name and surname for the student");
            }
        }
	
		static void OnLowGradeAdd(object sender, EventArgs args)
		{
			Console.WriteLine($"Oh no! Student receive grade under 3. We should inform student’s parents about this fact");
		}

        private static void EnterGrade(StudentBase student)
		{
			while (true)
			{
                Console.WriteLine($"Enter grade for {student.Name}  {student.Surname} if you want to leave push q");
                var input = Console.ReadLine();

				if (input == "q" || input == "Q")
				{
                    break;
				}
				try
				{
                    student.AddGrade(input);
				}
				catch (Exception e)
				{

					Console.WriteLine($"{e}");
				}
			}
		} 
	}
}
