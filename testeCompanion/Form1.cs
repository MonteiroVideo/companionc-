using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace testeCompanion
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private Thread tcpListenerThread;
        private TcpClient tcpClient;
        private int port = 7600; // Porta para escutar comandos
        private string companionIP = IPAddress.Loopback.ToString();
        private int companionPort; // Porta do Companion
        private System.Windows.Forms.Timer timer;
        private DateTime startTime;
        private bool isTimerRunning;
        string custom;

        public Form1()
        {
            InitializeComponent();
            companionPort = 12345;
            companionIP = GetLocalIPAddress();
            lblIPPort.Text = $"IP: {companionIP}, Porta: {port}";
            StartTCPListener();
            InitializeTimer();
        }

        private string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] localIPs = Dns.GetHostAddresses(hostName);

            foreach (IPAddress address in localIPs)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }

            return "127.0.0.1"; // Retorna loopback caso nenhum IP válido seja encontrado
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Adicionando 5 itens ao ListBox ao carregar o formulário
            listBox1.Items.Add("Item 1");
            listBox1.Items.Add("Item 2");
            listBox1.Items.Add("Item 3");
            listBox1.Items.Add("Item 4");
            listBox1.Items.Add("Item 5");
            listBox1.Items.Add("Item 6");
            listBox1.Items.Add("Item 7");
            listBox1.Items.Add("Item 8");
            listBox1.Items.Add("Item 9");
            listBox1.Items.Add("Item 10");
            listBox1.Items.Add("Item 11");
            listBox1.Items.Add("Item 12");
            listBox1.Items.Add("Item 13");
            listBox1.Items.Add("Item 14");
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Atualiza a cada segundo
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                TimeSpan elapsedTime = DateTime.Now - startTime;
                string hours = elapsedTime.Hours.ToString("D2");
                string minutes = elapsedTime.Minutes.ToString("D2");
                string seconds = elapsedTime.Seconds.ToString("D2");

                txtHoras.Text = hours;
                txtMin.Text = minutes;
                txtSec.Text = seconds;

                string timeString = $"{hours}:{minutes}:{seconds}";
                lblTimeString.Text = timeString; // Label que mostra o tempo completo

                SendTimeToCompanion(hours, minutes, seconds, timeString);
            }
        }

        private void StartTCPListener()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                tcpListenerThread = new Thread(new ThreadStart(ListenForClients));
                tcpListenerThread.IsBackground = true;
                tcpListenerThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar o listener TCP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenForClients()
        {
            while (true)
            {
                try
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao aceitar conexão TCP: {ex.Message}");
                }
            }
        }

        private void HandleClientComm(object client_obj)
        {
            tcpClient = (TcpClient)client_obj;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                string messageReceived = Encoding.ASCII.GetString(message, 0, bytesRead);
                Console.WriteLine($"Recebido TCP: {messageReceived}");

                _ = Invoke((MethodInvoker)(() =>
                {
                    lblCompanion.Text = messageReceived;

                    if (lblCompanion.Text == "GO")
                    {
                        txtHoras.Text = "50";
                    }
                }));
            }

            tcpClient.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            isTimerRunning = true;
            timer.Start();
        }

        private void SendTimeToCompanion(string hours, string minutes, string seconds, string timeString)
        {
            try
            {
                using (TcpClient client = new TcpClient(companionIP, companionPort))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = Encoding.ASCII.GetBytes($"hours={hours}&minutes={minutes}&seconds={seconds}&time={timeString}");
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar mensagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCompanionWithList()
        {
            try
            {
                // Criar uma lista temporária para garantir que sempre haja 20 itens
                var tempList = listBox1.Items.Cast<string>().ToList();

                // Adicionar strings "PRESET" com índice até que a lista tenha 20 itens
                while (tempList.Count < 20)
                {
                    tempList.Add($"PRESET\n{tempList.Count + 1}");
                }

                // Criar a string de mensagem formatada com base na lista de itens
                string message = string.Join("&", tempList.Select((item, index) => $"item{index + 1}={item}"));

                // Enviar a mensagem formatada ao Companion
                SendMessageToCompanion(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o Companion com a lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpListener.Stop();
            tcpListenerThread?.Abort();
            tcpClient?.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Captura os valores de horas e minutos das caixas de texto
            string hours = txtHoras.Text;
            string minutes = txtMin.Text;

            // Formata a mensagem no formato esperado pelo Companion
            string message = $"TIME=+{hours}:{minutes}:00&STATE=PLAYING&DISPLAY=TIMER&MESSAGE=FALSE";

            // Envia a mensagem ao Companion
            SendMessageToCompanion(message);

            UpdateCompanionWithList();
        }

        private void SendMessageToCompanion(string message)
        {
            try
            {
                // Conecta ao Companion usando TCP
                using (TcpClient client = new TcpClient(companionIP, companionPort))
                using (NetworkStream stream = client.GetStream())
                {
                    // Envia a mensagem
                    byte[] buffer = Encoding.ASCII.GetBytes(message + "\r\n");
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar mensagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento de seleção de item, se necessário
        }
    }
}
