--Create database 
create database TechShop

--Create Table Customers
create table Customers(CustomerID int primary key,
FirstName varchar(50) ,
LastName  varchar(50) ,
Email varchar(50)  ,
phone char(10) ,
Address varchar(100) )

alter table customers
add total_order int

alter table customers
add constraint UK_customers_email UNIQUE (email)


--Create table Products
create table Products(ProductID int  primary key,
ProductName varchar(50) ,
Category varchar(50),
Description text ,
Price int)

alter table Products add constraint CK_Products_Price
check(Price>0)

--Create table Orders
create table Orders (OrderID int primary key,
CustomerID int not null foreign key references Customers(CustomerID),
OrderDate date not null,
TotalAmount decimal(10,3))

  --Create Table orderdetails  
  create table OrderDetails(OrderDetailID int primary key,
  OrderID int not null foreign key references Orders(OrderID),
  ProductID int  not null foreign key references Products(ProductID),
  Quantity int )

  --Create table Inventory
  create table Inventories (InventoryID int primary key,
  ProductID int not null foreign key references Products(ProductID),
  QuantityInStock int ,
  LastStockUpdate date)

  

 -- Insert at least 10 sample records into each of the following tables.

 -- insert into customers table

insert into Customers values(1,'Arun','Prasad','arun23@gmail.com','9012365456','4,Besant Nagar,Chennai'),
                            (2,'Revathi','E','revathie05@gmail.com','9048024663','7,Mariyappanpillai Nagar,Namakkal'),
                             (3,'Bhaviyazhini','A', 'bhavi001@gmail.com','6985741254','5,Aarya nagar,Karur'),
                             (4,'Rakshana','A','arrbaalayam@gmail.com','9945687336','31,Bajanamada street,Namakkal'),
                             (5,'Shalini','S','shalini3344@gmail.com','9576841235','46,Aaliya nagar,Salem'),
                             (6,'Devadharshini','S','devadharshini345@gmail.com','9945615784','25,Sarojini nagar,Bangalore'),
                             (7,'Vivetha','Harini','viveaarthi25@gmail.com','9956874565','34,Anna Nagar,Chennai'),
                             (8,'Sudha','B','sudha23@gmail.com','7845961235','45,Ganghiji nagar,Chennai'),
                             (9,'Ramesh','S','sramesh78@gmail.com','9564125784','89,kk nagar,Bangalore'),
                             (10,'Raju','R','rraju345@gmail.com','8546791256','85,Rajaji nagar,Kerala'),
                             (11,'Vasu','S','vasus@gmail.com','9654781236','96,RK nagar,Chennai'),
                             (12,'Kiran','Mehta','kiranm@gmail.com','7845129632','23,Ashok Nagar,Chennai')

 

 select * from Customers

  -- insert into Products table
 insert into Products values (102,'Powerbank','Mobile Accessories','Portable powerbank with high-capacity battery, fast charging support, compact design, and multiple ports for charging smartphones and other devices',500),
                             (105,'Smart watches','Wearable Devices ','Smartwatch with fitness tracking, heart rate monitor, alerts, and customizable watch faces',2000),
                             (202,'Wireless Earbuds','Mobile Accessories','Compact Bluetooth earbuds with clear sound, noise cancellation, and long battery life',1000),
                             (506,'Keyboards','Computer Accessories','Ergonomic and responsive keyboard designed for smooth typing experience. Available in wired and wireless models, suitable for office work, gaming, or home use with durable key switches',2000),
                             (205,'Mouse','Computer Accessories','Precision optical mouse with ergonomic design for comfortable grip and smooth cursor control. Available in wired and wireless options, ideal for daily use and professional tasks',700),
                             (702,'Decorative lights','Home Electronics','Stylish decorative lamps perfect for enhancing home ambiance. Available in various shapes and colors with LED bulbs, ideal for festivals, bedrooms, or living spaces',4500),
                             (802,'LED Bulbs','Home Electronics','Energy-efficient LED lights providing bright illumination with low power consumption. Ideal for homes, offices, and commercial use. Long-lasting and eco-friendly alternative to traditional lighting',250),
                             (900,'webcam','Mobile Accessories','High-resolution webcam with built-in microphone for smooth video calls, online meetings, and streaming. Compatible with most devices, offering plug-and-play convenience and clear image quality',5000),
                             (603,'solar lights','Renewable Energy Devices','Solar-powered, eco-friendly lights with automatic charging. Ideal for gardens and outdoor use. Weatherproof and energy-saving',6000),
                             (305,'Hair Dryer','Personal Care Electronics','Compact and powerful hair dryer with adjustable heat and speed settings. Designed for quick drying and styling with safety features and lightweight body for easy handling',7000)

