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
        output.SetForegroundColor(Color);
        output.SetBackgroundColor(Color);
        
        for (int y = Bounds.P1.Y; y <= Bounds.P2.Y; y++)
        {
            output.SetCursorPosition(Bounds.P1.X, y);

            for (int x = Bounds.P1.X; x <= Bounds.P2.X; x++)
            {
                output.Write(' ');
            }
        }
        
        output.Show();
    }

    public void Draw(IOutput output, Rect bounds)
    {
        output.SetForegroundColor(Color);
        output.SetBackgroundColor(Color);
        
        for (int y = bounds.P1.Y; y <= bounds.P2.Y; y++)
        {
            output.SetCursorPosition(bounds.P1.X, y);

            for (int x = bounds.P1.X; x <= bounds.P2.X; x++)
            {
                output.Write(' ');
            }
        }

        output.Show();
    }
}