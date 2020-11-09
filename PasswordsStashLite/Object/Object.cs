using System;

namespace PasswordsStashLite.Object
{
    public class Object
    {
        public int passwordsStashLiteObject_id { get; set; }

        public Object()
        {
            generate_new_object_id();
        }

        //Gives a new id to the object by changing the
        //passwordsStashLiteObject_id value
        public void generate_new_object_id()
        {
            Random random = new Random();
            this.passwordsStashLiteObject_id = random.Next(1,999999999);
        }

        //To set PasswordsStashLite Object ID
        public void set_object_id(int id)
        {
            this.passwordsStashLiteObject_id = id;
        }
        public int get_object_id()
        {
            return this.passwordsStashLiteObject_id;
        }
    }
}
