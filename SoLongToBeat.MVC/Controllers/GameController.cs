using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoLongToBeat.Domain.Entities;
using SoLongToBeat.MVC.ApiClientHelper;

namespace SoLongToBeat.MVC.Controllers
{
    public class GameController : Controller
    {
        ApiClient _apiClient = new ApiClient();

        // GET: GameController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Game> games = new List<Game>();
            HttpResponseMessage res = await _apiClient.Client.GetAsync("api/game");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                games = JsonConvert.DeserializeObject<List<Game>>(results);
            }
            return View(games);
        }

        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            var post = _apiClient.Client.PostAsJsonAsync<Game>("api/Game", game);
            post.Wait();

            var result = post.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: GameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
