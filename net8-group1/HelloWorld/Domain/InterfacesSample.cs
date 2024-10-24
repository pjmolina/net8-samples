namespace HelloWorld.Domain
{
    /// <summary>
    /// Contract to deliver pizzas
    /// </summary>
    public interface IDeliverService
    {
        public int DeliverOrder(int orderId, Customer customer, Address adr);
        public DeliverInfo TrackOrder(int trackId);

        public bool CancelDelivery(int trackId);
    }

    public class DeliverInfo
    {
        public int TrackId { get; set; }
        public string Status { get; set; }
    }

    public class DeliverService : IDeliverService
    {
        public bool CancelDelivery(int trackId)
        {
            // .... dabase
            return false;
        }
        public int DeliverOrder(int orderId, Customer customer, Address adr)
        {
            // ...
            return 7;
        }
        public DeliverInfo TrackOrder(int trackId)
        {
            return new DeliverInfo()
            {
                //...
            };
        }
    }

    public interface IClipboard
    {
        void Cut();
        void Paste();
        void Copy();

    }

    public class BlackBoard : IClipboard
    {
        void Write() { }
        void Draw() { }
        void Clean() { }

        public void Cut() { }
        public void Paste() { }
        public void Copy()
        {
            //...
            //
        }

    }
}
