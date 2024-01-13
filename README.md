# Guided Assignment: Instance Methods

In C#, instance methods are methods that are associated with specific instances (objects) of a class. These methods are defined within the class and can be called on objects created from that class. Instance methods operate on and have access to the instance-specific data and attributes of the object.

Here's an example of an instance method in C#:

```csharp
using System;

class MyClass
{
    private int value; // Instance variable

    public MyClass(int initialValue)
    {
        value = initialValue;
    }

    // Instance method
    public void MultiplyBy(int factor)
    {
        value *= factor;
    }

    // Instance method to display the current value
    public void DisplayValue()
    {
        Console.WriteLine("Current value: " + value);
    }
}

class Program
{
    static void Main()
    {
        // Creating instances of MyClass
        MyClass obj1 = new MyClass(10);
        MyClass obj2 = new MyClass(20);

        // Calling instance methods on objects
        obj1.MultiplyBy(3);
        obj2.MultiplyBy(2);

        obj1.DisplayValue();
        obj2.DisplayValue();
    }
}
```

In this C# example:

- `MultiplyBy` and `DisplayValue` are instance methods of the `MyClass` class.

- `MultiplyBy` is called on specific instances `obj1` and `obj2` and modifies the `value` attribute of those instances.

- `DisplayValue` is also called on specific instances and displays the current value of the instance.

- Instance methods can access and modify the instance-specific data (in this case, the `value` attribute) and perform operations that are specific to each object.

Instance methods are a fundamental concept in object-oriented programming and are used to encapsulate the behavior associated with individual objects created from a class.

---

# Requirements

Here's a list of all the method names in the `Student` class:

1. Create a new application called GA_ClassMethods_***YourName***
1. Put your name and the date in comments at the top of your main application file.
1. Implement all the code for the `Student.cs` class
1. Implement the following methods and ALL their functionality and test code.
1. `CalculateAverageScore()`: Calculates the average score of all exams for the student.
2. `GetGrade()`: Determines the overall letter grade based on the average score.
3. `DisplayStudentInfo()`: Displays basic student information including name, average score, and grade.
4. `AddGrade(int grade)`: Adds a grade to the list of exam scores, with validation to ensure it's within the 0-100 range.
5. `DisplayAllGrades()`: Displays all exam grades, including both letter and number grades, for the student.
6. `GetLetterGrade(int score)`: A private helper method to get the letter grade based on the number grade for individual exams.
7. Add the Final code to test and demonstrate your new class methods
8. Make sure your code compiles correctly, then upload to GitHub and submit the repository to canvas



---

# Steps

--- 
### Step 1 - Make your project and add this code for the student class

1. After you've created your application create a new Student class and add the following code.

```csharp
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

    }
```

This code consist of 
- 2 fields 
    - `string name;`
    - `List<int> ExamScores;` 
- 2 Constructors, 
    - One that takes just a name, and initalizes and empty list
    - One that takes a name, and a list of grades

To test create a new instance of a Student object in your Program.cs. Give it your name, and pass in a List of grades. 

Example
`Program.cs`
```csharp
    public static void Main(string[] args) {
        
        // Create a list of 5 grades ranging between 0 and 100
        List<int> willGrades = new List<int> { 85, 92, 78, 90, 88 };

        // Create a new instance of the Student class with the name "Will" and the grades list
        Student willStudent = new Student("Will", willGrades);
    }
```

---

## Step 2 - Add an Add Grade Method

In this step we are going to create a method called `void AddGrade(int)`.

This method will let us add to the internal list of grades by passing in a numerical grade. 

1. Start with the method signature and body.

`Student.cs`
```csharp
    public void AddGrade(int grade)
    {
        // Code for AddGrade
    }
```

2. Now lets add the grade that is passed in into our `ExamScores` list.

`Student.cs`
```csharp
    public void AddGrade(int grade)
    {
        // Add grade to ExamScores
        ExamScores.Add(grade);
    }
```

Now this would work. But we have a problem, no validation. The user could enter in a number like -200 or 100000. We want to prevent that. Lets add some validation.

3. Create a condition that will only run when a grade between 0 and 100 is passed in. Then place your previous code in the code block.

We are also going to out a `Console.WriteLine()` to display information when it's been properly added.


`Student.cs`
```csharp
    public void AddGrade(int grade)
    {
        // Only grades between 0 and 100 can be entered.
        if (grade >= 0 && grade <= 100)
        {
            ExamScores.Add(grade);
            Console.WriteLine($"Added grade {grade} for {Name}");
        }
    }
```

4. Much better, now we are making sure only valid grades are entered. But good design habits means we should tell the user when and why bad data was entered. Lets add an else.

`Student.cs`
```csharp
    public void AddGrade(int grade)
    {

        if (grade >= 0 && grade <= 100)
        {
            ExamScores.Add(grade);
            Console.WriteLine($"Added grade {grade} for {Name}");
        }
        else
        {
            // Displays that the grade wasn't entered and why
            Console.WriteLine($"Invalid grade: {grade}. Grade must be between 0 and 100.");
        }
    }
```

