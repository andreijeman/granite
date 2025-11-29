using System.Text;
using Granite.Drawing.Abstractions;
using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Visual;
using Granite.Drawing.Visual.Primitives;

namespace Granite.Drawing.Outputs;

public class AnsiOutput : IOutput, IDrawableHandler
{
    private readonly object _locker = new();
    
    private readonly StringBuilder _buffer = new();
    private Point _origin = Point.One;
    
    public void Write(char character)
    {
        _buffer.Append(character);
    }

    public void Write(string text)
    {
        _buffer.Append(text);
    }

    public void SetCursorPosition(int x, int y)
    {
        _buffer.Append($"\x1b[{_origin.Y + y};{_origin.X + x}H");
    }

    public void SetForegroundColor(Color color)
    {
        _buffer.Append($"\x1b[38;2;{color.R};{color.G};{color.B}m");
    }

    public void SetBackgroundColor(Color color)
    {
        _buffer.Append($"\x1b[48;2;{color.R};{color.G};{color.B}m");
    }

    public void MoveOrigin(Point offset)
    {
        _origin += offset;
    }

    public void Show()
    {
        var s =_buffer.ToString();
        Console.Write(_buffer.ToString());
    }

    public void Reset()
    {
        _buffer.Clear();
        _origin = Point.One;
    }

    public void Draw(object sender, IDrawable drawable, Point origin)
    {
        _origin += origin;
        drawable.Draw(this);
        Reset();
    }

    public void Draw(object sender, IDrawable drawable, Point origin, Rect bounds)
    {
        _origin += origin;
        drawable.Draw(this, bounds);
        Reset();
    }
}

