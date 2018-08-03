/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-03-19
 * Time: 20:35
 * 
 */
using System;
using System.IO;
using System.Xml;

namespace LastFmLib
{
	/// <summary>
	/// Description of Tag.
	/// </summary>
	public class Tag
	{
		private ShortTag shortTag = new ShortTag();
		
		public string Name
		{ 
			get {
				return this.shortTag.Name;
			}
			private set {
				this.shortTag.Name = value;
			}
		}
		
		public string Url
		{ 
			get {
				return this.shortTag.Url;
			}
			private set {
				this.shortTag.Url = value;
			}
		}
		
		public int Total;
		public int Reach;
		
		public string Summary { get; private set; }
		public string Description { get; private set; }
		
		public string Status { get; private set; }
		
		public Tag()
		{
		}
		
		public Tag(string file)
		{
			this.Load(file);
		}
		
		public void Load(string file)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			
			this.Name = doc.GetElementsByTagName("name")[0].InnerText;
			this.Url = "http://last.fm/tag/"+this.Name;
			
			this.Total = int.Parse(doc.SelectNodes("lfm/tag/total")[0].InnerText);
			this.Reach = int.Parse(doc.SelectNodes("lfm/tag/reach")[0].InnerText);
			
			this.Summary = doc.GetElementsByTagName("summary")[0].InnerText;
			this.Description = doc.GetElementsByTagName("content")[0].InnerText;
			
			this.Status = doc.SelectNodes("lfm/@status")[0].InnerText;
		}
	}
}
