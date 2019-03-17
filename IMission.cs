using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public interface IMission
    {
        event EventHandler<double> OnCalculate;  // An Event of when a mission is activated
        // get the mission's name
        String Name { get; }
        // get the mission's type
        String Type { get; }
        /// <summary>
        /// Calculate :gets a value and calculate a value 
        /// using the methods that are saved in delegate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double Calculate(double value);
    }
}
