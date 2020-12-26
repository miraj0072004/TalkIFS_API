using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAuthRepository
    {

        AuthInfo Login(string url,string username, string password);
    }
}
