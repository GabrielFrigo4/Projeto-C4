using System.Runtime.InteropServices;
using System;

public static unsafe class PointerMethod
{
    public static void* Malloc(int size)
    {
        void* ptr = Alloc(size);
        for (int i = 0; i < size; i++)
        {
            ((byte*)ptr)[i] = 0;
        }
        return ptr;
    }

    public static void* Alloc(int size)
    {
        return Marshal.AllocHGlobal(size).ToPointer();
    }

    public static void Free(void* pointer)
    {
        Marshal.FreeHGlobal((IntPtr)pointer);
    }

    public static IntPtr GetPointer(ref object obj)
    {
        GCHandle handle = GCHandle.Alloc(obj);
        return handle.AddrOfPinnedObject();
    }

    public static type GetValue<type>(IntPtr ptr)
    {
        GCHandle handle = (GCHandle)ptr;
        return (type)handle.Target;
    }
}