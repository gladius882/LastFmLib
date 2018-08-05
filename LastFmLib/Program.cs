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
			Tag tag = new Tag();
			tag.Name = "Metal";
			tag.Save("output/Metal.xml");
			
			Track track = new Track();
			track.Name = "Stairway to heaven";
			track.Mbid = " ";
			track.Url = " ";
			track.ArtistName = "Led Zeppelin";
			track.ArtistMbid = " ";
			track.ArtistUrl = " ";
			track.Tags.Add(new ShortTag("rock", "https://last.fm/tag/rock"));
			track.AlbumTitle = "Some album of Led Zeppelin";
			track.Save("output/Led Zeppelin - Stairway to heaven.xml");
			
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