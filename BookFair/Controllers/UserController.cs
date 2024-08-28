using BookFair.Enums;
using BookFair.Models;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Web;

namespace BookFair.Controllers
{
    public class UserController
    {

        private static UserController instance;

        private UserController() { }
        public static UserController getInstance()
        {
            if (instance == null)
            {
                instance = new UserController();
            }
            return instance;

        }

        public async Task AddCustomer(Session session, string first_name, string last_name, string email, string password)
        {
            try
            {
                Customer customer = new Customer(session)
                {
                    First_Name = first_name,
                    Last_Name = last_name,
                    Email = email,
                    Password = password,
                    User_Role = UserRole.Customer
                };
                await session.SaveAsync(customer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AddEmployee(Session session, string first_name, string last_name, string email, string password, EmployeeRole role, decimal? salary = 0, int? phone_number = 0)
        {
            try
            {
                Employee employee = new Employee(session)
                {
                    First_Name = first_name,
                    Last_Name = last_name,
                    Email = email,
                    Password = password,
                    User_Role = UserRole.Employee,
                    Phone_Number = phone_number.HasValue ? (int)phone_number : 0,
                    Emp_Role = role,
                    Salary = salary.HasValue ? (decimal)salary : 0,


                };


                await session.SaveAsync(employee);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<Customer> GetCustomer(Session session, int user_id)
        {

            try
            {
                var customer = await session.GetObjectByKeyAsync<Customer>(user_id);
                return customer;
            }
            catch (Exception ex)
            {
                throw;

            }
        }



        public async Task<Employee> GetEmployee(Session session, int emp_id)
        {

            try
            {
                var emp = await session.GetObjectByKeyAsync<Employee>(emp_id);
                return emp;
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        public async Task AddOTPCode(Session session, User user, string OTP)
        {

            try
            {
                DateTime now = DateTime.Now;
                DateTime Expiration = now.AddMinutes(30);
                user.OTP_Code = OTP;
                user.OTP_Code_Expiration = Expiration;
                await session.SaveAsync(user);
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        public async Task RemoveOTPCode(Session session, User user)
        {

            try
            {
                user.OTP_Code = null;
                await session.SaveAsync(user);
            }
            catch (Exception ex)
            {
                throw;

            }
        }





        public async Task<User> GetUserByEmail(Session session, string email)
        {

            try
            {
                XPQuery<User> users = new XPQuery<User>(session);
                List<User> user = await Task.Run(() => users.Where((c) => c.Email == email).ToList<User>());
                if (user.Count != 0)

                {
                    return user[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        public async Task ChangePassword(Session session, User user, string password)
        {

            try
            {
                user.Password = password;
                await session.SaveAsync(user);
            }
            catch (Exception ex)
            {
                throw;

            }
        }


    }

}