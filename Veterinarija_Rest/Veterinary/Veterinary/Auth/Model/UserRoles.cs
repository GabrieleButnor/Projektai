using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinary.Auth.Model
{
    // Varotojų rolių aprašymas
    public static class UserRoles
    {
        // Rolės
        public const string Admin = nameof(Admin);
        public const string SimpleUser = nameof(SimpleUser);
        public const string DoctorUser = nameof(DoctorUser);

        // Rolių sujungimas autorizacijai aprašyti
        public const string DoctorOrSimpleUser = DoctorUser + "," + SimpleUser;
        public const string DoctorOrAdmin = DoctorUser + "," + Admin;
        public const string SimpleOrAdmin = SimpleUser + "," + Admin;
        public const string SimpleDocAdmin = SimpleUser + "," + DoctorUser + "," + Admin;

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, SimpleUser, DoctorUser };

    }
}
