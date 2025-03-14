namespace OOP_LR1.BankSystem.Infrastructure.Logging
{
    public interface ILogger
    {
        void Log(string message, LogLevel level = LogLevel.Info);
        void CleanOldLogs(TimeSpan maxAge);

    }
}
