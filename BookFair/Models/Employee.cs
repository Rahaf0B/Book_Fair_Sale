using BookFair.Enums;
using DevExpress.Xpo;
using System;

namespace BookFair.Models
{
    public class Employee : User
    {
        public Employee() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Employee(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }


        private decimal _salary;
        [Persistent("salary")]
        [Nullable(true)]
        public decimal Salary
        {
            get => _salary;
            set
            {
                SetPropertyValue(nameof(Salary), ref _salary, value);
            }
        }


        private int _phone_number;
        [Persistent("phone_number")]
        [Nullable(true)]
        public int Phone_Number
        {
            get => _phone_number;
            set
            {
                SetPropertyValue(nameof(Phone_Number), ref _phone_number, value);
            }
        }


        private EmployeeRole _empRole;
        [Persistent("emp_role")]
        public EmployeeRole Emp_Role
        {
            get => _empRole;
            set
            {
                SetPropertyValue<EmployeeRole>(nameof(Emp_Role), ref _empRole, value);
            }
        }

    }

}