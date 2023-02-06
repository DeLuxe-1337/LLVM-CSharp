using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLVM
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ModuleRef : IEquatable<ModuleRef>
    {
        [FieldOffset(0)]
        private readonly IntPtr handle;

        public ModuleRef(IntPtr handle)
        {
            this.handle = handle;
        }

        public bool Equals(ModuleRef other)
        {
            return handle == other.handle;
        }

        public override bool Equals(object obj)
        {
            return obj is ModuleRef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        public static bool operator ==(ModuleRef left, ModuleRef right)
        {
            return left.handle.Equals(right.handle);
        }

        public static bool operator !=(ModuleRef left, ModuleRef right)
        {
            return !(left.handle == right.handle);
        }
    }
}
