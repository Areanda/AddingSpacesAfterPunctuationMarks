/* 
 * This application fixes sentences that have punctuation marks and an unusual number of spaces between the punctuation mark and the next character; the unusual number can vary and starts from 0 spaces
 * Example: The brown fox jumps over the lazy dog.The brown fox jumps over the lazy dog.   The brown fox jumps over the lazy dog...The brown fox jumps over the lazy dog.
 * Result: The brown fox jumps over the lazy dog. The brown fox jumps over the lazy dog. The brown fox jumps over the lazy dog. The brown fox jumps over the lazy dog.
 * 
 * The program reads the 'quests.sql' from the executable's folder file which contains only insert statements and the problems with the punctuation marks explained above. 
 * It then creates the file 'modifiedQuestDescriptions.sql' that has the fixed insert statements.
 */

#region Libraries
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace Adding_Spaces_After_Punctuation_Marks
{
    class Program
    {
        static void Main(string[] args)
        {


            string sqlInsert = String.Empty;
            Queue<string> queueSql = new Queue<string>();

            #region Checking if the file exists, if so, delete the file, otherwise create it
            if (File.Exists("modifiedQuestDescriptions.sql"))
            {
                File.Delete("modifiedQuestDescriptions.sql");
                File.Create("modifiedQuestDescriptions.sql").Close();
            }
            #endregion
            
            using (StreamReader sr = File.OpenText(@"quests.sql"))
            {
                string s = String.Empty;

                // Reading each line from the file
                while ((s = sr.ReadLine()) != null)
                {

                    // Splitting after ', which is considered here the delimitator between SQL columns
                    string[] DBColumnElement = s.Split(new string[] { "\'," }, StringSplitOptions.None);

                    // Going from 4 to 5 because the only problems that were found were in the quest description (insert statement splitted = item 4) and quest objectives(insert statement splitted = item 5) 
                    for (byte k = 4; k <= 5; k++) 
                    {
                        #region Fixing the . character
                        // Making sure the index exists and is not the last character; this situation needs to be ignored
                        if ((DBColumnElement[k].IndexOf('.') > 0) && (DBColumnElement[k].IndexOf('.') < DBColumnElement[k].Length - 1))
                        {
                            string[] splitAfterDot = DBColumnElement[k].Split('.');
                            int splitCount = 0; // counter
                            int splitTempCount = 0; // counter
                            DBColumnElement[k] = String.Empty;

                            #region Finding the max number of splitted strings
                            foreach (string split in splitAfterDot)
                            {
                                splitCount++;
                            }
                            #endregion

                            for (int i = 0; i < splitCount; i++)
                            {
                                splitTempCount++;
                                splitAfterDot[i].Trim();
                                if (splitTempCount == splitCount) // if we reached the last split element where we don't need to add the last .
                                {
                                    DBColumnElement[k] += splitAfterDot[i];
                                }
                                else
                                {
                                    // Checking if there's a situation like this: ...
                                    if (splitAfterDot[i].Length > 1 && splitAfterDot[i + 1].Length > 1)
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + ". ";
                                    }
                                    else
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + ".";
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Fixing the , character
                        if ((DBColumnElement[k].IndexOf(',') > 0) && (DBColumnElement[k].IndexOf(',') < DBColumnElement[k].Length - 1))
                        {
                            string[] splitAfterDot = DBColumnElement[k].Split(',');
                            int splitCount = 0;
                            int splitTempCount = 0;
                            DBColumnElement[k] = String.Empty;

                            #region Finding the max number of splitted strings
                            foreach (string split in splitAfterDot)
                            {
                                splitCount++;
                            }
                            #endregion

                            for (int i = 0; i < splitCount; i++)
                            {
                                splitTempCount++;
                                splitAfterDot[i].Trim();
                                if (splitTempCount == splitCount) // if we reached the last split element where we don't need to add the last .
                                {
                                    DBColumnElement[k] += splitAfterDot[i];
                                }
                                else
                                {
                                    // Checking if there's a situation like this: ...
                                    if (splitAfterDot[i].Length > 1 && splitAfterDot[i + 1].Length > 1)
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + ", ";
                                    }
                                    else
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + ",";
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Fixing the ; character
                        if ((DBColumnElement[k].IndexOf(';') > 0) && (DBColumnElement[k].IndexOf(';') < DBColumnElement[k].Length - 1))
                        {
                            string[] splitAfterDot = DBColumnElement[k].Split(';');
                            int splitCount = 0;
                            int splitTempCount = 0;
                            DBColumnElement[k] = String.Empty;

                            #region Finding the max number of splitted strings
                            foreach (string split in splitAfterDot)
                            {
                                splitCount++;
                            }
                            #endregion

                            for (int i = 0; i < splitCount; i++)
                            {
                                splitTempCount++;
                                splitAfterDot[i].Trim();
                                if (splitTempCount == splitCount) // if we reached the last split element where we don't need to add the last .
                                {
                                    DBColumnElement[k] += splitAfterDot[i];
                                }
                                else
                                {
                                    // Checking if there's a situation like this: ...
                                    if (splitAfterDot[i].Length > 1 && splitAfterDot[i + 1].Length > 1)
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + "; ";
                                    }
                                    else
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + ";";
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Fixing the : character
                        if ((DBColumnElement[k].IndexOf(':') > 0) && (DBColumnElement[k].IndexOf(':') < DBColumnElement[k].Length - 1))
                        {
                            string[] splitAfterDot = DBColumnElement[k].Split(':');
                            int splitCount = 0;
                            int splitTempCount = 0;
                            DBColumnElement[k] = String.Empty;

                            #region Finding the max number of splitted strings
                            foreach (string split in splitAfterDot)
                            {
                                splitCount++;
                            }
                            #endregion

                            for (int i = 0; i < splitCount; i++)
                            {
                                splitTempCount++;
                                splitAfterDot[i].Trim();
                                if (splitTempCount == splitCount) // if we reached the last split element where we don't need to add the last .
                                {
                                    DBColumnElement[k] += splitAfterDot[i];
                                }
                                else
                                {
                                    // Checking if there's a situation like this: ...
                                    if (splitAfterDot[i].Length > 1 && splitAfterDot[i + 1].Length > 1)
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + ": ";
                                    }
                                    else
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + ":";
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Fixing the ? character
                        if ((DBColumnElement[k].IndexOf('?') > 0) && (DBColumnElement[k].IndexOf('?') < DBColumnElement[k].Length - 1))
                        {
                            string[] splitAfterDot = DBColumnElement[k].Split('?');
                            int splitCount = 0;
                            int splitTempCount = 0;
                            DBColumnElement[k] = String.Empty;

                            #region Finding the max number of splitted strings
                            foreach (string split in splitAfterDot)
                            {
                                splitCount++;
                            }
                            #endregion

                            for (int i = 0; i < splitCount; i++)
                            {
                                splitTempCount++;
                                splitAfterDot[i].Trim();
                                if (splitTempCount == splitCount) // if we reached the last split element where we don't need to add the last .
                                {
                                    DBColumnElement[k] += splitAfterDot[i];
                                }
                                else
                                {
                                    // Checking if there's a situation like this: ...
                                    if (splitAfterDot[i].Length > 1 && splitAfterDot[i + 1].Length > 1)
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + "? ";
                                    }
                                    else
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + "?";
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Fixing the ! character
                        if ((DBColumnElement[k].IndexOf('!') > 0) && (DBColumnElement[k].IndexOf('!') < DBColumnElement[k].Length - 1))
                        {
                            string[] splitAfterDot = DBColumnElement[k].Split('!');
                            int splitCount = 0;
                            int splitTempCount = 0;
                            DBColumnElement[k] = String.Empty;

                            #region Finding the max number of splitted strings
                            foreach (string split in splitAfterDot)
                            {
                                splitCount++;
                            }
                            #endregion

                            for (int i = 0; i < splitCount; i++)
                            {
                                splitTempCount++;
                                splitAfterDot[i].Trim();
                                if (splitTempCount == splitCount) // if we reached the last split element where we don't need to add the last .
                                {
                                    DBColumnElement[k] += splitAfterDot[i];
                                }
                                else
                                {
                                    // Checking if there's a situation like this: ...
                                    if (splitAfterDot[i].Length > 1 && splitAfterDot[i + 1].Length > 1)
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + "! ";
                                    }
                                    else
                                    {
                                        DBColumnElement[k] += splitAfterDot[i] + "!";
                                    }
                                }
                            }
                        }
                        #endregion
                    }

                    #region <Commented>
                    //if (DBColumnElement[1].IndexOf(',') > 0)
                    //{

                    //}
                    //if (DBColumnElement[1].IndexOf(';') > 0)
                    //{

                    //}
                    //if (DBColumnElement[1].IndexOf(':') > 0)
                    //{

                    //}
                    //if (DBColumnElement[1].IndexOf('!') > 0)
                    //{

                    //}
                    //if (DBColumnElement[1].IndexOf('?') > 0)
                    //{

                    //}
                    #endregion
                    #region Finding the max number of elements that were separated by ',
                    int DBColumnElementCount = 0;
                    foreach (string DBElement in DBColumnElement)
                    {
                        DBColumnElementCount++;
                    }
                    #endregion
                    #region Creating the SQL statement
                    for (byte i = 0; i < DBColumnElementCount-1; i++ )
                    {
                        sqlInsert += DBColumnElement[i] + "\',";
                    }
                    sqlInsert += DBColumnElement[DBColumnElementCount-1];
                    #endregion
                    #region <Commented> Old code - did not work cause sometimes we had more than 14 elements in the split string
                    //sqlInsert =
                        //    DBColumnElement[0] + "\'," +
                        //    DBColumnElement[1] + "\'," +
                        //    DBColumnElement[2] + "\'," +
                        //    DBColumnElement[3] + "\'," +
                        //    DBColumnElement[k] + "\'," +
                        //    DBColumnElement[5] + "\'," +
                        //    DBColumnElement[6] + "\'," +
                        //    DBColumnElement[7] + "\'," +
                        //    DBColumnElement[8] + "\'," +
                        //    DBColumnElement[9] + "\'," +
                        //    DBColumnElement[10] + "\'," +
                        //    DBColumnElement[11] + "\'," +
                        //    DBColumnElement[12] + "\'," +
                        //    DBColumnElement[13] + "\'," +
                    //    DBColumnElement[14] + "\'," + DBColumnElement[15];
                    #endregion
                    queueSql.Enqueue(sqlInsert);

                    sqlInsert = String.Empty;
                }

            }

            #region Writing the modifiedQuestDescriptions.sql file
            using (StreamWriter sw = new StreamWriter("modifiedQuestDescriptions.sql"))
            {
                foreach (string queueItem in queueSql)
                {
                    // The copy is needed cause regex cannot be applied to the original string
                    string queueItemCopy = queueItem; 
                    #region Removing all double whitespaces
                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex(@"[ ]{2,}", options);
                    queueItemCopy = regex.Replace(queueItemCopy, @" ");
                    #endregion
                    sw.WriteLine(queueItemCopy);
                }
                Console.WriteLine("Done");
            }
            #endregion

            //Console.ReadKey();

        }
    }
}
