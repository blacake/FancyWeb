﻿using FancyWeb.Areas.Management.ViewModels;
using FancyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FancyWeb.Areas.Management.Service
{
    public class LineBotService
    {
        private FancyStoreEntities db = new FancyStoreEntities();

        public string Getpupp()
        {
            var pupp = db.OrderDetails.AsEnumerable().GroupBy(n => n.ProductID).Select(n => new { n.Key, sum = n.Sum(m => m.OrderQTY) }).OrderByDescending(n => n.sum).Take(3).ToList();
            string LineMessage="";
            string[] i = { "1⃣" , "2⃣", "3⃣" };
            int j = 0;
            foreach (var item in pupp)
            {
                var product = db.Products.Find(item.Key);
                LineMessage += i[j] + product.ProductName + "\n";
                j++;
            }
            return LineMessage;
        }

        public string GetActityP(string url)
        {
            var Activity = db.ActivityProducts.OrderBy(n => Guid.NewGuid()).Take(3).Select(n=> new {
                Pid = n.ProductID, pname = n.Product.ProductName,Avname = n.Activity.ActivityName,
                oup = n.Product.UnitPrice ,nup = n.Product.UnitPrice*n.Activity.DiscountMethod.Discount
            }).ToList();
            string LineMessage = "🔥活動商品! 還不快出手🔥\n\n";
            foreach (var item in Activity)
            {
                LineMessage += $"🔸[{item.Avname}] = >    {item.pname}\n原價: NT$ {item.oup} 優惠價: NT$ {item.nup.ToString("C0")}\n商品連接  → {url}/{item.Pid} \n\n";
            }
            LineMessage += "活動期間好康大放送，加緊你的腳步❗❗\n";
            return LineMessage;
        }


        public List<Line_Template> Line_Templates(string url)
        {
            var romd = db.Products.OrderBy(n => Guid.NewGuid()).Take(3).Select(n => new {
                pname =n.ProductName,
                pup = n.UnitPrice,
                pid = n.ProductID
            }).ToList();
            List<Columns> columns = new List<Columns>();
            foreach (var item in romd)
            {
                List<ViewModels.Action> actions = new List<ViewModels.Action>();
                actions.Add(new ViewModels.Action
                {
                    type = "uri",
                    label = "前往商品頁面",
                    uri = "https://msit12201.azurewebsites.net/ProductDisplay/Product/GetProductDetail/" + item.pid,

                });
                columns.Add(new Columns
                {
                    thumbnailImageUrl = "https://msit12201.azurewebsites.net/ProductDisplay/Product/ByteImage/" + item.pid,
                    title = item.pname ,
                    text = "NT$ "+item.pup.ToString(),
                    actions = actions
                });
            }
            Line_Template ddd = new Line_Template()
            {
                template = new Template
                {
                    type = "carousel",
                    columns = columns
                }
            };
            List<Line_Template> _Templates = new List<Line_Template>();
            _Templates.Add(ddd);

            return _Templates;
        }
    }
}