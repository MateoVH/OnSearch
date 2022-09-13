using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSearch.Web.Data;
using OnSearch.Web.Entities;
using OnSearch.Web.Helpers;
using Syncfusion.EJ2.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace OnSearch.Web.Controllers
{
    public class ScheduleDatasController : Controller
    {
        private readonly DataContext _context;


        public ScheduleDatasController(DataContext context)
        {

            _context = context;
        }
        public ActionResult Index()
        {
            //ViewBag.datasource = _context.ScheduleDatas;
            return View();
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult LoadData()  // Here we get the Start and End Date and based on that can filter the data and return to Scheduler
        {
            var data = _context.ScheduleDatas.ToListAsync();
            return Json(data);
        }
        //public IActionResult MonthAgenda()
        //{
        //    ViewBag.appointments = new ScheduleData();
        //    return View();
        //}


        [HttpPost]
        public ActionResult UpdateData([FromBody] EditParams param)
        {
            if (param.action == "insert" || (param.action == "batch" && param.added != null)) // this block of code will execute while inserting the appointments
            {
                var value = (param.action == "insert") ? param.value : param.added[0];
                //int intMax = _context.ScheduleDatas.ToList().Count > 0 ? _context.ScheduleDatas.ToList().Max(p => p.Id) : 1;
                DateTime startTime = Convert.ToDateTime(value.StartTime);
                DateTime endTime = Convert.ToDateTime(value.EndTime);
                ScheduleData appointment = new ScheduleData()
                {
                    //Id = intMax + 1,
                    StartTime = startTime,
                    EndTime = endTime,
                    Subject = value.Subject,
                    //IsAllDay = value.IsAllDay,
                    //StartTimezone = value.StartTimezone,
                    //EndTimezone = value.EndTimezone,
                    //RecurrenceRule = value.RecurrenceRule,
                    //RecurrenceID = value.RecurrenceID,
                    //RecurrenceException = value.RecurrenceException
                };
                
                _context.ScheduleDatas.Add(appointment);
                _context.SaveChanges();
            }
            if (param.action == "update" || (param.action == "batch" && param.changed != null)) // this block of code will execute while updating the appointment
            {
                var value = (param.action == "update") ? param.value : param.changed[0];
                var filterData = _context.ScheduleDatas.Where(c => c.Id == Convert.ToInt32(value.Id));
                if (filterData.Count() > 0)
                {
                    DateTime startTime = Convert.ToDateTime(value.StartTime);
                    DateTime endTime = Convert.ToDateTime(value.EndTime);
                    ScheduleData appointment = _context.ScheduleDatas.Single(A => A.Id == Convert.ToInt32(value.Id));
                    appointment.StartTime = startTime;
                    appointment.EndTime = endTime;
                    //appointment.StartTimezone = value.StartTimezone;
                    //appointment.EndTimezone = value.EndTimezone;
                    //appointment.Subject = value.Subject;
                    //appointment.IsAllDay = value.IsAllDay;
                    //appointment.RecurrenceRule = value.RecurrenceRule;
                    //appointment.RecurrenceID = value.RecurrenceID;
                    //appointment.RecurrenceException = value.RecurrenceException;
                }
                _context.SaveChanges();
            }
            if (param.action == "remove" || (param.action == "batch" && param.deleted != null)) // this block of code will execute while removing the appointment
            {
                if (param.action == "remove")
                {
                    int key = Convert.ToInt32(param.key);
                    ScheduleData appointment = _context.ScheduleDatas.Where(c => c.Id == key).FirstOrDefault();
                    if (appointment != null) _context.ScheduleDatas.Remove(appointment);
                }
                else
                {
                    foreach (var apps in param.deleted)
                    {
                        ScheduleData appointment = _context.ScheduleDatas.Where(c => c.Id == apps.Id).FirstOrDefault();
                        if (appointment != null) _context.ScheduleDatas.Remove(appointment);
                    }
                }
                _context.SaveChanges();
            }
            var data = _context.ScheduleDatas.ToList();
            return Json(data);
        }
    }
}
