using System.Collections;
using System.Collections.Generic;

public class Dendrite
{
    public double Weight { get; set; }

    public Dendrite()
    {
        CryptoRandom n = new CryptoRandom();
        this.Weight = n.RandomValue;
    }
}

