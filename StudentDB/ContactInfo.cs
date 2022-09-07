namespace StudentDB
{
    public class ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string emailAddress;
        //fully specified all aprams will get values s
        public ContactInfo(string first, string last, string email)
        {
            FirstName = first;
            LastName = last;
            EmailAddress = email;
        }
        public string EmailAddress
        {
            get
            {
                // not changing the get from the auto-impliment version
                return emailAddress;
            }
            set
            {
                if (value.Contains("@") && value.Length > 3)
                {
                    emailAddress = value;
                }
                else
                {
                    emailAddress = "ERROR: INVALID EMAIL ADDRESS.";
                }
            }
        }
        //lambda expression-bodied method for utility printing out a contact info obj
        public override string ToString() => $"{FirstName} {LastName}\n{EmailAddress}\n";
        public string ToStringLegal() => $"{LastName}, {FirstName}, {EmailAddress}";
    }
}