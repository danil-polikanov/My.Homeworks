using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHomework
{
    class Manager
    {
        string connectionString { get; set; } = @"Server=DESKTOP-BNTF795;Database=AdventureWorksLT2019;Trusted_Connection=True";
        public ArrayList GetSortingTable_SecondTask()
        {
            ArrayList table = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT [ProductID],[Product].[Name],[ProductNumber],[Product].[Color],[Product].[Weight] FROM [SalesLT].[Product] ORDER BY [Product].[Color] ASC,[Product].[Weight] DESC";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string color;
                        decimal Weight;
                        string columnName1 = reader.GetName(0);
                        string columnName3 = reader.GetName(2);
                        string columnName4 = reader.GetName(3);
                        string columnName5 = reader.GetName(4);
                        string columnName2 = reader.GetName(1);
                        string[] columns = new string[] { columnName1, columnName3,columnName5, columnName4, columnName2 };
                        table.Add(columns);
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);

                            string name = reader.GetString(1);

                            string ProductNumber = reader.GetString(2);

                            if (!reader.IsDBNull(3)) color = reader.GetString(3);
                            else color = "null";
                            
                            if (!reader.IsDBNull(4)) Weight = reader.GetDecimal(4);
                            else Weight = 0;
                            table.Add(id);                          
                            table.Add(ProductNumber);
                            table.Add(color);
                            table.Add(Weight);
                            table.Add(name);
                        }
                    }
                    reader.Close();
                    return table;
                }
            }
        }
        public void ShowTable(ArrayList table)
        {
            string[] columns = (string[])table[0];
            foreach (string i in columns)
            {
                if(i==columns[0])
                Console.Write(i + "\t");
                else
                Console.Write(i + "\t\t  ");
            }
            Console.WriteLine();
            table.RemoveAt(0);
            foreach (var i in table)
            {
                if (table.IndexOf(i) % columns.Count()==0&&table.IndexOf(i)!=0)
                {
                    Console.WriteLine("\n");
                }
                 Console.Write(i + "\t\t  ");             
            }

        }
        public ArrayList JoinsFirstTask()
        {
            ArrayList table = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT P.ProductID,P.Name,P.Color,P.Weight,S.UnitPrice,S.UnitPriceDiscount*100 As UnitPriceDiscount,'%'AS perc FROM AdventureWorksLT2019.SalesLT.Product AS P,AdventureWorksLT2019.SalesLT.SalesOrderDetail AS S JOIN SalesLT.Product ON SalesLT.Product.ProductID = S.ProductID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string color;
                        string name;
                        decimal weight;
                        decimal unitPrice;
                        decimal unitPriceDiscount;
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                        string columnName4 = reader.GetName(3);
                        string columnName5 = reader.GetName(4);
                        string columnName6 = reader.GetName(5);
                        string[] columns = new string[] { columnName1, columnName3, columnName4, columnName5, columnName6, columnName2 };
                        table.Add(columns);
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) name = reader.GetString(1);
                            else name = "null";
                            if (!reader.IsDBNull(2)) color = reader.GetString(2);
                            else color = "null";
                            if (!reader.IsDBNull(3)) weight = reader.GetDecimal(3);
                            else weight = 0;
                            if (!reader.IsDBNull(4)) unitPrice = reader.GetDecimal(4);
                            else unitPrice = 0;
                            if (!reader.IsDBNull(5)) unitPriceDiscount = reader.GetDecimal(5);
                            else unitPriceDiscount = 0;
                            table.Add(id);
                            table.Add(color);
                            table.Add(weight);
                            table.Add(unitPrice);
                            table.Add(unitPriceDiscount);
                            table.Add(name);
                        }
                    }
                    reader.Close();
                    return table;
                }
            }
        }
        public ArrayList SixPointSix()
        {
            ArrayList table = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT MIN(P.Weight) AS MaxWeight,MAX(P.Weight) AS MinWeight FROM AdventureWorksLT2019.SalesLT.Product AS P WHERE Weight IS NOT null";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        decimal productModelid;
                        decimal averageWeight;                       
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);                 
                        string[] columns = new string[] { columnName1,columnName2 };
                        table.Add(columns);
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) productModelid = reader.GetDecimal(0);
                            else productModelid = 0;
                            if (!reader.IsDBNull(1)) averageWeight = reader.GetDecimal(1);
                            else averageWeight = 0;
                            table.Add(productModelid);
                            table.Add(averageWeight);
                        }
                    }
                    reader.Close();
                    return table;
                }
            }
        }
        public ArrayList SevenPointOne()
        {
            ArrayList table = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT PC.ProductCategoryID,PC.Name,SUM(SOD.LineTotal) AS TotalSold FROM AdventureWorksLT2019.SalesLT.Product AS P JOIN AdventureWorksLT2019.SalesLT.SalesOrderDetail AS SOD ON P.ProductID = SOD.ProductID JOIN AdventureWorksLT2019.SalesLT.ProductCategory AS PC ON P.ProductCategoryID = PC.ProductCategoryID GROUP BY PC.ProductCategoryID,PC.Name";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        int productCategoryID;
                        string name;
                        decimal totalSold;
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                        string[] columns = new string[] { columnName1, columnName2, columnName3 };
                        table.Add(columns);
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) productCategoryID = reader.GetInt32(0);
                            else productCategoryID = 0;
                            if (!reader.IsDBNull(1)) name = reader.GetString(1);
                            else name="null";
                            if (!reader.IsDBNull(1)) totalSold = reader.GetDecimal(2);
                            else totalSold = 0;
                            table.Add(productCategoryID);
                            table.Add(name);
                            table.Add(totalSold);
                            
                        }
                    }
                    reader.Close();
                    return table;
                }
            }
        }
        public ArrayList SevenPointTwo()
        {
            ArrayList table = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT C.CustomerID,C.LastName,C.MiddleName,C.FirstName,SOD.UnitPriceDiscount FROM AdventureWorksLT2019.SalesLT.Customer AS C JOIN AdventureWorksLT2019.SalesLT.SalesOrderHeader AS SOH ON C.CustomerID = SOH.CustomerID JOIN AdventureWorksLT2019.SalesLT.SalesOrderDetail AS SOD ON SOD.SalesOrderID = SOH.SalesOrderID WHERE SOD.UnitPriceDiscount * 100 >= 40";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string lastName;
                        string middleNAme;
                        string FirstName;
                        decimal UnitPriceDiscount;
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                        string columnName4 = reader.GetName(3);
                        string columnName5 = reader.GetName(4);
                        string[] columns = new string[] { columnName1, columnName2, columnName3, columnName4 , columnName5};
                        table.Add(columns);
                        while (reader.Read())
                        {
                            int custmoerId = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) lastName = reader.GetString(1);
                            else lastName = "null";
                            if (!reader.IsDBNull(2)) middleNAme = reader.GetString(2);
                            else middleNAme = "null";
                            if (!reader.IsDBNull(3)) FirstName = reader.GetString(3);
                            else FirstName = "null";
                            if (!reader.IsDBNull(4)) UnitPriceDiscount = reader.GetDecimal(4);
                            else UnitPriceDiscount = 0;
                            table.Add(custmoerId);
                            table.Add(lastName);
                            table.Add(middleNAme);
                            table.Add(FirstName);
                            table.Add(UnitPriceDiscount);
                        }
                    }
                    reader.Close();
                    return table;
                }
            }
        }
        public ArrayList SevenPointThree()
        {
            ArrayList table = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT C.CustomerID,C.LastName,C.FirstName,C.MiddleName,SOD.LineTotal FROM SalesLT.Customer AS C JOIN SalesLT.SalesOrderHeader AS SOH ON C.CustomerID = SOH.CustomerID JOIN SalesLT.SalesOrderDetail AS SOD ON SOH.SalesOrderID = SOD.SalesOrderID WHERE LineTotal> 15000";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string LastName;
                        string MiddleName;
                        string FirstName;
                        decimal LineTotal;
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                        string columnName4 = reader.GetName(3);
                        string columnName5 = reader.GetName(4);
                        string[] columns = new string[] { columnName1, columnName2, columnName3, columnName4, columnName5 };
                        table.Add(columns);
                        while (reader.Read())
                        {
                            int customerId = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) LastName = reader.GetString(1);
                            else LastName = "null";
                            if (!reader.IsDBNull(2)) MiddleName = reader.GetString(2);
                            else MiddleName = "null";
                            if (!reader.IsDBNull(3)) FirstName = reader.GetString(3);
                            else FirstName = "null";
                            if (!reader.IsDBNull(4)) LineTotal = reader.GetDecimal(4);
                            else LineTotal = 0;
                            table.Add(customerId);
                            table.Add(LastName);
                            table.Add(MiddleName);
                            table.Add(FirstName);
                            table.Add(LineTotal);

                        }
                    }
                    reader.Close();
                    return table;
                }
            }
        }
    }

}


