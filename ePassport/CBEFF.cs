
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ePassport
{    

    public static class CBEFF
    {
        public enum Gender : byte
        {
            Unspecified = 0,
            Male = 1,
            Female = 2,
            Transgender = 0xFF
        }

        public enum EyeColor : byte
        {
            Unspecified = 0,
            Black = 1,
            Blue = 2,
            Brown = 3,
            Gray = 4,
            Green = 5,
            MultiColored = 6,
            Pink = 7,
            Other = 0xFF
        }

        public enum HairColor : byte
        {
            Unspecified = 0,
            Bald = 1,
            Black = 2,
            Blonde = 3,
            Brown = 4,
            Gray = 5,
            White = 6,
            Red = 7,
            Other = 0xFF
        }

        public enum CompressionAlgorithm : byte
        {
            None = 0,
            BitPacking = 1,
            WSQ = 2,
            JPEG = 3,
            JPEG2000 = 4,
            PNG = 5
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct FacialRecordHeader
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string formatIdentifier;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string versionNumber;

            public uint lengthOfRecords;

            public ushort numberOfFacialImages;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FacialInformationBlock
        {

            public uint recordDataLength;

            public ushort numberOfFeaturesPoints;

            [MarshalAs(UnmanagedType.U1)]
            public Gender gender;

            [MarshalAs(UnmanagedType.U1)]
            public EyeColor eyeColor;

            [MarshalAs(UnmanagedType.U1)]
            public HairColor hairColor;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            byte[] featureMask;

            public ushort expression;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] poseAngle;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] poseUncertainty;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FacialImageInformation
        {
            public byte faceImageType;

            public byte imageDataType;

            public ushort width;

            public ushort height;

            public byte imageColorSpace;

            public byte sourceType;

            public ushort deviceType;

            public ushort quality;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct FingerPrintRecordHeader
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string formatIdentifier;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string versionNumber;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] recordLength;

            public ushort captureDeviceId;

            public ushort acquisitionLevel;

            public byte count;

            public byte scaleUnits;

            public ushort scanResolutionHorizontal;

            public ushort scanResolutionVertical;

            public ushort imageResolutionHorizontal;

            public ushort imageResolutionVertical;

            public byte depth;

            [MarshalAs(UnmanagedType.U1)]
            public CompressionAlgorithm compressionAlgorithm;

            public ushort rfu;

        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FingerPrintImageInformation
        {
            public uint recordLength;

            public byte position;

            public byte viewCount;

            public byte viewNumber;

            public byte quality;

            public byte impressionType;

            public ushort width;

            public ushort height;

            public byte rfu;
        }

        /// <summary>
        /// Unmarshal array of bytes into the provided CBEFF struct (handle endianness)
        /// </summary>
        /// <typeparam name="T">Structure</typeparam>
        /// <param name="bytes">byte array source</param>
        /// <param name="offset">offset in array (+sizeof(struct) upon method return)</param>
        /// <returns>populated structure</returns>
        public static T ByteArrayToCBEFFStruct<T>(byte[] bytes, ref int offset) where T : struct
        {
            byte[] subData = new byte[Marshal.SizeOf(typeof(T))];
            Array.Copy(bytes, offset, subData, 0, subData.Length);

            T stuff;
            GCHandle handle = GCHandle.Alloc(subData, GCHandleType.Pinned);
            try
            {
                stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }

            System.Type t = stuff.GetType();
            FieldInfo[] fieldInfo = t.GetFields();

            foreach (FieldInfo fi in fieldInfo)
            {
                if (fi.FieldType == typeof(System.UInt16))
                {
                    UInt16 i16 = (UInt16)fi.GetValue(stuff);
                    List<byte> rev = new List<byte>(BitConverter.GetBytes(i16));
                    rev.Reverse();
                    byte[] b16r = rev.ToArray();
                    fi.SetValueDirect(__makeref(stuff), BitConverter.ToUInt16(b16r, 0));
                }
                else if (fi.FieldType == typeof(System.UInt32))
                {
                    UInt32 i32 = (UInt32)fi.GetValue(stuff);
                    List<byte> rev = new List<byte>(BitConverter.GetBytes(i32));
                    rev.Reverse();
                    byte[] b32r = rev.ToArray();
                    fi.SetValueDirect(__makeref(stuff), BitConverter.ToUInt16(b32r, 0));
                }
                else if (fi.FieldType == typeof(System.UInt64))
                {
                    UInt64 i64 = (UInt64)fi.GetValue(stuff);
                    List<byte> rev = new List<byte>(BitConverter.GetBytes(i64));
                    rev.Reverse();
                    byte[] b64r = rev.ToArray();
                    fi.SetValueDirect(__makeref(stuff), BitConverter.ToUInt16(b64r, 0));
                }
            }

            offset += Marshal.SizeOf(typeof(T));

            return stuff;
        }
    }

}
