namespace AplicatieConsolaAgentieTursim.Model
{
    public class User : IHasID<int>
    {
        
        private string username;
        private string password;


        public User(int id, string username, string password)
        {
            this.ID = id;
            this.username = username;
            this.password = password;
        }

        

        public int ID { get; set; }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
       

    }
}