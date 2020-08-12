namespace P02.Graphic_Editor
{
    public abstract class Shape
    {
        public virtual string GetShape() 
        {
            return $"I'm {this.GetType().Name}";
        }
    }
}
