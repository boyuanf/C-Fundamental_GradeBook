using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public delegate void NameChangedDelegate(string oldValue, string newValue);
    public delegate void NameChangedEvent(
        object sender, NameChangedEventArgs args);


}
