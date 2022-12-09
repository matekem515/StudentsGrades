using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
	public interface IStudent
	{
		string Name { get; set; }
		string Surname { get; set; }

		event OnGradeAddedLowDelegate LowGradeAdded;
		void AddGrade(double grade);
		void AddGrade(string grade);
		Statistics GetStatistics();
		void ShowStatistics();
	}
}
