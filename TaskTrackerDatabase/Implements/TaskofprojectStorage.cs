using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTrackerBusinessLogic.BindingModels;
using TaskTrackerBusinessLogic.Interfaces;
using TaskTrackerBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
/*
namespace TaskTrackerDatabase.Implements
{

   public class TaskofprojectStorage: ITaskProjectStorage
   {
           public List<TaskofprojectViewModel> GetFullList()
           {
               using (var context = new TaskTrackerContext())
               {
                   return context.Tasks
                   .Include(x => x.Projectid).Include(x => x)
                   .ThenInclude(x => x.Hotel)
                   .Select(CreateModel)
                   .ToList();
               }
           }

           public List<NumberofhotelViewModel> GetFilteredList(NumberofhotelBindingModel model)
           {
               if (model == null)
               {
                   return null;
               }
               using (var context = new TravelAgencyContext())
               {
                   return context.Numberofhotel.Include(x => x.Typeofnumber).Include(x => x.HotelNumberofhotel)
                   .ThenInclude(x => x.Hotel)
                   .Where(rec => rec.Viewnumber == model.Viewnumber)
                   .Select(CreateModel)
                   .ToList();
               }
           }

           public NumberofhotelViewModel GetElement(NumberofhotelBindingModel model)
           {
               if (model == null)
               {
                   return null;
               }
               using (var context = new TravelAgencyContext())
               {
                   var numberofhotel = context.Numberofhotel.Include(x => x.HotelNumberofhotel)
                   .ThenInclude(x => x.Hotel).Include(x => x.Typeofnumber)
                   .FirstOrDefault(rec => rec.Numberofhotelid == model.Id);
                   return numberofhotel != null ? CreateModel(numberofhotel) :
                   null;
               }
           }

           public void Insert(NumberofhotelBindingModel model)
           {
               using (var context = new TravelAgencyContext())
               {
                   using (var transaction = context.Database.BeginTransaction())
                   {
                       try
                       {
                           Numberofhotel numberofhotel = CreateModel(model, new Numberofhotel());
                           context.Numberofhotel.Add(numberofhotel);
                           context.SaveChanges();
                           numberofhotel = CreateModel(model, numberofhotel, context);
                           transaction.Commit();
                       }
                       catch
                       {
                           transaction.Rollback();
                           throw;
                       }
                   }
               }
           }

           public void Update(NumberofhotelBindingModel model)
           {
               using (var context = new TravelAgencyContext())
               {
                   using (var transaction = context.Database.BeginTransaction())
                   {
                       try
                       {
                           var element = context.Numberofhotel.FirstOrDefault(rec => rec.Numberofhotelid ==
                          model.Id);
                           if (element == null)
                           {
                               throw new Exception("Номер не найден");
                           }
                           CreateModel(model, element, context);
                           context.SaveChanges();
                           transaction.Commit();
                       }
                       catch
                       {
                           transaction.Rollback();
                           throw;
                       }
                   }

               }
           }

           public void Delete(NumberofhotelBindingModel model)
           {
               using (var context = new TravelAgencyContext())
               {
                   Numberofhotel element = context.Numberofhotel.FirstOrDefault(rec => rec.Numberofhotelid == model.Id);
                   if (element != null)
                   {
                       context.Numberofhotel.Remove(element);
                       context.SaveChanges();
                   }
                   else
                   {
                       throw new Exception("Номер не найден");
                   }
               }
           }
           private NumberofhotelViewModel CreateModel(Numberofhotel numberofhotel)
           {
               NumberofhotelViewModel model = new NumberofhotelViewModel();
               model.Id = numberofhotel.Numberofhotelid;
               model.Viewnumber = numberofhotel.Viewnumber;
               model.Typeofnumberid = numberofhotel.Typeofnumberid;
               model.Type = numberofhotel.Typeofnumber.Viewnumber;
               model.Price = numberofhotel.Price;
               model.HotelNumberofhotel = numberofhotel.HotelNumberofhotel.ToDictionary(x => x.Hotelid, x => x.Hotel.Hotelname);
               return model;
           }
           private Numberofhotel CreateModel(NumberofhotelBindingModel model, Numberofhotel numberofhotel)
           {
               numberofhotel.Typeofnumberid = model.Typeofnumberid;
               numberofhotel.Viewnumber = model.Viewnumber;
               numberofhotel.Price = model.Price;
               return numberofhotel;
           }
           private Numberofhotel CreateModel(NumberofhotelBindingModel model, Numberofhotel numberofhotel, TravelAgencyContext context)
           {
               numberofhotel.Typeofnumberid = model.Typeofnumberid;
               numberofhotel.Viewnumber = model.Viewnumber;
               numberofhotel.Price = model.Price;
               if (model.Id.HasValue)
               {
                   var roomsHotel = context.HotelNumberofhotel.Where(rec =>
                  rec.Numberofhotelid == model.Id.Value).ToList();
                   // удалили те, которых нет в модели
                   context.HotelNumberofhotel.RemoveRange(roomsHotel.Where(rec =>
                   !model.HotelNumberofhotel.ContainsKey(rec.Hotelid)).ToList());
                   context.SaveChanges();
                   // обновили количество у существующих записей
                   foreach (var elem in roomsHotel)
                   {
                       model.HotelNumberofhotel.Remove(elem.Hotelid);
                   }

               }
               // добавили новые
               foreach (var pc in model.HotelNumberofhotel)
               {
                   context.HotelNumberofhotel.Add(new HotelNumberofhotel
                   {
                       Numberofhotelid = numberofhotel.Numberofhotelid,
                       Hotelid = pc.Key
                   });
                   try
                   {
                       context.SaveChanges();
                   }
                   catch (DbUpdateException e)
                   {
                       throw;
                   }
               }
               return numberofhotel;
           }
       }
}
   */