using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBank.Models.ViewModel
{
    public class ExamPrepareViewModel
    {
        #region ManuelSoruListeleme
        public int DersID { get; set; }
        public int DonemID { get; set; }
        #endregion

        #region SoruListeleme
        public Question questions{ get; set; }
        #endregion

        #region ManuelSınavHazırlama
        public string SinavAdi { get; set; }
        public int[] SeciliSorular { get; set; }

        #endregion
        #region OtomatikSınavHazırlama
        public string ZorlukID { get; set; }
        public int KlasikSoruAdet { get; set; }
        public int TestSoruAdet { get; set; }
        public int BoslukSoruAdet { get; set; }
        public int KlasikSoruPuan { get; set; }
        public int TestSoruPuan { get; set; }
        public int BoslukSoruPuan { get; set; }
        #endregion
    }
}