using System;
using System.Collections.Generic;
using System.Linq;

namespace GA_ClassMethods
{
    public class Student
    {
        // Properties
        public string Name { get; set; }
        public List<int> ExamScores { get; private set; }

        // Constructor to initialize the student with a name and a list of exam scores
        public Student(string name)
        {
            Name = name;
            ExamScores = new List<int>();
        }

        // Constructor that takes a name and a list of grades
        public Student(string name, List<int> examScores)
        {
            Name = name;
            ExamScores = examScores;
        }

        // Method to calculate the average score of all exams
        public double CalculateAverageScore()
        {
            if (ExamScores.Count == 0)
            {
                return 0;
            }

            int totalScore = 0;
            foreach (int score in ExamScores)
            {
                totalScore += score;
            }

            return (double)totalScore / ExamScores.Count;
        }

        // Method to get the overall letter grade based on the average score
        public char GetGrade()
        {
            double averageScore = CalculateAverageScore();

            if (averageScore >= 90)
            {
                return 'A';
            }
            else if (averageScore >= 80)
            {
                return 'B';
            }
            else if (averageScore >= 70)
            {
                return 'C';
            }
            else if (averageScore >= 60)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        // Method to display basic student information
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Average Score: {CalculateAverageScore():F2}");
            Console.WriteLine($"Grade: {GetGrade()}");
        }

        // Method to add a grade to the list, with validation to ensure it's within the 0-100 range
        public void AddGrade(int grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                ExamScores.Add(grade);
                Console.WriteLine($"Added grade {grade} for {Name}");
            }
            else
            {
                Console.WriteLine($"Invalid grade: {grade}. Grade must be between 0 and 100.");
            }
        }

        // Method to display all exam grades with both letter and number grades
        public void DisplayAllGrades()
        {
            Console.WriteLine($"Grades for {Name}:");
            for (int i = 0; i < ExamScores.Count; i++)
            {
                char letterGrade = GetLetterGrade(ExamScores[i]);
                Console.WriteLine($"Exam {i + 1}: {letterGrade} ({ExamScores[i]})");
            }
        }

        // Private helper method to get the letter grade based on the number grade for individual exams
        private char GetLetterGrade(int score)
        {
            if (score >= 90)
            {
                return 'A';
            }
            else if (score >= 80)
            {
                return 'B';
            }
            else if (score >= 70)
            {
                return 'C';
            }
            else if (score >= 60)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
