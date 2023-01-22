using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Models.Home;
using OnlineShoppingStore.Repository;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PayPal.Api;
using Antlr.Runtime;

namespace OnlineShoppingStore.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentWithPapal2()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PaymentWithPapal2(Shippingdetail shippingdetail)
        {
            dbMyOnlineShoppingEntities db = new dbMyOnlineShoppingEntities();

            Tbl_ShippingDetails tbl = new Tbl_ShippingDetails();

            tbl.Adress = shippingdetail.Adress;
            tbl.MemberId = 1;
            tbl.City = shippingdetail.City;
            tbl.State = shippingdetail.State;
            tbl.Country = shippingdetail.Country;
            tbl.ZipCode = shippingdetail.ZipCode;
         
            tbl.AmountPaid = shippingdetail.AmountPaid;
            tbl.PaymentType = "Cash";

            db.Tbl_ShippingDetails.Add(tbl);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}

