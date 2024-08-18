using Microsoft.AspNetCore.Mvc;

using GourmetApplication.Models;
using GourmetApplication.Models.Data;
using Database;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using static Azure.Core.HttpHeader;

namespace GourmetApplication.Controllers
{
    public class RamenController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.LoadAsync();

            // ViewModelにラーメン情報を追加する。
            var viewModel = InitViewModel();
            if(this.HttpContext.Session.Get<RamenViewModel>("ramenMdl") == default)
            {
                this.HttpContext.Session.Set<RamenViewModel>("ramenMdl", viewModel);
                Debug.WriteLine("1 Set");
            }

            // Viewを返却する際に、ViewModelを送る。
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(RamenViewModel formData)
        {
            this.HttpContext.Session.LoadAsync();

            RamenViewModel viewModel;

            // 入力エラーがある場合
            if (!ModelState.IsValid)
            {
                var errormsgs = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.ErrorMessage)).ToList();
                Debug.WriteLine(string.Join(", ", errormsgs));

                viewModel = this.HttpContext.Session.Get<RamenViewModel>("ramenMdl");
                if (viewModel is null)
                {
                    Debug.WriteLine("Session is null");
                    viewModel = InitViewModel();
                }
                Debug.WriteLine("2 Get");

                viewModel.SearchPrefecture = formData.SearchPrefecture;
                viewModel.SearchName = formData.SearchName;

                this.HttpContext.Session.Set<RamenViewModel>("ramenMdl", viewModel);
                Debug.WriteLine("3 Set");

                return View(viewModel);
            }

            // ViewModelを作成する。
            viewModel = InitViewModel();
            var ramenList = viewModel.RamenList;


            // 都道府県が指定されていれば絞り込みを行う。
            if (!string.IsNullOrWhiteSpace(formData.SearchPrefecture))
            {
                ramenList = ramenList.Where(x => x.Prefecture.Contains(formData.SearchPrefecture)).ToList();
            }

            // 名前が指定されていれば絞り込みを行う。
            if (!string.IsNullOrWhiteSpace(formData.SearchName))
            {
                ramenList = ramenList.Where(x => x.Name.Contains(formData.SearchName)).ToList();
            }

            // ViewModelにラーメン情報を追加する。
            viewModel.RamenList = ramenList;

            this.HttpContext.Session.Set<RamenViewModel>("ramenMdl", viewModel);
            Debug.WriteLine("4 Set");

            // Viewを返却する際に、ViewModelを送る。
            return View(viewModel);
        }

        private RamenViewModel InitViewModel()
        {
            // ViewModelを作成する。
            var viewModel = new RamenViewModel()
            {
                UpdateDate = DateTime.Now,
            };

            // ラーメン情報を作成する。
            var ramenList = new List<RamenData>
            {
                new RamenData()
                {
                    Prefecture = "北海道",
                    Name = "旭川ラーメン",
                },
                new RamenData()
                {
                    Prefecture = "福島県",
                    Name = "喜多方ラーメン",
                },
                new RamenData()
                {
                    Prefecture = "栃木県",
                    Name = "佐野らーめん",
                },
                new RamenData()
                {
                    Prefecture = "神奈川県",
                    Name = "家系ラーメン",
                }
            };
            viewModel.RamenList = ramenList;
            return viewModel;
        } 
    }
}
