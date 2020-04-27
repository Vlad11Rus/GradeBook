using System;
using System.Collections.Generic;

namespace GradeBook
{    
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book("Vlad's Grade Book");
            
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                
                if(input == "q")
                {
                    break;
                }
                
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);                  
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally           
                {
                    Console.WriteLine("**"); 
                }                           
            }

             var stats = book.GetStatistics();          
             book.Name = "";

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
              
        }
    }
}


