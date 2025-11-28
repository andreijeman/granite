using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Outputs;
using Granite.Drawing.Visual.Elements;
using Granite.Drawing.Visual.Primitives;

var box = new ColorBox
{
    Color = new Color("FF00FF"),
    Bounds = new Rect(0, 0, 8, 8)
};

var output = new AnsiOutput();

output.Draw(box);