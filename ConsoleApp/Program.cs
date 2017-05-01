using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("begin ");
            //test zone

            Employe e = new Employe() { Matr = 1,Poste = "post" ,NomE ="oussama",Salaire=1000,Comm = 10,DateEmb="10/10/2017",_Departement = new Departement() { NumDept=10},Emp_Sup = new Employe() { Matr = 1020} };
            Employe.InsertEmploye(e);
            //end test zone
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}
