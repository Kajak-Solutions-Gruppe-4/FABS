using FABS_DataAccess.DataAccess;
using FABS_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess
{
    class ConsoleMain
    {
        static void Main()
        {
            var pR = new PersonRepository();

            var res = pR.Get(2);

            var listRes = pR.GetAll();
            foreach (var item in listRes)
            {
                Console.WriteLine(item.FirstName);

            }

            Person person = new Person("Clara", "Friis", "98765432", 2, 1, false);
            pR.Insert(person);

        }

    }
}
