namespace EZLog
{
    /// <summary>
    /// EZ logger
    /// </summary>
    public class EZ
    {
        /// <summary>
        /// a string representing a path to a specific sub-folder/sub-directory 
        /// </summary>
        public static string LogDirPath = ".\\EZLOG";

        /// <summary>
        /// to write messages/informations to a daily log file in a specific sub-folder/sub-directory 
        /// </summary>
        /// <param name="detailedMsg">a message/information which is going to be logged</param>
        /// <param name="selfDefinedCode">a self-defined integer for self-defined meaning</param>
        /// <param name="selfDefinedTag">a self-defined tag for self-defined meaning</param>
        /// <returns>(completed, info._to_the_sub-folder)</returns>
        public static (bool, DirectoryInfo) Log(string detailedMsg, int selfDefinedCode = 0, string selfDefinedTag = "INFO")
        {
            DateTime now = DateTime.Now;
            DirectoryInfo directoryInfo = new DirectoryInfo(LogDirPath);
            try
            {
                if (!Directory.Exists(LogDirPath))
                {
                    directoryInfo = Directory.CreateDirectory(LogDirPath);
                }
                string filePath = Path.Join(LogDirPath, $"{now.ToString("yyyyMMdd")}_log.txt");
                File.AppendAllText(filePath, $"[{selfDefinedCode}：{selfDefinedTag}]\n{detailedMsg}\n== {now.ToString("yyyy/MM/ddTHH:mm:ss.ffffff")} (UTC：{now.ToUniversalTime().ToString("yyyy/MM/ddTHH:mm:ss.ffffff")}) ==\n");
                return (true, directoryInfo);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.ToString());
#endif
                Console.WriteLine("[EZLog] log failed.");
                return (false, directoryInfo);
            }
        }

    }
}
