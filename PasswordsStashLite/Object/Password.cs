using PasswordsStashLite.Logic;

namespace PasswordsStashLite.Object
{
    public class Password : Object
    {
        public Password()
        {
            generate_new_object_id();
        }

        private string service, email, user, password_content, notes;

        //The id given by the database at id column.
        //It is used to perform delete and edit actions.
        private int database_password_id_index;

        public int getDatabaseID()
        {
            return this.database_password_id_index;
        }

        public void setDatabaseID(int database_id)
        {
            this.database_password_id_index = database_id;
        }

        //Normal GET methods.
        #region GETS
        public string getService()
        {
            return this.service;
        }
        public string getEmail()
        {
            return this.email;
        }
        public string getUser()
        {
            return this.user;
        }
        public string getPassword_content()
        {
            return this.password_content;
        }
        public string getNotes()
        {
            return this.notes;
        }
        #endregion

        //Normal SET methods.
        #region SETS
        public void setService(string service)
        {
            this.service = service;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public void setUser(string user)
        {
            this.user = user;
        }
        public void setPassword_content(string password_content)
        {
            this.password_content = password_content;
        }
        public void setNotes(string notes)
        {
            this.notes = notes;
        }
        #endregion

        //Will convert values into Base64 and then return them.
        #region GETS IN BASE64
        public string getServiceBase64()
        {
            return Base64.Base64Encode(this.service);
        }
        public string getEmailBase64()
        {
            return Base64.Base64Encode(this.email);
        }
        public string getUserBase64()
        {
            return Base64.Base64Encode(this.user);
        }
        public string getPassword_contentBase64()
        {
            return Base64.Base64Encode(this.password_content);
        }
        public string getNotesBase64()
        {
            return Base64.Base64Encode(this.notes);
        }
        #endregion

        //Will convert values intro AES, then into Base64, and
        //then return the value.
        #region GETS IN BASE64 AND AES
        public string getServiceEncryptedBase64()
        {
            string aes = AES.Encrypt(this.service, Memory.master_password.legible_master_password);
            return Base64.Base64Encode(aes);
        }
        public string getEmailEncryptedBase64()
        {
            string aes = AES.Encrypt(this.email, Memory.master_password.legible_master_password);
            return Base64.Base64Encode(aes);
        }
        public string getUserEncryptedBase64()
        {
            string aes = AES.Encrypt(this.user, Memory.master_password.legible_master_password);
            return Base64.Base64Encode(aes);
        }
        public string getPassword_contentEncryptedBase64()
        {
            string aes = AES.Encrypt(this.password_content, Memory.master_password.legible_master_password);
            return Base64.Base64Encode(aes);
        }
        public string getNotesEncryptedBase64()
        {
            string aes = AES.Encrypt(this.notes, Memory.master_password.legible_master_password);
            return Base64.Base64Encode(aes);
        }
        #endregion

        public override string ToString()
        {
            string str = "";
            string service = this.service;
            string user = this.user;
            string email = this.email;
            string notes = this.notes;
            str += service + ". ";
            if (!string.IsNullOrEmpty(user))
            {
                str += "User: " + user + ", ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                str += "E-mail: " + email + ", ";
            }
            if (!string.IsNullOrEmpty(notes))
            {
                str += "notes included.";
            }
            return str;
        }
    }
}
