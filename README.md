Before run the project plz follow the below process:

----------------------------------------Project Setup---------------------------------------------------

1.Change the connection string:Got to PresentationLayer->appsettings.json->ConnectionStrings:Server = your sql server name.
2.Go to Tools -> NuGate Package Manager -> Package Manager Console.
3.Run the following command: i.Add-Migration MigrationName
                             ii. Update-Database
It will create the following table:
1.Category
2.Products.
3.Sales.
4.Stock.
5.Asp.NetUsers.
6.Asp.NetRoles.

---------------------------------------------------Registration and Login---------------------------------------------------

1.Registration: User can register as an admin or can register as a general user by providing the require information.
2.Login with your registered email and password

--------------------------------------------------Authorization---------------------------------------------
1.An admin can add new category, Can sale product and can purchase products.
2.General user only can view the Category,Products added history and Stock Information.

--------------------------------------------------Add Category-----------------------------------------------

1.First add a new category .To add a category click the category from the sidebar button.
2.Prodive category name. Category information will added to the categories table.

--------------------------------------------------Add New product to the store--------------------------------
1.Click Purchase menu from the sidebar 
2.It will show all previous Purchase history .
3.Click add new button to add new product to the store.
4.you can generate provious purchase report by clicking the PDF icon from the top right.
5.If we purchase a product the stock table's value automaticall increase.

---------------------------------------------------Sales---------------------------------
1.To sales a product Select sales menu from the sidebar menu
2.First select product category it will automatic show its related products provide require information.
3.If we sell a product the quantity of that product of stock table auto decrease.
4.Also user can ganerate a report base on previous all sales information.
5.User also search sales history base on date.

------------------------------------Stock Table------------------------------------------
1. It provides the Products stocks information.
2.User can generate a report for stacks information.






