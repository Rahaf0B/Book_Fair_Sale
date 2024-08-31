using BookFair.Enums;
using DevExpress.Xpo;
using System;

namespace BookFair.Models
{
    public class User : XPLiteObject
    {
        public User() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public User(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
        [Persistent("user_id")]
        [Key(true)]
        private int _user_id;
        public int User_id
        {
            get { return _user_id; }
        }


        private string _first_name;
        [Persistent("first_name")]
        [Nullable(true)]
        public string First_Name
        {
            get => _first_name;
            set
            {
                SetPropertyValue<string>(nameof(First_Name),ref _first_name, value);
            }
        }

        private string _last_name;
        [Persistent("last_name")]
        [Nullable(true)]
        public string Last_Name
        {
            get => _last_name;
            set
            {
                SetPropertyValue<string>(nameof(Last_Name),ref _last_name, value);
            }
        }


        private string _email;
        [Persistent("email")]
        [Indexed(Unique = true)]
        [Nullable(true)]
        public string Email
        {
            get => _email;
            set
            {
                SetPropertyValue<string>(nameof(Email),ref _email,value);
            }
        }



        private string _password;
        [Persistent("password")]
        [Nullable(true)]
        public string Password
        {
            get => _password;
            set
            {
                SetPropertyValue<string>(nameof(Password), ref _password, value);
            }
        }


        private UserRole _userRole;
        [Persistent("user_role")]
        [Nullable(true)]
        public UserRole User_Role
        {
            get => _userRole;
            set
            {
                SetPropertyValue<UserRole>(nameof(User_Role), ref _userRole, value);
            }
        }


        private string _profile_img;
        [Persistent("profile_img")]
        [Nullable(true)]
        [Size(700)]
        public string Profile_Img
        {
            get => _profile_img;
            set
            {
                SetPropertyValue<string>(nameof(Profile_Img), ref _profile_img, value);

            }
        }


        private string _otp_code;
        [Persistent("otp_code")]
        [Nullable(true)]
        [Size(10)]
        public string OTP_Code
        {
            get => _otp_code;
            set
            {
                SetPropertyValue<string>(nameof(OTP_Code), ref _otp_code, value);
            }
        }

        private DateTime _otp_code_expiration;
        [Persistent("otp_code_expiration")]
        public DateTime OTP_Code_Expiration
        {
            get => _otp_code_expiration;
            set
            {
                SetPropertyValue<DateTime>(nameof(OTP_Code_Expiration), ref _otp_code_expiration, value);
            }
        }

    }

}