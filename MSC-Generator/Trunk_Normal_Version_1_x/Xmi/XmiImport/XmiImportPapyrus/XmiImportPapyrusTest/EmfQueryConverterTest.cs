/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 03.12.2007
 * Zeit: 19:37
 * 
 * Tests the method "ConvertEmfQuery" of the class "EmfQueryConverter"
 */

using System;
using System.Collections;
using NUnit.Framework;



namespace xmiImportPapyrus
{
	[TestFixture]
	public class EmfQueryConverterTest
	{
		private const string ONE_EMF_QUERY="/1/@contained.0/@contained.1";
		private const string FIRST_EXPECTED_XPATH_QUERY="contained[1]";
		private const string TWO_EMF_QUERY="/1/@contained.0/@contained.1 /1/@contained.0/@contained.2";
		private const string FIRST_OF_TWO_EXPECTED_XPATH_QUERY="contained[1]";
		private const string SECOND_OF_TWO_EXPECTED_XPATH_QUERY="contained[2]";
		private const string ONE_EMF_QUERY_DEPTH_TWO_ELEMENTS="/1/@contained.0/@contained.1/@anchorage.0";
		private const string ONE_EXPECTED_QUERY_DEPTH_TWO_ELEMENTS="contained[1]/anchorage[0]";
		private const string TWO_EMF_QUERY_DEPTH_TWO_ELEMENTS="/1/@contained.0/@contained.1/@anchorage.0 /1/@contained.0/@contained.2/@anchorage.1";
		private const string FIRST_OF_TWO_EXPECTED_QUERY_DEPTH_TWO_ELEMENTS="contained[1]/anchorage[0]";
		private const string SECOND_OF_TWO_EXPECTED_QUERY_DEPTH_TWO_ELEMENTS="contained[2]/anchorage[1]";
		private const string THREE_EMF_QUERY_DEPTH_THREE_ELEMENTS="/1/@contained.0/@contained.1/@contained.2/@anchorage.3 /1/@contained.0/@contained.4/@contained.5/@anchorage.6 /1/@contained.0/@contained.7/@contained.8/@anchorage.9";		
		private const string FIRST_OF_THREE_EXPECTED_QUERY_DEPTH_THREE_ELEMENTS="contained[1]/contained[2]/anchorage[3]";
		private const string SECOND_OF_THREE_EXPECTED_QUERY_DEPTH_THREE_ELEMENTS="contained[4]/contained[5]/anchorage[6]";
		private const string THIRD_OF_THREE_EXPECTED_QUERY_DEPTH_THREE_ELEMENTS="contained[7]/contained[8]/anchorage[9]";
		
		private EmfQueryConverter queryConverter;
		
		[SetUp]
		public void Init()
		{
			queryConverter =new EmfQueryConverter();
		}
		
		
		[Test]
		public void ConvertEmfQueryOneQueryTest()
		{
			ArrayList actualValueList=queryConverter.ConvertEmfQuery(ONE_EMF_QUERY);
			int actualValueListCount=actualValueList.Count;
			Assert.IsTrue(actualValueListCount==1);
			string actualQuery=(string)actualValueList[0];
			Assert.AreEqual(FIRST_EXPECTED_XPATH_QUERY,actualQuery);
		}
		
		[Test]
		public void ConvertEmfQueryTwoQueryTest()
		{
			ArrayList actualValueList=queryConverter.ConvertEmfQuery(TWO_EMF_QUERY);
			int actualValueListCount=actualValueList.Count;
			
			Assert.IsTrue(actualValueListCount==2);
			string firstActualQuery=(string)actualValueList[0];
			Assert.AreEqual(FIRST_OF_TWO_EXPECTED_XPATH_QUERY,firstActualQuery);
			string secondActualQuery=(string)actualValueList[1];
			Assert.AreEqual(SECOND_OF_TWO_EXPECTED_XPATH_QUERY,secondActualQuery);	
		}
		
		[Test]
		public void ConvertEmfQueryOneQueryDepthTwoTest()
		{
			ArrayList actualValueList=queryConverter.ConvertEmfQuery(ONE_EMF_QUERY_DEPTH_TWO_ELEMENTS);
			int actualValueListCount=actualValueList.Count;
			Assert.IsTrue(actualValueListCount==1);
			string actualQuery=(string)actualValueList[0];
			Assert.AreEqual(ONE_EXPECTED_QUERY_DEPTH_TWO_ELEMENTS,actualQuery);
		}
		
		[Test]
		public void ConvertEmfQueryTwoQueryDepthTwoTest()
		{
			ArrayList actualValueList=queryConverter.ConvertEmfQuery(TWO_EMF_QUERY_DEPTH_TWO_ELEMENTS);
			int actualValueListCount=actualValueList.Count;
			
			Assert.IsTrue(actualValueListCount==2);
			string firstActualQuery=(string)actualValueList[0];
			Assert.AreEqual(FIRST_OF_TWO_EXPECTED_QUERY_DEPTH_TWO_ELEMENTS,firstActualQuery);
			string secondActualQuery=(string)actualValueList[1];
			Assert.AreEqual(SECOND_OF_TWO_EXPECTED_QUERY_DEPTH_TWO_ELEMENTS,secondActualQuery);	
		}
		
		[Test]
		public void ConvertEmfQueryThreeQueryDepthThreeTest()
		{
			ArrayList actualValueList=queryConverter.ConvertEmfQuery(THREE_EMF_QUERY_DEPTH_THREE_ELEMENTS);
			int actualValueListCount=actualValueList.Count;
			
			Assert.IsTrue(actualValueListCount==3);
			string firstActualQuery=(string)actualValueList[0];
			Assert.AreEqual(FIRST_OF_THREE_EXPECTED_QUERY_DEPTH_THREE_ELEMENTS,firstActualQuery);
			string secondActualQuery=(string)actualValueList[1];
			Assert.AreEqual(SECOND_OF_THREE_EXPECTED_QUERY_DEPTH_THREE_ELEMENTS,secondActualQuery);	
			string thirdActualQuery=(string)actualValueList[2];
			Assert.AreEqual(THIRD_OF_THREE_EXPECTED_QUERY_DEPTH_THREE_ELEMENTS,thirdActualQuery);	
		}	
	}
}
