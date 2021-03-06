// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    /// <summary>
    /// Provides native file IO interfaces.
    /// </summary>
    internal unsafe class Stdio
    {
        static Stdio()
        {
            InternalCalls.__init();
        }

        internal static readonly int EOF = -1;

        internal static errno_t _wfopen_s(out void* fp, string path, string mode)
        {
            fixed (char* ppath = path)
            fixed (char* pmode = mode)
            {
                return CStdio.C_wfopen_s(out fp, ppath, pmode);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong fread(void* buffer, ulong elementSize, ulong count, void* fp) { return CStdio.fread(buffer, elementSize, count, fp); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong fwrite(void* buffer, ulong elementSize, ulong count, void* fp) { return CStdio.fwrite(buffer, elementSize, count, fp); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int fflush(void* fp) { return CStdio.fflush(fp); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int fclose(void* fp) { return CStdio.fclose(fp); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int feof(void* fp) { return CStdio.feof(fp); }
    }

    internal unsafe class CStdio
    {
        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern errno_t C_wfopen_s(out void* fp, char* path, char* mode);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ulong fread(void* buffer, ulong elementSize, ulong count, void* fp);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ulong fwrite(void* buffer, ulong elementSize, ulong count, void* fp);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int fflush(void* fp);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int fclose(void* fp);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int feof(void* fp);
    }
}
