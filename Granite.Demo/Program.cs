using Granite.Drawing.Abstractions;
using Granite.Drawing.Containers;
using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Outputs;
using Granite.Drawing.Visual.Elements;
using Granite.Drawing.Visual.Primitives;

var box = new ColorBox
(
    color: new Color("#f542ef"),
    bounds: new Rect(-3, 0, 4, 2)
);

var output = new AnsiOutput();

var bounds = new Rect(22, 3, 8, 8);
var container = new ImmutableContainer(output, [box], bounds);

container.Draw(output);