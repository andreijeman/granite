using Granite.Drawing.Abstractions;
using Granite.Drawing.Containers;
using Granite.Drawing.Geometry.Primitives;
using Granite.Drawing.Outputs;
using Granite.Drawing.Visual.Elements;
using Granite.Drawing.Visual.Primitives;

var pos = new Point(2, 2);

var box = new ColorBox
(
    color: new Color(215, 66, 245),
    bounds: new Rect(pos, pos + new Point(3, 1))
);

var box2 = new ColorBox
(
    color: new Color(66, 236, 245),
    bounds: new Rect(2, 1, 5, 2)
);

var box3= new ColorBox
(
    color: new Color(66, 33, 245),
    bounds: new Rect(0, 0, 3, 1)
);

var output = new AnsiOutput();

var bounds = new Rect(0, 0, 22, 10);
var container = new ImmutableContainer(output, [box3, box, box2], bounds);

Console.Clear();
container.Draw(output);

await Task.Delay(-1);