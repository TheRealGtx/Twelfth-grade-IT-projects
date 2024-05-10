//Creates a server and then a client that's able to send a message.
using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Threading;

namespace clientserver2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static string _messaggioRicevutoDaCLient;
        static string _messaggioDaInviareALServer;
        static Thread server = new Thread(startServer);
        static Thread client = new Thread(startClient);
        static SemaphoreSlim bloccaClient = new SemaphoreSlim(0);
        static SemaphoreSlim bloccaLabel = new SemaphoreSlim(0);
        bool enable1 = false;
        bool enable2 = false;
        

        static void startServer()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            
            try
            {
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                listener.Bind(localEndPoint);
                listener.Listen(10);

                Socket handler = listener.Accept();

                string data = null;
                byte[] bytes = null;

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                //ricevi messaggio
                _messaggioRicevutoDaCLient = data;
                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                bloccaLabel.Release();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        {
            server.Start();
            enable2 = true;

            if (enable2 & enable1)
            {
                btnInviaMessaggioAServer.IsEnabled = true;
            }
        }

        static void startClient()
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEp = new IPEndPoint(ipAddress, 11000);
                
                try
                {
                    Socket senderr = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    senderr.Connect(remoteEp);

                    bloccaClient.Wait();
                    _messaggioDaInviareALServer += "<EOF>";
                    byte[] msg = Encoding.ASCII.GetBytes(_messaggioDaInviareALServer);

                    int bytesSent = senderr.Send(msg);

                    int bytesRec = senderr.Receive(bytes);
                    _messaggioRicevutoDaCLient = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    senderr.Shutdown(SocketShutdown.Both);
                    senderr.Close();
                }
                catch (ArgumentException an)
                {
                }
                catch (SocketException se)
                {
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception er)
            {
            }
        }

        private void btnStartSClient_Click(object sender, RoutedEventArgs e)
        {
            client.Start();
            enable1 = true;

            if (enable2 & enable1)
            {
                btnInviaMessaggioAServer.IsEnabled = true;
            }
        }

        private void btnInviaMessaggioAClient_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnInviaMessaggioAServer_Click(object sender, RoutedEventArgs e)
        {
            _messaggioDaInviareALServer = txtnviaMessaggioAServer.Text;
            bloccaClient.Release();
            bloccaLabel.Wait();
            lblMessaggioDaClient.Content = _messaggioRicevutoDaCLient.Remove(_messaggioRicevutoDaCLient.Length - 5);
            btnInviaMessaggioAServer.IsEnabled = false;
        }

        private void lblMessaggioDaClient_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtnviaMessaggioAClient_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void txtnviaMessaggioAServer_GotFocus(object sender, RoutedEventArgs e)
        {
            txtnviaMessaggioAServer.Text = "";
        }
    }
}
