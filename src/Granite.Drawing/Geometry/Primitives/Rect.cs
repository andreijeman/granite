namespace Granite.Drawing.Geometry.Primitives;

public class Rect
{
    public Point P1 { get; init; }
    public Point P2 { get; init; }

    public Rect() { }

    public Rect(Point p1, Point p2)
    {
        P1 = p1;
        P2 = p2;
    }
    
    public Rect(int  x, int y, int width, int height)
    {
        P1 = new Point(x, y);
        P2 = new Point(x + width, y + height);
    }
}