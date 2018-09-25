using System;
using System.Globalization;
using System.Web;

namespace ComputerComponentsWeb.Helpers
{
    public class SessionHelper
    {
        public const string UserSessionKey = "UserId";

        /// <summary>
        /// Generates and returns a unique GUID to identify the user for the current session.
        /// </summary>
        /// <param name="ctx">HTTP context from the controller.</param>
        /// <returns>Unique GUID in a string format.</returns>
        public virtual string GetUserId(HttpContextBase ctx)
        {
            if (ctx == null)
            {
                return string.Empty;
            }

            if (ctx.Session[UserSessionKey] == null)
            {
                ctx.Session[UserSessionKey] = Guid.NewGuid().ToString();
            }

            return ctx.Session[UserSessionKey].ToString();
        }

        /// <summary>
        /// Adjusts the total price of the user selected configuration after an item is added/removed.
        /// </summary>
        /// <param name="ctx">HTTP context from the controller</param>
        /// <param name="itemPrice">The price of the item that was added/removed</param>
        /// <param name="op">Function delegate to add or subtract teh item price from the total amount</param>
        public virtual void SetUserTotalAmount(HttpContextBase ctx, decimal itemPrice, Func<decimal, decimal, decimal> op)
        {
            if (ctx == null) return;

            decimal total; 
            if (ctx.Session["TotalAmount"] == null)
            {
                total = itemPrice;
            }
            else
            {
                total = decimal.Parse(ctx.Session["TotalAmount"].ToString(), NumberStyles.Currency);
                total = op(total, itemPrice);
            }

            ctx.Session["TotalAmount"] = total.ToString("c");
        }
    }
}