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
			Artist a = new Artist();
			a.Load("The Cranberries.xml");
			
			foreach(ShortTag t in a.Tags)
			{
				Console.WriteLine(t.Name);
				Console.WriteLine(t.Url+"\n");
			}
			
			
			Console.ReadKey(true);
		}
	}
}