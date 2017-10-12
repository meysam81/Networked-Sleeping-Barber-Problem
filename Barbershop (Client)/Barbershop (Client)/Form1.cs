using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using static Barbershop__Client_.GlobalVariable;

namespace Barbershop__Client_
{
    public partial class FormBarbershop : Form
    {
        //Thread resumeSuspendedThreadsSitOnSofa;
        //Thread resumeSuspendedThreadsSitOnbarberChair;
        //Thread resumeSuspendedThreadsWaitToBeFinished;
        //Thread resumeSuspendedThreadsWaitReceipt;
        //Thread resumeSuspendedThreadsWaitLeaveBChair;
        //Thread resumeSuspendedThreadsWaitCoord;
        //==========================================================
        //static void ResumeSuspendedThreadsSitOnbarberChair()
        //{
        //    Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30003));
        //    mySocket1.Listen(100);
        //    while (true)
        //    {
        //        Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        byte[] sendMessage;
        //        byte[] receiveMessage = new byte[100];
        //        int threadNumber = 0;
        //        try
        //        {
        //            tempSocket = mySocket1.Accept();
        //            int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
        //            threadNumber = Convert.ToInt32(Encoding.ASCII.GetString(receiveMessage));
        //            if (movement[threadNumber].ThreadState == ThreadState.Suspended)
        //                movement[threadNumber].Resume();
        //            string str = string.Format("Thanks for resuming thread no. {0} in sitOnbarberChair", threadNumber);
        //            sendMessage = Encoding.ASCII.GetBytes(str);
        //            tempSocket.Send(sendMessage, SocketFlags.None);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + threadNumber);
        //        }
        //        finally
        //        {
        //            tempSocket.Close();
        //        }
        //    }
        //}
        //static void ResumeSuspendedThreadsSitOnSofa()
        //{
        //    Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30002));
        //    mySocket1.Listen(100);
        //    while (true)
        //    {
        //        Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        byte[] sendMessage;
        //        byte[] receiveMessage = new byte[100];
        //        int threadNumber = 0;
        //        try
        //        {
        //            tempSocket = mySocket1.Accept();
        //            int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
        //            threadNumber = Convert.ToInt32(Encoding.ASCII.GetString(receiveMessage));
        //            if (movement[threadNumber].ThreadState == ThreadState.Suspended)
        //                movement[threadNumber].Resume();
        //            string str = string.Format("Thanks for resuming thread no. {0} in sitOnSofa", threadNumber);
        //            sendMessage = Encoding.ASCII.GetBytes(str);
        //            tempSocket.Send(sendMessage, SocketFlags.None);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + threadNumber);
        //        }
        //        finally
        //        {
        //            tempSocket.Close();
        //        }
        //    }
        //}
        //static void ResumeSuspendedThreadsWaitToBeFinished()
        //{
        //    Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    int portServerSending3 = 30004;
        //    mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSending3));
        //    mySocket1.Listen(100);
        //    while (true)
        //    {
        //        Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        byte[] sendMessage;
        //        byte[] receiveMessage = new byte[100];
        //        int threadNumber = 0;
        //        try
        //        {
        //            tempSocket = mySocket1.Accept();
        //            int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
        //            threadNumber = Convert.ToInt32(Encoding.ASCII.GetString(receiveMessage));
        //            if (movement[threadNumber].ThreadState == ThreadState.Suspended)
        //                movement[threadNumber].Resume();
        //            string str = string.Format("Thanks for resuming thread no. {0} in WaitToBeFinished", threadNumber);
        //            sendMessage = Encoding.ASCII.GetBytes(str);
        //            tempSocket.Send(sendMessage, SocketFlags.None);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + threadNumber);
        //        }
        //        finally
        //        {
        //            tempSocket.Close();
        //        }
        //    }
        //}
        //static void ResumeSuspendedThreadsWaitReceipt()
        //{
        //    Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    int portServerSending4 = 30005;
        //    mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSending4));
        //    mySocket1.Listen(100);
        //    while (true)
        //    {
        //        Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        byte[] sendMessage;
        //        byte[] receiveMessage = new byte[100];
        //        int threadNumber = 0;
        //        try
        //        {
        //            tempSocket = mySocket1.Accept();
        //            int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
        //            threadNumber = Convert.ToInt32(Encoding.ASCII.GetString(receiveMessage));
        //            if (movement[threadNumber].ThreadState == ThreadState.Suspended)
        //                movement[threadNumber].Resume();
        //            string str = string.Format("Thanks for resuming thread no. {0} in WaitReceipt", threadNumber);
        //            sendMessage = Encoding.ASCII.GetBytes(str);
        //            tempSocket.Send(sendMessage, SocketFlags.None);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + threadNumber);
        //        }
        //        finally
        //        {
        //            tempSocket.Close();
        //        }
        //    }
        //}
        //static void ResumeSuspendedThreadsWaitLeaveBChair()
        //{
        //    Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    int portServerSending = 30007;
        //    mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSending));
        //    mySocket1.Listen(100);
        //    while (true)
        //    {
        //        Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        byte[] sendMessage;
        //        byte[] receiveMessage = new byte[100];
        //        int threadNumber = 0;
        //        try
        //        {
        //            tempSocket = mySocket1.Accept();
        //            int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
        //            threadNumber = Convert.ToInt32(Encoding.ASCII.GetString(receiveMessage));
        //            if (barberThread[threadNumber].ThreadState == ThreadState.Suspended)
        //                barberThread[threadNumber].Resume();
        //            string str = string.Format("Thanks for resuming thread no. {0} in LeaveBChair", threadNumber);
        //            sendMessage = Encoding.ASCII.GetBytes(str);
        //            tempSocket.Send(sendMessage, SocketFlags.None);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + threadNumber);
        //        }
        //        finally
        //        {
        //            tempSocket.Close();
        //        }
        //    }
        //}
        //static void ResumeSuspendedThreadsWaitCoord()
        //{
        //    Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    int portServerSending = 30009;
        //    mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSending));
        //    mySocket1.Listen(100);
        //    while (true)
        //    {
        //        Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        byte[] sendMessage;
        //        byte[] receiveMessage = new byte[100];
        //        int threadNumber = 0;
        //        try
        //        {
        //            tempSocket = mySocket1.Accept();
        //            int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
        //            threadNumber = Convert.ToInt32(Encoding.ASCII.GetString(receiveMessage));
        //            if (cashierThread.ThreadState == ThreadState.Suspended)
        //                cashierThread.Resume();
        //            string str = string.Format("Thanks for resuming thread no. {0} in WaitPayment", threadNumber);
        //            sendMessage = Encoding.ASCII.GetBytes(str);
        //            tempSocket.Send(sendMessage, SocketFlags.None);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + threadNumber);
        //        }
        //        finally
        //        {
        //            tempSocket.Close();
        //        }
        //    }
        //}
        //===============================================================================================================================
        static Thread[] movement;
        static Thread[] barberThread;
        static Customer[] customer;
        static Barber[] barber;
        static Cashier cashier;
        static Thread cashierThread;
        Thread customerResume;
        Thread barberResume;
        Thread cashierResume;
        delegate void MyDelegate();
        static int portServerReceivingCustomer = 30001;
        static int portServerReceivingBarber = 30002;
        static int portServerReceivingCashier = 30003;
        //===============================================================================================================================
        public FormBarbershop()
        {
            InitializeComponent();
        }
        public PointF GetSofaLocation(int i)
        {
            PointF pf = new PointF();
            switch (i)
            {
                case 1:
                    pf = labelSofa4.Location;
                    break;
                case 2:
                    pf = labelSofa3.Location;
                    break;
                case 3:
                    pf = labelSofa2.Location;
                    break;
                case 4:
                    pf = labelSofa1.Location;
                    break;
                default:
                    break;
            }
            return pf;
        }
        public PointF GetBarberChairLocation(int i)
        {
            PointF pf = new PointF();
            switch (i)
            {
                case 1:
                    pf = labelBarberChair1.Location;
                    break;
                case 2:
                    pf = labelBarberChair2.Location;
                    break;
                case 3:
                    pf = labelBarberChair3.Location;
                    break;
                default:
                    break;
            }
            return pf;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 4; i++)
                sofaQueue.Enqueue(i);
            for (int i = 1; i <= 3; i++)
                barberChairQueue.Enqueue(i);
            buttonStart.Enabled = false;
            MyDelegate d = new MyDelegate(StartFunction);
            d += new MyDelegate(customerResume.Start);
            //d += new MyDelegate(resumeSuspendedThreadsSitOnSofa.Start);
            //d += new MyDelegate(resumeSuspendedThreadsSitOnbarberChair.Start);
            //d += new MyDelegate(resumeSuspendedThreadsWaitToBeFinished.Start);
            //d += new MyDelegate(resumeSuspendedThreadsWaitReceipt.Start);
            d += new MyDelegate(barberResume.Start);
            //d += new MyDelegate(resumeSuspendedThreadsWaitLeaveBChair.Start);
            d += new MyDelegate(cashierResume.Start);
            //d += new MyDelegate(resumeSuspendedThreadsWaitCoord.Start);
            d();
        }
        void StartFunction()
        {
            movement = new Thread[GlobalVariable.numberOfCustomer];
            customer = new Customer[GlobalVariable.numberOfCustomer];
            for (int i = 1; i < GlobalVariable.numberOfCustomer; i++)
            {
                customer[i] = new Customer(this);
                movement[i] = new Thread(new ThreadStart(customer[i].CustomerFunction));
                movement[i].Name = (i).ToString();
            }
            barber = new Barber[3];
            barberThread = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                barber[i] = new Barber();
                barberThread[i] = new Thread(new ThreadStart(barber[i].BarberFunction));
                barberThread[i].Name = (51 + i).ToString();
            }
            cashier = new Cashier();
            cashierThread = new Thread(new ThreadStart(cashier.CashierFunction));
            cashierThread.Name = (54).ToString();
            for (int i = 0; i < 3; i++)
                barberThread[i].Start();
            cashierThread.Start();
            for (int i = 1; i < GlobalVariable.numberOfCustomer; i++)
                movement[i].Start();
        }
        static void CustomerResume()
        {
            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerReceivingCustomer));
            mySocket.Listen(100);
            while (true)
            {
                Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                string message = null;
                try
                {
                    tempSocket = mySocket.Accept();
                    int receiveMessageSize = tempSocket.Receive(receiveMessage, SocketFlags.None);
                    message = Encoding.ASCII.GetString(receiveMessage);
                    message = message.Substring(0, receiveMessageSize);
                    //int f = message.IndexOf(':');
                    //string line = message.Substring(0, f);
                    //message = message.Substring(f + 2);
                    int threadNumber = Convert.ToInt32(message);
                    if (movement[threadNumber].ThreadState == ThreadState.Suspended)
                    {
                        movement[threadNumber].Resume();
                        string str = string.Format("Thanks for resuming thread no. {0}", threadNumber);
                        sendMessage = Encoding.ASCII.GetBytes(str);
                        tempSocket.Send(sendMessage, SocketFlags.None);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + message + "\n" + e.HelpLink + "\n" + e.InnerException
                        + "\n" + e.Source + "\n" + e.TargetSite);
                }
                finally
                {
                    tempSocket.Close();
                    Thread.Sleep(500);
                }
            }
        }
        static void BarberResume()
        {
            Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerReceivingBarber));
            mySocket1.Listen(100);
            while (true)
            {
                Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                int threadNumber = 0;
                string message = null;
                try
                {
                    tempSocket = mySocket1.Accept();
                    int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
                    message = Encoding.ASCII.GetString(receiveMessage);
                    threadNumber = Convert.ToInt32(message);
                    if (barberThread[threadNumber - 51].ThreadState == ThreadState.Suspended)
                    {
                        barberThread[threadNumber - 51].Resume();
                        string str = string.Format("Thanks for resuming thread no. {0}", threadNumber);
                        sendMessage = Encoding.ASCII.GetBytes(str);
                        tempSocket.Send(sendMessage, SocketFlags.None);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + message + "\n" + e.HelpLink + "\n" + e.InnerException
                        + "\n" + e.Source + "\n" + e.TargetSite);
                }
                finally
                {
                    tempSocket.Close();
                }
            }
        }
        static void CashierResume()
        {
            Socket mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket1.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerReceivingCashier));
            mySocket1.Listen(100);
            while (true)
            {
                Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                int threadNumber = 0;
                string message = null;
                try
                {
                    tempSocket = mySocket1.Accept();
                    int n = tempSocket.Receive(receiveMessage, SocketFlags.None);
                    message = Encoding.ASCII.GetString(receiveMessage);
                    threadNumber = Convert.ToInt32(message);
                    if (cashierThread.ThreadState == ThreadState.Suspended)
                    {
                        cashierThread.Resume();
                        string str = string.Format("Thanks for resuming thread no. {0}", threadNumber);
                        sendMessage = Encoding.ASCII.GetBytes(str);
                        tempSocket.Send(sendMessage, SocketFlags.None);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "\n" + e.StackTrace + "\nThread number: " + message + "\n" + e.HelpLink + "\n" + e.InnerException
                        + "\n" + e.Source + "\n" + e.TargetSite);
                }
                finally
                {
                    tempSocket.Close();
                }
            }
        }
        private void FormBarbershop_Load(object sender, EventArgs e)
        {
            customerResume = new Thread(new ThreadStart(CustomerResume));
            barberResume = new Thread(new ThreadStart(BarberResume));
            cashierResume = new Thread(new ThreadStart(CashierResume));
            //resumeSuspendedThreadsSitOnSofa = new Thread(new ThreadStart(ResumeSuspendedThreadsSitOnSofa));
            //resumeSuspendedThreadsSitOnbarberChair = new Thread(new ThreadStart(ResumeSuspendedThreadsSitOnbarberChair));
            //======================================================================
            //resumeSuspendedThreadsWaitToBeFinished = new Thread(new ThreadStart(ResumeSuspendedThreadsWaitToBeFinished));
            //resumeSuspendedThreadsWaitReceipt = new Thread(new ThreadStart(ResumeSuspendedThreadsWaitReceipt));
            //resumeSuspendedThreadsWaitLeaveBChair = new Thread(new ThreadStart(ResumeSuspendedThreadsWaitLeaveBChair));
            //resumeSuspendedThreadsWaitCoord = new Thread(new ThreadStart(ResumeSuspendedThreadsWaitCoord));
        }
        private void FormBarbershop_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}