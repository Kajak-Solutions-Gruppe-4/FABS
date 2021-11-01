using FABS_DataAccess.DataAccess;
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

        }

    }
}
