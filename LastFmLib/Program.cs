/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-03-19
 * Time: 20:32
 * 
 */
using System;
using System.IO;
using System.Xml;

namespace LastFmLib
{
	class Program
	{
		public static void Main(string[] args)
		{
			Authenticator.Initialize("6c295fdbad8695ff5b29afacc5770358");
			
			Artist artist = new Artist();
			artist.GetInfo("Led Zeppelin");
			
			Console.WriteLine(artist.Name);
			Console.WriteLine(artist.Summary);
			
			Console.ReadKey(true);
		}
	}
}