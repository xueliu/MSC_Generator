/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Administrator
 * Datum: 19.10.2007
 * Zeit: 13:11
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;

namespace xmi
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class UmlModelElements
	{
		
		public const string UML_MODEL="Model";
		public const string LIFELINE="Lifeline";
		public const string INTERACTION="Interaction";
		public const string MESSAGE="Message";
		public const string MESSAGE_END="Interaction";
		public const string MESSAGE_SORT_SYNCH_CALL="synchCall";
		public const string MESSAGE_SORT_ASYNCH_CALL="asynchCall";
		public const string MESSAGE_SORT_ASYNCH_SIGNAL="asynchSignal";
		public const string MESSAGE_KIND_COMPLETE="complete";
		public const string MESSAGE_KIND_LOST="lost";
		public const string MESSAGE_KIND_FOUND="found";
		public const string MESSAGE_KIND_UNKNOWN="unknown";
		public const string NAME_ATTR_NAME="name";
		public const string MESSAGE_KIND_ATTR_NAME="messageKind";
        public const string MESSAGE_SORT_ATTR_NAME="messageSort";
        public const string MESSAGE_ATTR_NAME="message";
        public const string RECEIVE_EVENT_ATTR_NAME="receiveEvent";
        public const string SEND_EVENT_ATTR_NAME="sendEvent";
        public const string MESSAGE_OCCURRENCE_SPECIFICATION="MessageOccurrenceSpecification"; 
	}
}
