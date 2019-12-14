using System;
using System.Collections.Generic;
using System.Text;
using PharmacyApp.Services;

namespace PharmacyApp
{
    static class ServiceProvider
    {
        private static readonly UserService Service = new UserService();

        public static UserService GetUserService()
        {
            return Service;
        }
    }
}
