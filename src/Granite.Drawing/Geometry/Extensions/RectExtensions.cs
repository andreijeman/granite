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

    public static IEnumerable<Rect> ExcludePart(this Rect rect, Rect part)
    {
        // Top part
        if (rect.P1.Y < part.P1.Y)
            yield return new Rect(rect.P1, new Point(rect.P2.X, part.P1.Y - 1));

        // Bottom part
        if (rect.P2.Y > part.P2.Y)
            yield return new Rect(new Point(rect.P1.X, part.P2.Y + 1), rect.P2);

        // Left part
        if (rect.P1.X < part.P1.X)
            yield return new Rect(new Point(rect.P1.X, part.P1.Y), new Point(part.P1.X - 1, part.P2.Y));

        // Right part
        if (rect.P2.X > part.P2.X)
            yield return new Rect(new Point(part.P2.X + 1, part.P1.Y), new Point(rect.P2.X, part.P2.Y));
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