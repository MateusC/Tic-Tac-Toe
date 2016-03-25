using System;

namespace TicTaeToe.Domain
{
    public static class IntegerExtension
    {
        public static Boolean IsIn(this Int32 integer, params Int32[] @params)
        {
            for (int i = 0; i < @params.Length; i++)
                if (integer == @params[i]) return true;

            return false;
        }

    }
}
