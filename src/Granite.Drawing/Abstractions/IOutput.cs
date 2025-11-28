using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Visual;
using Granite.Drawing.Visual.Primitives;

namespace Granite.Drawing.Abstractions;

public interface IOutput
{
    void Write(char character);
    void Write(string text);
    
    void SetCursorPosition(Point position);
    void SetForegroundColor(Color color);
    void SetBackgroundColor(Color color);
}