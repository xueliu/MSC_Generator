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
using System;
using System.Collections.Specialized;
using System.Collections;
using System.Text.RegularExpressions;

namespace CommandLine.Utility
{
    /// <summary>
    /// Arguments class
    /// </summary>
    public class Arguments{
        // Variables
        private ArrayList Options;
        private StringDictionary Parameters;

        // Constructor
        public Arguments()
        {
        	Options = new ArrayList();
            Parameters = new StringDictionary();
        }

        // Retrieve a parameter value if it exists 
        // (overriding C# indexer property)
        public string this [string Param]
        {
            get
            {
                return(Parameters[Param]);
            }
        }
        
        public void parse (string []Args)
        {
            // original: Regex Spliter = new Regex(@"^-{1,2}|^/|=|:",
            //    RegexOptions.IgnoreCase|RegexOptions.Compiled);
            Regex Spliter = new Regex(@"^-{1,2}|^/|=",
                RegexOptions.IgnoreCase|RegexOptions.Compiled);

            Regex Remover = new Regex(@"^['""]?(.*?)['""]?$",
                RegexOptions.IgnoreCase|RegexOptions.Compiled);

            string Parameter = null;
            string[] Parts;
            string lastArgs = "";

            // Valid parameters forms:
            // // old: {-,/,--}param{ ,=,:}((",')value(",'))
            // {-,/,--}param{ ,=}((",')value(",'))
            // Examples: 
            // -param1 value1 --param2 /param3:"Test-:-work" 
            //   /param4=happy -param5 '--=nice=--'
            foreach(string Txt in Args)
            {
                // Look for new parameters (-,/ or --) and a
                // possible enclosed value (=,:)
                Parts = Spliter.Split(Txt,3);

                // Needed when looking up added option:
                string key;
                int count = 0;
                
                switch(Parts.Length){
                // Found a value (for the last parameter 
                // found (space separator))
                case 1:
                    if(Parameter != null)
                    {
                        Parts[0] = Remover.Replace(Parts[0], "$1");
                        if (!Parameter.Contains (Parameter))
	                        Parameters.Add(Parameter, Parts[0]);
                        Parameters [Parameter] = Parts[0];
                        Parameter=null;
                    }
                    else
	                    lastArgs += " " + Parts [0];
                    break;

                // Found just a parameter
                case 2:
                    lastArgs = ""; // reset last parameters list
                    //
                    key = null;
                    count = 0;
                    foreach (ArrayList option in Options) {
                    	if ((string)option[0] == Parts [1] || (string)option[1] == Parts [1]) {
                    		key = (string)option [0];
                    		count = (int)option [2];
                    	}
                    }
                    if (key != null) {
	                    // The last parameter is still waiting. 
	                    // With no value, set it to true.
	                    if(Parameter!=null) {
	                        if(!Parameters.ContainsKey (Parameter)) 
	                            Parameters.Add (Parameter, "true");
	                        Parameters [key] = "";
	                    }
                    	if (!Parameters.ContainsKey (key))
                    		Parameters.Add (key, "true");
                    	Parameters [key] = "";
	                    if (count == 0) {
	                    	Parameter = null;
	                    } else {
	                    	Parameter = key;
	                    }
                    }
                    break;

                // Parameter with enclosed value
                case 3:
                    lastArgs = ""; // reset last parameters list
                    //
                    key = null;
                    count = 0;
                    foreach (ArrayList option in Options) {
                    	if ((string)option[0] == Parts [1] || (string)option[1] == Parts [1]) {
                    		key = (string)option [0];
                    		count = (int)option [2];
                    	}
                    }
                    if (key != null) {
	                    // The last parameter is still waiting. 
	                    // With no value, set it to true.
	                    if(Parameter != null)
	                    {
	                        if(!Parameters.ContainsKey(Parameter)) 
	                            Parameters.Add(Parameter, "true");
	                        Parameters[Parameter] = "";
	                    }
	
	                    Parameter = key;
	
	                    // Remove possible enclosing characters (",')
	                    if(!Parameters.ContainsKey(Parameter))
	                        Parameters.Add(Parameter, "true");

	                    Parts[2] = Remover.Replace(Parts[2], "$1");
	                    Parameters [Parameter] = Parts[2];
                    }
                    Parameter=null;
                    break;
                }
            }
            // In case a parameter is still waiting
            if(Parameter != null)
            {
                if(!Parameters.ContainsKey(Parameter)) 
                    Parameters.Add(Parameter, "true");
            }
            Parameters.Add ("-args", lastArgs.Trim());
        }
        
        public void addOption (string longName, string shortName, int args)
        {
        	ArrayList option = new ArrayList();
        	option.Add (longName);
        	option.Add (shortName);
        	option.Add (args);
        	Options.Add (option);
        }
        
        public void dump()
        {
        	foreach (string key in Parameters.Keys)
        		Console.WriteLine (key + " => " + Parameters [key]);
        }
    }
}
