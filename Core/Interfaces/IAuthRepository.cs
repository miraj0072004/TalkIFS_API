using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IAuthRepository
    {

        bool Login(string username, string password);
    }
}
