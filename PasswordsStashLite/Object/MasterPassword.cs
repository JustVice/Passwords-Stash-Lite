namespace PasswordsStashLite.Object
{
    public class MasterPassword : Object
    {
        public string sha512_master_password { get; set; } = "";
        public string legible_master_password { get; set; } = "";
        public string password_hint { get; set; } = "";

        public MasterPassword() { }
    }
}