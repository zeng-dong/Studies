using System;
using System.Collections.Generic;

namespace EventSourcing
{
    public class CurrentState { }

    public class WarehouseProduct
    {
        public string Sku { get; set; }
        readonly IList<IEvent> _events = new List<IEvent>();

        // projection
        private readonly CurrentState _currentState = new();

        public WarehouseProduct(string sku)
        {
            Sku = sku;
        }

        public void ShipProduct(int quantity)
        {
            if (quantity > _currentState.QuantityOnHand)
            {
                throw new InvalidDomainException("Ah ... we don't have that many to ship");
            }

            AddEvent(new ProductShipped(Sku, quantity, DateTime.UtcNow));
        }

        public void ReceiveProduct(int quantity)
        {
            AddEvent(new ProductReceived(Sku, quantity, DateTime.UtcNow));
        }

        public void AdjustInventory(int quantity, string reason)
        {
            if (_currentState.QuantityOnHand + quantity < 0)
            {
                throw new InvalidDomainException("Cannot adjust to a negative quantity ");
            }

            AddEvent(new InventoryAdjusted(Sku, quantity, reason, DateTime.UtcNow));
        }

        internal void AddEvent(IEvent evnt)
        {
            throw new NotImplementedException();
        }
    }
}
