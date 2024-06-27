using CarWorkshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;

namespace CarWorkshop.MVC.ControllerExtensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller, string message, string type)
        {
            var notification = new Notification(message,type);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
