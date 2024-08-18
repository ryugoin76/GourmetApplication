using Database.Entities;

namespace GourmetApplication.Models
{
    public class GourmetViewModel
    {
        #region 画面表示

        /// <summary>
        /// データ更新日
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// グルメ情報
        /// </summary>
        public List<Gourmet> GourmetList { get; set; } = new List<Gourmet>();

        #endregion
    }
}
