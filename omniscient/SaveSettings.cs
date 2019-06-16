using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace omniscient
{
    class SaveSettings
    {
        public static string LoadedList;

        public static void FileSaver()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Omniscient"); //Omniscient Data Folder path (documents/omniscient)
            string blpath = Path.Combine(path, "blocked_words.txt"); //Blocked Words list path.

           //Check if directory doesnt exist.
            if (!Directory.Exists(path)) {
                // Create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                MessageBox.Show("Folder Created. (Documents/Omniscient)", "Omniscient Save System: Version 1.4");
                //Create the block list file.
                File.WriteAllText(blpath, MainWindow.BlockList);
                MessageBox.Show("Blocked Words list succesfully saved.", "Omniscient Save System: Version 1.4");
            }
            else {
                //If directory exists just create file.
                File.WriteAllText(blpath, MainWindow.BlockList);
                MessageBox.Show("Blocked Words list succesfully saved.", "Omniscient Save System: Version 1.4");
            }
        }

        public static void FileLoader()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Omniscient"); //Omniscient Data Folder path (documents/omniscient)
            string blpath = Path.Combine(path, "blocked_words.txt"); //Blocked Words list path.

            if (File.Exists(blpath))
            {
                LoadedList = File.ReadAllText(blpath);
            }

        }
    }
}
