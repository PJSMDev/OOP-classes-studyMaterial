﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using D00_Utility;

namespace D13_AccessModifiers
{
    internal class User
    {
        /*
         * D13, criar a classe User:
         * 1 field para suportar a propriedade RegistrationDate
         *6 properties: Id, Name, Department, RegistrationDate (clássica),  Username e Password
         * 2 constructors
         * 2 methods: CreateUser e ListUser
        */
        #region Field
        private DateTime registrationDate;      // não usar _registrationDate -> deprecated!!!

        #endregion

        #region Classic properties
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }       // <- se fosse read-only, tirava isto
        }
        #endregion

        #region Auto-implemented properties
        public int Id { get; }      // read-only

        public string Name { get; set; }

        public string Department { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        #endregion



        #region Constructors
        public User() 
        {
            Id = 1;     // pq não vou conseguir atribuir-lhe um valor
            // os construtores é que vão lidar com a atribuição dos valores a fields read-only
            // usar valores anteriores como referência e incrementar
            Name = string.Empty;
            Department = string.Empty;
            // RegistrationDate = DateTime.MinValue;       // data vazia
            RegistrationDate = DateTime.Today;       // como DateTime.Now mas só para a data (e não a data e a hora)
            Username = string.Empty;
            Password = string.Empty;
        }

        public User(int id, string name, string department, DateTime regDate, string userName, string password)
        {
            Id = id;
            Name = name;
            Department = department;

            if (!DateTime.TryParse(regDate.ToString(), out DateTime dateParsed))
            {
                dateParsed = DateTime.Today;
            }
            RegistrationDate = dateParsed;

            Username = userName;
            Password = password;
        }
        #endregion

        #region Methods
        public void CreateUser()
        {
            Utility.WriteMessage("Name: ");
            Name = Console.ReadLine();

            Utility.WriteMessage("Department: ");
            Department = Console.ReadLine();

            DateTime dateParsed;
            Utility.WriteMessage("Data de registo: ");
            while (!DateTime.TryParse(Console.ReadLine(), out dateParsed))
            {
                Utility.WriteMessage("Data inválida. Tente novamente...", "", "\n");
            }

            Utility.WriteMessage("Username: ");
            Username = Console.ReadLine();

            Utility.WriteMessage("Password: ");
            Password = Console.ReadLine();
            Utility.WriteMessage("\n");
        }

        public void ListUser()
        {
            Utility.WriteTitle("List User");

            Utility.WriteMessage($"ID: {Id}\nName: {Name}\nDepartment: {Department}\nRegistration Date: {RegistrationDate.ToString("d")}\nUsername: {Username}\nPassword: {Password}");
        }
        #endregion
    }
}
