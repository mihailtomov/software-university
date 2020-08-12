namespace LoggerExercise.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Template => @"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";
    }
}
