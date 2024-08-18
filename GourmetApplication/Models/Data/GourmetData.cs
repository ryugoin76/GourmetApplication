namespace GourmetApplication.Models.Data
{
    public class GourmetData
    {
        /// <summary>
        /// 都道府県
        /// </summary>
        public required string PrefectureName { get; set; }

        /// <summary>
        /// グルメ名
        /// </summary>
        public required string GourmetName { get; set; }

        /// <summary>
        /// 評価
        /// </summary>
        public required string Rate { get; set; }
    }
}
