/*
 * Created by SharpDevelop.
 * User: lx
 * Date: 8/10/2015
 * Time: 11:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;

namespace nGenerator.Xmi
{
	/// <summary>
	/// Description of EclipseProject.
	/// </summary>
	public class EclipseProject
	{
		private const String eclipseProjectName = @".project";
		
		public EclipseProject(String pathname, String name)
		{
			this.PathName = pathname;
			this.Name = name;
		}

		public String ProjectDescription {
			get;
			set;
		}
		
		public String Name {
			get;
			set;
		}
		
		public String PathName {
			get;
			set;
		}

		public String Comment {
			get;
			set;
		}		
		

		public String Projects {
			get;
			set;
		}

		public String BuildSpec {
			get;
			set;
		}			
			
		public String Natures {
			get;
			set;
		}
		
		public String EclipseProjectName {
			get { return eclipseProjectName; } 
		}
		
		public void Export() {
			XmlWriterSettings settings = new XmlWriterSettings();
        	//settings.Encoding = Encoding.UTF8;
        	settings.Indent = true;
			using (XmlWriter writer = XmlWriter.Create(PathName + "//" + EclipseProjectName, settings)) {

			    writer.WriteStartDocument();
			    writer.WriteStartElement("projectDescription");
		
				writer.WriteElementString("name", this.Name);
				writer.WriteElementString("comment", "");
				writer.WriteElementString("projects", "");
				writer.WriteElementString("buildSpec", "");
				writer.WriteElementString("natures", "");
			    writer.WriteEndElement();
			    writer.WriteEndDocument();
			}
		}
		
		public void Import() {
		
		}
	}
}
