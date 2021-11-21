using System.Runtime.InteropServices;
using System;

public unsafe class Address<type> where type : unmanaged
{
    type* adress;
    bool isAlloc;

    public Address(type value)
    {
        adress = (type*)Marshal.AllocHGlobal(Marshal.SizeOf(value));
        *adress = value;
        isAlloc = true;
    }

    public Address(in type value)
    {
        fixed (type* ptr = &value)
        {
            adress = ptr;
        }
        isAlloc = false;
    }

    ~Address()
    {
        if (isAlloc)
        {
            Marshal.FreeHGlobal((IntPtr)adress);
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