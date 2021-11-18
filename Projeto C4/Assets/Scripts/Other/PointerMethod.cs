using System.Runtime.InteropServices;
using System;

public static class PointerMethod
{
    public static IntPtr CreatePointer<type>(type obj) where type : unmanaged
    {
        IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
        Marshal.StructureToPtr(obj, pnt, false);
        return pnt;
    }

    public unsafe static IntPtr GetPointerPtr<type>(ref type obj) where type : unmanaged
    {
        fixed(void* ptr = &obj)
        {
            return new IntPtr(ptr);
        }
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