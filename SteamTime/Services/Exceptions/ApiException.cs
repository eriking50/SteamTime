using System;
namespace SteamTime.Services.Exceptions
{
    public class ApiException : ApplicationException
    {
        public ApiException(string message) : base(message)
        {            
        }
    }
}