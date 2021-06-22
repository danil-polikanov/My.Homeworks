-- 1.1
Select ProductID,Name,ProductNumber,Color FROM AdventureWorksLT2019.SalesLT.Product
--1.2
Select CustomerID,Customer.LastName,Customer.FirstName,Customer.MiddleName,Customer.FirstName,Customer.EmailAddress,Customer.Phone
FROM AdventureWorksLT2019.SalesLT.Customer
--2.1
SELECT ProductID,Product.Name,ProductNumber,Product.Color 
FROM AdventureWorksLT2019.SalesLT.Product
WHERE Product.Color IN('Black')
--2.2
SELECT ProductID,Product.Name,ProductNumber,Product.Color 
FROM AdventureWorksLT2019.SalesLT.Product
WHERE Product.Color IN ('Black','Silver')  OR Product.Color = ('Multi')
--2.3
SELECT ProductID,Product.Name,ProductNumber,Product.Color 
FROM AdventureWorksLT2019.SalesLT.Product
WHERE Product.Color IN ('Black')  OR Product.Color = ('Yellow')
--2.4
SELECT ProductID,Product.Name,ProductNumber,Product.Weight
FROM AdventureWorksLT2019.SalesLT.Product
WHERE Product.Weight Is null
--2.5
Select ProductID,Product.Name,ProductNumber,Product.Weight
FROM AdventureWorksLT2019.SalesLT.Product
Where Product.Weight>1000
--2.6
Select ProductID,Product.Name,ProductNumber,Product.Weight
FROM AdventureWorksLT2019.SalesLT.Product
Where Product.Weight<6000
--2.7
Select ProductID,Product.Name,ProductNumber,Product.Weight
FROM AdventureWorksLT2019.SalesLT.Product
WHERE Weight BETWEEN 2000.0 AND 5000;
--2.8
Select ProductID,Product.Name,ProductNumber
FROM AdventureWorksLT2019.SalesLT.Product
WHERE ProductNumber LiKE ('[BB-BK]%')
--2.9
Select ProductID,Product.Name,ProductNumber,Product.SellStartDate
FROM AdventureWorksLT2019.SalesLT.Product
WHERE Product.SellEndDate Is null
--3.1
SELECT ProductID,Product.Name,ProductNumber,Product.Color
FROM AdventureWorksLT2019.SalesLT.Product
ORDER BY Color
--3.2
SELECT ProductID,Product.Name,ProductNumber,Product.Color,Product.Weight
FROM AdventureWorksLT2019.SalesLT.Product
ORDER BY Color ASC,Weight DESC
--3.3
SELECT ProductID,Product.Name,ProductNumber,Product.Color,Product.Weight
FROM AdventureWorksLT2019.SalesLT.Product
ORDER BY ProductNumber ASC,Weight DESC
--4.1
SELECT TOP(10)*
FROM AdventureWorksLT2019.SalesLT.Product 
--4.2
SELECT TOP(10)*
FROM AdventureWorksLT2019.SalesLT.Product
ORDER BY Weight
--4.3
WITH SRC AS(
SELECT TOP(10)*
FROM AdventureWorksLT2019.SalesLT.Product
ORDER BY ProductID DESC
)
SELECT * FROM SRC
ORDER BY Weight
--4.4
SELECT*
FROM AdventureWorksLT2019.SalesLT.Product
ORDER BY Weight
OFFSET 10 ROWS FETCH NEXT 10 ROWS Only
--5.1
SELECT P.ProductID,P.Name,P.Color,P.Weight,S.UnitPrice,S.UnitPriceDiscount*100 As UnitPriceDiscount,'%'AS perc
FROM AdventureWorksLT2019.SalesLT.Product AS P,AdventureWorksLT2019.SalesLT.SalesOrderDetail AS S
JOIN SalesLT.Product ON SalesLT.Product.ProductID=S.ProductID
--5.2
SELECT C.CustomerID,C.LastName,C.MiddleName,C.FirstName,
C.EmailAddress,C.Phone,A.City,A.CountryRegion,A.PostalCode
,A.AddressLine1,A.AddressLine2,CA.AddressID,CA.CustomerID
FROM AdventureWorksLT2019.SalesLT.Customer AS C, 
AdventureWorksLT2019.SalesLT.Address AS A,AdventureWorksLT2019.SalesLT.CustomerAddress AS CA
--5.3
SELECT P.ProductID,P.Name,P.ProductNumber,P.ProductCategoryID,
PC.ParentProductCategoryID,PC.ProductCategoryID,PC.Name
FROM AdventureWorksLT2019.SalesLT.Product AS P,
AdventureWorksLT2019.SalesLT.ProductCategory AS PC
--6.1
SELECT COUNT(*) AS Productcount
FROM AdventureWorksLT2019.SalesLT.Product AS P
--6.2
SELECT COUNT(*) AS Productcount
FROM AdventureWorksLT2019.SalesLT.Product AS P
WHERE P.SellEndDate IS NOT null
--6.3
SELECT COUNT(*) AS Productcount
FROM AdventureWorksLT2019.SalesLT.Product AS P
WHERE P.Weight IS  null
--6.4
SELECT P.ProductModelID, AVG(P.Weight) AS AverageWeight
FROM AdventureWorksLT2019.SalesLT.Product AS P
WHERE Weight IS NOT null
GROUP BY P.ProductModelID
--6.5
SELECT AVG(P.Weight) AS AverageWeight
FROM AdventureWorksLT2019.SalesLT.Product AS P
WHERE P.Weight IS not null
--6.6
SELECT MIN(P.Weight) AS MaxWeight,MAX(P.Weight) AS MinWeight
FROM AdventureWorksLT2019.SalesLT.Product AS P
WHERE Weight IS NOT null
--6.7
SELECT P.ProductCategoryID,P.Name,COUNT(P.ProductCategoryID) AS CategoryCount,
SUM(P.Weight) AS SumCategory,
MAX(P.Weight) AS MaxCategory,MIN(P.Weight) AS MinCategory,AVG(P.Weight) AS AvgWeight
FROM AdventureWorksLT2019.SalesLT.Product AS P
GROUP BY P.ProductCategoryID,P.Name WITH ROLLUP
--6.8
SELECT P.ProductCategoryID,P.Name,COUNT(P.ProductCategoryID) AS CategoryCount,
SUM(P.Weight) AS SumCategory
FROM AdventureWorksLT2019.SalesLT.Product AS P
GROUP BY P.ProductCategoryID,P.Name WITH ROLLUP
--6.9
SELECT P.ProductCategoryID,P.Name,COUNT(P.ProductCategoryID) AS CategoryCount,
SUM(P.Weight) AS SumCategory,
MAX(P.Weight) AS MaxCategory,MIN(P.Weight) AS MinCategory,AVG(P.Weight) AS AvgWeight
FROM AdventureWorksLT2019.SalesLT.Product AS P
GROUP BY P.ProductCategoryID,P.Name WITH ROLLUP
HAVING SUM(P.Weight) IS NOT null AND MAX(P.Weight) IS NOT null
AND MIN(P.Weight) IS NOT null AND AVG(P.Weight) IS NOT null
--6.10
SELECT P.ProductCategoryID,P.Name,COUNT(P.ProductCategoryID) AS CategoryCount,
SUM(P.Weight) AS SumCategory,
MAX(P.Weight) AS MaxCategory,MIN(P.Weight) AS MinCategory,AVG(P.Weight) AS AvgWeight
FROM AdventureWorksLT2019.SalesLT.Product AS P
GROUP BY P.ProductCategoryID,P.Name WITH ROLLUP
HAVING SUM(P.Weight) IS NOT null AND MAX(P.Weight) IS NOT null
AND MIN(P.Weight) IS NOT null AND AVG(P.Weight) IS NOT null AND MAX(P.Weight)>10000
--7.1
SELECT 
PC.ProductCategoryID,PC.Name,SUM(SOD.LineTotal) AS TotalSold
FROM AdventureWorksLT2019.SalesLT.Product AS P
JOIN AdventureWorksLT2019.SalesLT.SalesOrderDetail AS SOD ON P.ProductID=SOD.ProductID
JOIN AdventureWorksLT2019.SalesLT.ProductCategory AS PC ON P.ProductCategoryID=PC.ProductCategoryID
GROUP BY PC.ProductCategoryID,PC.Name
--7.2
SELECT C.CustomerID,C.LastName,C.MiddleName,C.FirstName,SOD.UnitPriceDiscount
FROM AdventureWorksLT2019.SalesLT.Customer AS C
JOIN AdventureWorksLT2019.SalesLT.SalesOrderHeader AS SOH ON C.CustomerID=SOH.CustomerID
JOIN AdventureWorksLT2019.SalesLT.SalesOrderDetail AS SOD ON SOD.SalesOrderID=SOH.SalesOrderID
WHERE SOD.UnitPriceDiscount*100>=40
--7.3
SELECT C.CustomerID,C.LastName,C.FirstName,C.MiddleName,SOD.LineTotal
FROM SalesLT.Customer AS C
JOIN SalesLT.SalesOrderHeader AS SOH ON C.CustomerID=SOH.CustomerID
JOIN SalesLT.SalesOrderDetail AS SOD ON SOH.SalesOrderID=SOD.SalesOrderID
WHERE LineTotal>15000


































































