namespace FootballFieldManagmentAngularJS.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
