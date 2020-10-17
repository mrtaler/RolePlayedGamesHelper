using System;
using System.IO;

namespace RolePlayedGamesHelper.Repository.UnitTests.TestObjects.Assert
{
    //TODO: BG - This guts of the following code was found online. Find the source and reference.
    public class RelativeDirectory
    {
        private DirectoryInfo dirInfo;

        public RelativeDirectory()
        {
            dirInfo = new DirectoryInfo(AppContext.BaseDirectory);
        }

        public RelativeDirectory(string absoluteDir)
        {
            dirInfo = new DirectoryInfo(absoluteDir);
        }

        public string Dir
        {
            get { return dirInfo.Name; }
        }

        public string Path
        {
            get { return dirInfo.FullName; }
            set
            {
                try
                {
                    var newDir = new DirectoryInfo(value);
                    dirInfo = newDir;
                }
                catch
                {
                    // silent
                }
            }
        }

        public Boolean UpTo(string folderName)
        {
            do
            {
                if (dirInfo.Name.Equals(folderName)) return true;
            } while (Up());

            return false;
        }

        public Boolean Up(int numLevels)
        {
            for (int i = 0; i < numLevels; i++)
            {
                DirectoryInfo tempDir = dirInfo.Parent;
                if (tempDir != null)
                    dirInfo = tempDir;
                else
                    return false;
            }
            return true;
        }

        public Boolean Up()
        {
            return Up(1);
        }
        public Boolean Down(string match)
        {
            DirectoryInfo[] dirs = dirInfo.GetDirectories(match + '*');

            if (dirs.Length == 0) return false;

            dirInfo = dirs[0];
            return true;
        }
    }
}
