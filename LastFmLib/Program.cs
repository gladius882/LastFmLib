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
			Image img = new Image();
			img.Small = "https://lastfm-img2.akamaized.net/i/u/34s/943152c140464b819e5188cec5a5b91f.png";
			img.Download("file.png", ImageSize.Small);
			
			Console.WriteLine("Download complete");
			
			Console.ReadKey(true);
		}
	}
}