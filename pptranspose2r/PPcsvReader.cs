using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pptranspose2r
{

    /// <summary>
    /// Reads the PP generated csv-file into the internal data strucutres. (List of data and the summary record.)
    /// </summary>
    public class PPcsvReader
    {
        public readonly List<DataRecord> Records;
        public readonly DataAverageRecord AverageRecord;
        public readonly string ParticipantID;
        public readonly int NumRecords;
        public readonly string FirstDate;
        public readonly string LastDate;

        /// <summary>
        /// Constructs the reader by reading all data into memory.
        /// </summary>
        /// <param name="inputFile">The input file to read the data from.</param>
        public PPcsvReader(string inputFile)
        {
            (ParticipantID, List<HeaderData> hd) = ReadFile(inputFile);
            NumRecords = (hd.Count - 1 - 15) / 15; // -1 ParticipantID and -15 AverageRecord and /15 per DataRecord

            Records = new List<DataRecord>();
            for (int i = 1; i < NumRecords * 15 + 1; i += 15)
                Records.Add(new(hd.Skip(i)));

            Records.Sort();
            FirstDate = Records[0].Date;
            LastDate = Records[Records.Count - 1].Date;
            AverageRecord = new(hd.Skip(NumRecords * 15 + 1));
        }

        /// <summary>
        /// Actually opens and reads the data in Header-Data-cell combinations.
        /// </summary>
        /// <param name="inputFile">The file to open and read the data from.</param>
        /// <returns>Tupel containing the participantID and the list of HeaderData-combinations.</returns>
        /// <exception cref="IOException">When there are none or more than 1 perticipant in the file.</exception>
        private (string, List<HeaderData>) ReadFile(string inputFile)
        {
            List<HeaderData> hd = new();

            List<string> lines = File.ReadLines(inputFile).ToList();
            if (lines.Count != 2)
                throw new IOException("Too many lines found in the input file?");

            string[] header = lines[0].Split(',');
            string[] data = lines[1].Split(',');

            for (int i = 0; i < header.Length; i++)
                hd.Add(new(header[i].Replace("\"", ""), data[i].Replace("\"", "")));

            return (data[0].Replace("\"", ""), hd);
        }

        /// <summary>
        /// Saves the records to a file R can more easely read.
        /// </summary>
        /// <param name="file">File name to save to.</param>
        public void SaveRecordsTo(string file)
        {
            List<String> lines = new();
            string header = "ParticipantID, " + String.Join(", ", DataRecord.DataHeaders);
            lines.Add(header);

            foreach (DataRecord dr in Records)
                lines.Add(dr.GetRLine(ParticipantID));

            File.WriteAllLines(file, lines);
        }

        /// <summary>
        /// Saves the tail average record to a file.
        /// </summary>
        /// <param name="file">File name to save to.</param>
        public void SaveAverageRecordTo(string file)
        {
            List<String> lines = new();
            string header = "ParticipantID, " + String.Join(", ", DataAverageRecord.DataAverageHeaders);
            lines.Add(header);

            lines.Add(AverageRecord.GetRLine(ParticipantID));

            File.WriteAllLines(file, lines);
        }

    }

}
