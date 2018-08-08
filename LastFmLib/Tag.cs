/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-03-19
 * Time: 20:35
 * 
 */
using System;
using System.Net;
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
			set {
				this.shortTag.Name = value;
			}
		}
		
		public string Url
		{ 
			get {
				return this.shortTag.Url;
			}
			set {
				this.shortTag.Url = value;
			}
		}
		
		public int Total;
		public int Reach;
		
		public string Summary;
		public string Description;
		
		public string Status;
		
		public Tag()
		{
			Name = "No name";
			Url = String.Empty;
			Total = 0;
			Reach = 0;
			Summary = "No description";
			Description = "No description";
			Status = "ok";
		}
		
		public Tag(string file)
		{
			FromFile(file);
		}
		
		public void FromFile(string file)
		{
			string xml = File.ReadAllText(file);
			FromText(xml);
		}
		
		public void FromText(string xml)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
			
			this.Name = doc.GetElementsByTagName("name")[0].InnerText;
			this.Url = "http://last.fm/tag/"+this.Name.ToLower().Replace(' ', '+');
			
			this.Total = int.Parse(doc.SelectNodes("lfm/tag/total")[0].InnerText);
			this.Reach = int.Parse(doc.SelectNodes("lfm/tag/reach")[0].InnerText);
			
			this.Summary = doc.GetElementsByTagName("summary")[0].InnerText;
			this.Description = doc.GetElementsByTagName("content")[0].InnerText;
			
			this.Status = doc.SelectNodes("lfm/@status")[0].InnerText;
		}
		
		public void Save(string file)
		{
			XmlDocument doc = new XmlDocument();
			XmlElement lfm = doc.CreateElement("lfm");
			lfm.SetAttribute("status", Status);
			XmlElement tag = doc.CreateElement("tag");
			
			XmlElement name = doc.CreateElement("name");
			name.InnerText = Name;
			
			XmlElement total = doc.CreateElement("total");
			total.InnerText = Total.ToString();
			
			XmlElement reach = doc.CreateElement("reach");
			reach.InnerText = Reach.ToString();
			
			XmlElement wiki = doc.CreateElement("wiki");
			XmlElement summary = doc.CreateElement("summary");
			summary.InnerText = Summary;
			XmlElement content = doc.CreateElement("content");
			content.InnerText = Description;
			
			wiki.AppendChild(summary);
			wiki.AppendChild(content);
			
			tag.AppendChild(name);
			tag.AppendChild(total);
			tag.AppendChild(reach);
			tag.AppendChild(wiki);
			
			lfm.AppendChild(tag);
			doc.AppendChild(lfm);
			
			doc.Save(file);
		}
		
		public void GetInfo(string tagName)
		{
			Name = tagName;
			GetInfo();
		}
		
		public void GetInfo()
		{
			using(WebClient client = new WebClient())
			{
				string name = Name.ToLower().Replace(' ', '+');
				string response = client.DownloadString("http://ws.audioscrobbler.com/2.0/?method=tag.getInfo&tag="+name+"&api_key="+Authenticator.APIKey);
				FromText(response);
			}
		}
	}
}
