using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Honey.DAL.Entity;
using LINQtoCSV;

namespace Honey.DAL.CRUD
{
    public class ProductCRUD : CRUD<Product>
    {
        public ProductCRUD()
            : base() { }

        public override List<Product> GetList()
        {
            CsvContext cc = new CsvContext();
            List<Product> products = cc.Read<Product>(FileName).ToList();
            return products;
        }

        public override Product Get(int id)
        {
            return default(Product);
        }

        public override int Add(Product item)
        {
            if (item == null)
            {
                // TODO: Fail
                return 0;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Product> products = GetList();
            if (products == null)
            {
                // Create list
                products = new List<Product>();
            }

            // Get next id
            int nextId = GetNextNumber();
            // Set next id
            item.Id = nextId;

            if (item.IsDefault)
            {
                int index = products.FindIndex(x => x.IsDefault == true);
                if (index != -1)
                {
                    products[index].IsDefault = false;
                }
            }
            products.Add(item);
            // Write
            cc.Write(products, FileName);
            // Return item id
            return item.Id;
        }


        public override void Update(Product item)
        {
            CsvContext cc = new CsvContext();
            List<Product> products = GetList();
            int index = GetList()
            .FindIndex(x => x.Id == item.Id);
            if (index != -1)
            {
                if (item.IsDefault)
                {
                    int i = products.FindIndex(x => x.IsDefault == true);
                    if (i != -1)
                    {
                        products[i].IsDefault = false;
                    }
                }
                products[index].Cost = item.Cost;
                products[index].Name = item.Name;
                products[index].Recived = item.Recived;
                products[index].Remains = item.Remains;
                products[index].ProductedDate = item.ProductedDate;
                products[index].Discount = item.Discount;
                products[index].IsDefault = item.IsDefault;
                cc.Write(products, FileName);
            }
        }

        public override void Delete(int id)
        {
            if (id == 0)
            {
                // TODO: Fail
                return;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Product> products = GetList();
            if (products == null)
            {
                // TODO: Fail
                return;
            }
            // Search item by id
            Product product = products.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (product == null || !product.Id.Equals(id))
            {
                // TODO: Fail
                return;
            }
            // Delete item
            products.Remove(product);
            // Write
            cc.Write(products, FileName);
        }
        public bool UpdateByName(Custom item)
        {
            CsvContext cc = new CsvContext();
            List<Product> products = GetList();
            if (item == null || item.HoneyType == "" || item.Amount <= 0)
            {
                return false;
            }

            int index = GetList()
                .FindIndex(x => x.Name == item.HoneyType);
            if (index != -1)
            {
                if (products[index].Remains - item.Amount < 0.5)
                {
                    products[index].Remains = 0;
                }
                else
                {
                    products[index].Remains = products[index].Remains - item.Amount;
                }
                cc.Write(products, FileName);
                return true;
            }
            return false;
        }
    }

}
