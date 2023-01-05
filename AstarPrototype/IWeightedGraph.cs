using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarPrototype
{
    public interface IWeightedGraph<L>
    {
        double Cost(Location a, Location b);
        IEnumerable<Location> PassableNeighbors(Location id);
    }
}
