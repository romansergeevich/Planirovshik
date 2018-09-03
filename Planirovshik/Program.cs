using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planirovshik.DataModel;

namespace Planirovshik
{
    class Program
    {
        static void Main(string[] args)  
        {
            using (PlanirovshikContext planirovka = new PlanirovshikContext())
            {
                Plan plan = new Plan();
                Console.WriteLine("Введите 1 для записи нового плана на день");
                Console.WriteLine("Введите 2 для чтение всех планов");
                Console.WriteLine("Введите 3 для удаление плана из планировщика");
                Console.WriteLine("Введите 4 для измененния плана в планировщике");
                for (int i = 0; i < 999; i++)
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            Console.WriteLine("Введите день недели и событие");
                            string m = Console.ReadLine();
                            string p = Console.ReadLine();
                            plan.Den = m;
                            plan.PlanNaden = p;
                            planirovka.Plans.Add(plan);
                            planirovka.SaveChanges();

                            break;
                        case 2:
                            var planss = planirovka.Plans;
                            Console.WriteLine("Список планов");
                            foreach (Plan u in planss)
                            {
                                Console.WriteLine("{0},{1}-{2}", u.PlanId, u.Den, u.PlanNaden);
                            }

                            break;
                        case 3:
                            Console.WriteLine("Введите номер события, который хотите удалить");
                            int w = Convert.ToInt32(Console.ReadLine());
                            Plan delplan = new Plan() { PlanId = w };
                            planirovka.Plans.Attach(delplan);
                            planirovka.Plans.Remove(delplan);
                            planirovka.SaveChanges();


                            break;
                        case 4:
                            Console.WriteLine("Введите номер события, который хотите изменить");
                            int k = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите день недели и событие");
                            string a = Console.ReadLine();
                            string b = Console.ReadLine();
                            var plaaaan = planirovka.Plans
                             .Where(c => c.PlanId == k)
                             .FirstOrDefault();
                            plaaaan.Den = a;
                            plaaaan.PlanNaden = b;

                         
                            planirovka.SaveChanges();


                            break;
                        default:
                            Console.WriteLine("Вы выбрали неправильную операцию");
                            break;





                    }


                }

            }
            Console.ReadKey();



        }

        
    }
}
    