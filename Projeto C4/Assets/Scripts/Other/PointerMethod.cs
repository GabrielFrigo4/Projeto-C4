using System.Runtime.InteropServices;
using System;

public static unsafe class UnsafePointerMethod
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
}

public unsafe static class SafePointerMethod
{
    public static IntPtr CreatePointer<type>(type obj) where type : unmanaged
    {
        IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
        Marshal.StructureToPtr(obj, pnt, false);
        return pnt;
    }

    public static type GetPointerValue<type>(IntPtr ptr) where type : unmanaged
    {
        type val = Marshal.PtrToStructure<type>(ptr);
        return val;
    }

    public static void SetPointerValue<type>(IntPtr ptr, type newValue) where type : unmanaged
    {
        int size = Marshal.SizeOf(typeof(type));
        IntPtr newValuePtr = CreatePointer(newValue);
        for(int i  = 0; i < size; i++)
        {
            byte newPart = Marshal.ReadByte(newValuePtr, i);
            Marshal.WriteByte(ptr, i, newPart);
        }
    }

    public static void FreePointer(IntPtr ptr)
    {
        Marshal.FreeHGlobal(ptr);
    }
}