using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace dataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = GetTable();

            string drugRequired = default(string);

            while (drugRequired != "exit")
            {
                Console.Write("Please enter drug name to determine patient who requires it (type exit to stop): ");
                drugRequired = Console.ReadLine();
                if (drugRequired != "exit")
                {
                    var patient = (from DataRow dr in table.AsEnumerable()
                                   where dr.Field<string>("Drug").ToString() == drugRequired
                                   select dr).FirstOrDefault();
                    if (patient != null)
                        Console.WriteLine($"Patient who requires {drugRequired} is : {patient.Field<string>("Patient")}");
                    else
                        Console.WriteLine($"No Patient for drug {drugRequired} is currently in the system.");
                    Console.WriteLine();
                }
            }
            //Console.ReadKey();
        }

        private static DataTable GetTable()
        {
         
            DataTable table = createTable();            
            return table;
        }

        private static DataTable createTable()
        {
            // Create a DataTable with four columns;
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            

            // Add five Data Rows (data)
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);

            return table;
        }

        
    }
}
