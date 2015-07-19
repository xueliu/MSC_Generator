/*

Copyright (C) 2005-2007 by Itesys Institut fuer Technische Systeme GmbH
http://www.itesys-gmbh.de   
mailto:software@itesys.de

This file is part of sdgen. Project home:
http://www.itesys-gmbh.de/home/produkte/msc_generator.html

sdgen is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

sdgen is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with sdgen; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

*/
/*
 * Erstellt mit SharpDevelop.
 * Benutzer: LG
 * Datum: 15.10.2007
 * Zeit: 12:10
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using mscElements;
using xmi;

namespace xmiExport
{
	/// <summary>
	/// Description of UmlModelElementCreator.
	/// </summary>
	
	public class UmlModelElementCreator:XmlElementCreator
	{
		public UmlModelElementCreator(XmlDocument xmiDocument,XmlDocumentBuilder xmiDocumentBuilder):
									  base(xmiDocument,xmiDocumentBuilder){}	
		
		public XmlElement CreateUmlModelElement(String modelName)
		{
			XmlDocument xmiDocument=this.XmiDocument;
			XmlElement documentElement=xmiDocument.DocumentElement;
			XmlElement modelElement=CreateUmlElement(documentElement,UmlModel.UML_MODEL); 
			AddUmlModelNameAttribute(modelElement,modelName);
			return modelElement;
		}
		
		private void AddUmlModelNameAttribute(XmlElement modelElement,String modelName)
		{
			AddAttribute(modelElement,UmlModel.NAME_ATTR_NAME,modelName);
		}
	}
}
