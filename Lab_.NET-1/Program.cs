using System;

namespace Lab_.NET_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("Добавление контакта - 1");
                Console.WriteLine("Редактирование контакта - 2");
                Console.WriteLine("Просмотр контакта - 3");
                Console.WriteLine("Удаление контакта - 4");

                Console.Write("Введите команду: ");
                string tempCom = Console.ReadLine();
                int com;
                while (true)
                {
                    if (int.TryParse(tempCom, out int num))
                    {
                        com = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите номер комманды!");
                        tempCom = Console.ReadLine();
                    }
                }

                switch(com)
                {
                    case 1:
                        Contact.CreateContact();
                        break;
                    case 2:
                        Contact.EditContact();
                        break;
                    case 3:
                        Contact.WatchContact();
                        break;
                    case 4:
                        Contact.DeleteContact();
                        break;
                }
            }
        }
    }
}
