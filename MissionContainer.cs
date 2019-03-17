using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    // a delegate that will save the functions
    public delegate double Functions(double value);

    /// <summary>
    /// FunctionsContainer class: will contain functions, 
    /// given by the user, in a dictionary 
    /// </summary>
    public class FunctionsContainer
    {
        // dictionary for the functions, the key is the name of function 
        Dictionary<string, Functions> functionsList = 
            new Dictionary<string, Functions>();
  
        /// <summary>
        /// Indexer for the functions.
        /// </summary>
        /// <param name="funcName"></param>
        /// <returns></returns>
        public Functions this[string funcName]
        {
            // returns function by name
            get
            {
                // if there is no function with this name, 
                // create a new delegate that does not change the given value
                if (!functionsList.ContainsKey(funcName))
                {
                    functionsList.Add(funcName, val => val);
                }
                return functionsList[funcName]; 
            }
            // sets a new delegate
            set
            {
                // if there is a function with this name, change it
                if (functionsList.ContainsKey(funcName))
                {
                    functionsList[funcName] = value;
                }
                // else, crate a new 
                else
                {
                    functionsList.Add(funcName, value);
                }
            }
        }

        /// <summary>
        /// returns list of the functions's name
        /// </summary>
        /// <returns></returns>
        public List<string> getAllMissions()
        {
            return new List<string>(this.functionsList.Keys);
        }
    }
}
