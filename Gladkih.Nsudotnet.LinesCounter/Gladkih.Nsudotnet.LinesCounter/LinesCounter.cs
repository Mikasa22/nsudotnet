using System;
using System.IO;
using System.Linq;

namespace Gladkih.Nsudotnet.LinesCounter
{
    internal class LinesCounter
    {

        public static int GetNumberOfLinesInDirectory(string dirName, string fileNameTemplate, CommentsTemplate comments)
        {
            string[] dirs = Directory.GetDirectories(dirName);
            int result = dirs.Sum(s => GetNumberOfLinesInDirectory(s, fileNameTemplate, comments));

            string[] files = Directory.GetFiles(dirName, fileNameTemplate);
            result += files.Sum(s => GetNumberOfLinesInFile(s, comments));

            return result;
        }

        private static int GetNumberOfLinesInFile(string fileName, CommentsTemplate comments)
        {
            int result = 0;
            char[] ignoreSymbols = {' ', '\t'};
            bool isCommentOpen = false;

            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                string line;
                while (null != (line = sr.ReadLine()))
                {
                    while (true)
                    {
                        if (!isCommentOpen)
                        {
                            int lineCommentInd = line.IndexOf(comments.MonoComment, StringComparison.Ordinal);
                            int startCommentInd = line.IndexOf(comments.StartMultylineComment, StringComparison.Ordinal);

                            if (lineCommentInd == startCommentInd)
                            {
                                break;
                            }

                            if ((lineCommentInd < startCommentInd || -1 == startCommentInd) && -1 != lineCommentInd)
                            {
                                line = line.Substring(0, lineCommentInd);
                                break;
                            }

                            isCommentOpen = true;
                            int endCommentInd = line.IndexOf(comments.EndMultylineComment, StringComparison.Ordinal);
                            if (0 <= endCommentInd)
                            {
                                isCommentOpen = false;
                                if (endCommentInd + comments.EndMultylineComment.Length < line.Length)
                                {
                                    line = line.Substring(0, startCommentInd) + line.Substring(endCommentInd + comments.EndMultylineComment.Length);
                                }
                                else
                                {
                                    line = line.Substring(0, startCommentInd);
                                    break;
                                }
                            }
                            else
                            {
                                line = line.Substring(0, startCommentInd);
                                break;
                            }
                            
                        }
                        else
                        {
                            int endCommentInd = line.IndexOf(comments.EndMultylineComment, StringComparison.Ordinal);
                            if (0 <= endCommentInd)
                            {
                                isCommentOpen = false;
                                if (endCommentInd + comments.EndMultylineComment.Length < line.Length)
                                {
                                    line = line.Substring(endCommentInd + comments.EndMultylineComment.Length);
                                }
                                else
                                {
                                    line = "";
                                    break;
                                }
                            }
                            else
                            {
                                line = "";
                                break;
                            }
                        }
                    }

                    line = line.Trim(ignoreSymbols);
                    if (0 != line.Length)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}

