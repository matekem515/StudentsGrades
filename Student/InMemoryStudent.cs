using System;
using System.Collections.Generic;

namespace ChallengeApp
{
	public class InMemoryStudent: StudentBase
	{
		public override string Name { get; set; }
		public override string Surname  { get; set; }

		private List<double> grades;

		public InMemoryStudent(string name,string surname) : base(name,surname)	
		{
			grades = new List<double>();
		}

		public InMemoryStudent(double grade) : base(grade)
		{
			
		}

		public override void AddGrade(double grade)
		{
			grades.Add(grade);
			if (grade < 3)
			{
				GradeUnder();
			}
		}
		
		public override Statistics GetStatistics()
		{
			var result = new Statistics();
			result.GetStatistics(grades);
			return result;
		}

		public void ChangeName(string name)
		{
			var isDigit = false;
			foreach (var item in name)
			{
				if (char.IsDigit(item))
				{
					isDigit = true;
					Console.WriteLine("In string we have found a digit");
					break;
				}
			}
			if (isDigit == true)
			{
				this.Name = name;
				Console.WriteLine($"Name was changed to: {name}");
			}
		}

		public override void AddGrade(string grade)
		{
			{
				if ((grade.Contains("+")))
				{
					switch (grade)
					{
						case "5+" or "+5":
							{
								this.grades.Add(double.Parse("5,5"));
								break;
							}

						case "4+" or "+4":
							{
								this.grades.Add(double.Parse("4,5"));
								break;
							}

						case "3+" or "+3":
							{
								this.grades.Add(double.Parse("3,5"));
								break;
							}

						case "2+" or "+2":
							{
								this.grades.Add(double.Parse("2,5"));
								break;
							}

						case "1+" or "+1":
							{
								this.grades.Add(double.Parse("1,5"));
								break;
							}
					}
				}
				else
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
			}
		}
	}
}