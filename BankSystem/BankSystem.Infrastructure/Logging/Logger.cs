using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR1.BankSystem.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        private readonly string _logFilePath;
        private readonly bool _encryptLogs;
        private readonly bool _logToConsole;

        public Logger(string logFilePath, bool encryptLogs = false, bool logToConsole = false)
        {
            _logFilePath = logFilePath;
            _encryptLogs = encryptLogs;
            _logToConsole = logToConsole;

            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Close();
            }
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            string logMessage = $"{DateTime.UtcNow} [{level}]: {message}";

            if (_logToConsole)
            {
                Console.WriteLine(logMessage);
            }

            if (_encryptLogs)
            {
                logMessage = Encrypt(logMessage); 
            }

            WriteToFileAsync(logMessage).Wait(); 
        }

        private async Task WriteToFileAsync(string message)
        {
            try
            {
                await using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    await writer.WriteLineAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи лога: {ex.Message}");
            }
        }

        private string Encrypt(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public void CleanOldLogs(TimeSpan maxAge)
        {
            try
            {
                var logLines = File.ReadAllLines(_logFilePath).ToList();
                var currentTime = DateTime.UtcNow;

                logLines.RemoveAll(line =>
                {
                    if (DateTime.TryParse(line.Split(' ')[0], out var logTime))
                    {
                        return (currentTime - logTime) > maxAge;
                    }
                    return false;
                });

                File.WriteAllLines(_logFilePath, logLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при очистке логов: {ex.Message}");
            }
        }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}