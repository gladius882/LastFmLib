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
			
			Album album = new Album();
			album.GetInfo("The Cranberries", "No need to argue");
			
			Console.WriteLine(album.Name);
			Console.WriteLine(album.Url);
			Console.WriteLine(album.Summary);
			
//			Track t = new Track();
//			t.Load("The Cranberries - Zombie.xml");
//			
//			Console.WriteLine(t.Name);
//			Console.WriteLine(t.Mbid);
//			Console.WriteLine(t.Url);
//			Console.WriteLine(t.Position);
//			Console.WriteLine(t.Duration);
//			Console.WriteLine(t.Published);
			
			Console.ReadKey(true);
		}
	}
}