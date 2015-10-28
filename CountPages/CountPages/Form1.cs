using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace CountPages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this._begin = Int32.Parse(beginBox.Text);
            this._end = Int32.Parse(endBox.Text);
            this.runButton.Enabled = validateRun();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (this.runThread != null)
            {
                if (this.runThread.IsAlive)
                {
                    this.runThread.Abort();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();

            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderBox.Text = folderBrowserDialog1.SelectedPath;
                global::CountPages.Properties.Settings.Default.LastFolder = folderBox.Text;
                global::CountPages.Properties.Settings.Default.Save();
            }
        }

        private void folderBox_LostFocus(object sender, System.EventArgs e)
        {
            global::CountPages.Properties.Settings.Default.LastFolder = folderBox.Text;
            global::CountPages.Properties.Settings.Default.Save();
            runButton.Enabled = validateRun();
        }

        private void beginBox_LostFocus(object sender, EventArgs e)
        {
            if (!Int32.TryParse(beginBox.Text, out _begin))
            {
                logBox.AppendText("开始病历号必须是数字!\n");
                _begin = -1;
            }

            runButton.Enabled = validateRun();
        }

        private bool validateRun()
        {
            return (
                !String.IsNullOrEmpty(beginBox.Text)
                && !String.IsNullOrEmpty(endBox.Text)
                && !String.IsNullOrEmpty(folderBox.Text)
                && _begin > -1
                && _end > -1);
        }

        private void endBox_LostFocus(object sender, EventArgs e)
        {
            if (!Int32.TryParse(endBox.Text, out _end))
            {
                logBox.AppendText("结束病历号必须是数字！\n");
                _end = -1;
            }

            if (_end < _begin)
            {
                logBox.AppendText("结束病历号必须大于开始病历号！\n");
            }

            runButton.Enabled = validateRun();
        }

        Thread runThread;
        bool cancel = false;

        private void runButton_Click(object sender, EventArgs ea)
        {
            if (runThread != null)
            {
                if (!cancel)
                {
                    cancel = true;
                    runButton.Text = "重置";
                }
                else if (!runThread.IsAlive)
                {
                    runThread = null;
                    runButton.Text = "运行";
                    cancel = false;
                }
            }
            else
            {
                cancel = false;
                runThread = new Thread(() => { run(); });
                runThread.Start();
                runButton.Text = "中止";
            }
        }

        delegate void logTextCallback(string text);

        private void logText(string text)
        {
            if (this.logBox.InvokeRequired)
            {
                logTextCallback d = new logTextCallback(logText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.logBox.AppendText(text);
            }
        }

        delegate void setCountCallback(int count);

        private void setCount(int count)
        {
            if (this.countLabel.InvokeRequired)
            {
                setCountCallback d = new setCountCallback(setCount);
                this.Invoke(d, new object[] { count });
            }
            else
            {
                this.countLabel.Text = count.ToString();
            }
        }

        delegate void setPagesCallback(int pages);

        private void setPages(int pages)
        {
            if (this.pagesLabel.InvokeRequired)
            {
                setPagesCallback d = new setPagesCallback(setPages);
                this.Invoke(d, new object[] { pages });
            }
            else
            {
                this.pagesLabel.Text = pages.ToString();
            }
        }

        private void run()
        { 
            int count = 0;
            int pages = 0;

            if (!Directory.Exists(folderBox.Text))
            {
                logText(string.Format("文件目录:{0} 不存在！\n", folderBox.Text));
                return;
            }

            // figure out current month
            DateTime current = DateTime.Now;

            // current week # of files
            // current week # of pages
            int curWeekFiles = 0;
            int curWeekPages = 0;

            // last week # of files
            // last week # of pages
            int lastWeekFiles = 0;
            int lastWeekPages = 0;

            // current month # of files
            // current month # of pages
            int curMonthFiles = 0;
            int curMonthPages = 0;

            // last month # of files
            // last month # of pages
            int lastMonthFiles = 0;
            int lastMonthPages = 0;

            Queue<string> directories = new Queue<string>();
            directories.Enqueue(folderBox.Text);

            while (directories.Count > 0)
            {
                if (cancel)
                {
                    break;
                }

                string currentDirectory = directories.Dequeue();

                logText(string.Format("正在统计{0}...\n", currentDirectory));

                foreach (string directory in Directory.GetDirectories(currentDirectory, "*"))
                {
                    directories.Enqueue(directory);
                }

                foreach (string fileName in Directory.GetFiles(currentDirectory, "*.pdf"))
                {
                    if (cancel)
                    {
                        break;
                    }

                    try
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        int num = Int32.Parse(name);

                        if (num >= _begin && num <= _end)
                        {
                            count++;

                            FileInfo fi = new FileInfo(fileName);
                            DateTime creation = fi.LastWriteTime;
                            int monthDuration = getMonths(creation, current);
                            int weekDuration = getWeeks(creation, current);

                            if (monthDuration == 0)
                            {
                                curMonthFiles++;
                            }
                            else if (monthDuration == 1)
                            {
                                lastMonthFiles++;
                            }

                            if (weekDuration == 0)
                            {
                                curWeekFiles++;
                            }
                            else if (weekDuration == 1)
                            {
                                lastWeekFiles++;
                            }

                            using (PdfReader reader = new PdfReader(fileName))
                            {
                                logText(string.Format("{0}: {1} 页\n", Path.GetFileName(fileName), reader.NumberOfPages));

                                pages += reader.NumberOfPages;

                                if (monthDuration == 0)
                                {
                                    curMonthPages += reader.NumberOfPages;
                                }
                                else if (monthDuration == 1)
                                {
                                    lastMonthPages += reader.NumberOfPages;
                                }

                                if (weekDuration == 0)
                                {
                                    curWeekPages += reader.NumberOfPages;
                                }
                                else if (weekDuration == 1)
                                {
                                    lastWeekPages += reader.NumberOfPages;
                                }

                                reader.Close();
                            }

                            setCount(count);
                            setPages(pages);
                        }
                    }
                    catch (Exception e)
                    {
                        System.Console.Error.WriteLine(e.Message);
                        System.Console.Error.WriteLine(e.StackTrace);
                    }
                }
            }

            logText(string.Format("总文件数: {0} 总页数: {1}\n", count, pages));
            logText(string.Format("本周文件数： {0} 页数： {1}\n", curWeekFiles, curWeekPages));
            logText(string.Format("上周文件数： {0} 页数： {1}\n", lastWeekFiles, lastWeekPages));
            logText(string.Format("本月文件数： {0} 页数： {1}\n", curMonthFiles, curMonthPages));
            logText(string.Format("上月文件数： {0} 页数： {1}\n", lastMonthFiles, lastMonthPages));
        }

        private int getWeeksInYear(DateTime current)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            return ci.Calendar.GetWeekOfYear(current, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        private int getMonths(DateTime start, DateTime end)
        {
            return (end.Year - start.Year) * 12 + end.Month - start.Month;
        }

        private int getWeeks(DateTime start, DateTime end)
        {
            return (end.Year - start.Year) * 52 + getWeeksInYear(end) - getWeeksInYear(start);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            logBox.Clear();
        }
    }
}
