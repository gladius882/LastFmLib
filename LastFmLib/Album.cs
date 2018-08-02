/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-08-02
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace LastFmLib
{
	/// <summary>
	/// Description of Album.
	/// </summary>
	public class Album
	{
		public string Name;
		public string Artist;
		public string Mbid;
		public string Url;
		
		public Image Image;
		
		public int Listeners;
		public int Playcount;
		
		public List<Track> Tracks;
		
		public string Status;
		
		public Album()
		{
			this.Image = new Image();
			this.Tracks = new List<Track>();
		}
		
		public void Load(string file)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			
			this.Name = doc.SelectNodes("lfm/album/name")[0].InnerText;
			this.Artist = doc.SelectNodes("lfm/album/artist")[0].InnerText;
			this.Mbid = doc.SelectNodes("lfm/album/mbid")[0].InnerText;
			this.Url = doc.SelectNodes("lfm/album/url")[0].InnerText;
			
			this.Image.Small = doc.SelectNodes("lfm/album/image[@size=\"small\"]")[0].InnerText;
			this.Image.Medium = doc.SelectNodes("lfm/album/image[@size=\"medium\"]")[0].InnerText;
			this.Image.Large = doc.SelectNodes("lfm/album/image[@size=\"large\"]")[0].InnerText;
			this.Image.ExtraLarge = doc.SelectNodes("lfm/album/image[@size=\"extralarge\"]")[0].InnerText;
			
			this.Listeners = int.Parse(doc.SelectNodes("lfm/album/listeners")[0].InnerText);
			this.Playcount = int.Parse(doc.SelectNodes("lfm/album/playcount")[0].InnerText);
			
			this.Status = doc.SelectNodes("lfm/@status")[0].InnerText;
			
			XmlNodeList selectedTracks = doc.SelectNodes("lfm/album/tracks/track");
			foreach(XmlNode track in selectedTracks)
			{
				// TODO Album.Load
				this.Tracks.Add(new Track());
			}
		}
	}
}
