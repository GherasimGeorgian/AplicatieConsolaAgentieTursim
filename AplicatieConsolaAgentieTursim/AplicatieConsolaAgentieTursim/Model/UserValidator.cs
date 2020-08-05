namespace AplicatieConsolaAgentieTursim.Model
{
    class UserValidator : IValidator<User>
    {
        public void Validate(User user)
        {
            if (user.Username.Equals(null)) throw new System.ArgumentNullException("Username cannot be null");
            if (user.Password.Equals(null)) throw new System.ArgumentException("Password cannot be null");
        }
    }
}
