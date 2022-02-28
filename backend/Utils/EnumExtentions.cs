using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arx.ElpeChargeGo.Core.Utils
{
    public static class EnumExtentions
    {
        public static string GetName<T>(this T val) where T : Enum => Enum.GetName(typeof(T), val);
    }
}
