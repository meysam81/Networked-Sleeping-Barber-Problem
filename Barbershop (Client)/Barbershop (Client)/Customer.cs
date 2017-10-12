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
    public class Customer
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        static Semaphore enterShop = new Semaphore(1, 1);
        //static Semaphore mutex1 = new Semaphore(1, 1);
        static Semaphore sofaSemaphore = new Semaphore(1, 1);
        static Semaphore barberChairSemaphore = new Semaphore(1, 1);
        static Semaphore paySemaphore = new Semaphore(1, 1);
        static int cashierX = 810, enterShopY = 370, enterShopX = 830;
        int tempEnterShopX, tempEnterShopY, tempCashierX, cashierY = 120, barberChairNumber, sofaNumber;
        readonly int width = 20, height = 20;
        //static int count = 0;
        int leftBeforeSitOnSofa, upBeforeExitShop;
        PointF tempPF, pfName, sofaCoordinate, barberChairCoordinate;
        Graphics g;
        Form f1;
        string myThreadName;
        int myThreadNumber;
        GlobalVariable glv;
        Objects o;
        Brush formColor, objectColor, objectName, respond;
        FormBarbershop bf;
        ////////////////////////////////////Functions///////////////////////////////////////////////
        public Customer(Form f)
        {
            bf = new FormBarbershop();
            o = new Objects(f);
            glv = new GlobalVariable();
            //myThreadName = myThreadName;
            //bf = new barberForm();
            f1 = f;
            g = f1.CreateGraphics();
            objectName = new SolidBrush(Color.Black);
            formColor = new SolidBrush(f1.BackColor);
            objectColor = new SolidBrush(Color.Tomato);
            respond = new SolidBrush(Color.Yellow);
        }
        /////////////////////////////////////Customer//////////////////////////////////////////
        public void CustomerFunction()
        {
            myThreadName = Thread.CurrentThread.Name;
            myThreadNumber = Convert.ToInt32(myThreadName);
            o.Run();
            //int custnr;
            BeforeEnterShop();
            //mutex1.WaitOne();
            //custnr = count;
            //count++;
            //mutex1.Release();
            //sofa.WaitOne();
            EnterShop();
            BeforeSitOnSofa();
            SitOnSofa();
            //barberChair.WaitOne();
            WaitForBarberChairCustomer();
            GetUpFromSofa();
            //sofa.Release();
            SofaRelease();
            SitInBarberChair();
            //mutex2.WaitOne();
            //queue1.Enqueue(custnr);
            //custReady.Release();
            CustReady();
            //mutex2.Release();
            WaitToBeFinishedCustomer();
            //finished[custnr].WaitOne();
            LeaveBarberChair();
            //leaveBChair[custnr].Release();
            ReleaseLeaveBChairBarber();
            Pay();
            //mutex3.WaitOne();
            //queue2.Enqueue(custnr);
            //mutex3.Release();
            //payment.Release();
            ReleasePayment();
            //receipt[custnr].WaitOne();
            WaitReceipt();
            ExitShop();
            ReleaseMaxCapacity();
            //maxCapacity.Release();
        }
        //=======================================================================================
        public void BeforeEnterShop()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("enterShop: " + myThreadNumber);
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
        ////////////////////////////////EnterShop////////////////////////////////////////////////
        public void EnterShop()
        {
            //Thread.Sleep(200);
            enterShop.WaitOne();
            //if (myThreadNumber > 1)
            enterShopX -= 60;
            if (enterShopX <= 280)
            {
                enterShopX = 770;
                enterShopY += 30;
            }
            if (enterShopY > 430)
                enterShopY = 370;
            tempEnterShopX = enterShopX;
            tempEnterShopY = enterShopY;
            tempPF = myCoordinate[myThreadNumber];
            enterShop.Release();
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.X = 200;
            g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(myThreadName, f1.Font, objectName, pfName);
            while (tempPF.Y < 370)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X < tempEnterShopX)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
                if (tempPF.X > 260)
                    while (tempPF.Y < tempEnterShopY)
                    {
                        Thread.Sleep(3);
                        g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                        tempPF.Y += 1;
                        g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                        pfName = tempPF;
                        pfName.X += 2;
                        pfName.Y += 2;
                        g.DrawString(myThreadName, f1.Font, objectName, pfName);
                    }
            }
        }
        //==========================================================================================
        public void BeforeSitOnSofa()
        {

            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("sitOnSofa: " + myThreadNumber);
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
        //////////////////////////////////SitOnSofa////////////////////////////////////////////////
        public void SitOnSofa()
        {
            sofaSemaphore.WaitOne();
            sofaNumber = GlobalVariable.sofaQueue.Dequeue();
            sofaSemaphore.Release();
            sofaCoordinate = bf.GetSofaLocation(sofaNumber);
            leftBeforeSitOnSofa = (int)tempPF.X - 25;
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.Y -= 1;
            g.FillEllipse(respond, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(myThreadName, f1.Font, objectName, pfName);
            Thread.Sleep(800);
            while (tempPF.X > leftBeforeSitOnSofa)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > 336)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X > 520)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X < 520)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > 280)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X > sofaCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X < sofaCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > sofaCoordinate.Y - 20)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
        }
        //==========================================================================================
        public void WaitForBarberChairCustomer()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("waitForBarberChairCustomer: " + myThreadNumber);
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
        //==========================================================================================
        //////////////////////////////////GetUpFromSofa/////////////////////////////////////////////
        public void GetUpFromSofa()
        {
            sofaSemaphore.WaitOne();
            GlobalVariable.sofaQueue.Enqueue(sofaNumber);
            sofaSemaphore.Release();
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.Y -= 1;
            g.FillEllipse(respond, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(myThreadName, f1.Font, objectName, pfName);
            Thread.Sleep(800);
        }
        public void SofaRelease()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("sofaRelease: " + myThreadNumber);
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
        ////////////////////////////////////SitInBarberChair//////////////////////////////////////////
        public void SitInBarberChair()
        {
            barberChairSemaphore.WaitOne();
            barberChairNumber = barberChairQueue.Dequeue();
            barberChairSemaphore.Release();
            barberChairCoordinate = bf.GetBarberChairLocation(barberChairNumber);
            while (tempPF.Y > 156)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X > barberChairCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X < barberChairCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > barberChairCoordinate.Y - 20)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
        }
        public void CustReady()
        {
            byte[] sendMessage;
            byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("custReady: " + myThreadNumber);
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
        public void WaitToBeFinishedCustomer()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("waitToBeFinishedCustomer: " + myThreadNumber);
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
        /////////////////////////////////////LeaveBarberChair/////////////////////////////////////////////
        public void LeaveBarberChair()
        {
            barberChairSemaphore.WaitOne();
            barberChairQueue.Enqueue(barberChairNumber);
            barberChairSemaphore.Release();
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.Y -= 1;
            g.FillEllipse(respond, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(myThreadName, f1.Font, objectName, pfName);
            Thread.Sleep(800);
        }
        //============================================================================================
        public void ReleaseLeaveBChairBarber()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("releaseLeaveBChairBarber: " + myThreadNumber);
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
        ////////////////////////////////////////Pay/////////////////////////////////////////////////
        public void Pay()
        {
            paySemaphore.WaitOne();
            //if (Convert.ToInt32(myThreadName) > 1)
            cashierX -= 20;
            if (cashierX <= 716)
                cashierX = 745;
            tempCashierX = cashierX;
            paySemaphore.Release();
            while (tempPF.Y > 12)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            //while (tempPF.X < barberChairCoordinate.X + 50)
            //{
            //    Thread.Sleep(8);
            //    g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            //    tempPF.X += 1;
            //    g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
            //    pfName = tempPF;
            //    pfName.X += 2;
            //    pfName.Y += 2;
            //    g.DrawString(myThreadName, f1.Font, objectName, pfName);
            //}
            while (tempPF.X < tempCashierX)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.Y < barberChairCoordinate.Y + 60)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.Y < cashierY)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
        }
        ///=============================================================================================
        public void ReleasePayment()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("releasePayment: " + myThreadNumber);
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
        //===============================================================================================
        public void WaitReceipt()
        {
            byte[] sendMessage;
            //byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("waitReceipt: " + myThreadNumber);
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
        ////////////////////////////////////ExitShop//////////////////////////////////////////////
        public void ExitShop()
        {
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.Y -= 1;
            g.FillEllipse(respond, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(myThreadName, f1.Font, objectName, pfName);
            Thread.Sleep(800);
            upBeforeExitShop = (int)tempPF.Y - 30;
            while (tempPF.Y > upBeforeExitShop + 10)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            while (tempPF.X <= 820)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(myThreadName, f1.Font, objectName, pfName);
            }
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
        }
        //================================================================================================
        public void ReleaseMaxCapacity()
        {
            byte[] sendMessage;
            byte[] receiveMessage = new byte[10];
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000));
                sendMessage = Encoding.ASCII.GetBytes("releaseMaxCapacity: " + myThreadNumber);
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
        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}