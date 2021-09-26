using System;
using System.Collections.Generic;
using System.Collections;

namespace C_Sharp_Iterator_Pattern_Exercise
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

            ClassStudent classStudent = new ClassStudent(students); //將students放入列舉

            foreach (Student student in classStudent)   //foreach調用IEnumerable與IEnumerator
            {
                Console.WriteLine(student);
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

    public class ClassStudent : IEnumerable<Student>
    {
        private ClassStudentEnum _classStudentEnum;

        public ClassStudent(Student[] students)
        {
            _classStudentEnum = new ClassStudentEnum(students); //產生IEnumerator的物件
        }

        public IEnumerator<Student> GetEnumerator() //此方法會被foreach調用,返回IEnumerator
        {
            return _classStudentEnum;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ClassStudentEnum : IEnumerator<Student>
    {
        private Student[] _students;
        private int index = -1;

        public ClassStudentEnum(Student[] students)
        {
            _students = students;   //取得Student[]
        }

        public Student Current  //返回搜尋的結果
        {
            get
            {
                return _students[index];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()   //釋放資源
        {
            _students = null;
        }

        public bool MoveNext()  //確認是否還有資料需要輸出
        {
            while (index < _students.Length - 1)
            {
                index++;
                if (_students[index].Age >= 18) //輸出大於18歲以上的學生資料
                    return true;
            }
            return false;
        }

        public void Reset() //設定列舉的初始位置
        {
            index = -1;
        }
    }
}