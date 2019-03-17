using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Excercise_1
{
    /// <summary>
    /// SingleMission : contains one mission
    /// </summary>
    public class SingleMission : IMission
    {
        // An Event of when a mission is activated
        public event EventHandler<double> OnCalculate;
        // get the mission's name
        public String Name { get; }
        // get the mission's type
        public String Type { get; }
        private Functions function; // the mission will save in this delegate
        /// <summary>
        /// SingleMission : gets a function, and a name of the mission, 
        /// and sets them
        /// </summary>
        /// <param name="func"></param> function
        /// <param name="name"></param> name of mission
        public SingleMission(Functions func, string name)
        {
            Name = name;
            Type = "Single"; // type is : single mission
            function = func;
        }
        /// <summary>
        /// Calculate : gets a value, and calls the method
        /// using the delegate objects, and the event in the event handler
        /// </summary>
        /// <param name="value"></param> 
        /// <returns></returns>
        public double Calculate(double value)
        {
            double result = function(value); // calls the method
            // if there is event saved in the event handler, call it
            OnCalculate?.Invoke(this, result);
            return result;       
        }
    }
}
