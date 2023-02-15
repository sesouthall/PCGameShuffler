using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GameShuffler
{
    public partial class Form1 : Form
    {
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        int RemoveGameKeyId = 1;

        int RemoveGameKey = (int)Keys.PageDown;

        Thread? shuffleThread = null;
        bool stopShuffle = false;

        int minShuffleTime = 0;
        int maxShuffleTime = 0;
        List<Process> gamesToShuffle = new List<Process>();

        Process? currentGame = null;

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
            var allProcesses = Process.GetProcesses();
            runningProcessesSelectionList.SelectedItems.Clear();
            runningProcessesSelectionList.Items.Clear();
            runningProcessesSelectionList.Items.AddRange(
                allProcesses.Where(process => !string.IsNullOrEmpty(process.MainWindowTitle))
                            .Select(process => $"{process.MainWindowTitle}\t{process.Id}")
                            .ToArray());
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;
            runningProcessesSelectionList.Enabled = false;
            startButton.Enabled = false;
            minTimeTextBox.Enabled = false;
            maxTimeTextBox.Enabled = false;
            stopButton.Enabled = true;
            if (!int.TryParse(minTimeTextBox.Text, out minShuffleTime) || minShuffleTime < 0)
            {
                MessageBox.Show("Minimum shuffle time must be a positive number");
            }

            if (!int.TryParse(maxTimeTextBox.Text, out maxShuffleTime) || maxShuffleTime < minShuffleTime)
            {
                MessageBox.Show("Maximum shuffle time must be a positive number greater than minimum shuffle time");
            }

            if (!RegisterHotKey(this.Handle, RemoveGameKeyId, 0x0000, RemoveGameKey))
            {
                MessageBox.Show("Failed to initialize shuffle start key");
            }

            foreach (var processString in runningProcessesSelectionList.CheckedItems)
            {
                var process = Process.GetProcessById(int.Parse(((string)processString).Split("\t")[1]));
                gamesToShuffle.Add(process);
            }

            shuffleThread = new Thread(ShuffleLoop);
            shuffleThread.Start();
        }

        private void StopButton_Clicked(object sender, EventArgs e)
        {
            refreshButton.Enabled = true;
            runningProcessesSelectionList.Items.Clear();
            runningProcessesSelectionList.Enabled = true;
            startButton.Enabled = true;
            minTimeTextBox.Enabled = true;
            maxTimeTextBox.Enabled = true;
            stopButton.Enabled = false;

            if (shuffleThread != null)
            {
                stopShuffle = true;
            }

            UnregisterHotKey(this.Handle, RemoveGameKeyId);
        }

        private void ShuffleLoop()
        {
            foreach (var process in gamesToShuffle) 
            { 
                SuspendProcess(process);
            }

            while (gamesToShuffle.Any() && !stopShuffle)
            {
                if (currentGame != null)
                {
                    ShowWindow(currentGame.MainWindowHandle, 0);
                    SuspendProcess(currentGame);
                }

                StartNewGame();

                Thread.Sleep(rand.Next(minShuffleTime, maxShuffleTime)*1000);
            }

            foreach (var process in gamesToShuffle)
            {
                if (process != currentGame)
                {
                    ResumeProcess(process);
                }
            }

            stopShuffle = false;
        }

        private void StartNewGame()
        {
            var currentGameIndex = currentGame == null ? 0 : gamesToShuffle.IndexOf(currentGame);
            var newGameIndex = currentGameIndex;
            while (newGameIndex == currentGameIndex)
            {
                newGameIndex = rand.Next(gamesToShuffle.Count);
            }
            var newGame = gamesToShuffle[newGameIndex];
            ResumeProcess(newGame);
            ShowWindow(newGame.MainWindowHandle, 3);
            SetForegroundWindow(newGame.MainWindowHandle);
            currentGame = newGame;
        }

        private static void SuspendProcess(Process process)
        {
            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                SuspendThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
        }

        public static void ResumeProcess(Process process)
        {
            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                var suspendCount = 0;
                do
                {
                    suspendCount = ResumeThread(pOpenThread);
                } while (suspendCount > 0);

                CloseHandle(pOpenThread);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = (int)m.WParam;

                if (id == RemoveGameKeyId && currentGame != null)
                {
                    gamesToShuffle.Remove(currentGame);
                    currentGame.Kill();
                    if (gamesToShuffle.Any())
                    {
                        StartNewGame();
                    }
                }
            }

            base.WndProc(ref m);
        }
    }
}