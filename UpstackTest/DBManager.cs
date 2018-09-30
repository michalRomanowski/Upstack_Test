using System.Linq;
using UpstackTest.Models;

namespace UpstackTest
{
    public enum RegisterUserResult
    {
        Ok,
        UsernameTaken,
        EmailTaken
    }

    public enum ActivateUserResult
    {
        Ok,
        NoSuchUser
    }

    public class DBManager
    {
        public User GetUser(string username)
        {
            using (var db = new UpstackContext())
            {
                return db.Users.FirstOrDefault(x => string.Equals(username, x.Username));
            }
        }

        public RegisterUserResult RegisterUser(User newUser)
        {
            using (var db = new UpstackContext())
            {
                if (db.Users.Any(x => newUser.Username.Equals(x.Username)))
                    return RegisterUserResult.UsernameTaken;

                //if (db.Users.Any(x => newUser.Email.Equals(x.Email)))
                //    return RegisterUserResult.EmailTaken;

                db.Users.Add(newUser);
                db.SaveChanges();

                return RegisterUserResult.Ok;
            }
        }

        public ActivateUserResult ActivateUser(int id)
        {
            using (var db = new UpstackContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                    return ActivateUserResult.NoSuchUser;

                user.Active = true;
                db.SaveChanges();

                return ActivateUserResult.Ok;
            }
        }
    }
}