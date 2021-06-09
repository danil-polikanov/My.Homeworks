using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHomework
{
    class Manager
    {
        public void Sorting_SecondTask()
        {
            string connectionString = @"Server=DESKTOP-BNTF795;Database=AdventureWorksLT2019;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT [ProductID],[Product].[Name],[ProductNumber],[Product].[Color],[Product].[Weight] FROM [SalesLT].[Product] ORDER BY [Product].[Color] ASC,[Product].[Weight] DESC";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // выводим названия столбцов
                        //Console.WriteLine("{0}\t\t\t\t{1}\t\t\t\t{2}\t\t{3}\t\t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));

                        while (reader.Read())
                        {
                            object id = reader.GetValue(0);
                            object name = reader.GetValue(1);
                            object ProductNumber = reader.GetValue(2);
                            object color = reader.GetValue(3);
                            object Weight = reader.GetValue(4);

                            //Console.WriteLine("{0} \t\t\t\t{1}\t\t\t\t{2}\t\t{3}\t\t{4}", id, name, ProductNumber, color, Weight);
                        }
                    }
                    reader.Close();
                }
            }
        }
        public void JoinsFirstTask()
        {
            string connectionString = @"Server=DESKTOP-BNTF795;Database=AdventureWorksLT2019;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT P.ProductID,P.Name,P.Color,P.Weight,S.UnitPrice,S.UnitPriceDiscount*100 As UnitPriceDiscount,'%'AS perc FROM AdventureWorksLT2019.SalesLT.Product AS P,AdventureWorksLT2019.SalesLT.SalesOrderDetail AS S JOIN SalesLT.Product ON SalesLT.Product.ProductID = S.ProductID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        //Console.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t{3}\t\t{4}\t{5}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5));

                        while (reader.Read())
                        {
                            object id = reader.GetValue(0);
                            object name = reader.GetValue(1);
                            object color = reader.GetValue(2);
                            object weight = reader.GetValue(3);
                            object unitPrice = reader.GetValue(4);
                            object unitPriceDiscount = reader.GetValue(5);

                            //Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}\t\t{4}\t{5}", id, name, color, weight, unitPrice, unitPriceDiscount);
                        }
                    }
                    reader.Close();
                }
            }
        }
        public void SixPointSix()
        {
            string connectionString = @"Server=DESKTOP-BNTF795;Database=AdventureWorksLT2019;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT MIN(P.Weight) AS MaxWeight,MAX(P.Weight) AS MinWeight FROM AdventureWorksLT2019.SalesLT.Product AS P WHERE Weight IS NOT null";
                 connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                        while (reader.Read())
                        {
                            object productModelid = reader.GetValue(0);
                            object averageWeight = reader.GetValue(1);


                            //Console.WriteLine("{0}\t\t{1}", productModelid, averageWeight);
                        }
                    }
                    reader.Close();
                }
            }
        }
        public void SevenPointOne()
        {
            string connectionString = @"Server=DESKTOP-BNTF795;Database=AdventureWorksLT2019;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT PC.ProductCategoryID,PC.Name,SUM(SOD.LineTotal) AS TotalSold FROM AdventureWorksLT2019.SalesLT.Product AS P JOIN AdventureWorksLT2019.SalesLT.SalesOrderDetail AS SOD ON P.ProductID = SOD.ProductID JOIN AdventureWorksLT2019.SalesLT.ProductCategory AS PC ON P.ProductCategoryID = PC.ProductCategoryID GROUP BY PC.ProductCategoryID,PC.Name";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        //Console.WriteLine("{0}\t{1}\t\t\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                        while (reader.Read())
                        {
                            object productCategoryID = reader.GetValue(0);
                            object name = reader.GetValue(1);
                            object totalSold = reader.GetValue(2);
                         

                            //Console.WriteLine("{0}\t\t\t{1}\t\t{2}", productCategoryID, name, totalSold);
                        }
                    }
                    reader.Close();
                }
            }
        }
        public void SevenPointTwo()
        {
            string connectionString = @"Server=DESKTOP-BNTF795;Database=AdventureWorksLT2019;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT C.CustomerID,C.LastName,C.MiddleName,C.FirstName,SOD.UnitPriceDiscount FROM AdventureWorksLT2019.SalesLT.Customer AS C JOIN AdventureWorksLT2019.SalesLT.SalesOrderHeader AS SOH ON C.CustomerID = SOH.CustomerID JOIN AdventureWorksLT2019.SalesLT.SalesOrderDetail AS SOD ON SOD.SalesOrderID = SOH.SalesOrderID WHERE SOD.UnitPriceDiscount * 100 >= 40";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));

                        while (reader.Read())
                        {
                            object customerID = reader.GetValue(0);
                            object lastName = reader.GetValue(1);
                            object middleNAme = reader.GetValue(2);
                            object FirstName = reader.GetValue(3);
                            object UnitPriceDiscount = reader.GetValue(4);

                            //Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}\t\t{4}", customerID, lastName, middleNAme, FirstName, UnitPriceDiscount );
                        }
                    }
                    reader.Close();
                }
            }
        }
        public void SevenPointThree()
        {
            string connectionString = @"Server=DESKTOP-BNTF795;Database=AdventureWorksLT2019;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT C.CustomerID,C.LastName,C.FirstName,C.MiddleName,SOD.LineTotal FROM SalesLT.Customer AS C JOIN SalesLT.SalesOrderHeader AS SOH ON C.CustomerID = SOH.CustomerID JOIN SalesLT.SalesOrderDetail AS SOD ON SOH.SalesOrderID = SOD.SalesOrderID WHERE LineTotal> 15000";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));

                        while (reader.Read())
                        {
                            object id = reader.GetValue(0);
                            object name = reader.GetValue(1);
                            object color = reader.GetValue(2);
                            object weight = reader.GetValue(3);
                            object unitPrice = reader.GetValue(4);

                            //Console.WriteLine("{0}\t\t{1}\t\t{2}\t{3}\t\t\t{4}", id, name, color, weight, unitPrice);
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
}
