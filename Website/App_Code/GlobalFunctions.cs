using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Here are the functions / methods that will need to be called over and over again,
/// or simply need to be called from different pages. A nice convenient place that
/// any reusable method can be reached from.
/// 
/// jgunter7
/// December 2014
/// </summary>
public class GlobalFunctions
{
	public GlobalFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert the byte array to hexadecimal string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
}