using System;
using System.Runtime.InteropServices;

namespace Assets.Scripts
{
    public static class Guard
    {
        public static void ThrowIfNull(object objectToCheck, string exceptionMsg, [Optional] string argName)
        {
            if (String.IsNullOrEmpty(exceptionMsg.Trim()))
                throw new ArgumentException("Can't check if object is null, the exceptionMsg argument is null", "exceptionMsg");

            if (objectToCheck is null)
                throw new ArgumentException(exceptionMsg, argName);
        }
    }
}
