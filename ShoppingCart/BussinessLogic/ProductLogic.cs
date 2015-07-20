﻿using BussinessLogic.Classes;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class ProductLogic
    {
        public static Producto GetProducto(int id)
        {
            try
            {
                Product product = ProductData.GetById(id);
                Producto producto = Mapping(product);
                return producto;
            }
            catch (NullReferenceException)
            {
                return null;
            }

        }
        public static List<Producto> GetListaProductos()
        {
            List<Product> productList = ProductData.GetAll();
            List<Producto> listaProductos = new List<Producto>();
            try
            {
                foreach (Product product in productList)
                {
                    Producto producto = Mapping(product);
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }
            catch (NullReferenceException)
            {
                return null;
            }

        }
        public static void Update(Producto producto)
        {
            Product product = ProductData.GetById(producto.ProductID);
            product.UnitsInStock = producto.UnitsInStock;
            ProductData.UpdateProduct(product);
        }

        private static Producto Mapping(Product product)
        {
            Producto producto = new Producto();
            try
            {
                producto.ProductID = product.ProductID;
                producto.ProductName = product.ProductName;
                producto.QuantityPerUnit = product.QuantityPerUnit;
                producto.Discontinued = product.Discontinued;

                try
                {
                    producto.SupplierID = (int)product.SupplierID;
                }
                catch (NullReferenceException)
                {
                    producto.SupplierID = 0;
                }

                try
                {
                    producto.CategoryID = (int)product.CategoryID;
                }

                catch (NullReferenceException)
                {
                    producto.CategoryID = 0;
                }

                try
                {
                    producto.UnitPrice = (decimal)product.UnitPrice;
                }
                catch (NullReferenceException)
                {

                    producto.UnitPrice = 0;
                }

                try
                {
                    producto.UnitsInStock = (short)product.UnitsInStock;
                }
                catch (InvalidOperationException)
                {

                    producto.UnitsInStock = 0;
                }

                try
                {
                    producto.UnitsOnOrder = (short)product.UnitsOnOrder;
                }
                catch (InvalidOperationException)
                {

                    producto.ReorderLevel = 0;
                }

                try
                {            
                    producto.ReorderLevel = (short)product.ReorderLevel;
                }
                catch (InvalidOperationException)
                {
                    producto.UnitsOnOrder = 0;
                }

                return producto;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
