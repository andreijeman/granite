using Granite.Drawing.Abstractions;
using Granite.Drawing.Geometry.Extensions;
using Granite.Drawing.Geometry.Primitives;

namespace Granite.Drawing.Containers;

public class ImmutableContainer : IContainer
{
    private readonly IDrawableHandler _parent;
    private readonly List<IDrawable> _children;
    
    private readonly Dictionary<object, List<Rect>> _childrenBounds;
    
    private readonly Rect _innerBounds;
    public Rect Bounds { get; }
    
    public ImmutableContainer(IDrawableHandler parent, List<IDrawable> children, Rect bounds)
    {
        _parent = parent;   
        _children = children;
        Bounds = bounds;
        _innerBounds = bounds.Rebase(bounds.P1, Point.Zero);
        _childrenBounds = _children.ComputeBounds(bounds);
    }
    
    public void Draw(object sender, IDrawable drawable, Point origin)
    {
        foreach (var bound2 in _childrenBounds[sender])
        {
            _parent.Draw(this, drawable, Bounds.P1 + origin);
        }
    }

    public void Draw(object sender, IDrawable drawable, Point origin, Rect bounds)
    {
        foreach (var bound2 in _childrenBounds[sender])
        {
            if (bounds.Intersects(bound2))
            {
                _parent.Draw(this, drawable, Bounds.P1 + origin, bounds.GetIntersection(bound2));
            }
        }
    }
    
    public void Draw(IOutput output)
    {
        output.MoveOrigin(Bounds.P1);
        
        foreach (var drawable in _children)
        {
            drawable.Draw(output, drawable.Bounds.GetIntersection(_innerBounds));
        }
    }

    public void Draw(IOutput output, Rect bounds)
    {
        foreach (var drawable in _children)
        {
            drawable.Draw(output, drawable.Bounds.GetIntersection(bounds));
        }
    }
    
}