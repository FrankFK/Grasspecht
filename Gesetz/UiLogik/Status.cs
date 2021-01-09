using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gesetz.UiLogik
{
    public static class Status
    {
        private const string SessionStateKeySchlüssel = "gamekey";

        public static int LeseSpielschlüssel(ISession session)
        {
            var value = session.GetInt32(SessionStateKeySchlüssel);
            if (value == null) {
                return 0;
            }
            else {
                return (int)value;
            }
        }

        public static void SchreibeSpielschlüssel(ISession session, int schlüssel)
        {
            session.SetInt32(SessionStateKeySchlüssel, schlüssel);
        }
    }
}
