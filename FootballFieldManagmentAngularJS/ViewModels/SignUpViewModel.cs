namespace FootballFieldManagmentAngularJS.ViewModels
{
    public class SignUpViewModel
    {

        public SignUpViewModel(string UserName, string Email, string Password, string PhoneNumber,string RePassword)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.RePassword = RePassword;
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string PhoneNumber { get; set; }
    }

}