### Test it out

In your main method in code try passing in 3 values, 1 between 0 and 100, one above, and one below. And run your code.

`Program.cs`
```csharp

    // Your student code in main

    willStudent.AddGrade(78); // Success
    willStudent.AddGrade(200); // Fails
    willStudent.AddGrade(-130); // Fails

```

Result
```
Added grade 78 for Will
Invalid grade: 200. Grade must be between 0 and 100.
Invalid grade: -130. Grade must be between 0 and 100.
```

---

## Step 3 - GetLetterGrade and DisplayAllGrades method

Here we are creating 2 new methods.
1. `private char GetLetterGrade(int)` - Which is used to convert a number grade into a letter grade. Because this method is never used with data outside of the Student class, we make it private. Only code inside of Student can use it. Also we return a `char` since we are only return a single character, ( A, B, C, D, F ).
2.  `void DisplayAllGrades()` - We create a method that will loop through our `ExamScores` list, and display all the grades. We use our `GetLetterGrade` method to display the letter grades.

Our first method, Get Letter Grade, takes an int. And depending on the grade passed in returns the related letter grade. Anything above 90 ( or 90% ) is an A, between 80 and 89 is a B, and so on.
`private char GetLetterGrade(int)`
```csharp
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
```

In our second method, we create a method that, when called, will display all the Grades related to the student.

1. Start with the Method name.

`void DisplayAllGrades()`
```csharp
    public void DisplayAllGrades()
    {
        // Code
    }
```

2. Next lets just write the code to loop through our internal list.

`void DisplayAllGrades()`
```csharp
public void DisplayAllGrades()
{
    // Loop through our ExamScores
    for (int i = 0; i < ExamScores.Count; i++)
    {
        
    }
}
```

3. Next we will print the grades to the screen in a formatted string. 

`void DisplayAllGrades()`
```csharp
public void DisplayAllGrades()
{
    for (int i = 0; i < ExamScores.Count; i++)
    {
        // We call our GetLetterGrade() method to get the appropriate grade
        char letterGrade = GetLetterGrade(ExamScores[i]);
        // Now we format a string to display the result
        Console.WriteLine($"Exam {i + 1}: {letterGrade} ({ExamScores[i]})");
        // Example: Exam 1: A 93
    }
}
```

