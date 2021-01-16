using AdminProject.CommonLayer.Aspects.Utitlities;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace AdminProject.CommonLayer.Aspects.Security
{
    public static class EncryptionEngine
    {
        //private IMemoryCache cache;

        //public EncryptionEngine(IMemoryCache memoryCache)
        //{
        //    cache = memoryCache;
        //}

        private const int KEY_SIZE = 256;
        private static string initVector = string.Empty;
        private const string cacheKey = "Dictionary";

        //private static MemoryCache cache = new MemoryCache();
        /// <summary>
        /// Method to encrypt the plain text into the system
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <returns>returns encrypted text</returns>
        public static string Encrypt(string plainText)
        {
            string encryptedText = string.Empty;
            if (String.IsNullOrEmpty(plainText))
                return string.Empty;
            try
            {
                string key = AppUtil.GetAppSettings(AspectEnums.ConfigKeys.EncryptionSaltKey);
                initVector = AppUtil.GetAppSettings(AspectEnums.ConfigKeys.EncryptionInitVector);
                byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(key, null);
                byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] Encrypted = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                encryptedText = Convert.ToBase64String(Encrypted);
            }
            catch (Exception)
            {

            }
            return encryptedText;
        }

        /// <summary>
        /// Method to decrypt the encrypted text into the system
        /// </summary>
        /// <param name="encryptedText">encrypted text</param>
        /// <returns>returns plain text</returns>
        public static string Decrypt(string encryptedText)
        {
            string plainText = string.Empty;
            try
            {
                if (String.IsNullOrEmpty(encryptedText))
                    return string.Empty;
                string key = AppUtil.GetAppSettings(AspectEnums.ConfigKeys.EncryptionSaltKey);
                initVector = AppUtil.GetAppSettings(AspectEnums.ConfigKeys.EncryptionInitVector);
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] DeEncryptedText = Convert.FromBase64String(encryptedText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(key, null);
                byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(DeEncryptedText);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[DeEncryptedText.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            catch (Exception)
            {

            }
            return plainText;
        }

        /// <summary>
        /// Method to encrypt plain text using custom method
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <returns>returns encrypted text</returns>
        public static string EncryptString(string plainText)
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dictionaryFilePath = buildDir + "\\Config\\DictionaryEncryption.xml";
            if (String.IsNullOrEmpty(plainText))
                return string.Empty;
            string encryptedText = string.Empty;
            try
            {
                DataSet dictionarySet = new DataSet();

                char[] textArray = plainText.ToArray();
                //string dictionaryFilePath = HostingEnvironment.ApplicationPhysicalPath + @"" + AppUtil.GetAppSettings(AspectEnums.ConfigKeys.EncryptionDictionary);
                dictionarySet.ReadXml(dictionaryFilePath);

                dictionarySet.Tables[0].CaseSensitive = true;
                foreach (char val in textArray)
                {
                    DataRow[] foundRow = dictionarySet.Tables[0].Select("CharacterValue = ('" + val.ToString().Replace("'", "''") + "')");
                    foreach (DataRow row in foundRow)
                    {
                        encryptedText = encryptedText + row[1].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ReverseString(encryptedText);
        }

        /// <summary>
        /// Method to encrypt plain text using custom method
        /// </summary>
        /// <param name="encryptedText">plain text</param>
        /// <returns>returns encrypted text</returns>
        public static string DecryptString(string encryptedText)
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dictionaryFilePath = buildDir + "\\Config\\DictionaryEncryption.xml";
            if (String.IsNullOrEmpty(encryptedText))
                return string.Empty;
            string plainText = string.Empty;
            int characterLength = 2;
            try
            {
                encryptedText = ReverseString(encryptedText);
                DataSet dictionarySet = new DataSet();
                //string dictionaryFilePath = HostingEnvironment.ApplicationPhysicalPath + @"" + AppUtil.GetAppSettings(AspectEnums.ConfigKeys.EncryptionDictionary);
                char[] textArray = encryptedText.ToArray();
                dictionarySet.ReadXml(dictionaryFilePath);

                //dictionarySet.ReadXml(dictionaryFilePath);
                dictionarySet.Tables[0].CaseSensitive = true;
                int index = 0;
                while (index < encryptedText.Length)
                {
                    DataRow[] foundRow = dictionarySet.Tables[0].Select("EncryptedValue = ('" + encryptedText.Substring(index, characterLength).Replace("'", "''") + "')");
                    foreach (DataRow row in foundRow)
                    {
                        plainText = plainText + row[0].ToString();
                    }
                    index = index + characterLength;
                }
            }
            catch (Exception)
            {

            }

            return plainText;
        }

        /// <summary>
        /// Method to reverse the characters in a word
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <returns>returns reversed string</returns>
        private static string ReverseString(string plainText)
        {
            char[] characters = plainText.ToArray();
            Array.Reverse(characters);
            return new String(characters);
        }
    }
}
