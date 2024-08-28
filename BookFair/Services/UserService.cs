using BookFair.Classes.Email.Model;
using BookFair.Controllers;
using BookFair.Enums;
using BookFair.Models;
using DevExpress.Web;
using DevExpress.Xpo;
using RandomString4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static DevExpress.Utils.MVVM.Internal.ILReader;

namespace BookFair.Services
{
    public class UserService

    {
        private static UserService _instance;
        private UserController _userInstance = UserController.getInstance();
        private EmailService _emailInstance = EmailService.getInstance();

        private UserService() { }

        public static UserService getInstance()
        {
            if (_instance == null)
            {
                _instance = new UserService();
            }
            return _instance;

        }

        private string _hash_Password(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            return passwordHash;
        }

        public bool Check_Password(string passwordToCheck, string password)
        {
            bool result = BCrypt.Net.BCrypt.Verify(passwordToCheck, password);
            return result;
        }
        public async Task Register_Customer(string first_name, string last_name, string email, string password)
        {
            try
            {
                if (first_name != null && last_name != null && email != null && password != null)
                {
                    string hashPassword = _hash_Password(password);

                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        await _userInstance.AddCustomer(uow, first_name,
                                last_name,
                            email,
                               hashPassword);
                        await uow.CommitChangesAsync();
                    }
                }

            }
            catch (Exception ex) { throw; }
        }



        public async Task<User> Get_User(string email)
        {
            try
            {
                using (Session session = new Session())
                {

                    User user = await _userInstance.GetUserByEmail(session, email);
                    return user;
                }
            }
            catch (Exception ex) { throw; }

        }



        public async Task<EmployeeRole?> Get_Employee_Role(int emp_id)
        {
            try
            {
                using (Session session = new Session())
                {

                    Employee emp = await _userInstance.GetEmployee(session, emp_id);
                    if (emp != null)
                    {
                        return emp.Emp_Role;
                    }
                    return null;

                }
            }
            catch (Exception ex) { return null; }

        }

        private string _generate_OTP_Code()
        {
            string randomString = RandomString.GetString(Types.ALPHANUMERIC_MIXEDCASE, 10);
            return randomString;
        }

        public async Task<bool> Check_User_Exist(string email)
        {
            try
            {

                using (Session session = new Session())
                {

                    User user = await _userInstance.GetUserByEmail(session, email);
                    return user != null;
                }
            }
            catch (Exception ex) { return false; }

        }


        public async Task<bool> Send_OTP_Code(string email)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    User user = await _userInstance.GetUserByEmail(uow, email);

                    if (user != null)

                    {
                        string randomString = _generate_OTP_Code();
                        await _userInstance.AddOTPCode(uow, user, randomString);
                        string body = $"<div style=\"display:flex; \r\n flex-direction: column; \r\n align-items: center; \r\n justify-content: space-around; \r\n height: 300px; \r\n  margin: auto; \r\n width: fit-content;\">\r\n " +
                        $"   <img style=\"width: 150px;\" }}=\"\" src=\"https://drive.google.com/file/d/13yPkpBgLCJ_mjFZwUKncKBqnAkxmvzAz/view?usp=drive_link\">\r\n\r\n  " +
                        $"  <h1 style=\"\r\n    font-size: 25px;\r\n    font-family: cursive;\r\n\">\r\n   " +
                        $"     An OTP Code has been request for This Email\r\n  " +
                        $"  </h1><label style=\"\r\n    font-size: 20px;\r\n    font-family: cursive;\r\n\">{email}</label>\r\n  " +
                        $"  \r\n    <label style=\"\r\n   font-size: 20px;\r\n font-family: cursive;\r\n\">\r\n  OTP Code is : {randomString}\r\n    </label>\r\n</div>";
                        await _send_Email(email, "arcodiet@gmail.com", "OTP Code Rest Password", body, "html");
                        await uow.CommitChangesAsync();

                        return true;
                    }
                    await uow.CommitChangesAsync();

                    return false;
                }
            }
            catch (Exception ex) { throw; }

        }
        private async Task _send_Email(string email_to, string email_from, string subject, string body, string email_type)
        {
            try
            {
                SendEmail sender = new SendEmail(subject, body, email_from, email_to);
                await _emailInstance.SendEmail(sender, email_type);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public bool Validate_Email(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }



        public async Task<bool> Check_OTP_Code(string OTP_Code, string email)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {

                    User user = await _userInstance.GetUserByEmail(uow, email);

                    if (user != null && user.OTP_Code != null && user.OTP_Code == OTP_Code && DateTime.Compare(user.OTP_Code_Expiration, DateTime.Now) > 0)
                    {
                        await _userInstance.RemoveOTPCode(uow, user);
                        await uow.CommitChangesAsync();

                        return true;
                    }
                    await uow.CommitChangesAsync();

                    return false;
                }
            }
            catch (Exception ex) { return false; }

        }


        public async Task ChangePassword(string email, string newPassword)
        {

            try
            {
                string password = _hash_Password(newPassword);
                using (UnitOfWork uow = new UnitOfWork())
                {
                    User user = await _userInstance.GetUserByEmail(uow, email);
                    await _userInstance.ChangePassword(uow, user, password);
                    await uow.CommitChangesAsync();
                }
            }
            catch (Exception ex) { throw; }

        }




        public async Task<(bool, string)> Add_Employee(string first_name, string last_name, string email, string password, EmployeeRole role, decimal salary = 0)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {

                    string hashedPassword = _hash_Password(password);
                    await _userInstance.AddEmployee(uow, first_name, last_name, email, hashedPassword, role, salary: salary);
                    await uow.CommitChangesAsync();

                    return (true, "The Employee Has Been Added");
                }
            }
            catch (DevExpress.Xpo.DB.Exceptions.ConstraintViolationException ex)
            {

                return (false, "This Email Is Taken");
            }
            catch (Exception ex) { return (false, "Error Occurred"); }
        }


    }



}

