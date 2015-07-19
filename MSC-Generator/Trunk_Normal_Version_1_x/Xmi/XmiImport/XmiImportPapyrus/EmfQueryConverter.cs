/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 03.12.2007
 * Zeit: 18:12
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Xml;
using System.Xml.XPath;
using System.Collections;

namespace xmiImportPapyrus
{
	/// <summary>
	/// Description of ReferenceValueConverter.
	/// </summary>
	public class EmfQueryConverter
	{
		private const string  FIRST_DIAGRAM_CONTAINED_ELEMENT="/1/@contained.0/";
		private const int INDEX_THIRD_SLASH=16; 
		private const int START_INDEX_OF_THIRD_SLASH_SEARCH=14;
		private const int INDEX_ZERO=0;
		private const int INDEX_ONE=1;
		private const int LENGTH_OF_ADD=1;
		private const string SLASH="/";
		private const string POINT=".";
		private const string OPENED_SQUARED_BRACKET="[";
		private const string CLOSED_SQUARED_BRACKET="]";
		private const string SPACE=" ";
		private ArrayList convertedOueryValues;
		
		
		public EmfQueryConverter()
		{
			convertedOueryValues=new ArrayList();
		}
		
		public ArrayList ConvertEmfQuery(string emfXPathQuerys)
		{
			string currentEmfXPathQuery;
			int indexOfSpace;	
			
			while(emfXPathQuerys.Length>0)
			{
				indexOfSpace=emfXPathQuerys.IndexOf(SPACE);
				
				if(indexOfSpace==-1)
				{
					currentEmfXPathQuery=emfXPathQuerys.Substring(INDEX_ZERO,emfXPathQuerys.Length);
					currentEmfXPathQuery=RemoveDiagramContainedElementQuery(currentEmfXPathQuery);
					AddXPathQuery(currentEmfXPathQuery);
					emfXPathQuerys=emfXPathQuerys.Remove(INDEX_ZERO,emfXPathQuerys.Length);	
				}
				else if(indexOfSpace>0)
				{
					currentEmfXPathQuery=emfXPathQuerys.Substring(INDEX_ZERO,indexOfSpace);
					currentEmfXPathQuery=RemoveDiagramContainedElementQuery(currentEmfXPathQuery);
					AddXPathQuery(currentEmfXPathQuery);
					emfXPathQuerys=emfXPathQuerys.Remove(INDEX_ZERO,indexOfSpace);
					emfXPathQuerys=emfXPathQuerys.Trim();
				}
			}
			
			return convertedOueryValues;
		}
		
		private void AddXPathQuery(string emfXPathQuery)
		{
			int indexOfSlash;
			string convertedXPathQuery=null;
			string convertedXPathQueryPart=null;
			
			while(emfXPathQuery.Length>0)
			{
				indexOfSlash=emfXPathQuery.IndexOf(SLASH);
				
				if(indexOfSlash==-1)
				{
					convertedXPathQueryPart=emfXPathQuery.Substring(INDEX_ONE,emfXPathQuery.Length-1);;
					convertedXPathQueryPart=convertedXPathQueryPart.Replace(POINT,OPENED_SQUARED_BRACKET);
					convertedXPathQueryPart=convertedXPathQueryPart+CLOSED_SQUARED_BRACKET;
					emfXPathQuery=emfXPathQuery.Remove(INDEX_ZERO,emfXPathQuery.Length);	
				}
				else if(indexOfSlash>0)
				{
					convertedXPathQueryPart=emfXPathQuery.Substring(INDEX_ONE,indexOfSlash);
					convertedXPathQueryPart=convertedXPathQueryPart.Replace(POINT,OPENED_SQUARED_BRACKET);
					convertedXPathQueryPart=convertedXPathQueryPart.Insert(indexOfSlash-1,CLOSED_SQUARED_BRACKET);
					emfXPathQuery=emfXPathQuery.Remove(INDEX_ZERO,indexOfSlash+1);
				}
				
				convertedXPathQuery=convertedXPathQuery+convertedXPathQueryPart;
			}
			convertedOueryValues.Add(convertedXPathQuery);
		}
		
		private string RemoveDiagramContainedElementQuery(string emfXPathOuery)
		{
			bool containsFirstDiagramContainedElement=emfXPathOuery.Contains(FIRST_DIAGRAM_CONTAINED_ELEMENT);
		
			if(containsFirstDiagramContainedElement)
			{
				emfXPathOuery=emfXPathOuery.Remove(INDEX_ZERO,INDEX_THIRD_SLASH);
				emfXPathOuery.Trim();
			}
			return emfXPathOuery;
		}
	}
}
