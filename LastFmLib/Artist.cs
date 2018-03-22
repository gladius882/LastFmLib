/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-03-20
 * Time: 18:22
 * 
 */
using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace LastFmLib
{
	/// <summary>
	/// Description of Artist.
	/// </summary>
	public class Artist
	{
		public string Name { get; private set; }
		public string Mbid { get; private set; }
		public string Url { get; private set; }
		
		public Image Image { get; private set; }
		
		public int Streamable { get; private set; }
		public int OnTuor { get; private set; }
		
		public int Listeners { get; private set; }
		public int PlayCount { get; private set; }
		
		public string Status { get; private set; }
		
		public List<Tag> Tags { get; private set; }
		
		public Artist()
		{
		}
		
		public void Load(string file)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			
			this.Name = doc.SelectNodes("lfm/artist/name")[0].InnerText;
			this.Mbid = doc.GetElementsByTagName("mbid")[0].InnerText;
			this.Url = doc.SelectNodes("lfm/artist/url")[0].InnerText;
			
			this.Image = new Image();
			this.Image.Small = doc.SelectNodes("lfm/artist/image[@size=\"small\"]")[0].InnerText;
			this.Image.Medium = doc.SelectNodes("lfm/artist/image[@size=\"medium\"]")[0].InnerText;
			this.Image.Large = doc.SelectNodes("lfm/artist/image[@size=\"large\"]")[0].InnerText;
			this.Image.ExtraLarge = doc.SelectNodes("lfm/artist/image[@size=\"extralarge\"]")[0].InnerText;
			
			this.Streamable = int.Parse(doc.SelectNodes("lfm/artist/streamable")[0].InnerText);
			this.OnTuor = int.Parse(doc.SelectNodes("lfm/artist/ontour")[0].InnerText);
			
			this.Listeners = int.Parse(doc.SelectNodes("lfm/artist/stats/listeners")[0].InnerText);
			this.PlayCount = int.Parse(doc.SelectNodes("lfm/artist/stats/playcount")[0].InnerText);
			
			this.Status = doc.SelectNodes("lfm/@status")[0].InnerText;
		}
	}
}
