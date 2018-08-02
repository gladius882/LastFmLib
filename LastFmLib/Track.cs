/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-08-02
 * Time: 17:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace LastFmLib
{
	/// <summary>
	/// Description of Track.
	/// </summary>
	public class Track
	{
		private ShortTrack shortTrack;
		
		public string Name
		{
			get {
				return this.shortTrack.Name;
			}
			set {
				this.shortTrack.Name = value;
			}
		}
		
		public string Mbid;
		
		public string Url
		{
			get {
				return this.shortTrack.Url;
			}
			set {
				this.shortTrack.Url = value;
			}
		}
		
		public int Position
		{
			get {
				return this.shortTrack.Position;
			}
			set {
				this.shortTrack.Position = value;
			}
		}
		
		public int Duration
		{
			get {
				return this.shortTrack.Duration;
			}
			set {
				this.shortTrack.Duration = value;
			}
		}
		
		public int Streamable
		{
			get {
				return this.shortTrack.Streamable;
			}
			set {
				this.shortTrack.Streamable = value;
			}
		}
		
		public int Listeners;
		public int Playcount;
		
		public string ArtistName
		{
			get {
				return this.shortTrack.ArtistName;
			}
			set {
				this.shortTrack.ArtistName = value;
			}
		}
		
		public string ArtistMbid
		{
			get {
				return this.shortTrack.ArtistMbid;
			}
			set {
				this.shortTrack.ArtistMbid = value;
			}
		}
		
		public string ArtistUrl
		{
			get {
				return this.shortTrack.ArtistUrl;
			}
			set {
				this.shortTrack.ArtistUrl = value;
			}
		}
		
		public string AlbumArtist;
		public string AlbumTitle;
		public string AlbumMbid;
		public string AlbumUrl;
		public Image AlbumImage;
		
		public List<ShortTag> Tags;
		
		public DateTime Published;
		public string WikiSummary;
		public string WikiContent;
		
		public string Status;
		
		public Track()
		{
			this.shortTrack = new ShortTrack();
			this.AlbumImage = new Image();
			this.Tags = new List<ShortTag>();
		}
		
		public void Load(string file)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			
			this.Name = doc.SelectNodes("lfm/track/name")[0].InnerText;
			this.Mbid = doc.SelectNodes("lfm/track/mbid")[0].InnerText;
			this.Url = doc.SelectNodes("lfm/track/url")[0].InnerText;
			
			this.Position = int.Parse(doc.SelectNodes("lfm/track/album/@position")[0].InnerText);
			this.Duration = int.Parse(doc.SelectNodes("lfm/track/duration")[0].InnerText)/1000;
			
			this.Streamable = int.Parse(doc.SelectNodes("lfm/track/streamable")[0].InnerText);
			this.Listeners = int.Parse(doc.SelectNodes("lfm/track/listeners")[0].InnerText);
			this.Playcount = int.Parse(doc.SelectNodes("lfm/track/playcount")[0].InnerText);
			
			this.ArtistName = doc.SelectNodes("lfm/track/artist/name")[0].InnerText;
			this.ArtistMbid = doc.SelectNodes("lfm/track/artist/mbid")[0].InnerText;
			this.ArtistUrl = doc.SelectNodes("lfm/track/artist/url")[0].InnerText;
			
			this.AlbumArtist = doc.SelectNodes("lfm/track/album/artist")[0].InnerText;
			this.AlbumTitle = doc.SelectNodes("lfm/track/album/title")[0].InnerText;
			this.AlbumMbid = doc.SelectNodes("lfm/track/album/mbid")[0].InnerText;
			this.AlbumUrl = doc.SelectNodes("lfm/track/album/url")[0].InnerText;
			this.AlbumImage.Small = doc.SelectNodes("lfm/track/album/image[@size=\"small\"]")[0].InnerText;
			this.AlbumImage.Medium = doc.SelectNodes("lfm/track/album/image[@size=\"medium\"]")[0].InnerText;
			this.AlbumImage.Large = doc.SelectNodes("lfm/track/album/image[@size=\"large\"]")[0].InnerText;
			this.AlbumImage.ExtraLarge = doc.SelectNodes("lfm/track/album/image[@size=\"extralarge\"]")[0].InnerText;
			
			XmlNodeList selectedTags = doc.SelectNodes("lfm/track/toptags/tag");
			foreach(XmlNode node in selectedTags)
			{
				ShortTag tag = new ShortTag();
				tag.Name = node.SelectNodes("name")[0].InnerText;
				tag.Url = node.SelectNodes("url")[0].InnerText;
			}
			
			this.Published = DateTime.Parse(doc.SelectNodes("lfm/track/wiki/published")[0].InnerText);
			
			this.WikiSummary = doc.SelectNodes("lfm/track/wiki/summary")[0].InnerText;
			this.WikiContent = doc.SelectNodes("lfm/track/wiki/content")[0].InnerText;
			
			this.Status = doc.SelectNodes("lfm/@status")[0].InnerText;
		}
		
		public ShortTrack GetShort()
		{
			return this.shortTrack;
		}
	}
}
