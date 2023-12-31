using System.Collections.Generic;

namespace AI.GOAP
{
    public interface IPlanner
    {
        bool MakePlan(IFactState worldState, IFactState goal, out List<IActor> plan);
    }
}