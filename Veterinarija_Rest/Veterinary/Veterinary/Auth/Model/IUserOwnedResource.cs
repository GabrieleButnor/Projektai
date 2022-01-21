using System;
using System.Collections.Generic;
using System.Linq;

namespace Veterinary.Auth.Model
{
    // Varotojui priklausančių ištekliu skiriamasis elementas
    public interface IUserOwnedResource
    {
        string fk_UserId { get; }
    }
}
