using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


internal sealed class PrivateImplementationDetails
{

    internal static uint ComputeStringHash(string text)
    {
        uint hashCode = 0;
        if (text != null)
        {
            hashCode = 2166136261u;
            for (int i = 0; i < text.Length; i++)
            {
                hashCode = ((uint)text[i] ^ hashCode) * 16777619u;
            }
        }
        return hashCode;
    }
}