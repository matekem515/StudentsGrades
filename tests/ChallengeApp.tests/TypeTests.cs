using ChallengeApp;
using System;
using Xunit;
namespace Ksiegarnia.tests
{
	public class TypeTests
	{
		int counter = 0;
		public delegate string WriteMessage(string message);

		[Fact]
		public void WriteMessageDelegateCanPointToMethod()
		{
			
			WriteMessage del;

			del = ReturnMessage;
			del += ReturnMessage;
			del += ReturnMessage2;

			var result = del("Hello");
			Assert.Equal(3, counter);
		}

		string ReturnMessage(string message)
		{
			counter++;
			return message;
		}
		string ReturnMessage2(string message)
		{
			counter++;
			return message.ToUpper() ;
		}
		[Fact]
		public void GetStudentReturnsDifferentsObjects()
		{
			var emp1 = GetStudent("Krzysztof","Fakt");
			var emp2 = GetStudent("Daniel","Koniec");
			var emp3 = emp1;

			Assert.NotSame(emp1, emp2);
			Assert.False(object.ReferenceEquals(emp1, emp2));
			Assert.NotEqual(emp1, emp2);
		}

		[Fact]
		public void GetStudentReturnsSameobjects()
		{
			var emp1 = GetStudent("Robert","Chrust");
			var emp2 = emp1;
			Assert.Same(emp1, emp2);
			Assert.Equal(emp1, emp2);
			Assert.True(object.ReferenceEquals(emp1, emp2));
		}

		[Fact]
		public void CScharCanPassByReference()
		{
			var emp1 = GetStudent("Monika","Wkret");
			GetStudentSetname(out emp1, "Monika", "Wkret");
			Assert.Equal("Monika", emp1.Name);
			Assert.Equal("Wkret", emp1.Surname);
		}

		private void GetStudentSetname(out InMemoryStudent emp,string name,string surname)
		{
			emp = new InMemoryStudent(name,surname);
		}

		[Fact]
		public void CanSetNameFromReference()
		{
			var emp1 = GetStudent("Dawid", "Pajak");
			this.SetName(emp1, "Dawid","Pajak");
			Assert.Equal("Dawid", emp1.Name);
			Assert.Equal("Pajak", emp1.Surname);
		}
		
		private InMemoryStudent GetStudent(string name,string surname)
		{
			return new InMemoryStudent(name,surname);
		}

		private void SetName(InMemoryStudent student,string name,string surname)
		{
			student = new InMemoryStudent("Pawe³","Maciek");
			student.Name = name;
			student.Surname = surname;
		}
	}
}
