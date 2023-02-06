using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
/// <summary>
/// Summary description for Encrypt
/// </summary>
public class Encrypt
{
    private static byte[] key = { };
    private static byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };


    /// <summary>***************************************
    ///  Perform Decription on Encrypted string 
    /// </summary>**************************************
    public static string Decryptstr(string stringToDecrypt)
    {
        stringToDecrypt = stringToDecrypt.Replace(" ", "+");
        string sEncryptionKey = "!#$a54?3";// ConfigurationSettings.AppSettings["EncKey"].ToString();
        byte[] inputByteArray = new byte[stringToDecrypt.Length];
        MemoryStream ms;
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(ms.ToArray());

        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }

    }
    /// <summary>***************************************
    ///  Perform Encription on the specified string 
    /// </summary>**************************************
    
    public static string Encryptstr(string stringToEncrypt)
    {
        string SEncryptionKey = "!#$a54?3";//ConfigurationSettings.AppSettings["EncKey"].ToString();
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8));

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }
}
