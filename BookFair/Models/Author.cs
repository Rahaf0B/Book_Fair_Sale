using DevExpress.Xpo;
using System;

namespace BookFair.Models
{
    [Persistent("Author")]
    public class Author : XPLiteObject
    {
        public Author() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Author(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }




        [Persistent("author_id")]
        [Key(true)]
        private int _author_id;
        public int Author_id
        {
            get { return _author_id; }
        }


        private string _name;
        [Persistent("author")]
        [Nullable(true)]
        public string Name
        {
            get => _name;
            set { SetPropertyValue<string>(nameof(Name), ref _name, value); }
        }




        // Apply the Association attribute to mark the Books property 
        // as the "many" end of the Authors-Books association.
        [Association("Author-Books")]
        public XPCollection<Book> Books
        {
            get { return GetCollection<Book>(nameof(Books)); }
        }


        protected override void OnDeleting()
        {
            foreach (var book in Books)
            {
                book.Subject = null;
                book.Save();
            }

            base.OnDeleting();
        }
    }

}