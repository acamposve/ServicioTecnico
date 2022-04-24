using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioTecnico.Infrastructure.Shared.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            if (user == null) return null;

            user.Password = null;
            return user;
        }

        public static string GeneratePONumber()
        {
            string result;
            try
            {
                result = GenerateNumber("PO");
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public static string GenerateSONumber()
        {
            string result;
            try
            {
                result = GenerateNumber("SO");
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public static string GenerateGRNumber()
        {
            string result;
            try
            {
                result = GenerateNumber("GR");
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public static string GenerateInvenTranNumber()
        {
            string result;
            try
            {
                result = GenerateNumber("TRN");
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        private static string GenerateNumber(string module)
        {
            string result;
            try
            {
                result = Guid.NewGuid().ToString()[..7].ToUpper() + "-" + DateTime.Now.ToString("yyyyMMdd") + "#" + module;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
