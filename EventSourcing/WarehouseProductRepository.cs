using System.Collections.Generic;

namespace EventSourcing
{
    public class WarehouseProductRepository
    {
        readonly Dictionary<string, IList<IEvent>> _inMemoryStream = new();

        public WarehouseProduct Get(string sku)
        {
            var p = new WarehouseProduct(sku);

            if (_inMemoryStream.ContainsKey(sku))
            {
                foreach (var evnt in _inMemoryStream[sku])
                {
                    p.AddEvent(evnt);
                }
            }

            return p;
        }

        public void Save(WarehouseProduct warehouseProduct)
        {
            _inMemoryStream[warehouseProduct.Sku] = warehouseProduct.GetEvents();
        }
    }
}
