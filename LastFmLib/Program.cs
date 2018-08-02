﻿/*
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
			Album album = new Album();
			album.Load("The Cranberries - No need to argue.xml");
			
			foreach(ShortTag tag in album.Tags)
			{
				Console.WriteLine(tag.Name);
				Console.WriteLine(tag.Url);
				Console.WriteLine();
			}
			
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