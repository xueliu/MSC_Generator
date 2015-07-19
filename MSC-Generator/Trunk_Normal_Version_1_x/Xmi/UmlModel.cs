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
 * Datum: 01.10.2007
 * Zeit: 13:39
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;


namespace xmi{
	/// <summary>
	/// Description of SeqeunceChartConstant.
	/// </summary>
	/// 
	
	
	
	public class UmlModel
	{
		public const string UML_MODEL="Model";
		public const string GRAPH_CONNECTOR="GraphConnector";
		public const string LIFELINE="Lifeline";
		public const string INTERACTION="Interaction";
		public const string EXECUTION_SPECIFICATION="ExecutionSpecification";
		public const string EXECUTION_OCCURRENCE_SPECIFICATION="ExecutionOccurrenceSpecification";
		public const string MESSAGE="Message";
		public const string MESSAGE_OCCURRENCE_SPECIFICATION="MessageOccurrenceSpecification";
		public const string OCCURRENCE_SPECIFICATION="OccurenceSpecification";
		public const string MESSAGE_END="Interaction";
		public const string MESSAGE_SORT_SYNCH_CALL="synchCall";
		public const string MESSAGE_SORT_ASYNCH_CALL="asynchCall";
		public const string MESSAGE_SORT_ASYNCH_SIGNAL="asynchSignal";
		public const string MESSAGE_KIND_COMPLETE="complete";
		public const string MESSAGE_KIND_LOST="lost";
		public const string MESSAGE_KIND_FOUND="found";
		public const string MESSAGE_KIND_UNKNOWN="unknown";
		public const string XMI_NAMESPACE_URI="http://www.omg.org/XMI";
		public const string XMI_NAMESPACE_PREFIX="xmi";
   		public const string XMI_VERSION="2.1";
    	public const string XMI_VERSION_ATTR_NAME="version";
		public const string XMI_ID_ATTR_NAME="id";
		public const string XMI_ID_ATTR_COMPLETE_NAME="xmi:id";
		public const string XMI_TYPE_ATTR_NAME="type";
		public const string XMI_TYPE_ATTR_COMPLETE_NAME="xmi:type";
		public const string XMI_IDREF_ATTR_NAME="idref";
		public const string XMI_IDREF_ATTR_COMPLETE_NAME="xmi:idref";
		public const string NAME_ATTR_NAME="name";
		public const string UML_NAMESPACE_PREFIX="uml";
        public const string UML_NAMESPACE_URI="http://www.omg.org/UML2";
        public const string MESSAGE_KIND_ATTR_NAME="messageKind";
        public const string MESSAGE_SORT_ATTR_NAME="messageSort";
		public const string COLLABORATION="Collaboration";
		public const string MESSAGE_ATTR_NAME="message";
		public const string RECEIVE_EVENT_ATTR_NAME="receiveEvent";
		public const string SEND_EVENT_ATTR_NAME="sendEvent";
		public const string START_ATTR_NAME="start";
		public const string FINISH_ATTR_NAME="finish";
		public const string TYPE_INFO_ATTR_NAME="typeInfo";
		public const string EXECUTION_ATTR_NAME="execution";
		public const string CORE_SEMANTIC_MODEL_BRIDGE="CoreSemanticModelBridge";
		public const string SIMPLE_SEMANTIC_MODEL_ELEMENT="SimpleSemanticModelElement";
		public const string ELEMENT_ATTR_NAME="element";
		public const string POSITION_ATTR_NAME="position";
		public const string DIMENSION_ATTR_NAME="dimension";
		public const string DOUBLE_TYPE_NAME="double";
		public const string GRAPH_NODE="GraphNode";
		public const string GRAPH_EDGE="GraphEdge";
		public const string DIAGRAM="Diagram";
		public const string GRAPH_EDGE_ATTR_NAME="graphEdge";
		public const string ANCHOR_ATTR_NAME="anchor";
		public const string COVERED_ATTR_NAME="covered";
		public const string BEHAVIOR_EXECUTION_SPECIFICATION="BehaviorExecutionSpecification";
		public const string PROPERTY="Property";
		public const string TYPE_ATTR_NAME="type";
		public const string REPRESENTS_ATTR_NAME="represents";
		public const string CLASS="Class";
		public const string COVERED_BY_ATTR_NAME="coveredBy";
		public const string EXECUTION_EVENT="ExecutionEvent";
		public const string SEND_OPERATION_EVENT="SendOperationEvent";
		public const string RECEIVE_OPERATION_EVENT="ReceiveOperationEvent";
		public const string EVENT_ATTR_NAME="event";
		public const string ASYNCH_SIGNAL="asynchSignal";
		public const string ASYNCH_CALL="asynchCall";
		public const string SYNCH_CALL="synchCall";
		public const string RECEIVE_SIGNAL_EVENT="ReceiveSignalEvent";
		public const string SEND_SIGNAL_EVENT="SendSignalEvent";
	}
}
