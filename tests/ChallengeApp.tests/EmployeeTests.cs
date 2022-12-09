using System;
using Xunit;
using ChallengeApp;

namespace ChallengeApp.tests
{
	public class EmployeeTests
	{
		[Fact]
		public void Test1()
		{
			//arrange
			var emp = new InMemoryStudent("Bartek", "Mak");
			emp.AddGrade(10.4);
			emp.AddGrade(9.4);
			emp.AddGrade(11.4);
			//act
			var result = emp.GetStatistics();

			//assert
			Assert.Equal(10.4, result.Avarage, 1);
			Assert.Equal(11.4, result.High);
			Assert.Equal(9.4, result.Low);
		}
	}
}
