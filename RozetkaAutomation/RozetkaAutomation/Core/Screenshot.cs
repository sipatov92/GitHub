using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RozetkaAutomation.Core
{
    public static class ScreenShot
    {
       
        private static ThreadLocal<Bitmap> bitmapHolder = new ThreadLocal<Bitmap>();
        private static String name = "";
        private static Boolean finalized = false;

        static ScreenShot()
        {
        }

        public static void DoScreenShotBeforeAction(string folderName)
        {
            finalized = false;
            name = folderName;
            DoScreenShot(false, name);
        }

        public static string DoScreenShotAfterAction()
        {
            string path = null;
            if (name != String.Empty && !finalized)
            {
                path = DoScreenShot(true, name);
                finalized = true;
            }
            return path;
        }

        /// <summary>
        /// Cleans work of doing screanshot.
        /// </summary>
        public static void ScreenShotFinalize()
        {
            if (bitmapHolder.IsValueCreated)
            {
                bitmapHolder.Value = null;
            }
        }

        private static string DoScreenShot(bool isWrite, String folderName)
        {
            string pathToHtmlPage = null;

            Rectangle bounds = Screen.GetBounds(Point.Empty);

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                if (isWrite)
                {
                    if (bitmapHolder.IsValueCreated)
                    {
                        string path = GetPathToFolder(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + folderName.Substring(0,15));
                        System.Console.WriteLine("Screenshots: " + path);

                        bitmapHolder.Value.Save(path + "\\" + "BeforeAction" + ".jpg", ImageFormat.Jpeg);
                        bitmapHolder.Value = null;

                        bitmap.Save(path + "\\" + "AfterAction" + ".jpg", ImageFormat.Jpeg);
                        bitmap.Dispose();
                        pathToHtmlPage = CreateHtmlPageForScreenshots(path);
                    }
                    else
                    {
                        throw new Exception(string.Format("{0} Before screenshot is expected to be in {1} folder.", "ThereAreNoScreenshotBeforeAction", folderName)); //TODO correct folderName
                    }
                }
                else
                {
                    bitmapHolder.Value = new Bitmap(bitmap);
                }
            }

            return pathToHtmlPage;
        }

    
        private static string GetPathToFolder(string folderName)
        {
            string activeDir = Path.Combine(Common.GetWorkingDirectory(), "Output");
            string newPath = Path.Combine(activeDir, "ScreenShots");

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            foreach (char c in invalid)
            {
                folderName.Replace(c.ToString(), "");
            }
            newPath = Path.Combine(newPath, folderName);
            Directory.CreateDirectory(newPath);

            return newPath;
        }

        private static string CreateHtmlPageForScreenshots(string folderName)
        {
            string pathToHtmlPage = folderName + "\\HtmlPageWithScreenShots.html";

            StreamWriter writter = new StreamWriter(folderName + "\\HtmlPageWithScreenShots.html");
            writter.Write("<html><head><title>" + folderName + "</title></head><body><p>Before action</p><img src='BeforeAction.jpg'><p>After action</p><img src='AfterAction.jpg'></body></html>");
            writter.Close();

            return pathToHtmlPage;
        }
    }
}
