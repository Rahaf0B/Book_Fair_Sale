# Book Sale Fair

**Book Sale Fair** is an ASP.NET project built using **DevExpress** and a **SQL database**. The main purpose of this project is to create an electronic book exhibition where users can browse, purchase, and manage books. The application supports three roles: **Customer**, **Employee**, and **Admin**.

## Features

### Customer
- **Registration Page**: Customers can register by providing their personal information, including email.
- **Login Page & Forget Password**: Perform login and password recovery via email.
- **Home Page**: Customers can browse books, filter by subject, search by name, and view details such as price.
- **Cart Management**:
	- Customer can add books to the cart.
	- Increase or decrease quantity of a book into the cart.
	- Remove a book from the cart.
- **Order Management**:
  - Customers can transfer the books in the cart to create a new order.
  - View and manage all orders with statuses: Pending, Accepted, or Rejected.
  - Modify or delete orders (pending and accepted), adjust quantities, or remove or add books from orders.
- **Logout**

### Employee
- **Login Page & Forget Password**: Perform login and password recovery via email.
- **Home Page**:
  - Employees can search, filter, and view all books.
  - View all customer orders, approve or reject them.
  - Employees can **add new books** to the inventory, including details like name, author, price, quantity, and book image.
  - Employees can **edit and delete books**.
- **Logout**

### Admin
- **Login Page & Forget Password**: Perform login and password recovery via email.
- **Home Page**:
  - Full system control for Admins.
  - Add new employees with all required information.
- **Logout**


## Technologies Used
- **ASP.NET** (Web Forms)
- **DevExpress**
- **SQL Server**
