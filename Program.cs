using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static string conectionString = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=Sql_Home;Trusted_Connection=yes;";


        static void Main(string[] args)
        {
            List<Area> areas = GetAreas();

            //var query1 = areas.Where(w => w.TypeArea == 1).OrderBy(o => o.FullName).ToList();
            //foreach(var item in query1)
            //{
            //    Console.WriteLine($"Name: {item.Name}");
            //    Console.WriteLine($"IP: {item.IP}");
            //    Console.WriteLine(item.FullName);
            //    Console.WriteLine();
            //}

            //var query2 = from a in areas
            //             where a.ParentId == 0
            //             select a;

            //foreach (var item in query2)
            //{
            //    Console.WriteLine($"Name: {item.Name}");
            //    Console.WriteLine($"IP: {item.IP}");
            //Console.WriteLine();
            //}


            //Я не знаю как сделать это задание правильно, я мог бы в подзапросе отсечь все нечетные числа, но в запросе
            //уже PavilionId не сможет сравнить себя с массивом данных и по любому приходиться сравнивать с тремя элементами массива

            //int[] Pavilion = new int[6]
            //{
            //    1,
            //    2,
            //    3,
            //    4,
            //    5,
            //    6
            //};

            //var query3 = areas.Where(w => w.PavilionId == Pavilion[1] || w.PavilionId == Pavilion[3] || w.PavilionId == Pavilion[5]);

            //foreach (var item in query3)
            //{
            //    Console.WriteLine($"Name: {item.Name}");
            //    Console.WriteLine($"PavilionId: {item.PavilionId}");
            //    Console.WriteLine($"IP: {item.IP}");
            //    Console.WriteLine();
            //}


            //var query4 = from a in areas
            //             where a.PavilionId == Pavilion[1] || a.PavilionId == Pavilion[3] || a.PavilionId == Pavilion[5]
            //             select a;
            //foreach (var item in query4)
            //{
            //    Console.WriteLine($"Name: {item.Name}");
            //    Console.WriteLine($"PavilionId: {item.PavilionId}");
            //    Console.WriteLine($"IP: {item.IP}");
            //    Console.WriteLine();
            //}

            //var query5 = from a in areas
            //             let WP = a.WorkingPeople > 1
            //             where WP == true
            //             select a;

            //foreach (var item in query5)
            //{
            //    Console.WriteLine($"Name: {item.Name}");
            //    Console.WriteLine($"PavilionId: {item.PavilionId}");
            //    Console.WriteLine($"WorkingPeople: {item.WorkingPeople}");
            //    Console.WriteLine($"IP: {item.IP}");
            //    Console.WriteLine();
            //}

            //var query6 = from a in areas
            //             select a
            //             into wer
            //             where wer.Dependence > 1
            //             select wer;
                         
            //foreach (var item in query6)
            //{
            //    Console.WriteLine($"Name: {item.Name}");
            //    Console.WriteLine($"Dependence: {item.Dependence}");
            //    Console.WriteLine($"PavilionId: {item.PavilionId}");
            //    Console.WriteLine($"WorkingPeople: {item.WorkingPeople}");
            //    Console.WriteLine($"IP: {item.IP}");
            //    Console.WriteLine();
            //}
        }

        public static List<Area> GetAreas()
        {
            List<Area> areas = new List<Area>();

            using (SqlConnection con = new SqlConnection(conectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Area";

                var reder = cmd.ExecuteReader();
                while (reder.Read())
                {
                    Area area = new Area();
                    area.TypeArea = Convert.ToInt32(reder["TypeArea"]);
                    area.IP = reder[9].ToString();
                    area.Name = reder[2].ToString();
                    area.FullName = reder[6].ToString();
                    area.ParentId = Convert.ToInt32(reder[3]);
                    area.PavilionId = Convert.ToInt32(reder[10]);
                    area.WorkingPeople = Convert.ToInt32(reder[14]);
                    area.Dependence = Convert.ToInt32(reder[13]);

                    areas.Add(area);
                }
            }

            return areas;
        }
    }
}
