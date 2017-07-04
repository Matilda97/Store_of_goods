using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store_of__goods.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(WAREHOUSE_DATA wardata, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.WarData.ID == wardata.ID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    WarData = wardata,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(WAREHOUSE_DATA wardata)
        {
            lineCollection.RemoveAll(l => l.WarData.ID == wardata.ID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => (decimal)e.WarData.CNR * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public WAREHOUSE_DATA WarData { get; set; }
        public int Quantity { get; set; }
    }
}