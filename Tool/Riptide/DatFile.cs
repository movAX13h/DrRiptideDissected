using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace riptide.Riptide
{
    public class DatFile
    {
        public string Error { get; private set; } = "";
        public string Log { get; private set; } = "";
        public List<DatFileEntry> Files { get; private set; }

        private string path;

        public DatFile(string path)
        {
            this.path = path;
        }

        public DatFileEntry GetByName(string name)
        {
            foreach(DatFileEntry file in Files)
            {
                if (file.Filename == name) return file;
            }

            return null;
        }

        public bool Unpack()
        {
            if (!File.Exists(path))
            {
                Error = "File not found!";
                return false;
            }            

            Files = new List<DatFileEntry>();

            byte[] data = File.ReadAllBytes(path);

            int numEntries = BitConverter.ToUInt16(data, 0);
            int offset = 2;
            
            Log = "Num entries: " + numEntries.ToString() + Environment.NewLine;

            for (int i = 0; i < numEntries; i++)
            {
                DatFileEntry entry = new DatFileEntry();

                entry.ID = i;

                entry.Size = BitConverter.ToInt32(data, offset);
                offset += 4;

                entry.Modified = BitConverter.ToInt32(data, offset);
                offset += 4;

                entry.Offset = BitConverter.ToInt32(data, offset);
                offset += 4;

                entry.Filename = ""; // 13 chars, null-terminated

                for (int j = 0; j < 13; j++)
                {
                    if (data[offset + j] == 0)
                    {
                        entry.Filename = Encoding.UTF8.GetString(data, offset, j);
                        break;
                    }
                }
                offset += 13;

                entry.Data = data.SubArray(entry.Offset, entry.Size);

                Files.Add(entry);
                Log += entry.ToString() + Environment.NewLine;
            }

            return true;
        }

        // not used (trying to do everything in memory)
        public bool WriteUnpackedFiles(string targetDir)
        {
            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            for (int i = 0; i < Files.Count; i++)
            {
                DatFileEntry file = Files[i];
                if (!file.Write(targetDir))
                {
                    Error = $"Failed to write file '{file.Filename}' to '{targetDir}'";
                    return false;
                }
            }
            return true;
        }
    }
}
