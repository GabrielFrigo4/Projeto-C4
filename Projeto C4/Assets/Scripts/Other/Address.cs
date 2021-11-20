using System.Runtime.InteropServices;
using System;

public unsafe struct Address<type> where type : unmanaged
{
    type* adress;

    public Address(type value)
    {
        adress = &value;
    }

    public Address(in type value)
    {
        fixed (type* ptr = &value)
        {
            adress = ptr;
        }
    }

    public type Value
    {
        get
        {
            return *adress;
        }

        set
        {
            *adress = value;
        }
    }

    public bool IsNull
    {
        get
        {
            return adress == null;
        }
    }
}