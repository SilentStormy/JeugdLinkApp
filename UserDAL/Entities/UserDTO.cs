namespace JeugdLinkDAL.Entities
{
    public class UserDTO
    {
        private int ID { get; set; }
        private string Firstname { get; set; }
        private string Lastname { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private DateTime DateOfBirth { get; set; }

        public int id
        {
            get { return ID; }
            set { ID = value; }
        }

        public string firstname
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        public string lastname
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public DateTime dateofbirth
        {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }

    }
}