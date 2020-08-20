using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Keysight.Cable.Project.Other
{
    using OpenTap.Keysight.Cable.Project.EnumClass;
    public static class StaticClass
    {
        public static string ProjectName;
        public static string DutId;
        public static EDutType DutType;
        public static string DirPath;
        public static string MarkerFileName;
        public static string SnpFileName;
        public static string ScreenshotFileName;
        public static string TimeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

        public static double Time;

        public static string FullSnpFilePath;
        public static string FullScreenFilePath;

        public static string ListOfPort;

    }
}
