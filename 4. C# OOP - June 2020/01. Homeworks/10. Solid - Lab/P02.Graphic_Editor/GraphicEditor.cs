using System;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(Shape shape)
        {
            Console.WriteLine(shape.GetShape());
        }
    }
}
