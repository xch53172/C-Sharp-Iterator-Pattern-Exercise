using System;
using System.Collections.Generic;

namespace C_Sharp_yield_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]  //建立student的陣列
            {
                new Student{Age=15,Name="Ben",Student_ID=001},
                new Student{Age=20,Name="Danny",Student_ID=002},
                new Student{Age=25,Name="Lucia",Student_ID=003},
                new Student{Age=18,Name="Daisy",Student_ID=004},
                new Student{Age=12,Name="Rob",Student_ID=005},
                new Student{Age=17,Name="Teddy",Student_ID=006},
                new Student{Age=22,Name="Jill",Student_ID=007}
            };

            foreach(Student student in Student_yield.IteratorMethod(students))  //由foreach調用Student_yield.IteratorMethod()
            {
                Console.WriteLine(student); //顯示yield return返回的資料
            }
        }
    }

    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Student_ID { get; set; }
        public override string ToString()   //複寫ToString方便最後給Console.WriteLine()呈現資料
        {
            return $"name= {Name} age= {Age} Student_ID= {Student_ID,0:D3}";
        }
    }

    public class Student_yield
    {
        public static IEnumerable<Student> IteratorMethod(Student[] students)   //回傳IEnumerable,並實作yield return
        {
            for(int i=0;i<students.Length;i++)
            {
                if (students[i].Age >= 18)  //輸出大於18歲的學生資料
                    yield return students[i];
            }
        }
    }
}
