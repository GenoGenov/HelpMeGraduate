namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;


    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.ViewModels.Rating;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class RatingsController : BaseController
    {
        public RatingsController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult GetRateResource(string id)
        {
            var userId = User.Identity.GetUserId();
            return this.GetRate(id, x => x.ResourceId.ToString() == id && x.AuthorId == userId, "/Ratings/RateResource/" + id);
        }

        public ActionResult GetRateInsight(string id)
        {
            var userId = User.Identity.GetUserId();
            return this.GetRate(id, x => x.InsightId.ToString() == id && x.AuthorId == userId, "/Ratings/RateInsight/" + id);
        }

        [HttpPost]
        public JsonResult RateResource(string id, int value)
        {
            var userId = User.Identity.GetUserId();
            var actionResult = this.PostRate(
                                 id,
                                 x => x.ResourceId.ToString() == id && x.AuthorId == userId,
                                 value,
                                 new Rating() { ResourceId = Guid.Parse(id) });
            var rating = this.CalculateRating(
                                              this.Data.Ratings.All().Where(x => x.ResourceId.ToString() == id).ToList());
            var resource = this.Data.Resources.Find(Guid.Parse(id));
            resource.Rating = rating;
            this.Data.Resources.Update(resource);
            this.Data.SaveChanges();

            return actionResult;
        }

        [HttpPost]
        public JsonResult RateInsight(string id, int value)
        {
            var userId = User.Identity.GetUserId();
            var actionResult = this.PostRate(
                                 id,
                                 x => x.InsightId.ToString() == id && x.AuthorId == userId,
                                 value,
                                 new Rating() { InsightId = Guid.Parse(id) });

            var rating = this.CalculateRating(
                                              this.Data.Ratings.All().Where(x => x.InsightId.ToString() == id).ToList());
            var insight = this.Data.Insigths.Find(Guid.Parse(id));
            insight.Rating = rating;
            this.Data.Insigths.Update(insight);
            this.Data.SaveChanges();

            return actionResult;
        }

        public ActionResult GetTotalRating(string id)
        {

            var ratingsForItem =
                this.Data.Ratings.All()
                    .Where(x => x.ResourceId.ToString() == id || x.InsightId.ToString() == id)
                    .ToList();
            var average = this.CalculateRating(ratingsForItem);
            return this.PartialView(
                                    "_TotalRatingPartial",
                                    new TotalRatingViewModel()
                                        {
                                            Rating = average,
                                            RatingsCount = ratingsForItem.Count,
                                            TargetId = id
                                        });
        }

        private double CalculateRating(IList<Rating> ratings)
        {
            var average = ratings.Select(x => x.Value).Sum() / (double)ratings.Count;
            return double.IsNaN(average) ? 0 : average;
        }


        private ActionResult GetRate(string id, Expression<Func<Rating, bool>> predicate, string routeToAction)
        {
            var ratingExists =
                this.Data.Ratings.All().FirstOrDefault(predicate);
            if (ratingExists != null)
            {
                return this.PartialView(
                                        "_RatingPartial",
                                        new RatingViewModel() { TargetId = id, Value = ratingExists.Value });
            }

            return this.PartialView(
                                    "_RatingPartial",
                                    new RatingViewModel() { TargetId = id, Value = null, RouteToAction = routeToAction });
        }



        private JsonResult PostRate(string id, Expression<Func<Rating, bool>> predicate, int value, Rating initial)
        {
            var ratingExists =
                this.Data.Ratings.All().FirstOrDefault(predicate);
            if (ratingExists != null)
            {
                Response.StatusCode = 400;
                return Json("You have already voted on that!");
            }

            initial.AuthorId = this.User.Identity.GetUserId();
            initial.Value = value;
            this.Data.Ratings.Add(initial);
            this.Data.SaveChanges();
            return Json("Your rating has been recorded!");
        }

    }
}