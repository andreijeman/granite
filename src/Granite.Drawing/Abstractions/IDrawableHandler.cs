using Granite.Drawing.Geometry.Primitives;

namespace Granite.Drawing.Abstractions;

public interface IDrawableHandler
{   
    void Draw(object sender, IDrawable drawable, Point origin);
    void Draw(object sender, IDrawable drawable, Point origin, Rect bounds);
}