using System;
using DapperCrud.Models;

namespace DapperCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            DbActions db = new DbActions();
            int Id = 0;
            int chs = 0;
            while (true)
            {
                Console.WriteLine("Добро Пожаловать");
                db.Select().ForEach(s =>
                {
                    Console.WriteLine($"Id = {s.Id}\nFullName = {s.FullName}\nAge = {s.Age}");
                });
                Console.Write("You can add one enter 1 or Select one enter 2:");
                chs = int.Parse(Console.ReadLine());
                if (chs == 1)
                {
                    Student st = new Student();
                    Console.Write("Введите полное имя");
                    st.FullName = Console.ReadLine();
                    Console.Write("Введите Возраст:");
                    st.Age = int.Parse(Console.ReadLine());
                    db.Add(st);
                }
                else if (chs == 2)
                {
                    Console.WriteLine("Выберите один из них 1 или 2 :");
                    try
                    {
                        Id = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                    Console.Write("Ввыберите действие \nВы можете Удалить1 или Обновть2  \n1 for delete\n2 for update\n:");
                    try
                    {
                        chs = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Что-то пошло не так, пожалуйста, попробуйте еще раз");
                        continue;
                    }
                    if (chs == 1)
                    {
                        db.Delete(Id);
                        Console.Clear();
                        Console.WriteLine("Вы выбрали удалить ");
                        continue;
                    }
                    else if (chs == 2)
                    {
                        Student st = new Student();
                        st.Id = Id;
                        Console.WriteLine("Введите полное имя:");
                        st.FullName = Console.ReadLine();
                        bool z = true;
                        while (z)
                        {
                            Console.WriteLine("Введите Возраст");
                            try
                            {
                                st.Age = int.Parse(Console.ReadLine());
                                z = false;
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.Write("Произошла ошибка попробуйте еще раз!\n");
                                continue;
                            }
                        }
                        db.Update(st);
                        Console.Clear();
                    }
                }
            }
        }
    }
}
