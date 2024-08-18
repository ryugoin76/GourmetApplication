using GourmetApplication.Models.Data;

namespace GourmetApplication.Models
{
    public class GourmetJoinViewModel
    {
        #region 画面表示

        /// <summary>
        /// データ更新日
        /// </summary>
        public DateTime UpdateDate { get; set; }

        public List<GourmetData> GourmetList { get; set; } = new List<GourmetData>();

        #endregion
    }
}