select * from Products
 -- insert into orders table
insert into Orders values(7745,4,'2025-06-12',9000),
                         (5492,5,'2024-05-08',950),
                          (6542,6,'2024-11-21',5000),
                          (2156,3,'2022-09-01',6000),
                          (3124,2,'2022-11-12',500),
                          (3755,1,'2025-05-06',4500),
                          (4102,8,'2024-08-07',2000),
                          (4503,9,'2024-10-25',3000),
                          (4679,7,'2024-12-07',3500),
                          (5167,1,'2025-04-02',700)

insert into Orders values(1125,5,'2021-11-20',1400)
insert into orders values(2245,6,'2022-04-21',1000)
select * from Orders

alter table orders 
add order_status varchar(30)
UPDATE Orders
SET order_status = 'pending'
WHERE OrderID = 7745;

UPDATE Orders
SET order_status = 'shipped'
WHERE OrderID IN (5492, 6542, 2156, 3142, 4102, 4503, 4679, 5167,1125,2245,3124);

UPDATE Orders
SET order_status = 'Processing'
WHERE OrderID = 3755;


-- insert into orders table
 insert into OrderDetails values(8854,2156,603,1),
                                 (5546,3124,802,2),
                                 (5586,3755,702,1),
                                 (4500,4102,506,1),
                                 (5674,4503,105,1),
                                 (5675,4503,102,2),
                                 (6987,4679,506,1),
                                 (6988,4679,202,1),
                                 (6989,4679,102,1),
                                 (7789,5167,205,1),
                                 (8865,5492,205,1),
                                 (8866,5492,802,1),
                                 (9945,6542,900,1),
                                 (9561,7745,702,2),
                                 (2245,1125,205,2)


  

  -- insert into inventory table
  insert into Inventories values(1,102,20,'2025-06-10'),
                               (2,105,60,'2025-06-11'),
                               (3,202,10,'2025-05-20'),
                               (4,205,15,'2025-04-03'),
                               (5,305,12,'2025-06-01'),
                               (6,506,19,'2025-05-30'),
                               (7,603,23,'2025-06-03'),
                               (8,702,25,'2025-05-22'),
                               (9,802,5,'2025-05-23'),
                               (10,900,8,'2025-06-15')

  select * from orders

  


-- 1. Write an SQL query to retrieve the names and emails of all customers

 select Firstname+' ' +Lastname as CustomerName,Email from Customers

 --2.Write an SQL query to list all orders with their order dates and corresponding customer names. 

select  o.OrderDate ,concat (c.FirstName,' ',c.LastName) as CustomerName from orders o
join customers c on  c.CustomerID=o.CustomerID
group by c.FirstName,c.LastName,OrderDate


  --3.Write an SQL query to insert a new customer record into the "Customers" table. Include 
--customer information such as name, email, and address
 
    insert into Customers (customerid,FirstName,LastName,Email,address) values ('13','Samaya','S','samayas56@gmail.com','59,Aditi Nagar,Erode')

  --4.Write an SQL query to update the prices of all electronic gadgets in the "Products" table by 
--increasing them by 10%

    update Products set Price=Price*1.10 

  --5.Write an SQL query to delete a specific order and its associated order details from the 
--"Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter. **

    declare @value int
     set @value=6542

    delete from OrderDetails where OrderID=@value
    delete from Orders where OrderID=@value


 --6.Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information.
  
    insert into Orders values(7755,10,'2025-06-12',6600,'pending')

 -- 7. Write an SQL query to update the contact information (e.g., email and address) of a specific 
--customer in the "Customers" table. Allow users to input the customer ID and new contact 
--information. 
     declare @customerid int
     set @customerid=13
     declare @new_email varchar(50)
     set @new_email='kiranss23@gmail.com'
     declare @new_address varchar(50)
     set @new_address='26,Valli nagar,delhi'
      
      update customers 
      set email=@new_email,address=@new_address 
      where customerid=@customerid

      

  -- 8.Write an SQL query to recalculate and update the total cost of each order in the "Orders" 
--table based on the prices and quantities in the "OrderDetails" table

update orders set TotalAmount=
(select sum(od.quantity*p.price) as total_cost from products p
join orderdetails od on
p.productid=od.productid where 
od.orderid=orders.orderid)

   -- 9.Write an SQL query to delete all orders and their associated order details for a specific 
--customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID 
--as a parameter 
 declare @customerid int
 set @customerId= 9
 
 delete from Orderdetails where orderid in 
 (select orderid from orders where customerid= @customerid)
 delete from  orders where customerid=@customerid



    --10.Write an SQL query to insert a new electronic gadget product into the "Products" table, 
--including product name, category, price, and any other relevant details
       
       insert into Products values(11,'air cooler','cooling appliances','An air cooler cools the air using water evaporation, offering energy-efficient and eco-friendly cooling',4000)


  --  11.Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from 
--"Pending" to "Shipped"). Allow users to input the order ID and the new status. 
     declare @orderid int 
     set @orderid=3755
     declare @new_status varchar(20)
     set @new_status='shipped'
      update Orders set order_status=@new_status where orderid=@orderid

    --12.Write an SQL query to calculate and update the number of orders placed by each customer 
--in the "Customers" table based on the data in the "Orders" table 

update customers set total_order=
(select count(orderid) from orders
where orders.customerid=customers.customerid)

--Task 3. Aggregate functions, Having, Order By, GroupBy and Joins: 


-- 1.Write an SQL query to retrieve a list of all orders along with customer information (e.g., 
--customer name) for each order
Select concat(c.FirstName,' ' ,c.LastName) as CustomerName,o.orderid,o.orderDate,o.TotalAmount from orders o join customers c on c.CustomerID=o.CustomerID
    

    --2.Write an SQL query to find the total revenue generated by each electronic gadget product. 
--Include the product name and the total revenue
select p.ProductName,sum(od.Quantity*p.price)  as Total_revenue from Products p join OrderDetails od  on p.ProductID= od.ProductID group by p.ProductName
  
 --3 Write an SQL query to list all customers who have made at least one purchase. Include their 
--names and contact information
 Select concat (c.FirstName,' ',c.LastName)as CustomerName,c.phone,count(o.OrderId) as TotalOrders from Customers c 
 join  Orders o 
 on o.CustomerId=c.CustomerId 
 group by c.FirstName,c.lastname,c.phone
 having count(o.orderid)>=1


 
 select * from orders
 select * from customers

 --4.Write an SQL query to find the most popular electronic gadget, which is the one with the highest 
--total quantity ordered. Include the product name and the total quantity ordered

   select top 1 p.ProductName,sum (od.quantity) as Totalquantity from Products p join OrderDetails od on od.ProductId=p.ProductId group by p.productname  order by Totalquantity desc


 --5.Write an SQL query to retrieve a list of electronic gadgets along with their corresponding categories.
 select Productname ,Category from  Products


 --6.Write an SQL query to calculate the average order value for each customer. Include the 
--customer's name and their average order value 

   select c.customerid, concat(c.FirstName,' ',c.LastName) as customername,cast(sum(p.price*od.quantity)  /count(distinct o.orderid)  as decimal(10,2)) as total_average from Customers c 
   join  orders o on o.customerid=c.customerid
   join orderdetails od on od.orderid=o.orderid
   join products p on p.productid=od.productid
   group by c.Firstname,c.lastname,c.customerid


   --7.Write an SQL query to find the order with the highest total revenue. Include the order ID, 
--customer information, and the total revenue.

      select  top 1  sum(od.quantity*p.price)as Total_revenue,o.orderid,concat(c.Firstname,' ',c.Lastname) as CustomerName from orders o
      join customers c  on o.customerid=c.customerid
      join orderdetails od on od.orderid=o.orderid
      join products p on p.productid=od.productid group by c.Firstname,c.lastname,o.orderid 
      order by Total_revenue  Desc

      --8.Write an SQL query to list electronic gadgets and the number of times each product has been 
--ordered. 
         select p.productname,count(o.orderid) as total_order from products p join orderdetails od  on od.productid=p.productid
         join orders o on o.orderid=od.orderid group by p.productname

      
      --9.Write an SQL query to find customers who have purchased a specific electronic gadget product. 
---Allow users to input the product name as a parameter 
                   declare @productname varchar(30)
                   set @productname='mouse'

                   select Concat(Firstname,' ' ,lastname) as CustomerName from customers c join orders o on o.customerid=c.customerid 
                   join orderdetails od on od.orderid=o.orderid
                   join products p on od.productid=p.productid where p.productname=@productname 


        --10.Write an SQL query to calculate the total revenue generated by all orders placed within a 
