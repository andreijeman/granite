using Granite.Drawing.Abstractions;
using Granite.Drawing.Geometry.Extensions;
using Granite.Drawing.Geometry.Primitives;

namespace Granite.Drawing.Containers;

public static class ChildrenExtensions
{
    public static Dictionary<object, List<Rect>> ComputeBounds(this List<IDrawable> drawables, Rect bounds)
    {
        var dict = new Dictionary<object, List<Rect>>();
        
        for (int i = drawables.Count - 1; i > -1; i--)
        {
            var boundsList = new List<Rect> { drawables[i].Bounds.GetIntersection(bounds) };

            for (int j = i - 1; j > -1; j--)
            {
                var tempList = new List<Rect>();
                
                foreach (var childBounds in boundsList)
                {
                    tempList.AddRange(childBounds.GetDifference(drawables[j].Bounds));
                }
                
                boundsList = tempList;
            }
            
            dict.Add(drawables[i], boundsList);
        }
        
        return dict;
    }
}