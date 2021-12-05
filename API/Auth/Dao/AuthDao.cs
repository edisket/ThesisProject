using Base.Abstract;
using Transaction.context;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;


namespace Auth.Dao
{
    public class AuthDao:BaseDao<thesis_schemaContext>
    {



        public bool AuthenticateAccount(string username, string password) {

            var count = _context.Accounts.Where(x => x.Username == username && x.Password == password).Count();

            return count > 0;
        
        }




    }
}
