using org.bn;
using org.bn.coders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace ePassport
{
    public static class Utils
    {
        /// <summary>
        /// Decode single OID value.
        /// </summary>
        /// <param name="bt">source stream.</param>
        /// <param name="v">output value</param>
        /// <returns>OID value bytes.</returns>
        private static int DecodeValue(Stream bt, ref BigInteger v)
        {
            byte b;
            int i = 0;
            v = 0;
            while (true)
            {
                b = (byte)bt.ReadByte();
                i++;
                v <<= 7;
                v += (ulong)(b & 0x7f);
                if ((b & 0x80) == 0)
                    return i;
            }
        }

        /// <summary>
        /// Decode OID <see cref="Stream"/> and return OID string.
        /// </summary>
        /// <param name="bt">source stream.</param>
        /// <returns>result OID string.</returns>
        private static string Decode(Stream bt)
        {
            string retval = "";
            byte b;
            BigInteger v = 0;
            b = (byte)bt.ReadByte();
            retval += Convert.ToString(b / 40);
            retval += "." + Convert.ToString(b % 40);
            while (bt.Position < bt.Length)
            {
                try
                {
                    DecodeValue(bt, ref v);
                    retval += "." + v.ToString();
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to decode OID value: " + e.Message);
                }
            }
            return retval;
        }

        /// <summary>
        /// Decode OID byte array to OID string.
        /// </summary>
        /// <param name="data">source byte array.</param>
        /// <returns>result OID string.</returns>
        public static string OIDDecode(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            ms.Position = 0;
            string retval = Decode(ms);
            ms.Close();
            return retval;
        }

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

    }
}
