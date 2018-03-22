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
		// TODO add ShortTag class
		public string Name { get; private set; }
		public string Url { get; private set; }
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
			this.Summary = doc.GetElementsByTagName("summary")[0].InnerText;
			this.Description = doc.GetElementsByTagName("content")[0].InnerText;
			
			this.Status = doc.SelectNodes("lfm/@status")[0].InnerText;
		}
	}
}
