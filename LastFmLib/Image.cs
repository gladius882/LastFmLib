/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-03-20
 * Time: 18:34
 * 
 */
using System;
using System.Net;

namespace LastFmLib
{
	/// <summary>
	/// Description of Image.
	/// </summary>
	
	public enum ImageSize
	{
		Small = 34,
		Medium = 64,
		Large = 174,
		ExtraLarge = 300
	}
	
	public class Image
	{
		public string Small { get; set; }
		public string Medium { get; private set; }
		public string Large { get; private set; }
		public string ExtraLarge { get; private set; }
		
		public Image()
		{
		}
		
		public string getLink(ImageSize size)
		{
			switch(size)
			{
				case ImageSize.Small: return Small;
				case ImageSize.Medium: return Medium;
				case ImageSize.Large: return Large;
				case ImageSize.ExtraLarge: return ExtraLarge;
				default: return Small;
			}
		}
		
		public void Download(string destination, ImageSize size)
		{
			using(WebClient client = new WebClient())
			{
				client.DownloadFile(new Uri(getLink(size)), destination);
			}
		}
	}
	
}
