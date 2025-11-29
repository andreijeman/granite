using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Visual.Primitives;

namespace Granite.Drawing.Abstractions;

public interface IOutput
{
    void Write(char character);
    
    void SetCursorPosition(int x, int y);
    void SetForegroundColor(Color color);
    void SetBackgroundColor(Color color);
    
    void MoveOrigin(Point offset);
    
    void Show();
}
