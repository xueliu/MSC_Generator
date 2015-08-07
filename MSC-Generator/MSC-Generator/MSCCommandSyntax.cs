/*
 * Created by SharpDevelop.
 * User: Koto
 * Date: 17.01.2006
 * Time: 13:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace mscEditor
{
	/// <summary>
	/// Description of MSCCommandSyntax.
	/// </summary>
	public enum ParamType{
		ElementID,
		InstanceID,
		Text,
		Format,
		Property,
		None
	}
	public enum CommandType{
		Command,
		Property
	}
	public delegate void RunCommandFunction(int line);

	public class MSCCommandSyntax
	{
		private string mCommand = String.Empty;
		private bool mInstanceBuilder = false;
		private int[] mElementID;
		private int[] mInstanceID;
		private int[] mText;
		private int[] mFormat;
		private int[] mProperty;
		private CommandType mCommandType;
		private RunCommandFunction mRCF;
		
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text)
		{
			mCommand = command;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mCommandType = CommandType.Command;
			mFormat = new int[]{};
			mProperty = new int[]{};
		}
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text, int[] format)
		{
			mCommand = command;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mFormat = format;
			mCommandType = CommandType.Command;
			mProperty = new int[]{};
		}
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text, bool instanceBuilder)
		{
			mCommand = command;
			mInstanceBuilder = instanceBuilder;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mCommandType = CommandType.Command;
			mFormat = new int[]{};
			mProperty = new int[]{};
		}
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text, int[] format, bool instanceBuilder)
		{
			mCommand = command;
			mInstanceBuilder = instanceBuilder;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mFormat = format;
			mCommandType = CommandType.Command;
			mProperty = new int[]{};
		}
		public MSCCommandSyntax(string command, int[] property)
		{
			mCommand = command;
			mElementID = new int[]{};
			mInstanceID = new int[]{};
			mText = new int[]{};
			mFormat = new int[]{};
			mCommandType = CommandType.Property;
			mProperty = property;
		}
		
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text, RunCommandFunction rcf)
		{
			mCommand = command;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mFormat = new int[]{};
			mProperty = new int[]{};
			mCommandType = CommandType.Command;
			mRCF = rcf;
		}
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text, int[] format, RunCommandFunction rcf)
		{
			mCommand = command;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mFormat = format;
			mCommandType = CommandType.Command;
			mProperty = new int[]{};
			mRCF = rcf;
		}
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text, bool instanceBuilder, RunCommandFunction rcf)
		{
			mCommand = command;
			mInstanceBuilder = instanceBuilder;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mCommandType = CommandType.Command;
			mFormat = new int[]{};
			mProperty = new int[]{};
			mRCF = rcf;
		}
		public MSCCommandSyntax(string command, int[] elementID, int[] instanceID, int[] text, int[] format, bool instanceBuilder, RunCommandFunction rcf)
		{
			mCommand = command;
			mInstanceBuilder = instanceBuilder;
			mElementID = elementID;
			mInstanceID = instanceID;
			mText = text;
			mCommandType = CommandType.Command;
			mFormat = format;
			mProperty = new int[]{};
			mRCF = rcf;
		}
		public MSCCommandSyntax(string command, int[] property, RunCommandFunction rcf)
		{
			mCommand = command;
			mCommandType = CommandType.Property;
			mElementID = new int[]{};
			mInstanceID = new int[]{};
			mText = new int[]{};
			mFormat = new int[]{};
			mProperty = property;
			mRCF = rcf;
		}

		public string command{
			get{
				return mCommand;
			}
		}
		public bool instanceBuilder{
			get{
				return mInstanceBuilder;
			}
		}
		public CommandType Type{
			get{
				return mCommandType;
			}
		}
		
		public ParamType GetParamType(int pos)
		{
			for (int i=0; i<mElementID.Length; i++){
				if (mElementID[i] == pos) return ParamType.ElementID;
			}
			for (int i=0; i<mInstanceID.Length; i++){
				if (mInstanceID[i] == pos) return ParamType.InstanceID;
			}
			for (int i=0; i<mText.Length; i++){
				if (mText[i] == pos) return ParamType.Text;
			}
			for (int i=0; i<mFormat.Length; i++){
				if (mFormat[i] == pos) return ParamType.Format;
			}
			for (int i=0; i<mProperty.Length; i++){
				if (mProperty[i] == pos) return ParamType.Property;
			}
			return ParamType.None;
		}
		
		public void RunFunction(int line){
			//System.Windows.Forms.MessageBox.Show(mCommand);
			if (mRCF!=null){
				mRCF(line);
			}
		}
	}
}
