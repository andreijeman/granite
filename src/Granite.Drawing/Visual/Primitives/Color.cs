namespace Granite.Drawing.Visual.Primitives;

public struct Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    
    public Color(byte  r, byte g, byte b)
    {
        R  = r;
        G = g;
        B = b;
    }
    
    public Color(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentException("Hex color cannot be null or empty.", nameof(hex));

        if (hex.StartsWith("#"))
            hex = hex[1..];

        if (hex.Length != 6)
            throw new ArgumentException("Hex color must be 6 characters.", nameof(hex));

        R = Convert.ToByte(hex.Substring(0, 2), 16);
        G = Convert.ToByte(hex.Substring(2, 2), 16);
        B = Convert.ToByte(hex.Substring(4, 2), 16);
    }
}