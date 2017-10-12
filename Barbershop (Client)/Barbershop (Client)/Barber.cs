using System.Threading;
using static Barbershop__Client_.GlobalVariable;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System;
using System.Windows.Forms;

namespace Barbershop__Client_
{
    class Barber
    {
        ////////////////////////////////Barber//////////////////////////////////////////////////
        string myThreadName;
        int myThreadNumber;
        public void BarberFunction()
        {
            //int bCust;
            myThreadName = Thread.CurrentThread.Name;
            myThreadNumber = Convert.ToInt32(myThreadName);
            while (true)
            {
                //custReady.WaitOne();
                WaitCustReady();
                //mutex2.WaitOne();
                //bCust = queue1.Dequeue();
                //mutex2.Release();
                //coord.WaitOne();
                WaitCoord();
                CutHair();
                //coord.Release();
                ReleaseCoord();
                //finished[bCust].Release();
                ReleaseFinished();
                //leaveBChair[bCust].WaitOne();
                WaitLeaveBChairBarber();
                //barberChair.Release();
                ReleaseBarberChairCustomer();
            }
        }
        //////////////////////////////CutHair///////////////////////////////////////////////////
        public void WaitCustReady()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("waitCustReady: " + myThreadNumber);
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
        public void WaitCoord()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
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
        private void CutHair()
        {
            Thread.Sleep(4000);
        }
        public void ReleaseCoord()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
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
        public void ReleaseFinished()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("releaseFinished: " + myThreadNumber);
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
        public void WaitLeaveBChairBarber()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("waitLeaveBChairBarber: " + myThreadNumber);
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
        public void ReleaseBarberChairCustomer()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("releaseBarberChairCustomer: " + myThreadNumber);
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
    }
}
