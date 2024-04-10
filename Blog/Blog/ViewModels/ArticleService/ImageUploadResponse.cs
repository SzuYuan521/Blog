/*===========================================================*/
/*             Created by Szu Yuan Chen 0402, 2024           */
/*===========================================================*/

/* 從CKEditor上傳圖片到後端時，後端會把圖片儲存到指定位置，並回傳成功的相關資料到前端，
 * 告訴我們上傳圖片是成功的，而回傳的相關資料就會由ImageUploadResponse.cs回傳到前端   */


namespace Blog.ViewModels.ArticleService
{
    public class ImageUploadResponse
    {
        public int Uploaded { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string Msg { get; set; }
    }
}
