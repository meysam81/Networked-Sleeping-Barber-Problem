using System;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
//using static BarberShop.GlobalVariable;
namespace Barbershop__Client_
{
    public class Objects
    {
        Form currentForm;
        Graphics graphic;
        Brush objectColor, objectNumber;
        PointF currentCoordinate = new PointF();
        PointF pfName = new PointF();
        public static PointF[] myCoordinate = new PointF[GlobalVariable.numberOfCustomer + 1];
        static Semaphore runSemaphore = new Semaphore(1, 1);
        readonly static int width = 20, height = 20;
        public Objects(Form f)
        {
            currentForm = f;
            graphic = currentForm.CreateGraphics();
            objectColor = new SolidBrush(Color.Tomato);
            objectNumber = new SolidBrush(Color.Black);
        }
        public void Run()
        {
            runSemaphore.WaitOne();
            currentCoordinate = GlobalVariable.GetPlace();
            myCoordinate[Convert.ToInt32(Thread.CurrentThread.Name)] = currentCoordinate;
            runSemaphore.Release();
            graphic.FillEllipse(objectColor, currentCoordinate.X, currentCoordinate.Y, width, height);
            pfName = currentCoordinate;
            pfName.X += 2;
            pfName.Y += 2;
            graphic.DrawString(Thread.CurrentThread.Name, currentForm.Font, objectNumber, pfName);
        }
    }
}