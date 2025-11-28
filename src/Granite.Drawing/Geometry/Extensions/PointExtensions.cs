using Granite.Drawing.Geometry.Primitives;

namespace Granite.Drawing.Geometry.Extensions;

public static class PointExtensions
{
    public static Rect ToRect(this Point position, Point size)
    {
        return new Rect(position, position + size - Point.One);
    }

    public static Point Rebase(this Point point, Point fromOrigin, Point toOrigin)
    {
        return point + toOrigin - fromOrigin;
    }
}