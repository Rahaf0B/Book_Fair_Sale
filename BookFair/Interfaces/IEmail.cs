using BookFair.Classes.Email.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFair.Interfaces
{
    public interface IEmail
    {
          Task SendEmail(SendEmail email, string BodyType);
    }
}