--specific time period. Allow users to input the start and end dates as parameters.
                   declare @start_date date
                   set @start_date='2024-11-30'
                   declare @end_date date
                   set @end_date=getdate()
                   select sum(p.price *od.quantity)as total_revenue from products p join orderdetails od on p.productid=od.productid 
                   join orders o on o.orderid=od.orderid
                   where orderdate between @start_date and @end_date
  

  --Task 4. Subquery and its type:  
  
  --1.Write an SQL query to find out which customers have not placed any orders.
   select  concat(firstname,' ',lastname) as CustomerName from customers where customerid not in(select customerid from orders)


  --2.Write an SQL query to find the total number of products available for sale.  
     select( select  count(*) from Inventories  where quantityInstock >0 ) as available_products
      
  --3.Write an SQL query to calculate the total revenue generated by TechShop.
   select sum(p.price *od.quantity) as total_revenue from products p join orderdetails od on od.productid=p.productid

   --4.Write an SQL query to calculate the average quantity ordered for products in a specific category. 
--Allow users to input the category name as a parameter 

   declare @categoryname varchar(50);
   set @categoryname='Mobile accessories'

   select avg(quantity) as average_quantity from orderdetails  where productid in
   (select productid from products 
   where category = @categoryname)

   
   --5.Write an SQL query to calculate the total revenue generated by a specific customer. Allow users 
--to input the customer ID as a parameter. 
     declare @customerid int
     set @customerid=7

     select  sum(od.quantity*p.price) as total_revenue from products p join orderdetails od on p.productid=od.productid
     where od.orderid in(select o.orderid from  orders o  
     where o.customerid=@customerid)
     

     --6.Write an SQL query to find the customers who have placed the most orders. List their names 
--and the number of orders they've placed 
       select concat(firstname,' ',lastname) as CustomerName ,
       (select count(*)  from orders o where o.customerid=c.customerid)as Totalcount
       from customers c
       where
       (select count(*) from orders o where o.customerid=c.customerid)=
       (select max(max_count) from (select count(*) as max_count from orders
       group by customerid)as total_order)
       
       
     --7.Write an SQL query to find the most popular product category, which is the one with the highest 
--total quantity ordered across all orders
                 select category from 
                 (select p.category, sum(od.quantity) as total_quantity from products p 
                 join orderdetails od on  p.productid =od.productid
                 group by p.category)as category_totals
                 where  total_quantity =(select max (total_quantity)  
                 from 
                 (select sum(od.quantity) as total_quantity from products p
                 join orderdetails od on  p.productid =od.productid
                 group by p.category)as total_quantity)
                 
       
    --8.Write an SQL query to find the customer who has spent the most money (highest total revenue) 
--on electronic gadgets. List their name and total spending 
       select  concat(customer_spending.Firstname,' ',customer_spending.lastname) as CustomerName  from 
       ( select  c.Firstname,c.lastname,sum(od.quantity*p.price) as total_revenue from customers c 
       join orders o on o.customerid=c.customerid
       join orderdetails od on od.orderid=o.orderid 
       join products p on p.productid = od.productid 
       group by  c.customerid,c.firstname,c.lastname )as customer_spending
       where customer_spending.total_revenue=
       (select max(total_revenue) 
       from (select sum(od.quantity*p.price) as total_revenue from customers c 
       join orders o on o.customerid=c.customerid
       join orderdetails od on od.orderid=o.orderid 
       join products p on p.productid = od.productid 
       group by c.customerid) as total_revenue)
    --9.Write an SQL query to calculate the average order value (total revenue divided by the number of 
--orders) for all customers  ** 
       select c.customerid,concat(c.Firstname,' ',c.lastname) as Customername,
       (select sum(od.quantity*p.price)
       from orders o 
       join orderdetails od on o.orderid=od.orderid
       join products p on p.productid=od.productid
       where o.customerid=c.customerid)/
       (select count(*) from orders o 
       where o.customerid=c.customerid) as average_value from customers c


     --10.Write an SQL query to find the total number of orders placed by each customer and list their 
--names along with the order count
       
         select customerid,concat(firstname,' ',Lastname) as Customername, 
         (select count(*) from orders o 
         where o.customerid=c.customerid) as total_order
         from customers c
         

--Extra Questions

   -- 1.add Rs to the price of the products
       Select productname,cast (price as varchar)+' '+'Rs' as price from products

   -- 2.select the product name which are not ordered
      select productid,price  from products   where productid not  in (select productid  from orderdetails) 

   --3.count quantity of product ordered by giving the productnames
     select sum(quantity) as total_ordered from orderdetails where productid  in (select productid from products where productname='mouse') 


     select *  from Products