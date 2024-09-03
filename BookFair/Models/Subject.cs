using DevExpress.Xpo;
using System;

namespace BookFair.Models
{
    public class Subject : XPLiteObject
    {
        public Subject() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Subject(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        [Persistent("subject_id")]
        [Key(true)]
        private int _subject_id;
        public int Subject_id
        {
            get { return _subject_id; }
        }

        private string _title;
        [Persistent("title")]
        public string Title {


            get => _title;
            set
            {
                SetPropertyValue<string>(nameof(Title), ref _title, value);
            }
        }



        [Association("Subject-Books")]
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