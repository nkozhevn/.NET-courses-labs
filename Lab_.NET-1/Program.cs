using System;

namespace Lab_.NET_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool trigger = true;
            while(trigger)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("Добавление контакта - 1");
                Console.WriteLine("Редактирование контакта - 2");
                Console.WriteLine("Просмотр всех контактов - 3");
                Console.WriteLine("Просмотр выбранного контакта - 4");
                Console.WriteLine("Удаление контакта - 5");
                Console.WriteLine("Выход - 6");

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
                        Contact.WatchAllContacts();
                        break;
                    case 4:
                        Contact.WatchContact();
                        break;
                    case 5:
                        Contact.DeleteContact();
                        break;
                    case 6:
                        trigger = false;
                        break;
                }
            }
        }
    }
}
