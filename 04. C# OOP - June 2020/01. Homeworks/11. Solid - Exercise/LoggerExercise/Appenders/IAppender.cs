namespace LoggerExercise.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        int MessagesCount { get; }
        void Append(string date, ReportLevel level, string message);
    }
}
