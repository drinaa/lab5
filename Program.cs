using System;

namespace lab5
{

    class Program
    {

        static void Main(string[] args)
        {
            CallCenter callCenter = new CallCenter();
            Worker worker = new Worker();
            Courier courier = new Courier();

            PizzaRestFacade order = new PizzaRestFacade(callCenter, worker, courier);

            Client client = new Client();
            Console.WriteLine("Клиент делает заказ");
            Console.WriteLine(new string ('-', 80));
            client.MakeOrder(order);

            Console.Read();
        }
    }
   
    /// <summary>
    /// Принимает заказ и обрабатывает его
    /// </summary>
    class CallCenter
    {
        public void CreateOrder()
        {
            Console.WriteLine("Заказ принят в обработку");
        }
        public void TransOrder()
        {
            Console.WriteLine("Заказ передан на производство");
        }
    }
    /// <summary>
    /// Выполняет заказ
    /// </summary>
    class Worker
    {
        public void PerformOrder()
        {
            Console.WriteLine("Заказ готовится");
        }
    }
    /// <summary>
    /// Отвечает за доставку заказа
    /// </summary>
    class Courier
    {
        public void PickUpOrder()
        {
            Console.WriteLine("Заказ передан курьеру");
        }
        public void DeliverOrder()
        {
            Console.WriteLine("Заказ доставлен");
        }
    }

    /// <summary>
    /// Фасад приложения для клиента
    /// </summary>
    class PizzaRestFacade
    {
        CallCenter callCenter;
        Worker worker;
        Courier courier;
        public PizzaRestFacade(CallCenter callCen, Worker work, Courier  cour)
        {
            this.callCenter = callCen;
            this.worker = work;
            this.courier = cour;
        }
        public void Start()
        {
            callCenter.CreateOrder();
            callCenter.TransOrder();
            worker.PerformOrder();
            courier.PickUpOrder();
        }
        public void End()
        {
            courier.DeliverOrder();
        }
    }

    /// <summary>
    /// Заказывает продукцию
    /// </summary>
    class Client
    {
        public void MakeOrder(PizzaRestFacade facade)
        {
            facade.Start();
            facade.End();
        }
    }
}
