using Ebenberger_Sample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebenberger_Sample.Classes
{
    public class MainWorker
    {
        #region Properties

        #region CancelWork
        private bool CancelWork { get; set; }
        #endregion

        #endregion

        #region EventHandler

        public event EventHandler<ProgressChangedEventArgs> WorkerChangedProgress;

        #endregion

        #region Konstruktor

        public MainWorker() { }

        #endregion

        #region Methoden

        /// <summary>
        /// Ermittelt die Wörter und zählt ihre Häufigkeit
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<WordCounterObject> GetWords(string fileName)
        {
            try
            {
                CancelWork = false;
                List<WordCounterObject> objList = new List<WordCounterObject>();

                List<string> fullSplittedWords = new List<string>();

                WorkerChangedProgress?.Invoke(this, new ProgressChangedEventArgs(-1, "Daten werden geladen..."));
                int wordCounter = 1;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (CancelWork) return null;

                        List<string> splittedWords = line.Split(' ').ToList();
                        fullSplittedWords.AddRange(splittedWords);
                    }
                }

                WorkerChangedProgress?.Invoke(this, new ProgressChangedEventArgs(-1, "Daten werden vearbeitet..."));
                foreach (string word in fullSplittedWords)
                {
                    if (CancelWork) return null;

                    WorkerChangedProgress?.Invoke(this, new ProgressChangedEventArgs(wordCounter, fullSplittedWords.Count()));
                    wordCounter++;

                    if (string.IsNullOrEmpty(word)) continue;

                    if (objList.Where(item => item.Word == word).Count() > 0)
                    {
                        WordCounterObject foundObj = objList.Where(item => item.Word == word).FirstOrDefault();
                        foundObj.Count++;
                    }
                    else
                    {
                        WordCounterObject obj = new WordCounterObject();
                        obj.Word = word;
                        obj.Count = 1;

                        objList.Add(obj);
                    }
                }

                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelWorker()
        {
            CancelWork = true;
        }

        #endregion
    }
}
