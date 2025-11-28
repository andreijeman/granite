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
        _buffer.Append($"\x1b[{position.Y + 1};{position.X + 1}H");
    }

    public void SetForegroundColor(Color color)
    {
        _buffer.Append($"\x1b[38;2;{color.R};{color.G};{color.B}m");
    }

    public void SetBackgroundColor(Color color)
    {
        _buffer.Append($"\x1b[48;2;{color.R};{color.G};{color.B}m");
    }

    public void Draw(IDrawable drawable)
    {
        lock (_locker)
        {
            drawable.Draw(this);
            Console.Write(_buffer.ToString());
            _buffer.Clear();
        }
    }
}

