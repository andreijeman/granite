using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Outputs;
using Granite.Drawing.Visual.Elements;
using Granite.Drawing.Visual.Primitives;

var box = new ColorBox
(
    color: new Color("242344"),
    bounds: new Rect(8, 8, 8, 8)
);

var output = new AnsiOutput();

output.Draw(box);