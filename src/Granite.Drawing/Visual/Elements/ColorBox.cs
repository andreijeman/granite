using Granite.Drawing.Abstractions;
using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Visual.Primitives;

namespace Granite.Drawing.Visual.Elements;

public class ColorBox : IDrawable
{
    public Color Color { get; }
    public Rect Bounds { get; }

    public ColorBox(Color color, Rect bounds)
    {
        Color = color;
        Bounds = bounds;
    }
    
    public void Draw(IOutput output)
    {
        for (int y = Bounds.P1.Y; y < Bounds.P2.Y; y++)
        {
            output.SetCursorPosition(new Point(Bounds.P1.X, y));
            output.SetForegroundColor(Color);
            output.SetBackgroundColor(Color);

            for (int x = Bounds.P1.X; x < Bounds.P2.X; x++)
            {
                output.Write(' ');
            }
        }
    }

    public void Draw(Rect section, IOutput output)
    {
        for (int y = section.P1.Y; y < section.P2.Y; y++)
        {
            output.SetCursorPosition(new Point(section.P1.X, y));
            output.SetForegroundColor(Color);
            output.SetBackgroundColor(Color);

            for (int x = section.P1.X; x < section.P2.X; x++)
            {
                output.Write(' ');
            }
        }
    }
}