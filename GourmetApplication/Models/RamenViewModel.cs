using GourmetApplication.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace GourmetApplication.Models
{
    public class RamenViewModel
    {
        #region 検索条件

        /// <summary>
        /// 検索用：都道府県
        /// </summary>
        [Display(Name ="都道府県")]
        [Required(ErrorMessage ="都道府県を指定してください")]
        [StringLength(10)]
        public string? SearchPrefecture { get; set; }

        /// <summary>
        /// 検索用：ラーメン名
        /// </summary>
        [Display(Name ="ラーメン名")]
        [Required(ErrorMessage ="ラーメン名を指定してください")]
        [StringLength(5)]
        public string? SearchName { get; set; }

        #endregion

        #region 画面表示

        /// <summary>
        /// データ更新日
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// ラーメン情報
        /// </summary>
        public List<RamenData> RamenList { get; set; } = new List<RamenData>();

        #endregion
    }
}
