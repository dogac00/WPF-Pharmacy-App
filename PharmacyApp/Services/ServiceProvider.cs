using System;
using System.Collections.Generic;
using System.Text;
using PharmacyApp.Services;

namespace PharmacyApp
{
    static class ServiceProvider
    {
        private static readonly UserService UserService = new UserService();
        private static readonly DrugService DrugService = new DrugService();

        public static UserService GetUserService()
        {
            return UserService;
        }

        public static DrugService GetDrugService()
        {
            return DrugService;
        }
    }
}
