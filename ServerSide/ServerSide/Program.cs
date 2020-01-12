using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSide
{
     class Program
    {
        static public List<TcpClient> tcplist = new List<TcpClient>();
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //initialize();
        }
            /*static void initialize()
            {
                TcpListener listener = null;
                try
                {
                    listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
                    listener.Start();
                    Console.WriteLine("MultiThreadedEchoServer started...");
                    while (true)
                    {
                        Console.WriteLine("Waiting for incoming client connections...");
                        TcpClient client = listener.AcceptTcpClient();
                        tcplist.Add(client);
                        Console.WriteLine("Accepted new client connection...");
                        Thread t = new Thread(ProcessClientRequests);
                        t.Start(client);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                }

                void ProcessClientRequests()
                {
                    
                }
            }*/
        }
    }

