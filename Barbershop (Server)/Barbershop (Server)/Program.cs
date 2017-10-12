using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Barbershop__Server_
{
    class Program
    {
        //============================================================================================================
        //static int portServerSending3 = 30004;
        //static int portServerSending4 = 30005;
        //static int portServerSending5 = 30006;
        //static int portServerSending6 = 30007;
        //static int portServerSending7 = 30008;
        //static int portServerSending8 = 30009;
        //static Semaphore[] leaveBChair = new Semaphore[51];
        //static Semaphore[] finished = new Semaphore[51];
        //static Semaphore[] receipt = new Semaphore[51];
        //static Semaphore[] finished = new Semaphore[50];
        //static Semaphore[] leaveBChair = new Semaphore[50];
        //static Semaphore[] receipt = new Semaphore[50];
        //static Semaphore custReady = new Semaphore(0, 50);
        //static Semaphore leaveBChair = new Semaphore(0, 50);
        //static Semaphore finished = new Semaphore(0, 50);
        //static Semaphore receipt = new Semaphore(0, 50);
        //static Semaphore maxCapacitySemaphore = new Semaphore(20, 20);
        //static Semaphore sitOnSofaSemaphore = new Semaphore(4, 4);
        //static Semaphore barberChairSemaphore = new Semaphore(3, 3);
        //static Semaphore payment = new Semaphore(0, 50);
        //static Semaphore coord = new Semaphore(3, 3);
        //static Thread beforeEnterShop = new Thread(new ThreadStart(BeforeEnterShop));
        //static Thread beforeSitOnSofa = new Thread(new ThreadStart(BeforeSitOnSOfa));
        //static Thread beforeBarberChair = new Thread(new ThreadStart(WaitForBarberChair));
        //static Thread waitToBeFinished = new Thread(new ThreadStart(WaitToBeFinished));
        //static Thread waitReceipt = new Thread(new ThreadStart(WaitReceipt));
        //static Thread waitCustReady = new Thread(new ThreadStart(WaitCustReady));
        //static Thread waitLeaveBChair = new Thread(new ThreadStart(WaitLeaveBChair));
        //static Thread waitPayment = new Thread(new ThreadStart(WaitPayment));
        //static Thread waitCoord = new Thread(new ThreadStart(WaitCoord));
        //static Thread waitCoord2 = new Thread(new ThreadStart(WaitCoord2));
        //static int no.OfCustomer = 51;
        static Thread receiveFromClient = new Thread(new ThreadStart(ReceiveFromClient));
        static int portServerReceiving = 30000;
        static int portServerSendingCustomer = 30001;
        static int portServerSendingBarber = 30002;
        static int portServerSendingCashier = 30003;
        static Semaphore enterShopQueueSemaphore = new Semaphore(1, 1);
        static Semaphore sitOnSofaQueueSemaphore = new Semaphore(1, 1);
        static Semaphore waitForBarberChairCustomerQueueSemaphore = new Semaphore(1, 1);
        static Semaphore WaitLeaveBChairBarberQueueSemaphore = new Semaphore(1, 1);
        static Semaphore waitCustReadyQueueSemaphore = new Semaphore(1, 1);
        static Semaphore waitToBeFinishedQueueSemaphore = new Semaphore(1, 1);
        static Semaphore WaitReceiptQueueSemaphore = new Semaphore(1, 1);
        static Semaphore WaitCoordQueueSemaphore = new Semaphore(1, 1);
        static Semaphore waitPaymentQueueSemaphore = new Semaphore(1, 1);
        //=========================================================================================
        static Queue<int> enterShopQueue = new Queue<int>(50);
        static Queue<int> sitOnSofaQueue = new Queue<int>(50);
        static Queue<int> waitForBarberChairCustomerQueue = new Queue<int>(50);
        static Queue<int> WaitLeaveBChairBarberQueue = new Queue<int>(50);
        static Queue<int> waitToBeFinishedQueue = new Queue<int>(50);
        static Queue<int> waitCustReadyQueue = new Queue<int>(50);
        static Queue<int> WaitReceiptQueue = new Queue<int>(50);
        static Queue<int> WaitCoordQueue = new Queue<int>(50);
        static Queue<int> waitPaymentQueue = new Queue<int>(50);
        //=========================================================================================
        static Semaphore sitOnSofaIntSemaphore = new Semaphore(1, 1);
        static Semaphore custReadyIntSemaphore = new Semaphore(1, 1);
        static Semaphore leaveBChairIntSemaphore = new Semaphore(1, 1);
        static Semaphore finishedIntSemaphore = new Semaphore(1, 1);
        static Semaphore receiptIntSemaphore = new Semaphore(1, 1);
        static Semaphore maxCapacityIntSemaphore = new Semaphore(1, 1);
        static Semaphore barberChairIntSemaphore = new Semaphore(1, 1);
        static Semaphore paymentIntSemaphore = new Semaphore(1, 1);
        static Semaphore coordIntSemaphore = new Semaphore(1, 1);
        //=========================================================================================
        static int maxCapacity = 20;
        static int sitOnSofa = 4;
        static int barberChair = 3;
        static int coord = 3;
        static int custReady = 0;
        static int finished = 0;
        static int leaveBChair = 0;
        static int payment = 0;
        static int receipt = 0;
        //===============================================================================================================================
        delegate void MyDelegate();
        static void Main(string[] args)
        {
            MyDelegate d = new MyDelegate(receiveFromClient.Start);
            //d += new MyDelegate(beforeEnterShop.Start);
            //d += new MyDelegate(beforeSitOnSofa.Start);
            //d += new MyDelegate(beforeBarberChair.Start);
            //d += new MyDelegate(waitToBeFinished.Start);
            //d += new MyDelegate(waitReceipt.Start);
            //d += new MyDelegate(waitCustReady.Start);
            //d += new MyDelegate(waitLeaveBChair.Start);
            //d += new MyDelegate(waitPayment.Start);
            //d += new MyDelegate(waitCoord.Start);
            //d += new MyDelegate(waitCoord2.Start);
            d();
        }
        //===============================================================================================================================
        static void ReceiveFromClient()
        {
            Socket receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            receiveSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerReceiving));
            receiveSocket.Listen(100);
            while (true)
            {
                Socket receiveSocketTemp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    receiveSocketTemp = receiveSocket.Accept();
                    int receiveMessageSize = receiveSocketTemp.Receive(receiveMessage, SocketFlags.None);
                    string str = Encoding.ASCII.GetString(receiveMessage);
                    str = str.Substring(0, receiveMessageSize);
                    int f = str.IndexOf(':');
                    string line = str.Substring(0, f);
                    str = str.Substring(f + 2);
                    int clientNumber = int.Parse(str);
                    if (clientNumber >= 1 && clientNumber <= 50)
                    {
                        switch (line)
                        {
                            case "enterShop":
                                BeforeEnterShop(clientNumber);
                                break;
                            case "sitOnSofa":
                                BeforeSitOnSOfa(clientNumber);
                                break;
                            case "waitForBarberChairCustomer":
                                WaitForBarberChairCustomer(clientNumber);
                                break;
                            case "sofaRelease":
                                SofaRelease();
                                break;
                            case "custReady":
                                CustReady();
                                break;
                            case "waitToBeFinishedCustomer":
                                WaitToBeFinishedCustomer(clientNumber);
                                break;
                            case "releaseLeaveBChairBarber":
                                ReleaseLeaveBChairBarber();
                                break;
                            case "releasePayment":
                                ReleasePayment();
                                break;
                            case "waitReceipt":
                                WaitReceipt(clientNumber);
                                break;
                            case "releaseMaxCapacity":
                                ReleaseMaxCapacity();
                                break;
                            default:
                                break;
                        }
                    }
                    else if (clientNumber >= 51 && clientNumber <= 53)
                    {
                        switch (line)
                        {
                            case "releaseFinished":
                                ReleaseFinished();
                                break;
                            case "waitCustReady":
                                WaitCustReady(clientNumber);
                                break;
                            case "waitCoord":
                                WaitCoord(clientNumber);
                                break;
                            case "releaseCoord":
                                ReleaseCoord();
                                break;
                            case "waitLeaveBChairBarber":
                                WaitLeaveBChairBarber(clientNumber);
                                break;
                            case "releaseBarberChairCustomer":
                                ReleaseBarberChairCustomer();
                                break;
                            default:
                                break;
                        }
                    }
                    else if (clientNumber == 54)
                    {
                        switch (line)
                        {
                            case "waitPayment":
                                WaitPayment(clientNumber);
                                break;
                            case "waitCoord":
                                WaitCoord(clientNumber);
                                break;
                            case "releaseCoord":
                                ReleaseCoord();
                                break;
                            case "releaseReceipt":
                                ReleaseReceipt();
                                break;
                            default:
                                break;
                        }

                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    receiveSocketTemp.Close();
                }
            }
        }
        //===============================================================================================================================
        static void BeforeEnterShop(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested to enter shop and is enqueued in enterShopQueue", clientNumber); //change
            enterShopQueueSemaphore.WaitOne(); //change
            enterShopQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in entershopQueue: {0}", enterShopQueue.Count); //change
            enterShopQueueSemaphore.Release(); //change
            maxCapacityIntSemaphore.WaitOne(); //change
            maxCapacity--; //change
            int num = maxCapacity; //change
            if (num >= 0)
            {
                maxCapacityIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    enterShopQueueSemaphore.WaitOne(); //change
                    int cn = enterShopQueue.Dequeue(); //change
                    int count = enterShopQueue.Count; //change
                    enterShopQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to enter shop from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in entershopQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer));
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                maxCapacityIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot enter shop just yet", clientNumber); //change
            }
        }
        //==================================================================================================================================
        static void BeforeSitOnSOfa(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested to sit on sofa and is enqueued in sitOnSofaQueue", clientNumber); //change
            sitOnSofaQueueSemaphore.WaitOne(); //change
            sitOnSofaQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in sitOnSofaQueue: {0}", sitOnSofaQueue.Count); //change
            sitOnSofaQueueSemaphore.Release(); //change
            sitOnSofaIntSemaphore.WaitOne(); //change
            sitOnSofa--; //change
            int num = sitOnSofa;  //change
            if (num >= 0)
            {
                sitOnSofaIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    sitOnSofaQueueSemaphore.WaitOne(); //change
                    int cn = sitOnSofaQueue.Dequeue(); //change
                    int count = sitOnSofaQueue.Count; //change
                    sitOnSofaQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to sit on sofa from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in sitOnSofaQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer));
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                sitOnSofaIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot sit on sofa just yet", clientNumber); //change
            }
        }
        //============================================================================================================================
        static void WaitForBarberChairCustomer(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested to sit on barber chair and is enqueued in waitForBarberChairCustomerQueue", clientNumber); //change
            waitForBarberChairCustomerQueueSemaphore.WaitOne(); //change
            waitForBarberChairCustomerQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in waitForBarberChairCustomerQueue: {0}", waitForBarberChairCustomerQueue.Count); //change
            waitForBarberChairCustomerQueueSemaphore.Release(); //change
            barberChairIntSemaphore.WaitOne(); //change
            barberChair--; //change
            int num = barberChair;  //change
            if (num >= 0)
            {
                barberChairIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitForBarberChairCustomerQueueSemaphore.WaitOne(); //change
                    int cn = waitForBarberChairCustomerQueue.Dequeue(); //change
                    Console.WriteLine(cn + " is allowed to sit on barber chair from the beginning of the queue"); //change
                    int count = waitForBarberChairCustomerQueue.Count; //change
                    Console.WriteLine("Number of items in waitForBarberChairCustomerQueue: {0}", count); //change
                    waitForBarberChairCustomerQueueSemaphore.Release(); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                barberChairIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot sit on barber chair just yet", clientNumber); //change
            }
        }
        //============================================================================================================================
        static void ReleaseBarberChairCustomer()
        {
            Console.WriteLine("A release on barber chair was received by the server"); //change
            barberChairIntSemaphore.WaitOne(); //change
            barberChair++; //change
            int num = barberChair; //change
            if (num <= 0)
            {
                barberChairIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitForBarberChairCustomerQueueSemaphore.WaitOne(); //change
                    int cn = waitForBarberChairCustomerQueue.Dequeue(); //change
                    Console.WriteLine(cn + " is allowed to leave barber chair from the beginning of the queue"); //change
                    int count = waitForBarberChairCustomerQueue.Count; //change
                    Console.WriteLine("Number of items in waitForBarberChairCustomerQueue: {0}", count); //change
                    waitForBarberChairCustomerQueueSemaphore.Release(); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                barberChairIntSemaphore.Release(); //change
        }
        //===========================================================================================================================
        static void WaitLeaveBChairBarber(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested to leave barber chair and is enqueued in WaitLeaveBChairBarberQueue", clientNumber); //change
            WaitLeaveBChairBarberQueueSemaphore.WaitOne(); //change
            WaitLeaveBChairBarberQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in WaitLeaveBChairBarberQueue: {0}", WaitLeaveBChairBarberQueue.Count); //change
            WaitLeaveBChairBarberQueueSemaphore.Release(); //change
            leaveBChairIntSemaphore.WaitOne(); //change
            leaveBChair--; //change
            int num = leaveBChair;  //change
            if (num >= 0)
            {
                leaveBChairIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    WaitLeaveBChairBarberQueueSemaphore.WaitOne(); //change
                    int cn = WaitLeaveBChairBarberQueue.Dequeue(); //change
                    int count = WaitLeaveBChairBarberQueue.Count; //change
                    WaitLeaveBChairBarberQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to leave barber chair from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in WaitLeaveBChairBarberQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingBarber)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                leaveBChairIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot leave barber chair just yet", clientNumber); //change
            }
        }
        //============================================================================================================================
        static void ReleaseLeaveBChairBarber()
        {
            Console.WriteLine("A release on leaveBChair was received by the server"); //change
            leaveBChairIntSemaphore.WaitOne(); //change
            leaveBChair++; //change
            int num = leaveBChair; //change
            if (num <= 0)
            {
                leaveBChairIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    WaitLeaveBChairBarberQueueSemaphore.WaitOne(); //change
                    int cn = WaitLeaveBChairBarberQueue.Dequeue(); //change
                    Console.WriteLine(cn + " is allowed to leave barber chair from the beginning of the queue"); //change
                    int count = WaitLeaveBChairBarberQueue.Count; //change
                    Console.WriteLine("Number of items in WaitLeaveBChairBarberQueue: {0}", count); //change
                    WaitLeaveBChairBarberQueueSemaphore.Release(); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingBarber)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                leaveBChairIntSemaphore.Release(); //change
        }
        //===========================================================================================================================
        static void SofaRelease()
        {
            Console.WriteLine("A release on sofa was received by the server"); //change
            sitOnSofaIntSemaphore.WaitOne(); //change
            sitOnSofa++; //change
            int num = sitOnSofa; //change
            if (num <= 0)
            {
                sitOnSofaIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    sitOnSofaQueueSemaphore.WaitOne(); //change
                    int cn = sitOnSofaQueue.Dequeue(); //change
                    int count = sitOnSofaQueue.Count; //change
                    sitOnSofaQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to sit on sofa from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in sitOnSofaQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                sitOnSofaIntSemaphore.Release(); //change
        }
        //============================================================================================================================
        static void CustReady()
        {
            Console.WriteLine("A release on custReady was received by the server"); //change
            custReadyIntSemaphore.WaitOne(); //change
            custReady++; //change
            int num = custReady; //change
            if (num <= 0)
            {
                custReadyIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitCustReadyQueueSemaphore.WaitOne(); //change
                    int cn = waitCustReadyQueue.Dequeue(); //change
                    int count = waitCustReadyQueue.Count; //change
                    waitCustReadyQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to work on a customer's hair from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in waitCustReadyQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingBarber)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                custReadyIntSemaphore.Release(); //change
        }
        //============================================================================================================================
        static void WaitToBeFinishedCustomer(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested to be finished and is enqueued in waitToBeFinishedQueue", clientNumber); //change
            waitToBeFinishedQueueSemaphore.WaitOne(); //change
            waitToBeFinishedQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in waitToBeFinishedQueue: {0}", waitToBeFinishedQueue.Count); //change
            waitToBeFinishedQueueSemaphore.Release(); //change
            finishedIntSemaphore.WaitOne(); //change
            finished--; //change
            int num = finished;  //change
            if (num >= 0)
            {
                finishedIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitToBeFinishedQueueSemaphore.WaitOne(); //change
                    int cn = waitToBeFinishedQueue.Dequeue(); //change
                    int count = waitToBeFinishedQueue.Count; //change
                    waitToBeFinishedQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to be finished from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in waitToBeFinishedQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                finishedIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot leave barber chair just yet", clientNumber); //change
            }
        }
        //============================================================================================================================
        static void ReleasePayment()
        {
            Console.WriteLine("A release on payment was received by the server"); //change
            paymentIntSemaphore.WaitOne(); //change
            payment++; //change
            int num = payment; //change
            if (num <= 0)
            {
                paymentIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitPaymentQueueSemaphore.WaitOne(); //change
                    int cn = waitPaymentQueue.Dequeue(); //change
                    int count = waitPaymentQueue.Count; //change
                    waitPaymentQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to receive customer's payment from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in waitPaymentQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCashier)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                paymentIntSemaphore.Release(); //change
        }
        //============================================================================================================================
        static void WaitReceipt(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested a receipt and is enqueued in WaitReceiptQueue", clientNumber); //change
            WaitReceiptQueueSemaphore.WaitOne(); //change
            WaitReceiptQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in WaitReceiptQueue: {0}", WaitReceiptQueue.Count); //change
            WaitReceiptQueueSemaphore.Release(); //change
            receiptIntSemaphore.WaitOne(); //change
            receipt--; //change
            int num = receipt;  //change
            if (num >= 0)
            {
                receiptIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    WaitReceiptQueueSemaphore.WaitOne(); //change
                    int cn = WaitReceiptQueue.Dequeue(); //change
                    int count = WaitReceiptQueue.Count; //change
                    WaitReceiptQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to receive a receipt from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in WaitReceiptQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                receiptIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot receive a receipt just yet", clientNumber); //change
            }
        }
        //===============================================================================================================================
        static void ReleaseMaxCapacity()
        {
            Console.WriteLine("A release on maxCapacity was received by the server"); //change
            maxCapacityIntSemaphore.WaitOne(); //change
            maxCapacity++; //change
            int num = maxCapacity; //change
            if (num <= 0)
            {
                maxCapacityIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    enterShopQueueSemaphore.WaitOne(); //change
                    int cn = enterShopQueue.Dequeue(); //change
                    int count = enterShopQueue.Count; //change
                    enterShopQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to enter shop from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in enterShopQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                maxCapacityIntSemaphore.Release(); //change
        }
        //===============================================================================================================================
        static void ReleaseFinished()
        {
            Console.WriteLine("A release on finished was received by the server"); //change
            finishedIntSemaphore.WaitOne(); //change
            finished++; //change
            int num = finished; //change
            if (num <= 0)
            {
                finishedIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitToBeFinishedQueueSemaphore.WaitOne(); //change
                    int cn = waitToBeFinishedQueue.Dequeue(); //change
                    Console.WriteLine(cn + " is allowed to be finished from the beginning of the queue"); //change
                    int count = waitToBeFinishedQueue.Count; //change
                    Console.WriteLine("Number of items in waitToBeFinishedQueue: {0}", count); //change
                    waitToBeFinishedQueueSemaphore.Release(); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                finishedIntSemaphore.Release(); //change
        }
        //===============================================================================================================================
        static void WaitCustReady(int clientNumber)
        {
            //if (clientNumber >= 51 && clientNumber <= 53)
            //{
            Console.WriteLine("Thread no. {0} requested a ready customer and is enqueued in waitCustReadyQueue", clientNumber); //change
            waitCustReadyQueueSemaphore.WaitOne(); //change
            waitCustReadyQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in waitCustReadyQueue: {0}", waitCustReadyQueue.Count); //change
            waitCustReadyQueueSemaphore.Release(); //change
            custReadyIntSemaphore.WaitOne(); //change
            custReady--; //change
            int num = custReady;  //change
            if (num >= 0)
            {
                custReadyIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitCustReadyQueueSemaphore.WaitOne(); //change
                    int cn = waitCustReadyQueue.Dequeue(); //change
                    int count = waitCustReadyQueue.Count; //change
                    waitCustReadyQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to receive a ready customer from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in waitCustReadyQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingBarber)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                custReadyIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot receive a ready customer just yet", clientNumber); //change
            }
            //}
        }
        //===========================================================================================================================
        static void WaitPayment(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested to receive payment and is enqueued in waitPaymentQueue", clientNumber); //change
            waitPaymentQueueSemaphore.WaitOne(); //change
            waitPaymentQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in waitPaymentQueue: {0}", waitPaymentQueue.Count); //change
            waitPaymentQueueSemaphore.Release(); //change
            paymentIntSemaphore.WaitOne(); //change
            payment--; //change
            int num = payment;  //change
            if (num >= 0)
            {
                paymentIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    waitPaymentQueueSemaphore.WaitOne(); //change
                    int cn = waitPaymentQueue.Dequeue(); //change
                    int count = waitPaymentQueue.Count; //change
                    waitPaymentQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to receive payment from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in waitPaymentQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCashier)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                paymentIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot receive payment just yet", clientNumber); //change
            }
        }
        //===========================================================================================================================
        static void WaitCoord(int clientNumber)
        {
            Console.WriteLine("Thread no. {0} requested a coord and is enqueued in WaitCoordQueue", clientNumber); //change
            WaitCoordQueueSemaphore.WaitOne(); //change
            WaitCoordQueue.Enqueue(clientNumber); //change
            Console.WriteLine("Number of items in WaitCoordQueue: {0}", WaitCoordQueue.Count); //change
            WaitCoordQueueSemaphore.Release(); //change
            coordIntSemaphore.WaitOne(); //change
            coord--; //change
            int num = coord;  //change
            if (num >= 0)
            {
                coordIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    WaitCoordQueueSemaphore.WaitOne(); //change
                    int cn = WaitCoordQueue.Dequeue(); //change
                    int count = WaitCoordQueue.Count; //change
                    WaitCoordQueueSemaphore.Release(); //change
                    int port = 0;
                    if (cn >= 51 && cn <= 53)
                        port = portServerSendingBarber;
                    else if (cn == 54)
                        port = portServerSendingCashier;
                    Console.WriteLine(cn + " is allowed to receive a coord from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in WaitCoordQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
            {
                coordIntSemaphore.Release(); //change
                Console.WriteLine("Thread no. {0} cannot receive a coord just yet", clientNumber); //change
            }
        }
        //===========================================================================================================================
        static void ReleaseCoord()
        {
            Console.WriteLine("A release on coord was received by the server"); //change
            coordIntSemaphore.WaitOne(); //change
            coord++; //change
            int num = coord; //change
            if (num <= 0)
            {
                coordIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    WaitCoordQueueSemaphore.WaitOne(); //change
                    int cn = WaitCoordQueue.Dequeue(); //change
                    int count = WaitCoordQueue.Count; //change
                    WaitCoordQueueSemaphore.Release(); //change
                    int port = 0;
                    if (cn >= 51 && cn <= 53)
                        port = portServerSendingBarber;
                    else if (cn == 54)
                        port = portServerSendingCashier;
                    Console.WriteLine(cn + " is allowed to receive a coord from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in WaitCoordQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                coordIntSemaphore.Release(); //change
        }
        //===========================================================================================================================
        static void ReleaseReceipt()
        {
            Console.WriteLine("A release on receipt was received by the server"); //change
            receiptIntSemaphore.WaitOne(); //change
            receipt++; //change
            int num = receipt; //change
            if (num <= 0)
            {
                receiptIntSemaphore.Release(); //change
                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] sendMessage;
                byte[] receiveMessage = new byte[100];
                try
                {
                    WaitReceiptQueueSemaphore.WaitOne(); //change
                    int cn = WaitReceiptQueue.Dequeue(); //change
                    int count = WaitReceiptQueue.Count; //change
                    WaitReceiptQueueSemaphore.Release(); //change
                    Console.WriteLine(cn + " is allowed to receive a receipt from the beginning of the queue"); //change
                    Console.WriteLine("Number of items in WaitReceiptQueue: {0}", count); //change
                    sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portServerSendingCustomer)); //change
                    sendMessage = Encoding.ASCII.GetBytes((cn).ToString());
                    sendSocket.Send(sendMessage, SocketFlags.None);
                    int b = sendSocket.Receive(receiveMessage, SocketFlags.None);
                    string print = Encoding.ASCII.GetString(receiveMessage);
                    print = print.Substring(0, b);
                    Console.WriteLine(print);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
                finally
                {
                    sendSocket.Close();
                }
            }
            else
                receiptIntSemaphore.Release(); //change
        }
        //===========================================================================================================================
    }
}