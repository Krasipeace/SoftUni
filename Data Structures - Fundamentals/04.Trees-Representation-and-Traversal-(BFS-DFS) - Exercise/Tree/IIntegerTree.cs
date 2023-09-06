using System;
using System.Collections.Generic;

namespace Tree
{
    public interface IIntegerTree: IAbstractTree<int>
    {
        IEnumerable<IEnumerable<int>> PathsWithGivenSum(int sum);

        IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum);
    }
}
