using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany_Front.ThisAppClass
{
    namespace Ken7_2
    {
        class _RowValue
        {
            public string ClassNo { get; set; }
            public string ClassName { get; set; }
            public string CourseNo { get; set; }
            public string CourseName { get; set; }
            public string LargeSubjectNo { get; set; }
            public string LargeSubjectNoSub { get; set; }
            public string LittleSubjectNo { get; set; }
            public string LittleSubjectName { get; set; }
            public string Edaban { get; set; }
            public string EdabanName { get; set; }
            public string ItemNo { get; set; }
            public string ItemName { get; set; }
            public string TeacherNo { get; set; }
            public string TeacherName { get; set; }
            public string ExecDate { get; set; }
            public string RoomNo { get; set; }
            public string RoomName { get; set; }
            public string LittleTestDate { get; set; }
            public int KuniTime { get; set; }

            public string SchooltimeString { get; set; }
            public string Schooltime { get; set; }
            public string SchoolCount { get; set; }

         }

        class _format
        {
            public string TeacherName { get; set; }
            public string No { get; set; }
            public string LiItemNo { get; set; }
            public string LiItemName { get; set; }
            public string Bikou { get; set; }
            public string LargeSubjectNo { get; set; }
            public string LargeSubjectNoSub { get; set; }
            public string ExecDate { get; set; }
            public string SchoolTimeString { get; set; }
            public string SchoolTime { get; set; }
            public string SchoolCount { get; set; }
        }



    }


    class do_Ken7_2
    {
        struct _列数
        {
            public const int No = 0;
            public const int LiItemNo = 1;
            public const int LiItemName = 1;
            public const int Bikou = 9;
            public const int LargeSubjectNo = 6;
            public const int LargeSubjectNoSub = 1;
            public const int ExecDate = 1;
            public const int SchoolTimeString = 1;
            public const int SchoolTime = 1;
            public const int SchoolCount = 1;
        }

        struct Act
        {
            public const int Clear = 0;
            public const int Insert = 1;
        }


        private const string sFormatSheetName = "【様式】県7の2";

        private const string sName = "7-2";
        private const string sStartDateIndex = "1";   //固定
        private string sEndDateIndex; // 可変

        private const string NowDateCell = "F2";


        private const string TeacherNamecell = "A8";
        private const string StartDatecell = "E11";
        private const string EndDatecell = "K11";
        private const string Heddercell = "B20";

        private string className_;
        private string courseName_;
        private long count_;
        private bool OnlyViewFlag;
        private long RowNum_;

        List<Ken7_2._RowValue> _rowvalues;

        //コンストラクタ
        public do_Ken7_2(List<Ken7_2._RowValue> _in)
        {
            _rowvalues = _in;
        }



    }
}
