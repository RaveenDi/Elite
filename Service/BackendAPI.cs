using Elite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

interface BackendAPI
{
    Task<User> GetUserAsync(string username);
    Task<Boolean> AddUser(User user);
    Task<User> Updateuser(string id, User user);
    Task<HttpStatusCode> DeleteUser(string id);
}
