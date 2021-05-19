// Author: Yao Zhou;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Driver_s_License_Exam
{
    public class VM : INotifyPropertyChanged
    {
        private string input = "";

        private ObservableCollection<Answer> wrong = new ObservableCollection<Answer>();
        public ObservableCollection<Answer> Wrong
        {
            get { return wrong; }
            set { wrong = value; propChange(); }
        }

        private string result = "";
        public string Result
        {
            get { return result; }
            set { result = value; propChange("Result"); }
        }

        private int correct = 0;
        public int Correct
        {
            get { return correct; }
            set { correct = value; propChange("Correct"); }
        }

        private int incorrect = 0;
        public int Incorrect
        {
            get { return incorrect; }
            set { incorrect = value; propChange("Incorrect"); }
        }

        public void grade()
        {
            Result = "";
            Incorrect = 0;
            Correct = 0;
            Wrong.Clear();

            string[] exam = new string[] { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A" };
            if(input == "")
            {
                Result = "You should input right files!";
                return;
            }
            string text = File.ReadAllText(input);
            string[] answer = text.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < exam.Length; i++)
            {
                string student_ans = answer[i];
                string exam_ans = exam[i];
                if (student_ans == exam_ans)
                {
                    Correct++;
                } else
                {
                    Incorrect++;
                    Answer ans = new Answer();
                    ans.select = exam_ans;
                    int j = i + 1;
                    ans.number = j.ToString();
                    Wrong.Add(ans);
                }
            }

            if (Correct >= 15)
            {
                Result = "Congratulation! You are PASS!";
            }
            else
            {
                Result = "Sorry! You are FAIL!";
            }
            
        }

        public void setFileName(string inputFileName)
        {
            input = inputFileName;
        }

        #region prop change
        public event PropertyChangedEventHandler PropertyChanged;

        private void propChange([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