4. To complete our code, lets also add a new line that displays the name of the student. Well put it outside of our loop ( we don't want it to display multiple times. )

`void DisplayAllGrades()`
```csharp
public void DisplayAllGrades()
{
    // This will display the students name.
    // Because we are accessing a local Property, we can just say Name. It was always refer to the name for the related instanced data.
    Console.WriteLine($"Grades for {Name}:");
    for (int i = 0; i < ExamScores.Count; i++)
    {
        char letterGrade = GetLetterGrade(ExamScores[i]);
        Console.WriteLine($"Exam {i + 1}: {letterGrade} ({ExamScores[i]})");
    }
}
```

### Test it out

Call our `.DisplayAllGrades()` on your instance of Student.

`Program.cs`
```csharp
    // Below your other code
    willStudent.DisplayAllGrades(); 
```

Result
```
Grades for Will:
Exam 1: B (85)
Exam 2: A (92)
Exam 3: C (78)
Exam 4: A (90)
Exam 5: B (88)
Exam 6: C (78)
```
---

## Step - CaculateAverageScore and DisplayClassGrade

We add two more methods
1. `double CaculateAverageScore()` - Which gets the average of all the Exam Scores
2. `GetGrade()` - Which uses `CalculateAverageScore()` to return the students letter grade.

First `CaculateAverageScore()`.

Add the following code to your `Student.cs` class.

`double CaculateAverageScore()`
```csharp
    // Method to calculate the average score of all exams
    public double CalculateAverageScore()
    {
        // 1a. Validation Condition
        if (ExamScores.Count == 0)
        {
            return 0;
        }

        // 1b. Sum all grades
        int totalScore = 0;
        foreach (int score in ExamScores)
        {
            totalScore += score;
        }

        // 1c. Return average grade
        return (double)totalScore / ExamScores.Count;
    }
```

Explination
- 1a. Validation Condition. If there are no grades in our list, this code will immedietly return 0. This is efficent as it wont run the rest of our code on an empty list.
- 1b. This is the standard code to sum up all numbers in a list of int.
- 1c. The equation to get the average of a group of numbers it to divide the SUM of the numbers by the NumberOfElements. We cast totalScore with (double) to ensure a decimal will be returned.

Now our second method, `public GetGrade()`.

Add the following code to your `Student.cs` class.

`public char GetGrade()`

```csharp
// Method to get the overall letter grade based on the average score
public char GetGrade()
{
    // 1a. Calculate the average score
    double averageScore = CalculateAverageScore();
    
    // 1b. Convert the average score to the nearest whole number
    int roundedAverageScore = (int)Math.Round(averageScore);
    
    // 1c. Get the letter grade based on the rounded average score
    return GetLetterGrade(roundedAverageScore);
}
```
---

- 1a. We call our `CalculateAverageScore()` method to get the students overall grade.
- 1b. By using Math.Round we convert our double, which will have decimals, to a whole number, Rounded apropretly.
- 1c. Now we call our `GetLetterGrade()` method to return our letter grade.

This method is made efficent by reusing methods we had created for other purposes.

### Test it out

Call our `.GetGrade()` on your instance of Student.

`Program.cs`
```csharp
    // Below your other code
    willStudent.GetGrade(); 
```

Result
```
B
```

---

## Step - Display Student Information
With our final method, we will display the students information in an easy to read format. This will include the students averge score and letter grade.

```csharp
// Method to display basic student information
public void DisplayStudentInfo()
{
    // Calculate the average score
    double averageScore = CalculateAverageScore();

    // Get the overall letter grade
    char grade = GetGrade();

    // Display the student's name
    Console.WriteLine($"Student Name: {Name}");

    // Display the average score with two decimal places
    Console.WriteLine($"Average Score: {averageScore:F2}");

    // Display the overall letter grade
    Console.WriteLine($"Grade: {grade}");
}
```

### Test it out

Call our `.DisplayStudentInfo()` on your instance of Student.

`Program.cs`
```csharp
    // Below your other code
    willStudent.DisplayStudentInfo(); 
```

Result
```
Student Name: Will
Average Score: 85.17
Grade: B
```

---

## Final Code

1. Add the following code to `Program.cs`. UNDER the Main method ( outside of it.)

```csharp

    static void Main(string[] args) { // code }

    // Add code below
    static List<Student> GenerateRandomStudents()
    {
        List<Student> students = new List<Student>();
        Random random = new Random(); // Random object created here

        for (int i = 1; i <= 5; i++)
        {
            Student student = new Student($"Student{i}");

            for (int j = 0; j < 5; j++)
            {
                student.ExamScores.Add(random.Next(0, 101));
            }

            students.Add(student);
        }

        return students;
    }

```

In Main add the following code.

`Program.cs`

```csharp
    static void Main(string[] args) { 
    
    // After your original code

    List<Student> randomStudents = GenerateRandomStudents();

    // Add your student to this list
    randomStudents.Add(willStudent);

    // Loop and display all the info
    foreach (Student student in randomStudents)
    {
        student.DisplayStudentInfo();
    }
    
    } // Main
```

Result

```
- Previous Result
Student Name: Student1
Average Score: 53.00
Grade: F
Student Name: Student2
Average Score: 47.80
Grade: F
Student Name: Student3
Average Score: 74.40
Grade: C
Student Name: Student4
Average Score: 62.60
Grade: D
Student Name: Student5
Average Score: 38.00
Grade: F
Student Name: Will
Average Score: 85.17
Grade: B
```

## Submission
Upload your repo to Github, and submit your repo link in the textbox on canvas.

---

## Rubric


| **Criteria**                                  | **Description**                                                                                               | **Points** |
|-----------------------------------------------|---------------------------------------------------------------------------------------------------------------|------------|
| **Project Setup and Code Structure**          |                                                                                                               | **20**     |
| Application Creation                          | Successfully created an application called GA_ClassMethods_YourName.                                          | 5          |
| Comments and Documentation                    | Included name and date in comments at the top of the main application file.                                   | 5          |
| Class Implementation                          | Correctly implemented the `Student.cs` class with all required properties and constructors.                  | 5          |
| Code Organization                             | Code is well-organized, readable, and follows C# conventions.                                                 | 5          |
| **Method Implementation**                     |                                                                                                               | **60**     |
| CalculateAverageScore() Method                | Correctly calculates and returns the average score of all exams. Handles cases with no scores.               | 10         |
| GetGrade() Method                             | Accurately determines and returns the overall letter grade based on the average score.                       | 10         |
| DisplayStudentInfo() Method                   | Displays student name, average score, and grade correctly.                                                    | 10         |
| AddGrade(int grade) Method                    | Adds a grade to the exam scores list with proper validation (0-100 range). Provides user feedback for input. | 10         |
| DisplayAllGrades() Method                     | Displays all exam grades correctly, including both letter and numerical grades.                              | 10         |
| GetLetterGrade(int score) Method              | Accurately converts numerical grade to letter grade. Method is private and used correctly within the class.  | 10         |
| **Test Code and Final Demonstration**         |                                                                                                               | **10**     |
| Test Code Implementation                      | Successfully implemented and demonstrated test code for all class methods.                                   | 5          |
| Final Code Compilation                        | Code compiles correctly without errors.                                                                       | 5          |
| **Submission and Repository**                 |                                                                                                               | **10**     |
| GitHub Repository                             | Code is correctly uploaded to GitHub with appropriate commit messages and repository structure.              | 5          |
| Canvas Submission                             | Submitted the GitHub repository link on Canvas.                                                              | 5          |
| **Total**                                     |                                                                                                               | **100**    |

