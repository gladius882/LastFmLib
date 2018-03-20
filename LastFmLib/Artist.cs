/*
 * Created by SharpDevelop.
 * User: gladius882
 * Date: 2018-03-20
 * Time: 18:22
 * 
 */
using System;
using System.Collections.Generic;

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
		
//		public Image Image { get; private set; }
		
		public int Streamable { get; private set; }
		public int OnTuor { get; private set; }
		
		public List<Tag> Tags { get; private set; }
		
		public Artist()
		{
		}
	}
}
