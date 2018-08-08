/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-08-08
 * Time: 12:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LastFmLib
{
	/// <summary>
	/// Description of Authenticator.
	/// </summary>
	public static class Authenticator
	{
		private static string _APIKey;
		private static string _SharedSecret;
		
		private static string _Token;
		private static DateTime _TokenExpire = new DateTime();
		
		public static string APIKey
		{
			get {
				return _APIKey;
			}
		}
		
		public static string SharedSecret
		{
			get {
				return _SharedSecret;
			}
		}
		
		public static string Token
		{
			get {
				return _Token;
			}
		}
		
		public static void Initialize(string key, string secret = "")
		{
			Authenticator._APIKey = key;
			Authenticator._SharedSecret = secret;
			Authenticator._Token = String.Empty;
		}
	}
}
