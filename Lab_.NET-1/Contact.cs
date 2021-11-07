using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_.NET_1
{
    class Contact
    {
        private static Dictionary<int, Contact> contactsList = new Dictionary<int, Contact>();
        private static int contactCount = 0;
        public static int ContactCount => contactCount;

        public static void CreateContact()
        {
            Console.WriteLine("\nСоздание нового контакта:");

            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            while(true)
            {
                if(surname == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!");
                    surname = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            while (true)
            {
                if (name == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!");
                    name = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Введите Отчество: ");
            string patronymic = Console.ReadLine();

            Console.Write("Введите номер телефона (начиная с 8): ");
            string phoneNumber = Console.ReadLine();
            while (true)
            {
                if (phoneNumber == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!");
                    phoneNumber = Console.ReadLine();
                }
                else if (Convert.ToInt64(phoneNumber) >= 80000000000 && Convert.ToInt64(phoneNumber) < 90000000000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введите телефонный номер, начиная с 8!");
                    phoneNumber = Console.ReadLine();
                }
            }

            Console.Write("Введите страну: ");
            string country = Console.ReadLine();
            while (true)
            {
                if (country == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!\n");
                    country = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Введите дату рождения: ");
            string birthDate = Console.ReadLine();

            Console.Write("Введите организацию: ");
            string organisation = Console.ReadLine();

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            Console.Write("Введите дополнительную информацию: ");
            string notes = Console.ReadLine();

            Contact contact = new Contact(surname, name, patronymic, phoneNumber, country, birthDate, organisation, position, notes);
            contactsList.Add(contact.Id, contact);
        }

        public static void EditContact()
        {
            Console.Write("\nВведите id контакта: ");
            string tempId = Console.ReadLine();
            int id;
            while (true)
            {
                if (int.TryParse(tempId, out int num))
                {
                    if(contactsList.ContainsKey(num))
                    {
                        id = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Контакта с данным идентефикатором не существует!");
                        tempId = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Введите id!");
                    tempId = Console.ReadLine();
                }
            }

            Console.WriteLine("Редактирование " + id + " контакта:");

            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            while (true)
            {
                if (surname == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!");
                    surname = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            while (true)
            {
                if (name == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!");
                    name = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Введите Отчество: ");
            string patronymic = Console.ReadLine();

            Console.Write("Введите номер телефона (начиная с 8): ");
            string phoneNumber = Console.ReadLine();
            while (true)
            {
                if (phoneNumber == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!");
                    phoneNumber = Console.ReadLine();
                }
                else if (Convert.ToInt32(phoneNumber) >= 80000000000 && Convert.ToInt32(phoneNumber) < 90000000000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введите телефонный номер, начиная с 8!");
                    phoneNumber = Console.ReadLine();
                }
            }

            Console.Write("Введите страну: ");
            string country = Console.ReadLine();
            while (true)
            {
                if (country == "")
                {
                    Console.WriteLine("Обязательное для заполнения поле!");
                    country = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Введите дату рождения: ");
            string birthDate = Console.ReadLine();

            Console.Write("Введите организацию: ");
            string organisation = Console.ReadLine();

            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            Console.Write("Введите дополнительную информацию: ");
            string notes = Console.ReadLine();

            contactsList[id].EditContact(surname, name, patronymic, phoneNumber, country, birthDate, organisation, position, notes);
        }

        public static void WatchContact()
        {
            Console.Write("\nВведите id контакта: ");
            string tempId = Console.ReadLine();
            int id;
            while (true)
            {
                if (int.TryParse(tempId, out int num))
                {
                    if (contactsList.ContainsKey(num))
                    {
                        id = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Контакта с данным идентефикатором не существует!");
                        tempId = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Введите id!");
                    tempId = Console.ReadLine();
                }
            }

            Console.WriteLine(contactsList[id]);
        }

        public static void WatchAllContacts()
        {
            Console.WriteLine("\nСписок всех контактов:");
            Dictionary<int, Contact>.KeyCollection contactsKeys = contactsList.Keys;
            foreach(int key in contactsKeys)
            {
                Console.WriteLine(contactsList[key].ToStringShort());
            }
        }

        public static void DeleteContact()
        {
            Console.Write("\nВведите id контакта: ");
            string tempId = Console.ReadLine();
            int id;
            while (true)
            {
                if (int.TryParse(tempId, out int num))
                {
                    if (contactsList.ContainsKey(num))
                    {
                        id = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Контакта с данным идентефикатором не существует!");
                        tempId = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Введите id!");
                    tempId = Console.ReadLine();
                }
            }

            contactsList.Remove(id);
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string BirthDate { get; set; }
        public string Organisation { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }

        public Contact(string surname, string name, string patronymic, string phoneNumber, string country, string birthDate, string organisation, string position, string notes)
        {
            contactCount++;
            Id = contactCount;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Country = country;
            BirthDate = birthDate;
            Organisation = organisation;
            Position = position;
            Notes = notes;
        }

        public override string ToString()
        {
            string result = "\nИнформация о контакте:";
            result += "\nid: " + Id;
            result += "\nФамилия: " + Surname;
            result += "\nИмя: " + Name;
            if (Patronymic != "")
            {
                result += "\nОтчество: " + Patronymic;
            }
            result += "\nТелефонный номер: " + PhoneNumber;
            result += "\nСтрана: " + Country;
            if (BirthDate != "")
            {
                result += "\nДата рождения: " + BirthDate;
            }
            if (Organisation != "")
            {
                result += "\nОрганизация: " + Organisation;
            }
            if (Position != "")
            {
                result += "\nДолжность: " + Position;
            }
            if (Notes != "")
            {
                result += "\nДополнительная информация: " + Notes;
            }
            return result;
        }

        public string ToStringShort()
        {
            string result = "\nКонтакт с id: " + Id;
            result += "\nФамилия: " + Surname;
            result += "\nИмя: " + Name;
            result += "\nТелефонный номер: " + PhoneNumber;
            return result;
        }

        public void EditContact(string surname, string name, string patronymic, string phoneNumber, string country, string birthDate, string organisation, string position, string notes)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Country = country;
            BirthDate = birthDate;
            Organisation = organisation;
            Position = position;
            Notes = notes;
        }
    }
}
