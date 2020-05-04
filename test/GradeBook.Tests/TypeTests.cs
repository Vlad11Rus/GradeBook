using System;
using Xunit;

namespace GradeBook.Tests
{
    
    public delegate string WriteLogDelegate(string logMessage);
    
    public class TypeTests
    {
        int count = 0; 

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage; 
            log += ReturnMessage;     
            log += IncrementCount;            
  
            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        
        
        
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassByRef()
        {
           var book1 = GetBook("Book1");
           GetBookSetName(out book1, "New Name");

           Assert.Equal("New Name", book1.Name);
           
        }
        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
           var book1 = GetBook("Book1");
           GetBookSetName(book1, "New Name");

           Assert.Equal("Book1", book1.Name);
           
        }
        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
           var book1 = GetBook("Book1");
           SetName(book1, "New Name");

           Assert.Equal("New Name", book1.Name);
           
        }
        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }



        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Vlad";
            var upper = MakeUppercase(name);

            Assert.Equal("Vlad", name);
            Assert.Equal("VLAD", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
           var book1 = GetBook("Book1");
           var book2 = GetBook("Book2");

           Assert.Equal("Book1", book1.Name);
           Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {

           var book1 = GetBook("Book1");
           var book2 = book1;

           Assert.Same(book1, book2);
           Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
