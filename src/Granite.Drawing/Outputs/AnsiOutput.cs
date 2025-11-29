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
    private Point _origin;
    
    public void Write(char character)
    {
        _buffer.Append(character);
    }

    public void Write(string text)
    {
        _buffer.Append(text);
    }

    public void SetCursorPosition(Point position)
    {
        _buffer.Append($"\x1b[{_origin.Y + position.Y + 1};{_origin.X + position.X + 1}H");
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
        Console.Write(_buffer.ToString());
    }

    public void Reset()
    {
        _buffer.Clear();
        _origin = Point.Zero;
    }

    public void Draw(object sender, IDrawable drawable, Point origin)
    {
        lock (_locker)
        {
            _origin = origin;
            drawable.Draw(this);
            Reset();
        }
    }

    public void Draw(object sender, IDrawable drawable, Point origin, Rect bounds)
    {
        lock (_locker)
        {
            _origin = origin;
            drawable.Draw(this, bounds);
            Reset();
        }
    }
    
}

