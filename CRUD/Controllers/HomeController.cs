using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClassLibrary.Entities;
using Microsoft.Identity.Client;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult DetailsList()
        {
            var dbContext = new MoneyDbContext();

            var Details = dbContext.MoneyDetails.ToList();

            return View(Details);
        }

        public IActionResult Editor(int? Id = null)
        {
            Model model = new Model();

            if (Id.HasValue)
            {
                var dbContext = new MoneyDbContext();
                MoneyDetail money = dbContext.MoneyDetails.FirstOrDefault(p => p.Id == Id);


                model.AmtSend = money.AmtSend;
                model.AmtRecieve = money.AmtRecieve;
                model.SenderName = money.SenderName;
                model.RecieverName = money.RecieverName;
                model.Purpose = money.Purpose;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Editor(Model model)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new MoneyDbContext();

                var MoneyObj = new MoneyDetail();

                if (model.Id.HasValue)
                {
                    //  EDIT , i.e where user is updating the money details 

                    MoneyObj = dbContext.MoneyDetails.FirstOrDefault(p => p.Id == model.Id);

                    MoneyObj.AmtSend = model.AmtSend;
                    MoneyObj.AmtRecieve = model.AmtRecieve;
                    MoneyObj.SenderName = model.SenderName;
                    MoneyObj.RecieverName = model.RecieverName;
                    MoneyObj.Purpose = model.Purpose;

                    dbContext.MoneyDetails.Update(MoneyObj);
                }
                else
                {
                    // Add Mode, i.e user is adding new data

                    MoneyObj.AmtSend = model.AmtSend;
                    MoneyObj.AmtRecieve = model.AmtRecieve;
                    MoneyObj.SenderName = model.SenderName;
                    MoneyObj.RecieverName = model.RecieverName;
                    MoneyObj.Purpose = model.Purpose;

                    dbContext.MoneyDetails.Add(MoneyObj);
                }

                dbContext.SaveChanges();

                return RedirectToAction("DetailsList", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Money Details are not saved, please fix errors and save again!");

                return View(model);
            }
        }

        // Deleting a record from the list
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dbContext = new MoneyDbContext();

            var moneyDetails = dbContext.MoneyDetails.Find(id);

            if (moneyDetails != null)
            {
                dbContext.MoneyDetails.Remove(moneyDetails);
                dbContext.SaveChanges();
            }

            return RedirectToAction("DetailsList");
        }

        
    }
}



