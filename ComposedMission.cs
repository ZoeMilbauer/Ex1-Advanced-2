using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /// <summary>
    /// ComposedMission : contains missions
    /// </summary>
    public class ComposedMission : IMission
    {
        // An Event of when a mission is activated
        public event EventHandler<double> OnCalculate;
        // get the mission's name
        public String Name { get; }
        // get the mission's type
        public String Type { get; }
        private Functions functions; // the missions will save in this delegate

        /// <summary>
        /// ComposedMission : gets the composed mission name
        /// </summary>
        /// <param name="name"></param>
        public ComposedMission(string name)
        {
            Name = name;
            Type = "Composed"; // type is : composed mission
        }

        /// <summary>
        /// Add : gets a function, and add it to the delegate 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public ComposedMission Add(Functions func)
        {
            functions += func;
            return this;
        }

        /// <summary>
        /// Calculate : gets a value, and calls the methods
        /// using the delegate objects, one after one,
        /// and the event in the event handler
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Calculate(double value)
        {
            var val = value;
            // call all methods in delegate, and calcualte the value
            for (int i = 0; i < functions.GetInvocationList().Length; i++)
            {
                var outputMsg = functions.GetInvocationList()[i];
                val = (double)outputMsg.DynamicInvoke(val);
            }
            // if there is event saved in the event handler, call it 
            OnCalculate?.Invoke(this, val);
            return val;

        }
    }
}
