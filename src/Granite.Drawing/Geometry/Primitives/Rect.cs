namespace Granite.Drawing.Geometry.Primitives;

public struct Rect
{
    public Point P1 { get; }
    public Point P2 { get; }
    
    public Rect(Point p1, Point p2)
    {
        P1 = p1;
        P2 = p2;
    }
    
    public Rect(int  x1, int y1, int x2, int y2)
    {
        P1 = new Point(x1, y1);
        P2 = new Point(x2, y2);
    }
}