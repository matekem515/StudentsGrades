using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
	public class InFileStudent: StudentBase
	{
		private const string FILENAME = "grades.txt";
		private const string AUDIT = "audit.txt";

		public InFileStudent(string name, string surname) : base(name,surname)
		{
		
		}

		public override void AddGrade(double grade)
		{
			using var write = File.AppendText(FILENAME);
			using var write2 = File.AppendText(AUDIT);
			write.WriteLine(grade);
			write2.WriteLine($"{Name} {Surname} : {DateTime.UtcNow}");
			if (grade < 3)
			{
				GradeUnder();
			}
		}

		public override void AddGrade(string grade)
		{
			{
				if (grade.Contains("+") && (char.IsDigit(grade[0]) || char.IsDigit(grade[1])) && grade[0] <= '5' && grade[1] <= '5' && grade.Length == 2)
				{
					switch (grade)
					{
						case "5+" or "+5":
							{
								AddGrade(5.5);
								break;
							}

						case  "4+" or "+4":
							{
								AddGrade(4.5);
								break;
							}

						case "3+" or "+3":
							{
								AddGrade(3.5);
								break;
							}

						case "2+" or "+2":
							{
								AddGrade(2.5);
								break;
							}

						case "1+" or "+1":
							{
								AddGrade(1.5);
								break;
							}
					}
				}
				else if (grade.Length == 1)
				{
					var tryToParse = double.TryParse(grade, out double result);
					if (tryToParse && result > 0 && result < 7)
					{
						AddGrade(result);
					}
					else
					{
						throw new ArgumentException($"Wrong value added you can only add values from 1 - 6");
					}
				}
				else
				{
					throw new ArgumentException($"Wrong value added you can only add values from 1 - 6");
				}
			}
		}

		public override Statistics GetStatistics()
		{
			var statistics = new Statistics();
			if (File.Exists(FILENAME))
			{
				using var read = File.OpenText(FILENAME);
				var text = read.ReadLine();
				while (text !=null)
				{
					var grade = double.Parse(text);
					statistics.Add(grade);
					text = read.ReadLine();
				}
			}
			return statistics;
		}
	}
}