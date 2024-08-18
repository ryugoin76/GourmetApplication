using Database;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;

using GourmetApplication.Models;
using GourmetApplication.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GourmetApplication.Controllers
{
    public class GourmetController : Controller
    {
        private readonly GourmetDbContext _context;

        public GourmetController(GourmetDbContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    全件取得
        //   var gourmetList = _context.Gourmet.ToList();
        //    var entities = _context.Gourmet;

        //    条件指定で取得
        //   var gourmetList = entities
        //       // 絞り込み
        //       .Where(g => g.PrefectureCode < 10 || g.GourmetName == "辛子明太子")
        //       // 並び替え（第一ソート、昇順）
        //       .OrderBy(g => g.PrefectureCode)
        //       // 並び替え（第二ソート、降順）
        //       .ThenByDescending(g => g.Rate)
        //       // 必要なデータを選択・加工
        //       .Select(g => new Gourmet
        //       {
        //           GourmetId = g.GourmetId,
        //           GourmetName = g.GourmetName == "辛子明太子"
        //               ? $"{g.GourmetName}！！！！！"
        //               : g.GourmetName,
        //           PrefectureCode = g.PrefectureCode,
        //           Rate = g.Rate * 10,
        //       }).ToList();

        //    同じ内容を「LINQのクエリ式構文」で取得
        //   var gourmetList = (from g in entities
        //                      where g.PrefectureCode < 10 || g.GourmetName == "辛子明太子"
        //                      orderby g.PrefectureCode, g.Rate descending
        //                      select new Gourmet
        //                      {
        //                          GourmetId = g.GourmetId,
        //                          GourmetName = g.GourmetName == "辛子明太子"
        //                           ? $"{g.GourmetName}！！！！！"
        //                           : g.GourmetName,
        //                          PrefectureCode = g.PrefectureCode,
        //                          Rate = g.Rate * 10,
        //                      }).ToList();

        //    評価が高い順から先頭1件取得
        //   var gourmet = entities
        //       .OrderByDescending(g => g.Rate)
        //       .FirstOrDefault();
        //    gourmetList = gourmet != null
        //        ? new List<Gourmet> { gourmet }
        //        : new List<Gourmet>();

        //    var viewModel = new GourmetViewModel()
        //    {
        //        UpdateDate = DateTime.Now,
        //        GourmetList = gourmetList
        //    };
        //}

        public IActionResult Index()
        {
            // グルメテーブルと都道府県テーブル結合
            var gourmetList = _context.Gourmet// 結合されるテーブル
                .Join(
                    _context.Prefecture,// 結合するテーブル
                    g => g.PrefectureCode,// 結合される側結合条件
                    p => p.PrefectureCode,// 結合する側結合条件
                    (g, p) => new
                    {
                        p.PrefectureCode,// 後続で必要なカラムを指定
                        p.PrefectureName,
                        g.GourmetName,
                        g.Rate
                    }
                ).OrderBy(x => x.PrefectureCode)
                .ThenBy(x => x.Rate)
                .Select(x => new GourmetData
                {
                    PrefectureName = x.PrefectureName,
                    GourmetName = x.GourmetName,
                    Rate = x.Rate != null
                        ? ((int)x.Rate).ToString()
                        : "-"
                })
                //.AsNoTracking()
                .ToList();

            var viewModel = new GourmetJoinViewModel()
            {
                UpdateDate = DateTime.Now,
                GourmetList = gourmetList
            };

            return View(viewModel);
        }

        public IActionResult Add()
        {
            // 追加するグルメ情報
            var addGourmet = new Gourmet()
            {
                GourmetName = "あんこう鍋",
                PrefectureCode = 8,
                Rate = 3
            };

            _context.Add(addGourmet);
            // DBに反映
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            // 対象データ取得
            var updateGourmet = _context.Gourmet
                .Where(g => g.GourmetName == "あんこう鍋")
                .FirstOrDefault();
            if (updateGourmet == null) return RedirectToAction(nameof(Index));

            // 取得したデータを変更
            updateGourmet.GourmetName = "盛岡冷麵";
            // DBに反映
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            // 対象データ取得
            var deleteGourmet = _context.Gourmet
                .Where(g => g.GourmetName == "盛岡冷麵")
                .FirstOrDefault();
            if (deleteGourmet == null) return RedirectToAction(nameof(Index));

            _context.Remove(deleteGourmet);
            // DBに反映
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
