using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Text;
using static Barbershop__Client_.Objects;
using static Barbershop__Client_.GlobalVariable;
using System.Net;
using System.Net.Sockets;
namespace Barbershop__Client_
{
    class Cashier
    {
        ////////////////////////////////Cashier//////////////////////////////////////////////////
        string myThreadName;
        int myThreadNumber;
        public void CashierFunction()
        {
            //int cCust;
            myThreadName = Thread.CurrentThread.Name;
            myThreadNumber = Convert.ToInt32(myThreadName);
            while (true)
            {
                //payment.WaitOne();
                WaitPayment();
                //coord.WaitOne();
                WaitCoord();
                AcceptPay();
                //coord.Release();
                ReleaseCoord();
                //mutex3.WaitOne();
                //cCust = queue2.Dequeue();
                //mutex3.Release();
                //receipt[cCust].Release();
                ReleaseReceipt();
            }
        }

        private void WaitPayment()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("waitPayment: " + myThreadNumber);
                sendSocket.Send(sendMessage, SocketFlags.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
            finally
            {
                sendSocket.Close();
                Thread.CurrentThread.Suspend();
            }
        }

        private void WaitCoord()
        {
            byte[] sendMessage;
            byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("waitCoord: " + myThreadNumber);
                sendSocket.Send(sendMessage, SocketFlags.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
            finally
            {
                sendSocket.Close();
                Thread.CurrentThread.Suspend();
            }
        }

        private void ReleaseCoord()
        {
            byte[] sendMessage;
            byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("releaseCoord: " + myThreadNumber);
                sendSocket.Send(sendMessage, SocketFlags.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
            finally
            {
                sendSocket.Close();
            }
        }

        private void ReleaseReceipt()
        {
            byte[] sendMessage;
            byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("releaseReceipt: " + myThreadNumber);
                sendSocket.Send(sendMessage, SocketFlags.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
            finally
            {
                sendSocket.Close();
            }
        }

        /////////////////////////////////AcceptPay///////////////////////////////////////////////
        private void AcceptPay()
        {
            Thread.Sleep(1200);
        }
    }
}
