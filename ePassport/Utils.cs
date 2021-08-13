
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

using org.bn;
using org.bn.coders;

namespace ePassport
{
    public static class Utils
    {
        #region HexString helpers

        /// <summary>
        /// Obtain the ASCII string representation of a Hexadecimal String
        /// </summary>
        /// <remarks>
        /// examples: 
        /// HexStringToAsciiString("31323334") = "1234"
        /// HexStringToAsciiString("41424344") = "ABCD"        
        /// </remarks>
        /// <param name="data">input string</param>
        /// <returns>string</returns>  
        public static string HexStringToAsciiString(string data)
        {
            byte[] arrayByte = HexStringToByteArray(data);
            return Encoding.ASCII.GetString(arrayByte);
        }

        /// <summary>
        /// Obtain an hexadecimal string representation of a byte array.
        /// </summary>
        /// <param name="input">input byte array</param>
        /// <param name="offset">offset within input byte array</param>
        /// <param name="len">length to process</param>
        /// <returns>hexadecimal string</returns>
        public static string ByteArrayToHexString(byte[] input, int offset, int len)
        {
            StringBuilder output = new StringBuilder();
            for (int i = offset; i < offset + len; i++)
            {
                output.Append(String.Format("{0:X2}", input[i]));
            }
            return output.ToString();
        }

        /// <summary>
        /// Obtain an hexadecimal string representation of a byte array.
        /// </summary>
        /// <param name="input">input byte array</param>
        /// <returns>hexadecimal string</returns>
        public static string ByteArrayToHexString(byte[] input)
        {
            return ByteArrayToHexString(input, 0, input.Length);
        }

        /// <summary>
        /// Obtain the byte array representation of an hexadecimal string.
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>byte array</returns>
        public static byte[] HexStringToByteArray(string input)
        {
            if ((input.Length % 2) != 0)
            {
                throw new ArgumentException("input byte length must be modulo-2");
            }

            byte[] output = new byte[input.Length / 2];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = (byte)Convert.ToInt32(input.Substring(i * 2, 2), 16);
            }

            return output;
        }

        #endregion

        #region Array comparison Helpers

        /// <summary>
        /// Compare two byte arrays.
        /// </summary>
        /// <param name="array1">input byte array</param>
        /// <param name="array2">input byte array</param>
        /// <returns>true if arrays content matches, false otherwise</returns>
        public static bool Compare(byte[] array1, byte[] array2)
        {
            return Compare(array1, 0, array2, 0);
        }

        /// <summary>
        /// Compare two byte arrays.
        /// </summary>
        /// <param name="array1">input byte array</param>
        /// <param name="offset1">offset within array1</param>
        /// <param name="array2">input byte array</param>
        /// <param name="offset2">offset within array2</param>
        /// <returns>true if arrays content matches, false otherwise</returns>
        public static bool Compare(byte[] array1, int offset1, byte[] array2, int offset2)
        {
            if ((array1.Length - offset1) == (array2.Length - offset2))
            {
                return Compare(array1, offset1, array2, offset2, array1.Length - offset1);
            }

            return false;
        }

        /// <summary>
        /// Compare two byte arrays.
        /// </summary>
        /// <param name="array1">input byte array</param>
        /// <param name="offset1">offset within array1</param>
        /// <param name="array2">input byte array</param>
        /// <param name="offset2">offset within array1</param>
        /// <param name="comparisonLength">kength to process</param>
        /// <returns>true if arrays content matches, false otherwise</returns>
        public static bool Compare(byte[] array1, int offset1, byte[] array2, int offset2, int comparisonLength)
        {
            if (offset1 + comparisonLength > array1.Length)
            {
                return false;
            }

            if (offset2 + comparisonLength > array2.Length)
            {
                return false;
            }

            for (int i = 0; i < comparisonLength; i++)
            {
                if (array1[i + offset1] != array2[i + offset2])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region DER Encoding/Decoding

        public static String DerEncodeAsHexString<T>(T t) where T : IASN1PreparedElement
        {
            return ByteArrayToHexString(DerEncodeAsByteArray<T>(t));
        }

        public static void DerEncodeToByteArray<T>(T t, byte[] dest, int destOffset) where T : IASN1PreparedElement
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                DerEncodeToMemoryStream<T>(t, memoryStream);
                memoryStream.Position = 0;
                memoryStream.Read(dest, 0, (int)memoryStream.Length);
            }
            finally
            {
                memoryStream.Close();
            }
        }

        public static byte[] DerEncodeAsByteArray<T>(T t) where T : IASN1PreparedElement
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                DerEncodeToMemoryStream<T>(t, memoryStream);
                memoryStream.Position = 0;
                return memoryStream.ToArray();
            }
            finally
            {
                memoryStream.Close();
            }
        }

        public static void DerEncodeToMemoryStream<T>(T t, MemoryStream memoryStream) where T : IASN1PreparedElement
        {
            CoderFactory.getInstance().newEncoder("DER").encode<T>(t, memoryStream);            
        }

        public static T DerDecode<T>(string message)
        {
            return DerDecode<T>(HexStringToByteArray(message));
        }

        public static T DerDecode<T>(byte[] message)
        {
            return DerDecode<T>(message, 0, message.Length);
        }

        public static T DerDecode<T>(byte[] message, int offset, int length)
        {
            MemoryStream memoryStream = new MemoryStream(message, offset, length);
            try
            {
                return DerDecode<T>(memoryStream);
            }
            finally
            {
                memoryStream.Close();
            }
        }

        public static T DerDecode<T>(MemoryStream memoryStream)
        {
            return CoderFactory.getInstance().newDecoder("DER").decode<T>(memoryStream);            
        }

        #endregion

        #region Extensions

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi == null)
            {
                throw new Exception(string.Format("GetEnumDescription() was unable to GetField for {0} of value {1}", value.GetType(), value.ToString()));
            }

            DescriptionAttribute[] attributes =
             (DescriptionAttribute[])fi.GetCustomAttributes(
             typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static string GetDescription(this Enum value)
        {
            return GetEnumDescription(value);
        }

        #endregion

    }
}
