using Granite.Drawing.Geometry.Primitives;

namespace Granite.Drawing.Geometry.Extensions;

public static class RectExtensions
{
    public static bool Intersects(this Rect rect, Rect rect2)
    {
        return rect.P1.X <= rect2.P2.X &&
               rect.P2.X >= rect2.P1.X &&
               rect.P1.Y <= rect2.P2.Y &&
               rect.P2.Y >= rect2.P1.Y;
    }

    public static Rect GetIntersection(this Rect rect, Rect rect2)
    {
        var p1 = new Point(Math.Max(rect.P1.X, rect2.P1.X), Math.Max(rect.P1.Y, rect2.P1.Y));
        var p2 = new Point(Math.Min(rect.P2.X, rect2.P2.X), Math.Min(rect.P2.Y, rect2.P2.Y));

        return new Rect(p1, p2);
    }

    public static List<Rect> GetDifference(this Rect rect, Rect rect2)
    {
        if (!rect.Intersects(rect2))
        {
            return new List<Rect> { rect };
        }
        
        var result = new List<Rect>();
        
        // Top part
        if (rect.P1.Y < rect2.P1.Y)
        {
            result.Add(new Rect(
                p1: rect.P1,
                p2: new Point(rect.P2.X, rect2.P1.Y - 1)
            ));
        }

        // Bottom part
        if (rect.P2.Y > rect2.P2.Y)
        {
            result.Add(new Rect(
                p1: new Point(rect.P1.X, rect2.P2.Y + 1),
                p2: rect.P2
            ));
        }

        // Left part (within vertical overlap)
        int top = Math.Max(rect.P1.Y, rect2.P1.Y);
        int bottom = Math.Min(rect.P2.Y, rect2.P2.Y);
        
        if (rect.P1.X < rect2.P1.X)
        {
            result.Add(new Rect(
                p1: new Point(rect.P1.X, top),
                p2: new Point(rect2.P1.X - 1, bottom)
            ));
        }

        // Right part (within vertical overlap)
        if (rect.P2.X > rect2.P2.X)
        {
            result.Add(new Rect(
                p1: new Point(rect2.P2.X + 1, top),
                p2: new Point(rect.P2.X, bottom)
            ));
        }
        
        return result;
    }

    public static Point GetSize(this Rect rect)
    {
        return rect.P2 - rect.P1 + Point.One;
    }

    public static Rect Translate(this Rect rect, Point offset)
    {
        return new Rect(rect.P1 + offset, rect.P2 + offset);
    }

    public static Rect Rebase(this Rect rect, Point fromOrigin, Point toOrigin)
    {
        var offset = toOrigin - fromOrigin;
        return rect.Translate(offset);
    }
}