using Granite.Drawing.Geometry.Primitives;

namespace Granite.Drawing.Abstractions;

public interface IDrawable
{
    Rect Bounds { get; }
 
    void Draw(IOutput output);
    void Draw(Rect section, IOutput output);
}