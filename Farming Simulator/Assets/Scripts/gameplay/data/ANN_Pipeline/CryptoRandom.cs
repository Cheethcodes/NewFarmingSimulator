using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class CryptoRandom
{
    public double RandomValue { get; set; }

    public CryptoRandom()
    {
        RNGCryptoServiceProvider p = new RNGCryptoServiceProvider();

        try
        {
            Random r = new Random(p.GetHashCode());
            this.RandomValue = r.NextDouble();
        }
        finally
        {

        }
    }
}